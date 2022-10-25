namespace ITJob.Infrastructure.Enums
{
    using System.ComponentModel;

    /// <summary>
    /// فعالیت شرکت کننده
    /// </summary>
    public enum ParticipantActivityType
    {
        /// <summary>
        /// شروع به آزمون
        /// </summary>
        [Description("شروع")] ExamStart = 1,

        /// <summary>
        /// آخرین مشاهده
        /// </summary>
        [Description("آخرین مشاهده")] LastSeen = 2,
    }
}