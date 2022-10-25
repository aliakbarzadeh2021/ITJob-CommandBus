using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertis= ITJob.DomainModel.Modules.AdvertisementModule.Aggregates.Advertisement;

namespace ITJob.EntityFramework.Read.Implement.Modules.Advertisement
{
    public class AdvertisementConfig : EntityTypeConfiguration<Advertis>
    {
        public AdvertisementConfig()
        {
            ToTable("Advertisement");
        }
    }
}
