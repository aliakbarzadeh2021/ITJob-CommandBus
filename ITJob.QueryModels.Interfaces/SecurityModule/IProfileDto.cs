using System;
using System.Collections.Generic;

namespace ITJob.QueryModels.Interfaces.SecurityModule
{
    /// <summary>
    /// اطلاعات پروفایل
    /// </summary>
    public interface IProfileDto
    {
        /// <summary>
        /// شناسه شخص
        /// </summary>
        Guid PersonId { get; set; }

        /// <summary>
        /// نام
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// نام خانوادگی
        /// </summary>
        string LastName { get; set; }

		/// <summary>
		/// کد ملی
		/// </summary>
	    string NationalCode { get; set; }

        /// <summary>
        /// نقش ها
        /// </summary>
        IEnumerable<string> Roles { get; set; }
    }
}