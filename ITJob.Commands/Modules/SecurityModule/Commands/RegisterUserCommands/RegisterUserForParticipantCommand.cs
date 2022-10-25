namespace ITJob.Commands.Modules.SecurityModule.Commands.RegisterUserCommands
{
    /// <summary>
    /// درخواست ثبت حساب کاربری جهت شرکت کننده
    /// </summary>
    public sealed class RegisterUserForParticipantCommand : RegisterUserCommand
    {
        /// <summary>
        /// نام
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// نام خانوادگی
        /// </summary>
        public string LastName { get; set; }
    }
}