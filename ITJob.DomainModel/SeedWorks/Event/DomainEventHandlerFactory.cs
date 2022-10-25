using System.Collections.Generic;

namespace ITJob.DomainModel.SeedWorks.Event
{
    public class DomainEventHandlerFactory : IDomainEventHandlerFactory
    {
        public IEnumerable<IDomainEventHandler<T>> GetDomainEventHandlersFor<T>(T domainEvent) where T : IDomainEvent
        {
            return DomainServiceLocator.GetAllInstances<IDomainEventHandler<T>>();
        }
    }
}