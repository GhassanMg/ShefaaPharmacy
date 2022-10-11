using DataLayer.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataLayer.MapTables
{
    public class ExistStuffMap
    {

        public ExistStuffMap(EntityTypeBuilder<ExistStuff> entity)
        {
            entity.ToTable("ExistStuff");
            entity.Property(e => e.CreationDate)
                .HasDefaultValue(DateTime.Now);
        }
    }
}
