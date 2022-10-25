namespace ITJob.SecurityService.Models
{
    /// <summary>
    /// پیام پاسخ یا بازخورد عملیات امنیتی
    /// </summary>
    public class SecurityResponseMessage
    {
        /// <summary>
        /// متن پیام
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// آیا عملیات با موفقیت انجام شد
        /// </summary>
        public bool Success { get; set; }
    }
}