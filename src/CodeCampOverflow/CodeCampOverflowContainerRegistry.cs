using CodeCampOverflow.Persistence;
using Raven.Client;
using Raven.Client.Client;
using Raven.Http;
using StructureMap.Configuration.DSL;

namespace CodeCampOverflow
{
    public class CodeCampOverflowContainerRegistry : Registry
    {
        public CodeCampOverflowContainerRegistry()
        {
            For<IQuestionRepository>().Use<QuestionRepository>();
            For<IDocumentStore>().Singleton().Use(StartupDb);
            For<IDocumentSession>()
                .HybridHttpOrThreadLocalScoped()
                .Use(x =>
                {
                    var store = x.GetInstance<IDocumentStore>();
                    return store.OpenSession();
                });
        }

        public static IDocumentStore StartupDb()
        {
            NonAdminHttp.EnsureCanListenToWhenInNonAdminContext(8080);
            var store = new EmbeddableDocumentStore
            {
                DataDirectory = @"App_Data\RavenDB",
                UseEmbeddedHttpServer = true
            };
            store.Initialize();

            return store;
        }
    }
}