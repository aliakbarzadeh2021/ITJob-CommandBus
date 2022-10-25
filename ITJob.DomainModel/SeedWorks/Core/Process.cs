using System;

namespace ITJob.DomainModel.SeedWorks.Core
{
    /// <summary>
    /// یک فعالیت بر روی یک موجودیت جهت ارائه ی یک نتیجه
    /// </summary>
    /// <typeparam name="T">نوع موجودیت</typeparam>
    /// <typeparam name="TResult">نوع نتیجه</typeparam>
    internal abstract class Process<T, TResult>
    {
        /// <summary>
        /// نتیجه ی فعالیت
        /// </summary>
        public abstract TResult Result { get; protected set; }

        /// <summary>
        /// اعمال فعالیت بر روی موجودیت
        /// </summary>
        /// <param name="entity">موجودیت</param>
        /// <param name="action">فعالیت</param>
        protected void Execute(T entity, Action action)
        {
            action.Invoke();
        }
    }
}