using System;
using DataLayer.Tables;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.MapTables
{
    class DetailedTaxCodeMap
    {
        public DetailedTaxCodeMap(EntityTypeBuilder<DetailedTaxCode> entity)
        {
            entity.ToTable("DetailedTaxCode");
        }
    }
}
