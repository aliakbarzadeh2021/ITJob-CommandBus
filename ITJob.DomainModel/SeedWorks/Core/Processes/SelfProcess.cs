namespace ITJob.DomainModel.SeedWorks.Core.Processes
{
    /// <summary>
    /// فعالیتی که بر روی موجودیت اعمال شده و خودش را به عنوان نتیجه ارائه می دهد
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal abstract class SelfProcess<T> : Process<T, T>
    {
    }
}