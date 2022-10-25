namespace ITJob.Infrastructure.Models
{
    /// <summary>
    /// سه تایی مرتب -کلید، مقدار و تعریف
    /// </summary>
    public class KeyValueDefinitionTriad<TKey, TValue, TDefinition>
    {
        /// <summary>
        /// ایجاد سه تایی مرتب پیش فرض
        /// </summary>
        public KeyValueDefinitionTriad()
        {
        }

        /// <summary>
        /// ایجاد سه تایی مرتب
        /// </summary>
        /// <param name="key">کلید</param>
        /// <param name="value">مقدار</param>
        /// <param name="definition">تعریف</param>
        public KeyValueDefinitionTriad(TKey key, TValue value, TDefinition definition)
        {
            Key = key;
            Value = value;
            Definition = definition;
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
    }
}