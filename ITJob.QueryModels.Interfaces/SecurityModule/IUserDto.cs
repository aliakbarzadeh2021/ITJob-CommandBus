using System;

namespace ITJob.QueryModels.Interfaces.SecurityModule
{
    /// <summary>
    /// کاربر
    /// </summary>
    public interface IUserDto
    {
        /// <summary>
        /// شناسه شخص
        /// </summary>
        Guid PersonId { get; set; }

        /// <summary>
        /// کد ملی
        /// </summary>
        string NationalCode { get; }

        /// <summary>
        /// نام
        /// </summary>
        string FirstName { get; }

        /// <summary>
        /// نام خانوادگی
        /// </summary>
        string LastName { get; }

        /// <summary>
        /// نام کاربری
        /// </summary>
        string UserName { get; }

        /// <summary>
        /// کد عبور
        /// </summary>
        string Password { get; }
    }
}