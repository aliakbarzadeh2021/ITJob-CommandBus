namespace ITJob.Commands.SeedWorks.Exceptions
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class CommandValidationException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public CommandValidationException(string message)
            : base(message)
        {
        }
    }
}