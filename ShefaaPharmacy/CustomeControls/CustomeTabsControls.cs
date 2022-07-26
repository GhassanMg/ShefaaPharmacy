﻿using System.Drawing;
using System.Windows.Forms;

namespace ShefaaPharmacy.CustomeControls
{
    public partial class CustomeTabsControls:TabControl
    {
        Rectangle TabBoundary;
        RectangleF TabTextBoundary;
        StringFormat format = new StringFormat(); //for tab header text

        public CustomeTabsControls()
        {
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.format.Alignment = StringAlignment.Center;
            this.format.LineAlignment = StringAlignment.Center;
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.FillRectangle(new SolidBrush(Color.Red), 0, 0, this.Size.Width, this.Size.Height);

            foreach (TabPage tp in this.TabPages)
            {
                //drawItem
                int index = this.TabPages.IndexOf(tp);

                this.TabBoundary = this.GetTabRect(index);
                this.TabTextBoundary = (RectangleF)this.GetTabRect(index);

                g.FillRectangle(new SolidBrush(Color.Black), this.TabBoundary);
                g.DrawString("tabPage " + index.ToString(), this.Font, new SolidBrush(Color.Black), this.TabTextBoundary, format);
            }
        }
    }
}
