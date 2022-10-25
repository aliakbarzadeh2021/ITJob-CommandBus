namespace ITJob.Infrastructure.Enums
{
    using System.ComponentModel;

    /// <summary>
    /// وضعیت پرسشنامه آزمون اجرایی
    /// </summary>
    public enum ExamQuestionnaireStatus
    {
        [Description("شروع نشده")]
        NotStarted = 1,

        [Description("شروع شده")]
        Started = 2,

        [Description("تکمیل")]
        Complete = 3
    }
}