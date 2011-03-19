using System.Collections.Generic;
using System.Linq;
using FubuMVC.Core.Registration;

namespace CodeCampOverflow.Behaviors
{
    public class ValidationConvention : IConfigurationAction
    {
        public void Configure(BehaviorGraph graph)
        {
            graph.Actions()
                .Where(actionCall => actionCall.Method.Name.EndsWith("Command") &&
                    actionCall.HasInput &
                    actionCall.InputType().Name.EndsWith("InputModel"))
                .Each(actionCall => actionCall.AddBefore(new ValidationNode(actionCall.InputType())));
        }
    }
}