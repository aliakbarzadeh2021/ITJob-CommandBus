using Microsoft.AspNet.Identity.EntityFramework;

namespace ITJob.SecurityService.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
        }

        public ApplicationUser(string userName) : base(userName)
        {
        }

        public ApplicationUser(string userName, string nationalCode) : base(userName)
        {
            NationalCode = nationalCode;
        }

        public ApplicationUser(string userName, string nationalCode, string firstName, string lastName) : base(userName)
        {
            NationalCode = nationalCode;
            FirstName = firstName;
            LastName = lastName;
        }

        public string NationalCode { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}