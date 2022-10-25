using SAF.SSN.Kernel.Infrastructure.Helpers;

namespace ITJob.ApiService.Factories
{
    using System.Collections.Generic;
    using System.Linq;
    using Infrastructure.Helper;
    using Castle.Core.Internal;

    public static class InitialDataFactory
    {
        private static readonly string[] EnumNames =
        {
            //"MilitaryExempt",
            //"MilitaryServiceType",
        };

        public static IEnumerable<EnumType> CreateInternalEnumOtherAddOn()
        {
            var scanner = new EnumsMemberScanner();
            scanner.Scan("ITJob.Infrastructure.dll");
            var enumMember = new EnumMemeber { Code = -1, Description = "سایر", Name = "Other" };
            var enums = scanner.EnumTypes;
            foreach (var item in scanner.EnumTypes.Where(x => EnumNames.Contains(x.Name)))
            {
                item.Members.Insert(item.Members.Count, enumMember);
            }

            //// گرفتن نام مولفه به همراه بعد
            var res = new List<EnumType>();

            enums.ForEach(d =>
            {

                var tmp = d.GetWithDimension();
                res.Add(tmp);

            });
            //scanner.Scan("SAF.Kernel.Infrastructure.dll");
            //enums.AddRange(scanner.EnumTypes);
            return res;
        }

    }
}