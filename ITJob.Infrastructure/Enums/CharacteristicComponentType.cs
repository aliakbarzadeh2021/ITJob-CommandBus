
using System.ComponentModel;

namespace ITJob.Infrastructure.Enums
{
    using Types;

    /// <summary>
    /// مولفه های شخصیت
    /// </summary>
    public enum CharacteristicComponentType
    {
        /// <summary>
        /// خلوص و بی ریایی
        /// </summary>
        [Description("خلوص و بی ریایی")]
        [Dimension((int)CharacteristicDemensionalType.HonestyHumility)]
        [Order(0)]
        PurityAndNaivety,

        /// <summary>
        /// درستکاری
        /// </summary>
        [Description("درستکاری")]
        [Dimension((int)CharacteristicDemensionalType.HonestyHumility)]
        [Order(1)]
        Honesty,

        /// <summary>
        /// پرهیز از طمع
        /// </summary>
        [Description("پرهیز از طمع")]
        [Dimension((int)CharacteristicDemensionalType.HonestyHumility)]
        [Order(2)]
        AvoidGreed,

        /// <summary>
        /// تواضع و فروتنی
        /// </summary>
        [Description("تواضع و فروتنی")]
        [Dimension((int)CharacteristicDemensionalType.HonestyHumility)]
        [Order(3)]
        Humility,

        /// <summary>
        /// شجاعت
        /// </summary>
        [Description("شجاعت(در مقابل ترس)")]
        [Dimension((int)CharacteristicDemensionalType.Excitation)]
        [Order(4)]
        Courage,

        /// <summary>
        /// آرامش
        /// </summary>
        [Description("آرامش (در مقابل اضطراب)")]
        [Dimension((int)CharacteristicDemensionalType.Excitation)]
        [Order(5)]
        Peace,

        /// <summary>
        /// استقلال
        /// </summary>
        [Description("استقلال (در مقابل وابستگی)")]
        [Dimension((int)CharacteristicDemensionalType.Excitation)]
        [Order(6)]
        Independence,

        /// <summary>
        /// کنترل احساسات
        /// </summary>
        [Description("کنترل احساسات")]
        [Dimension((int)CharacteristicDemensionalType.Excitation)]
        [Order(7)]
        EmotionsControl,

        /// <summary>
        /// عزت نفس
        /// </summary>
        [Description("عزت نفس اجتماعی")]
        [Dimension((int)CharacteristicDemensionalType.Extraversion)]
        [Order(8)]
        SocialSelfEsteem,

        /// <summary>
        /// جسارت و رهبری
        /// </summary>
        [Description("جسارت و رهبری")]
        [Dimension((int)CharacteristicDemensionalType.Extraversion)]
        [Order(9)]
        CourageAndLeadership,

        /// <summary>
        /// مردم آمیزی
        /// </summary>
        [Description("مردم آمیزی")]
        [Dimension((int)CharacteristicDemensionalType.Extraversion)]
        [Order(10)]
        Sociability,

        /// <summary>
        /// سرزندگی
        /// </summary>
        [Description("سرزندگی")]
        [Dimension((int)CharacteristicDemensionalType.Extraversion)]
        [Order(11)]
        Vitality,

        /// <summary>
        /// گذشت
        /// </summary>
        [Description("گذشت")]
        [Dimension((int)CharacteristicDemensionalType.Compatibility)]
        [Order(12)]
        Forgiveness,

        /// <summary>
        /// عطوفت
        /// </summary>
        [Description("عطوفت")]
        [Dimension((int)CharacteristicDemensionalType.Compatibility)]
        [Order(13)]
        Endearment,

        /// <summary>
        /// انعطاف پذیری
        /// </summary>
        [Description("انعطاف پذیری")]
        [Dimension((int)CharacteristicDemensionalType.Compatibility)]
        [Order(14)]
        Flexibility,

        /// <summary>
        /// صبر و شکیبایی
        /// </summary>
        [Description("صبر و شکیبایی")]
        [Dimension((int)CharacteristicDemensionalType.Compatibility)]
        [Order(15)]
        Patience,

        /// <summary>
        /// نظم
        /// </summary>
        [Description("نظم")]
        [Dimension((int)CharacteristicDemensionalType.Conscientiousness)]
        [Order(16)]
        Decipline,

        /// <summary>
        /// پشتکار
        /// </summary>
        [Description("پشتکار")]
        [Dimension((int)CharacteristicDemensionalType.Conscientiousness)]
        [Order(17)]
        Perseverance,

        /// <summary>
        /// کمال گرایی
        /// </summary>
        [Description("کمال گرایی")]
        [Dimension((int)CharacteristicDemensionalType.Conscientiousness)]
        [Order(18)]
        Perfectionism,

        /// <summary>
        /// تدبیر و احتیاط
        /// </summary>
        [Description("تدبیر و احتیاط")]
        [Dimension((int)CharacteristicDemensionalType.Conscientiousness)]
        [Order(19)]
        TactAndCaution,

        /// <summary>
        /// حس زیبایی شناختی
        /// </summary>
        [Description("درک زیبایی(حس زیبایی شناختی)")]
        [Dimension((int)CharacteristicDemensionalType.OpennessToExperience)]
        [Order(20)]
        AestheticSense,


        /// <summary>
        /// کنجکاوی
        /// </summary>
        [Description("کنجکاوی")]
        [Dimension((int)CharacteristicDemensionalType.OpennessToExperience)]
        [Order(21)]
        Pry,

        /// <summary>
        /// خلاقیت
        /// </summary>
        [Description("خلاقیت")]
        [Dimension((int)CharacteristicDemensionalType.OpennessToExperience)]
        [Order(22)]
        Creativity,

        /// <summary>
        /// ساختارشکنی
        /// </summary>
        [Description("ساختارشکنی")]
        [Dimension((int)CharacteristicDemensionalType.OpennessToExperience)]
        [Order(23)]
        Deconstruct,

        /// <summary>
        /// نوع دوستی
        /// </summary>
        [Description("نوع دوستی(درمقابل خصومت)")]
        [Dimension((int)CharacteristicDemensionalType.ScaleInterstitial)]
        [Order(24)]
        Altruism,
    }
}