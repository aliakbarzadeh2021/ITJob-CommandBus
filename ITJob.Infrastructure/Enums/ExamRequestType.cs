namespace ITJob.Infrastructure.Enums
{
    using System.ComponentModel;

    /// <summary>
    /// نوع آزمون درخواستی
    /// </summary>
    public enum ExamRequestType
    {
        /// <summary>
        /// استخدامی
        /// </summary>
        [Description("استخدامی")] Employment = 1,

        /// <summary>
        /// ارزیابی
        /// </summary>
        [Description("ارزیابی")] Assessment = 2
    }
}