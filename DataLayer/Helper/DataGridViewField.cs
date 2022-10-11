using System;

namespace DataLayer.Helper
{
    public class DataGridViewField : Attribute
    {
        public bool IsShow { set; get; }
        public DataGridViewField(bool isShow)
        {
            IsShow = isShow;
        }
    }
}
