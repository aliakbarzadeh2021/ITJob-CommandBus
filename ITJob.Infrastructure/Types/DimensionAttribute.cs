namespace ITJob.Infrastructure.Types
{
    using System;
    /// <summary>
    ///صفات ابعاد  
    /// </summary>
    public class DimensionAttribute : Attribute
    {
        public DimensionAttribute(int dimension)
        {
            Dimension = dimension;
        }

        public int Dimension { get; set; }
    }
}