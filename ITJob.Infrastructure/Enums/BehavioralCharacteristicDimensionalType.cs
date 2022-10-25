namespace ITJob.Infrastructure.Enums
{
    using System.ComponentModel;
    using Types;

    /// <summary>
    /// ابعاد روحیه جهادی
    /// </summary>
    public enum BehavioralCharacteristicDimensionalType
    {
        /// <summary>
        /// روحیه جهادی فردی
        /// </summary>
        [Description("روحیه جهادی فردی")]
        [Order(1)]
        IndividualJihadiMorale,

        /// <summary>
        /// روحیه جهادی اجتماعی
        /// </summary>
        [Description("روحیه جهادی اجتماعی")]
        [Order(2)]
        SocialJihadiMorale,

        /// <summary>
        /// روحیه جهادی اعتقادی
        /// </summary>
        [Description("روحیه جهادی اعتقادی")]
        [Order(0)]
        MakeBelieveJihadiMorale
    }
}
