namespace ITJob.Infrastructure.Enums
{
    using System.ComponentModel;

    /// <summary>
    /// انواع تفسیر کیفی
    /// </summary>
    public enum QualitativeInterpretationTypes
    {
        [Description("تفسیر کیفی نمرات خام")]
        QuestionnaireQualitativeInterpretation,
        [Description("تفسیر کیفی تناسب")]
        ExamQualitativeInterpretation
    }
}