using DataLayer.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataLayer.MapTables
{
    class FirstTimeArticlesMap
    {
        public FirstTimeArticlesMap(EntityTypeBuilder<FirstTimeArticles> entity)
        {
            entity.ToTable("FirstTimeArticles");
            entity.Property(e => e.CreationDate)
                .HasDefaultValue(DateTime.Now);
        }
    }
}
