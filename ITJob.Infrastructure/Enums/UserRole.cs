namespace ITJob.Infrastructure.Enums
{
    using System.ComponentModel;

    /// <summary>
    /// نقش های کاربری
    /// </summary>
    public enum UserRole
    {
        [Description("کاربر ارشد")]
        Admin,
        [Description("مدیر")]
        Manager,
        [Description("شرکت کننده")]
        Participant
    }
}