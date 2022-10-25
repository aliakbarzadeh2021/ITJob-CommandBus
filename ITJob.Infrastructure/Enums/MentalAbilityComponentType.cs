namespace ITJob.Infrastructure.Enums
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// مؤلفه های توانایی ذهنی
    /// </summary>
    public enum MentalAbilityComponentType
    {

        [Description("درک مطلب")]
        Comprehension,

        [Description("روابط کلامی")]
        VerbalRelations,

        [Description("تصور")]
        Imagination,

        [Description("فضاگرایی")]
        SpaceOrientation,

        [Description("سرعت نتیجه گیری")]
        ConclusionsSpeed,

        [Description("دقت انتخابی")]
        ChoiceAccuracy,

        [Description("سرعت ادراک")]
        PerceptionSpeed,

        [Description("شمارش")]
        Computation,

        [Description("استدلال ریاضی")]
        MathematicalReasoning,

        [Description("مرتب سازی اطلاعات")]
        OrderingInformation,

        [Description("استدلال")]
        Reasoning,

        [Description("شناسایی مشکل")]
        ProblemIdentification

    }

}