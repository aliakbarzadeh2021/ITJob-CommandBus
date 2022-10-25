using SAF.SSN.Kernel.Infrastructure.Helpers;

namespace ITJob.Infrastructure.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Types;

    public static class EnumTypeExtention
    {

        public static EnumType GetWithDimension(this EnumType et)
        {
            Type enumType = Type.GetType("ITJob.Infrastructure.Enums." + et.Name);

            if (enumType == null)
                return et;

            var s = et.Members.Select(c =>
            {

                return new EnumMemeberWithDimension()
                {

                    Name = c.Name,
                    Code = c.Code,
                    Description = c.Description,
                    Dimension =
                        ((DimensionAttribute)
                            enumType.GetMember(Enum.Parse(enumType, c.Name).ToString())
                                .FirstOrDefault()?
                                .GetCustomAttributes(typeof(DimensionAttribute), false)
                                .FirstOrDefault())?.Dimension ?? -1

                };
            }).ToList();

            return new EnumTypeWithDimension(s) { Name = et.Name };
        }
    }

    public class EnumMemeberWithDimension : EnumMemeber
    {
        public int Dimension { get; set; }
    }

    public class EnumTypeWithDimension : EnumType
    {
        public EnumTypeWithDimension(IList<EnumMemeberWithDimension> members)
        {
            Members = members;
        }

        public new IList<EnumMemeberWithDimension> Members { get; }
    }

}
