namespace ITJob.Infrastructure.Enums
{
    using System.ComponentModel;

    /// <summary>
    /// وضعیت درخواست آزمون
    /// </summary>
    public enum ExamRequestStateType
    {
        /// <summary>
        /// در انتظار تایید
        /// </summary>
        [Description("در انتظار تایید")]
        Pending=1,

        /// <summary>
        /// تایید
        /// </summary>
        [Description("تایید")]
        Confirmation=2,

        /// <summary>
        /// رد تایید
        /// </summary>
        [Description("رد تایید")]
        Reject=3
    }
}