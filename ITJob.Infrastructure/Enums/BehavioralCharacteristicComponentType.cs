namespace ITJob.Infrastructure.Enums
{
    using System.ComponentModel;
    using Types;

    /// <summary>
    /// مولفه های روحیه جهادی
    /// </summary>
    public enum BehavioralCharacteristicComponentType
    {
        /// <summary>
        /// اعتماد به کمک الهی (توکل)
        /// </summary>
        [Description("اعتماد به کمک الهی (توکل)")]
        [Dimension((int)BehavioralCharacteristicDimensionalType.MakeBelieveJihadiMorale)]
        [Order(0)]
        Trust,

        /// <summary>
        /// کار برای خدا-اخلاص
        /// </summary>
        [Description("کار برای خدا-اخلاص")]
        [Dimension((int)BehavioralCharacteristicDimensionalType.MakeBelieveJihadiMorale)]
        [Order(1)]
        Sincerity,

        /// <summary>
        /// ابتکار و خلاقیت
        /// </summary>
        [Description("ابتکار و خلاقیت")]
        [Dimension((int)BehavioralCharacteristicDimensionalType.IndividualJihadiMorale)]
        [Order(2)]
        InitiativeAndCreativity,

        /// <summary>
        /// پشتکار؛ تلاش و پیگیری مداوم؛ کار بی‌وقفه و خستگی‌ناپذیر
        /// </summary>
        [Description("پشتکار؛ تلاش و پیگیری مداوم؛ کار بی‌وقفه و خستگی‌ناپذیر")]
        [Dimension((int)BehavioralCharacteristicDimensionalType.IndividualJihadiMorale)]
        [Order(3)]
        Perseverance,

        /// <summary>
        /// آمادگی و اشتیاق برای کار در شرایط سخت
        /// </summary>
        [Description("آمادگی و اشتیاق برای کار در شرایط سخت")]
        [Dimension((int)BehavioralCharacteristicDimensionalType.IndividualJihadiMorale)]
        [Order(4)]
        PassionForHardwork,

        /// <summary>
        /// کار با نشاط و انگیزه
        /// </summary>
        [Description("کار با نشاط و انگیزه")]
        [Dimension((int)BehavioralCharacteristicDimensionalType.IndividualJihadiMorale)]
        [Order(5)]
        WorkMotivation,

        /// <summary>
        /// برنامه‌ریزی و کار علمی و مدبرانه
        /// </summary>
        [Description("برنامه‌ریزی و کار علمی و مدبرانه")]
        [Dimension((int)BehavioralCharacteristicDimensionalType.IndividualJihadiMorale)]
        [Order(6)]
        PlanningAndScientificWork,

        /// <summary>
        /// نظم
        /// </summary>
        [Description("نظم")]
        [Dimension((int)BehavioralCharacteristicDimensionalType.IndividualJihadiMorale)]
        [Order(7)]
        Discipline,

        /// <summary>
        /// جدیت در کار
        /// </summary>
        [Description("جدیت در کار")]
        [Order(8)]
        [Dimension((int)BehavioralCharacteristicDimensionalType.IndividualJihadiMorale)]
        HardAtWork,

        /// <summary>
        /// خودباوری و اعتمادبه‌نفس
        /// </summary>
        [Description("خودباوری و اعتمادبه‌نفس")]
        [Order(9)]
        [Dimension((int)BehavioralCharacteristicDimensionalType.IndividualJihadiMorale)]
        SelfEsteem,

        /// <summary>
        /// یافتن ضعف‌های خود
        /// </summary>
        [Description("یافتن ضعف‌های خود")]
        [Dimension((int)BehavioralCharacteristicDimensionalType.IndividualJihadiMorale)]
        [Order(10)]
        FindYourWeaknesses,

        /// <summary>
        /// آرمان‌گرایی و ایستادگی بر هدف
        /// </summary>
        [Description("آرمان‌گرایی و ایستادگی بر هدف")]
        [Dimension((int)BehavioralCharacteristicDimensionalType.IndividualJihadiMorale)]
        [Order(11)]
        Idealism,

        /// <summary>
        /// سرعت، کارایی و بازده مضاعف
        /// </summary>
        [Description("سرعت، کارایی و بازده مضاعف")]
        [Dimension((int)BehavioralCharacteristicDimensionalType.IndividualJihadiMorale)]
        [Order(12)]
        Performance,

        /// <summary>
        /// ازخودگذشتگی و ایثار در مقابل خودمحوری
        /// </summary>
        [Description("ازخودگذشتگی و ایثار در مقابل خودمحوری")]
        [Dimension((int)BehavioralCharacteristicDimensionalType.SocialJihadiMorale)]
        [Order(13)]
        Devotion,

        /// <summary>
        /// احساس مسئولیت و کار دلسوزانه
        /// </summary>
        [Description("احساس مسئولیت و کار دلسوزانه")]
        [Dimension((int)BehavioralCharacteristicDimensionalType.SocialJihadiMorale)]
        [Order(14)]
        Responsibility,

        /// <summary>
        /// استفاده از تمام توان، ظرفیت و استعداد
        /// </summary>
        [Description("استفاده از تمام توان، ظرفیت و استعداد")]
        [Dimension((int)BehavioralCharacteristicDimensionalType.SocialJihadiMorale)]
        [Order(15)]
        Talent,

        /// <summary>
        /// پرهیز از بی‌اخلاقی
        /// </summary>
        [Description("پرهیز از بی‌اخلاقی")]
        [Dimension((int)BehavioralCharacteristicDimensionalType.SocialJihadiMorale)]
        [Order(16)]
        AbstainFromImmorality,

        /// <summary>
        /// خدمتگزاری
        /// </summary>
        [Description("خدمتگزاری")]
        [Dimension((int)BehavioralCharacteristicDimensionalType.SocialJihadiMorale)]
        [Order(17)]
        Serving,

        /// <summary>
        /// اهل وحدت، هماهنگی و یکنوایی و همصدایی در مقابل اهل تعارض و دشمنی
        /// </summary>
        [Description("اهل وحدت، هماهنگی و یکنوایی و همصدایی در مقابل اهل تعارض و دشمنی")]
        [Dimension((int)BehavioralCharacteristicDimensionalType.SocialJihadiMorale)]
        [Order(18)]
        Unity,

        /// <summary>
        /// روحیه مردمی و اجتماعی
        /// </summary>
        [Description("روحیه مردمی و اجتماعی")]
        [Dimension((int)BehavioralCharacteristicDimensionalType.SocialJihadiMorale)]
        [Order(19)]
        CommunityMorale,

        /// <summary>
        /// روحیه تشکیلاتی و کار جمعی
        /// </summary>
        [Description("روحیه تشکیلاتی و کار جمعی")]
        [Dimension((int)BehavioralCharacteristicDimensionalType.SocialJihadiMorale)]
        [Order(20)]
        OrganizationalMorale,
        /// <summary>
        /// اعتماد به نیروهای جوان و بااستعداد
        /// </summary>
        [Description("اعتماد به نیروهای جوان و بااستعداد")]
        [Dimension((int)BehavioralCharacteristicDimensionalType.SocialJihadiMorale)]
        [Order(21)]
        TrustInYouth,

        /// <summary>
        /// نقادی با منطق محکم و بیان روشن
        /// </summary>
        [Description("نقادی با منطق محکم و بیان روشن")]
        [Dimension((int)BehavioralCharacteristicDimensionalType.SocialJihadiMorale)]
        [Order(22)]
        Criticism
    }
}