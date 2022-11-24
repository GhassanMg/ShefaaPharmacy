using DataLayer.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.MapTables
{
    class LastTimeArticlesMap
    {
        public LastTimeArticlesMap(EntityTypeBuilder<LastTimeArticles> entity)
        {
            entity.ToTable("LastTimeArticles").HasNoKey();
            //entity.Property(e => e.CreationDate)
            //    .HasDefaultValue(DateTime.Now);
        }
    }
}
