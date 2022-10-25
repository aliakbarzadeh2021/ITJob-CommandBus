namespace ITJob.Infrastructure.Enums
{
    using System.ComponentModel;

    /// <summary>
    /// تفسیر کیفی
    /// </summary>
    public enum Quality
    {
        [Description("خیلی کم")]
        VeryLow = 0,
        [Description("کم")]
        Low = 1,
        [Description("متوسط")]
        Normal = 2,
        [Description("زیاد")]
        High = 3,
        [Description("خیلی زیاد")]
        VeryHigh = 4
    }
}