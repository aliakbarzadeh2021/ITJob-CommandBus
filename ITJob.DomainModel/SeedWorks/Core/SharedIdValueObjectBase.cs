using System;
using SAF.SSN.Kernel.Infrastructure.Domain;

namespace ITJob.DomainModel.SeedWorks.Core
{
    /// <summary>
    /// کلاس پایه ی شیء ارزشمند شناسه ی اشتراک گذاری شده 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SharedIdValueObjectBase<T>: ValueObjectBase<T> where T : ValueObjectBase<T>
    {
        /// <summary>
        /// ایجاد شیء ارزشمند شناسه ی اشتراک گذاری شده
        /// </summary>
        /// <param name="code">کد شناسه</param>
        public SharedIdValueObjectBase(Guid code)
        {
            Code = code;
        }

        /// <summary>
        /// شناسه
        /// </summary>
        public Guid Code { get; set; }
    }
}