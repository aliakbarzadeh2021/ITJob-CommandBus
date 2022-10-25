namespace ITJob.Infrastructure.Enums
{
    using System.ComponentModel;

    /// <summary>
    /// انواع پرسشنامه
    /// </summary>
    public enum QuestionnaireType
    {
        [Description("رغبت")]
        Propensity = 1,
        [Description("ارزش کاری")]
        ValueOfWork = 2,
        [Description("شخصیت")]
        Characteristic = 3,
        [Description("توانایی ذهنی")]
        MentalAbility = 4,
        [Description("روحیه جهادی")]
        BehavioralCharacteristics = 7,
        [Description("دانش ضمنی")]
        TacitKnowledge = 5,
        [Description("دانش شغلی")]
        JobKnowledge = 6,
    }
}
