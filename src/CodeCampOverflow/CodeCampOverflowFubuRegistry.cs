using CodeCampOverflow.Behaviors;
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
                .HomeIs<HomeController>(x => x.IndexQuery())
                .IgnoreControllerNamespaceEntirely()
                .IgnoreMethodsNamed("Index")
                .IgnoreMethodSuffix("Command")
                .IgnoreMethodSuffix("Query")
                .ConstrainToHttpMethod(action => action.Method.Name.EndsWith("Command"), "POST")
                .ConstrainToHttpMethod(action => action.Method.Name.EndsWith("Query"), "GET");

            Views.TryToAttachWithDefaultConventions();

            ApplyConvention<ValidationConvention>();
            ApplyConvention<PersistenceConvention>();
        }
    }
}