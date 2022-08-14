using DataLayer.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

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
