namespace ITJob.DomainModel.SeedWorks.Event
{
    public static class DomainEvents
    {
        public static readonly IDomainEventHandlerFactory DomainEventHandlerFactory;

        static DomainEvents()
        {
            DomainEventHandlerFactory = DomainServiceLocator.GetInstance<IDomainEventHandlerFactory>();
        }

        public static void Raise<T>(T domainEvent) where T : IDomainEvent
        {
            foreach (var domainEventHandler in DomainEventHandlerFactory.GetDomainEventHandlersFor(domainEvent))
            {
                domainEventHandler.Handle(domainEvent);
            }
        }
    }
}