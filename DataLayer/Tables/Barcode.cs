using DataLayer.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Tables
{
    public class Barcode : BaseModel
    {
        public string Code { set; get; }
        #region Relation
        public int ArticaleId { set; get; }
        [ForeignKey("ArticaleId")]
        public Article Articale { set; get; }
        #endregion

    }
}
