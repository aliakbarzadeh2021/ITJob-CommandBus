namespace ITJob.Infrastructure.Enums
{
    using System.ComponentModel;

    /// <summary>
    /// وضعیت آزمون
    /// </summary>
    public enum ExamState
    {
        [Description("شروع نشده")] NotStarted = 1,

        [Description("ناتمام")] Unfinished = 2,

        [Description("تکمیل")] Complete = 3
    }
}