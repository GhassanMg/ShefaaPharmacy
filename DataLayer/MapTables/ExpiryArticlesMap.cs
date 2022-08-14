using DataLayer.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.MapTables
{
    class ExpiryArticlesMap
    {
        public ExpiryArticlesMap(EntityTypeBuilder<ExpiryTransfeerDetail> entity)
        {
            entity.ToTable("ExpiryTransfeerDetail");
            entity.Property(e => e.CreationDate)
                .HasDefaultValue(DateTime.Now);
        }
    }
}
