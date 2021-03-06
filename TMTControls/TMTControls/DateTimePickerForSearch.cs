﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TMT.Controls.WinForms.Dialogs;

namespace TMT.Controls.WinForms
{
    [ToolboxBitmap(typeof(DateTimePicker))]
    [ToolboxItem(false)]
    public partial class DateTimePickerForSearch : UserControl
    {
        private static string SEMICOLON = " or";
        private static string WHITE_SPACE = " ";

        private DateTimePickerDropDown dialog;

        public DateTimePickerForSearch()
        {
            InitializeComponent();
        }

        public override string Text
        {
            get
            {
                return textBoxMain.Text;
            }
            set
            {
                textBoxMain.Text = value;
            }
        }

        private void buttonDorpDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (dialog == null ||
                    dialog.IsDisposed)
                {
                    //The point just below the button
                    Point location = this.PointToScreen(new Point(buttonDorpDown.Left + buttonDorpDown.Width, buttonDorpDown.Bottom));
                    dialog = new DateTimePickerDropDown();
                    dialog.SetLocation(location);

                    dialog.DateSelected += dialog_DateSelected;

                    dialog.Show(this);
                }
                else if (dialog != null &&
                         dialog.IsDisposed == false)
                {
                    dialog.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorDialog.Show(this, ex, Properties.Resources.ERROR_ShowCalendar);
            }
        }

        private void dialog_DateSelected(object sender, DateRangeEventArgs e)
        {
            try
            {
                if (dialog != null &&
                    dialog.IsDisposed == false)
                {
                    if (string.IsNullOrEmpty(textBoxMain.Text) == false)
                    {
                        textBoxMain.Text = textBoxMain.Text.Trim();

                        if (textBoxMain.Text.EndsWith("!=", StringComparison.Ordinal) ||
                            textBoxMain.Text.EndsWith("<=", StringComparison.Ordinal) ||
                            textBoxMain.Text.EndsWith(">=", StringComparison.Ordinal) ||
                            textBoxMain.Text.EndsWith("<", StringComparison.Ordinal) ||
                            textBoxMain.Text.EndsWith(">", StringComparison.Ordinal) ||
                            textBoxMain.Text.EndsWith(SEMICOLON, StringComparison.Ordinal))
                        {
                            textBoxMain.Text += WHITE_SPACE + e.Start.ToShortDateString();
                        }
                        else
                        {
                            textBoxMain.Text += SEMICOLON + WHITE_SPACE + e.Start.ToShortDateString();
                        }
                    }
                    else
                    {
                        textBoxMain.Text = e.Start.ToShortDateString();
                    }
                    dialog.Hide(); //Hide the drop-down
                }
            }
            catch (Exception ex)
            {
                ErrorDialog.Show(this, ex, Properties.Resources.ERROR_SetSelectedDate);
            }
        }

        private void textBoxMain_Enter(object sender, EventArgs e)
        {
            try
            {
                if (dialog != null &&
                    dialog.IsDisposed == false)
                {
                    dialog.Close(); //close the drop-down
                }
            }
            catch (Exception ex)
            {
                ErrorDialog.Show(this, ex, Properties.Resources.ERROR_CloseCalendar);
            }
        }
    }
}