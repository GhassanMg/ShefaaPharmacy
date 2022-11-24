using System;
using DataLayer.Helper;
using DataLayer.Services;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Tables
{
    public class LastTimeArticles : BaseModel
    {
        public delegate void UpdateForm();
        public event UpdateForm onUpdateForm;

        [Browsable(false)]
        public int ArticleId { get; set; }
        [NotMapped]
        [DisplayName("الدواء")]
        public string ArticleIdDescr
        {
            get
            {
                return DescriptionFK.GetArticaleName(ArticleId);
            }
            set {; }
        }
        [Browsable(false)]
        public int UnitId { get; set; }
        [NotMapped]
        [DisplayName("الواحدة")]
        public string UnitIdDescr
        {
            get
            {
                return DescriptionFK.GetUnitName(UnitId);
            }
            set {; }
        }
        [DisplayName("الكمية المتبقية")]
        public double QuantityLeft { get; set; }
        [NotMapped]
        [Browsable(false)]
        double totalprice;

        [DisplayName("إجمالي السعر")]
        public double TotalPrice { get; set; }
        //{
        //    get { return totalprice; }
        //    set
        //    {
        //        totalprice = value * QuantityLeft;
        //        onUpdateForm?.Invoke();
        //    }
        //}
    }
}

