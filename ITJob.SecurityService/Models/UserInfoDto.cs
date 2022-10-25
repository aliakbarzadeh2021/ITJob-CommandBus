using ITJob.QueryModels.Interfaces.SecurityModule;

namespace ITJob.SecurityService.Models
{
    /// <inheritdoc />
    public class UserInfoDto : IUserInfoDto
    {
        public UserInfoDto(string userName, string nationalCode, string firstName, string lastName)
        {
            UserName = userName;
            NationalCode = nationalCode;
            FirstName = firstName;
            LastName = lastName;
        }

        /// <inheritdoc />
        public string UserName { get; private set; }

        /// <inheritdoc />
        public string NationalCode { get; private set; }

        /// <inheritdoc />
        public string FirstName { get; private set; }

        /// <inheritdoc />
        public string LastName { get; private set; }
    }
}