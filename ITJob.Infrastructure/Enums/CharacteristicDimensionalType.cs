using System.ComponentModel;

namespace ITJob.Infrastructure.Enums
{
    using Types;

    /// <summary>
    /// ابعاد شخصیت
    /// </summary>
    public enum CharacteristicDemensionalType
    {
        /// <summary>
        /// با وجدان بودن،وظیفه شناسی
        /// </summary>
        [Description("با وجدان بودن،وظیفه شناسی")]
        [Order(4)]
        Conscientiousness,

        /// <summary>
        /// "سازگاری ،دل پذیری در برابر خشم "
        /// </summary>
        [Description("سازگاری")]
        [Order(3)]
        Compatibility,

        /// <summary>
        /// برونگرایی
        /// </summary>
        [Description("برون گرایی")]
        [Order(2)]
        Extraversion,

        /// <summary>
        /// صداقت
        /// </summary>
        [Description("صداقت-تواضع")]
        [Order(0)]
        HonestyHumility,

        /// <summary>
        /// هیجان پذیری
        /// </summary>
        [Description("هیجان پذیری")]
        [Order(1)]
        Excitation,

        /// <summary>
        /// گشودگی به تجربه
        /// </summary>
        [Description("گشودگی به تجربه")]
        [Order(5)]
        OpennessToExperience,

        /// <summary>
        /// مقیاس بینابینی
        /// </summary>
        [Description("مقیاس بینابینی")]
        [Order(6)]
        ScaleInterstitial
    }
}