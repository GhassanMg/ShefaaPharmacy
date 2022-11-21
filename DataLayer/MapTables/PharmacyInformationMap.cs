using DataLayer.Tables;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.MapTables
{
    class PharmacyInformationMap
    {
        public PharmacyInformationMap(EntityTypeBuilder<PharmacyInformation> entity)
        {
            entity.ToTable("PharmacyInformation");
        }
    }
}
