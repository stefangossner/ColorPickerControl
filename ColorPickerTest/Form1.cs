using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorPickerTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ColorPickerControl1_SelectionChanged(object sender, StefanG.Controls.ColorPickerControl.SelectionChangedEventArgs e)
        {
            MessageBox.Show(string.Format("Selection Changed: {0:X8}", e.SelectedColor.ToArgb()));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("The following color is selected: {0:X8}", this.colorPickerControl1.SelectedColor.ToArgb()));
            
        }
    }
}
