using DataLayer.Tables;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.MapTables
{
    class TaxAccountMap
    {
        public TaxAccountMap(EntityTypeBuilder<TaxAccount> entity)
        {
            entity.ToTable("TaxAccount");
        }
    }
}
