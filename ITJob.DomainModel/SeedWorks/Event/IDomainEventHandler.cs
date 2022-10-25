namespace ITJob.DomainModel.SeedWorks.Event
{
    public interface IDomainEventHandler<in T> where T : IDomainEvent
    {
        void Handle(T domainEvent);
    }
}
