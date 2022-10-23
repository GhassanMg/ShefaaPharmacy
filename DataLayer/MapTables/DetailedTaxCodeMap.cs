using DataLayer.Tables;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.MapTables
{
    class DetailedTaxCodeMap
    {
        public DetailedTaxCodeMap(EntityTypeBuilder<DetailedTaxCode> entity)
        {
            entity.ToTable("DetailedTaxCode");
        }
    }
}
