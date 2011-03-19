using FubuMVC.Core.UI;
using HtmlTags;

namespace CodeCampOverflow
{
    public class CodeCampOverflowHtmlConventions : HtmlConventionRegistry
    {
        public CodeCampOverflowHtmlConventions()
        {
            Displays
                .If(accessor => accessor.Accessor.Name == "Body")
                .BuildBy(er => new HtmlTag("p").Text(er.StringValue()));

            Editors
                .If(accessor => accessor.Accessor.Name == "Body")
                .BuildBy(er => new HtmlTag("textarea").Attr("name", "Body").Attr("rows", 5));
        }
    }
}