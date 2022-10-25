using System;
using ITJob.QueryModels.Interfaces.SecurityModule;

namespace ITJob.SecurityService.Models
{
    public class UserDto : IUserDto
    {
        /// <inheritdoc />
        public UserDto(Guid personId, string nationalCode, string firstName, string lastName, string userName, string password)
        {
            PersonId = personId;
            NationalCode = nationalCode;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
        }
        public UserDto()
        { }

        /// <inheritdoc />
        public Guid PersonId { get; set; }

        /// <inheritdoc />
        public string NationalCode { get; set; }

        /// <inheritdoc />
        public string FirstName { get; set; }

        /// <inheritdoc />
        public string LastName { get; set; }

        /// <inheritdoc />
        public string UserName { get; set; }

        /// <inheritdoc />
        public string Password { get; set; }
    }
}