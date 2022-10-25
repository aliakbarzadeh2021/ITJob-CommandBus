namespace ITJob.Infrastructure.Enums
{
    using System.ComponentModel;

    /// <summary>
    /// دلایل رد اعتبار نتیجه
    /// </summary>
    public enum ExamResultValidationState
    {
        [Description("غیر قابل قبول")]
        InValid= 0,

        [Description("مورد تایید")]
        Valid = 1
    }
}