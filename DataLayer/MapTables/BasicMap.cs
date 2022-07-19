using DataLayer.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.MapTables
{
    public class BasicMap
    {
        public BasicMap(EntityTypeBuilder<Year> entity)
        {
            entity.ToTable("Year");
            entity.Property(e => e.CreationDate)
                .HasDefaultValue(DateTime.Now);
            entity.Property(e => e.Name)
                .HasDefaultValueSql("('')");
        }
        public BasicMap(EntityTypeBuilder<UnitType> entity)
        {
            entity.ToTable("UnitType");
            entity.Property(e => e.CreationDate)
                .HasDefaultValue(DateTime.Now);
            entity.Property(e => e.Name)
                .HasDefaultValueSql("('')");
        }
        public BasicMap(EntityTypeBuilder<Barcode> entity)
        {
            entity.ToTable("Barcode");
            entity.Property(e => e.CreationDate)
                .HasDefaultValue(DateTime.Now);
            entity.Property(e => e.Code)
                .HasDefaultValueSql("('')");
        }
        public BasicMap(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("User");
        }
        public BasicMap(EntityTypeBuilder<Connection> entity)
        {
            entity.ToTable("Connection");
        }
        public BasicMap(EntityTypeBuilder<Company> entity)
        {
            entity.ToTable("Company");
            entity.Property(e => e.Name)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.CreationDate)
                .HasDefaultValue(DateTime.Now);
        }
    }
}
