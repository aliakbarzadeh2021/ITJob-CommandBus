using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ITJob.DomainModel.SeedWorks.Core.Processes
{
    /// <summary>
    /// اعمال یکی از فعالیت های تعریف شده بر روی یک موجودیت بر مبنای یک قانون خاص
    /// </summary>
    /// <typeparam name="T">نوع موجودیت</typeparam>
    /// <typeparam name="TResult">نوع نتیجه</typeparam>
    internal abstract class Rule<T, TResult> : Process<T, TResult>
    {
        /// <summary>
        /// اعمال یک فعالیت از فهرست فعالیت ها بر مبنای شرایط موجودیت
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="entity">موجودیت</param>
        /// <param name="condition">مبنای شرایط</param>
        /// <param name="actions">فهرست فعالیت ها</param>
        protected void Execute<TKey>(T entity, Expression<Func<T, TKey>> condition,
            IDictionary<TKey, Action> actions)
        {
            var func = condition.Compile();
            var conditionResult = func(entity);
            var action = actions[conditionResult];
            Execute(entity, action);
        }
    }
}