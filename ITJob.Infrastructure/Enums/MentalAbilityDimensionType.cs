namespace ITJob.Infrastructure.Enums
{
    using System.ComponentModel;

    /// <summary>
    /// ابعاد توانایی ذهنی
    /// </summary>
    public enum MentalAbilityDimensionType
    {
        /// <summary>
        /// کلامی
        /// </summary>
        [Description("کلامی")]
        Speech,

        /// <summary>
        /// تجسم فضایی
        /// </summary>
        [Description("تجسم فضایی")]
        SpatialVisualization,

        /// <summary>
        /// دقت و تمرکز
        /// </summary>
        [Description("دقت و تمرکز")]
        PrecisionAndFocus,

        /// <summary>
        /// محاسبات
        /// </summary>
        [Description("محاسبات")]
        Calculation,

        /// <summary>
        /// حل مساله
        /// </summary>
        [Description("حل مساله")]
        ProblemSolving
    }
}