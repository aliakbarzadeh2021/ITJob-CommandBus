using System;

namespace ITJob.ApiService.Controllers.Security.Models
{
    /// <summary>
    /// حذف کاربر
    /// </summary>
    public class UserDeleteModel
    {
        /// <summary>
        /// شناسه کاربر
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// کد ملی کاربر
        /// </summary>
        public string NationalCode { get; set; }
    }
}