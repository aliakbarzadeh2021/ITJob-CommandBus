using System;
using System.Collections.Generic;
using System.Linq;

namespace ITJob.DomainModel.SeedWorks.Core.Processes
{
    /// <summary>
    /// ارائه ی تصادفی یکی از گزینه های یک لیست
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal sealed class GetRandomProcess<T> : Process<IEnumerable<T>, T>
    {
        /// <summary>
        /// گزینه ی تصادفی از فهرست
        /// </summary>
        public override T Result { get; protected set; }

        public GetRandomProcess(IEnumerable<T> list)
        {
            Execute(list, () =>
            {
                Result = list.OrderBy(o => Guid.NewGuid()).FirstOrDefault();
            });
        }
    }
}