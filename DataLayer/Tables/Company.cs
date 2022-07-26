﻿using DataLayer.Helper;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataLayer.Tables
{
    public class Company : BaseModel
    {
        [DisplayName("اسم مستودع الأدوية")]
        public string Name { get; set; }
        [DisplayName("مكان المستودع")]
        public string Location { set; get; }
        [Browsable(false)]
        public IList<Article> Articales { get; set; }
    }
}
