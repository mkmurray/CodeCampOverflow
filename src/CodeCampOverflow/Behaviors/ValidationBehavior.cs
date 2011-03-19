using System.Net;
using System.Net.Mime;
using FubuMVC.Core;
using FubuMVC.Core.Behaviors;
using FubuMVC.Core.Runtime;

namespace CodeCampOverflow.Behaviors
{
    public class ValidationBehavior<T> : BasicBehavior where T : class
    {
        private readonly IFubuRequest _fubuRequest;
        private readonly IOutputWriter _writer;

        public ValidationBehavior(IFubuRequest fubuRequest, IOutputWriter writer) :
            base(PartialBehavior.Ignored)
        {
            _fubuRequest = fubuRequest;
            _writer = writer;
        }

        protected override DoNext performInvoke()
        {
            var inputModel = _fubuRequest.Get<T>();
            var bodyProperty = inputModel.GetType().GetProperty("Body");
            var titleProperty = inputModel.GetType().GetProperty("Title");

            if ((bodyProperty != null &&
                string.IsNullOrEmpty(bodyProperty.GetValue(inputModel, null) as string)) ||
                (titleProperty != null &&
                string.IsNullOrEmpty(titleProperty.GetValue(inputModel, null) as string)))
            {
                _writer.WriteResponseCode(HttpStatusCode.InternalServerError);
                _writer.Write(MediaTypeNames.Text.Html, "Invalid blank input!");

                return DoNext.Stop;
            }

            return DoNext.Continue;
        }
    }
}