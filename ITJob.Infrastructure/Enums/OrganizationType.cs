namespace ITJob.Infrastructure.Enums
{
    using System.ComponentModel;

    /// <summary>
    /// نوع سازمان
    /// </summary>
    public enum OrganizationType
    {
        /// <summary>
        /// دولتی 
        /// </summary>
        [Description("دولتی")] Governmental = 1,

        /// <summary>
        /// خصوصی
        /// </summary>
        [Description("خصوصی")] Private = 2
    }
}