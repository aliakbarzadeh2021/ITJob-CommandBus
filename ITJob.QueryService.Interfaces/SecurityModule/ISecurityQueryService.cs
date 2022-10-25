using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITJob.QueryModels.Interfaces.SecurityModule;

namespace ITJob.QueryService.Interfaces.SecurityModule
{
    public interface ISecurityQueryService
    {
        /// <summary>
        /// ارائه ی اطلاعات پروفایل کاربر
        /// </summary>
        /// <param name="examId">شناسه آزمون</param>
        /// <param name="nationalCode">کدملی</param>
        /// <param name="userName">نام کاربری</param>
        /// <param name="password">کلمه عبور</param>
        /// <returns>اطلاعات پروفایل کاربر</returns>
        IUserDto GetPersonDetails(Guid examId, string nationalCode, string userName, string password);
        IEnumerable<IUserDto> GetPersons();
    }
}
