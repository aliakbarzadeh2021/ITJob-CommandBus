using System.Collections.Generic;

namespace ITJob.DomainModel.SeedWorks.Interfaces
{
    public interface IXmlReadOnlyRepository<T, TEntityKey>
    {
        /// <summary>
        /// جستجوی کلیه ی موجودیت ها 
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> FindAll();

        /// <summary>
        /// جستجوی موجودیت براساس شناسه
        /// </summary>
        /// <param name="id">شناسه ی موجودیت</param>
        /// <returns></returns>
        T FindBy(TEntityKey id);
    }
}