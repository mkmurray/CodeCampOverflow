using CodeCampOverflow.Controllers;
using FubuMVC.Core;

namespace CodeCampOverflow
{
    public class CodeCampOverflowFubuRegistry : FubuRegistry
    {
        public CodeCampOverflowFubuRegistry()
        {
            IncludeDiagnostics(true);

            Applies.ToThisAssembly();

            Actions.IncludeClassesSuffixedWithController();

            Routes
                .HomeIs<HomeController>(x => x.Index())
                .IgnoreControllerNamespaceEntirely()
                .IgnoreMethodsNamed("Index")
                .IgnoreMethodSuffix("Command")
                .IgnoreMethodSuffix("Query")
                .ConstrainToHttpMethod(action => action.Method.Name.EndsWith("Command"), "POST")
                .ConstrainToHttpMethod(action => action.Method.Name.StartsWith("Query"), "GET");

            Views.TryToAttachWithDefaultConventions();
        }
    }
}