using Raven.Client;
using FubuMVC.Core.Behaviors;

namespace CodeCampOverflow.Behaviors
{
    public class PersistenceBehavior : BasicBehavior
    {
        private readonly IDocumentSession _session;

        public PersistenceBehavior(IDocumentSession session) : base(PartialBehavior.Ignored)
        {
            _session = session;
        }

        protected override void afterInsideBehavior()
        {
            _session.SaveChanges();
            _session.Dispose();
        }
    }
}