using DataLayer.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.MapTables
{
    class MedicinesMap
    {
        public MedicinesMap(EntityTypeBuilder<Medicines> entity)
        {
            entity.ToTable("Medicines");
            
        }
    }
}
