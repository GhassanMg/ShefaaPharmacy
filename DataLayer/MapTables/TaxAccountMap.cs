using System;
using DataLayer.Tables;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.MapTables
{
    class TaxAccountMap
    {
        public TaxAccountMap(EntityTypeBuilder<TaxAccount> entity)
        {
            entity.ToTable("ExpiryTransfeerDetail");
        }
    }
}
