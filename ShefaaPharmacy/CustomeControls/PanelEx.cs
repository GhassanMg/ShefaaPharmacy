using System.Windows.Forms;

namespace ShefaaPharmacy.CustomeControls
{
    public partial class PanelEx : System.Windows.Forms.Panel
    {
        public PanelEx()
        {
            SetStyle(ControlStyles.UserPaint |ControlStyles.AllPaintingInWmPaint |ControlStyles.OptimizedDoubleBuffer,true);
        }
    }
}
