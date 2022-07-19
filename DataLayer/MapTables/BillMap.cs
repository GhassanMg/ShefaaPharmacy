using DataLayer.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.MapTables
{
    public class BillMap
    {
        public BillMap(EntityTypeBuilder<BillMaster> entity)
        {
            entity.ToTable("BillMaster");
            entity.Property(e => e.CreationDate)
                .HasDefaultValue(DateTime.Now);
        }
        public BillMap(EntityTypeBuilder<BillDetail> entity)
        {
            entity.ToTable("BillDetail");
            entity.Property(e => e.CreationDate)
                .HasDefaultValue(DateTime.Now);
        }
    }
}
