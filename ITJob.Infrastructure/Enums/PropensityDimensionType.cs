namespace ITJob.Infrastructure.Enums
{
    using System.ComponentModel;

    /// <summary>
    /// انواع تیپ های سوال های پرسشنامه رغبت
    /// </summary>
    public enum PropensityDimensionType
    {
        [Description("واقعگرا")]
        Realist = 1,
        [Description("جستجوگر")]
        Explorer = 2,
        [Description("هنری")]
        Artistic = 3,
        [Description("اجتماعی")]
        Social = 4,
        [Description("متهور")]
        Ahead = 5,
        [Description("قراردادی")]
        Contractual = 6
    }
}