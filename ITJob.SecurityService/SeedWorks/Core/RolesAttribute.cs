namespace ITJob.SecurityService.SeedWorks.Core
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Infrastructure.Enums;

    public class RolesAttribute : AuthorizeAttribute
    {
        public RolesAttribute(params UserRole[] roles)
        {
            if (roles.All(c => c != UserRole.Admin))
            {
                var list = roles.ToList();
                list.Add(UserRole.Admin);
                roles = list.ToArray();
            }

            Roles = string.Join(",", roles);
        }

        public RolesAttribute(RolesHandler roleHandler)
        {
            switch (roleHandler)
            {
                case RolesHandler.AllRoles:
                    Roles = string.Join(",", Enum.GetValues(typeof(UserRole)).OfType<UserRole>());
                    break;
                case RolesHandler.AllAndAnonymous:
                    Roles = null; //ToDo => h.tabasi: test
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(roleHandler), roleHandler, null);
            }
        }
    }
    public enum RolesHandler
    {
        AllRoles,
        AllAndAnonymous
    }
}
