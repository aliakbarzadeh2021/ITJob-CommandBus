using System.Security.AccessControl;

namespace ITJob.Infrastructure.Models
{
    /// <summary>
    /// چهار تایی مرتب -کلید، مقدار و تعریف و بعد
    /// </summary>
    public class KeyValueDefinitionQuadruple<TKey, TValue, TDefinition,TDimention>
    {
        /// <summary>
        /// ایجاد چهار تایی مرتب پیش فرض
        /// </summary>
        public KeyValueDefinitionQuadruple()
        {
        }

        /// <summary>
        /// ایجاد چهار تایی مرتب
        /// </summary>
        /// <param name="key">کلید</param>
        /// <param name="value">مقدار</param>
        /// <param name="definition">تعریف</param>
        /// <param name="dimention">نام بعد</param>
        public KeyValueDefinitionQuadruple(TKey key, TValue value, TDefinition definition, TDimention dimention)
        {
            Key = key;
            Value = value;
            Definition = definition;
            Dimention = dimention;
        }

        /// <summary>
        /// کلید
        /// </summary>
        public TKey Key { get; set; }

        /// <summary>
        /// مقدار
        /// </summary>
        public TValue Value { get; set; }

        /// <summary>
        /// تعریف
        /// </summary>
        public TDefinition Definition { get; set; }

        /// <summary>
        /// بعد
        /// </summary>
        public TDimention Dimention { get; set; }
    }
}
