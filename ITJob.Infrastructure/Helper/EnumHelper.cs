namespace ITJob.Infrastructure.Helper
{
    using System;
    using System.ComponentModel;
    using Types;

    public static class EnumHelper
    {
        /// <summary>
        /// Gets an attribute on an enum field value
        /// </summary>
        /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumVal">The enum value</param>
        /// <returns>The attribute of type T that exists on the enum value</returns>
        public static T GetAttributeOfType<T, TEnum>(this TEnum enumVal)
            where T : Attribute
            where TEnum : struct
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            if (memInfo.Length == 0)
                return null;
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            if (attributes.Length == 0)
                return null;
            return (T)attributes[0];
        }

        /// <summary>
        /// ارائه ی شرح یا متن فارسی لحاظ شده جهت یک مقدار عددی
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string GetDescription<T>(this T src) where T : struct
        {
            var attribute = src.GetAttributeOfType<DescriptionAttribute, T>();
            return attribute == null ? src.ToString() : attribute.Description;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src"></param>
        /// <returns></returns>
        public static int GetDimension<T>(this T src) where T : struct
        {
            var attribute = src.GetAttributeOfType<DimensionAttribute, T>();
            return attribute?.Dimension ?? -1;
        }

        /// <summary>
        /// ارائه ی مقدار خصوصیت ترتیب
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src"></param>
        /// <returns></returns>
        public static int GetOrder<T>(this T src) where T : struct
        {
            var attribute = src.GetAttributeOfType<OrderAttribute, T>();
            return attribute?.Order ?? 0;
        }

        public static T GetEnumByValue<T>(int value) where T : struct 
        {
            if (typeof(T).IsEnum && Enum.IsDefined(typeof(T), value))
            {
                return (T)Enum.Parse(typeof(T), value.ToString());
            }
            else
            {
                throw new Exception("Invalid Convertion.");
            }
        }
    }
}