using System;
using System.Collections.Generic;
using ITJob.QueryModels.Interfaces.SecurityModule;

namespace ITJob.SecurityService.Models
{
    /// <inheritdoc />
    public class ProfileDto : IProfileDto
    {
        /// <inheritdoc />
        public Guid PersonId { get; set; }

        /// <inheritdoc />
        public string FirstName { get; set; }

        /// <inheritdoc />
        public string LastName { get; set; }

        /// <inheritdoc />
        public string NationalCode { get; set; }

        /// <inheritdoc />
        public IEnumerable<string> Roles { get; set; }
    }
}