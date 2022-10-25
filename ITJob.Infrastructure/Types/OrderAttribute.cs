namespace ITJob.Infrastructure.Types
{
    using System;

    /// <summary>
    /// خصوصیت ترتیب  
    /// </summary>
    public class OrderAttribute : Attribute
    {
        public OrderAttribute(int order)
        {
            Order = order;
        }

        public int Order { get; set; }
    }
}