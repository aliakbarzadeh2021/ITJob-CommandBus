namespace ITJob.Infrastructure.Enums
{
    using System.ComponentModel;

    /// <summary>
    /// انواع هنجارهای پرسشنامه ارزش کاری
    /// </summary>
    public enum ValueOfWorkDimensionType
    {
        [Description("درامد مالی")]
        FinancialIncome = 1,
        [Description("امنیت خاطر")]
        PeaceOfMind = 2,
        [Description("شرایط کاری")]
        WorkingConditions = 3,
        [Description("جایگاه اجتماعی")]
        SocialPosition = 4,
        [Description("پیشرفت")]
        Progress = 5,
        [Description("ایمنی")]
        Safety = 6,
        [Description("بی نیازی از دیگران")]
        Independence = 7,
        [Description("استقلال")]
        Freedom = 8,
    }
}