﻿using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TMT.Controls.WinForms
{
    internal partial class DateTimePickerDropDown : Form
    {
        internal DateTimePickerDropDown()
        {
            InitializeComponent();

            this.Capture = true; //allows mouse events to be triggered no matter where the mouse clicks
        }

        [Category("Behavior")]
        public event DateRangeEventHandler DateSelected;

        internal void SetLocation(Point startLocation)
        {
            try
            {
                //Match the position to the parent control
                this.Left = startLocation.X - this.Width;
                this.Top = startLocation.Y;
            }
            catch { }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            try
            {
                //Check to see if the click is inside the drop-down Form
                if (this.RectangleToScreen(this.ClientRectangle).Contains(Cursor.Position) == false)
                {
                    this.Close(); //close the drop-down
                }
                else
                {
                    base.OnMouseDown(e);
                }
            }
            catch { }
        }

        private void MonthCalendarMain_DateSelected(object sender, DateRangeEventArgs e)
        {
            try
            {
                DateSelected?.Invoke(this, e);
            }
            catch { }
        }
    }
}