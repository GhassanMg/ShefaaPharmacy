using System.Collections.Generic;

namespace DataLayer.Helper
{
    public class ColumnShowState
    {
        public List<string> ShowCol { set; get; }
        public List<string> HideCol { set; get; }
        public ColumnShowState()
        {
            ShowCol = new List<string>();
            HideCol = new List<string>();
        }
    }
}
