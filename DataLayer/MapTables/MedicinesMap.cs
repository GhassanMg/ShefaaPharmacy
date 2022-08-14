using DataLayer.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

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
