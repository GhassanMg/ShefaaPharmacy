using DataLayer.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataLayer.MapTables
{
    public class BranchMap
    {
        public BranchMap(EntityTypeBuilder<PriceTagMaster> entity)
        {
            entity.ToTable("PriceTagMaster");
            entity.Property(e => e.CreationDate)
                .HasDefaultValue(DateTime.Now);
        }
        public BranchMap(EntityTypeBuilder<PriceTagDetail> entity)
        {
            entity.ToTable("PriceTagDetail");
            entity.Property(e => e.BuyPrice).HasDefaultValue(0);
            entity.Property(e => e.SellPrice).HasDefaultValue(0);
            entity.Property(e => e.CreationDate)
                .HasDefaultValue(DateTime.Now);
        }
        public BranchMap(EntityTypeBuilder<Branch> entity)
        {
            entity.ToTable("Branch");
            entity.Property(e => e.Name)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.CreationDate)
                .HasDefaultValue(DateTime.Now);
        }
    }
}
