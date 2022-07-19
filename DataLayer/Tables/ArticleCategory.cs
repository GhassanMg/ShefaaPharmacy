using DataLayer.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataLayer.Tables
{
    public class ArticleCategory : BaseModel
    {
        [DisplayName("اسم الصنف الرئيسي")]
        public string Name { set; get; }
        #region Relation
        [Browsable(false)]
        public IList<Article> Articles { get; set; }
        #endregion
    }
}
