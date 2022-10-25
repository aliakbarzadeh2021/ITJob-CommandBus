namespace ITJob.QueryModels.Interfaces.SecurityModule
{
    /// <summary>
    /// اطلاعات کاربر
    /// </summary>
    public interface IUserInfoDto
    {
        /// <summary>
        /// کد کاربری
        /// </summary>
        string UserName { get; }

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
    }
}