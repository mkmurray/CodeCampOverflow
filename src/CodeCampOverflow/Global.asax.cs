using System;
using System.Web.Routing;
using FubuMVC.Core;
using FubuMVC.Core.Packaging;
using FubuMVC.StructureMap;
using StructureMap;

namespace CodeCampOverflow
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            FubuApplication
                .For<CodeCampOverflowFubuRegistry>()
                .StructureMap(() => new Container(x => x.AddRegistry<CodeCampOverflowContainerRegistry>()))
                .Bootstrap(RouteTable.Routes);

            //PackageRegistry.AssertNoFailures();
        }
    }
}