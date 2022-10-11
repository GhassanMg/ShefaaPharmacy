using DataLayer.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataLayer.MapTables
{
    public class EntryMap
    {
        public EntryMap(EntityTypeBuilder<EntryMaster> entity)
        {
            entity.ToTable("EntryMaster");
            entity.Property(e => e.CreationDate)
                .HasDefaultValue(DateTime.Now);
            entity.Property(e => e.RelatedDocument)
                .HasDefaultValue(0);
        }
        public EntryMap(EntityTypeBuilder<EntryDetail> entity)
        {
            entity.ToTable("EntryDetail");
            entity.Property(e => e.CreationDate)
                .HasDefaultValue(DateTime.Now);
        }
    }
}
