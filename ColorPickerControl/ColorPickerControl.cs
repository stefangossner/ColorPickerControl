using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StefanG.Controls
{
    public partial class ColorPickerControl : UserControl
    {
        const int rows = 11;
        const float step = 512f / (rows + 1);

        public delegate void SelectionChangedEventHandler(object sender, SelectionChangedEventArgs e);
        public class SelectionChangedEventArgs : EventArgs
        {
            public Color SelectedColor;

            public SelectionChangedEventArgs(Color selectedColor)
            {
                this.SelectedColor = selectedColor;
            }
        }

        [System.ComponentModel.Category("ColorPicker Events")]
        [System.ComponentModel.DisplayName("SelectionChanged")]
        [System.ComponentModel.Description("Event which fires when the color selection has changed")]
        public event SelectionChangedEventHandler SelectionChanged = null;


        [System.ComponentModel.Category("ColorPicker Settings")]
        [System.ComponentModel.DisplayName("SelectedColor")]
        [System.ComponentModel.Description("Currently selected color")]
        public Color SelectedColor
        {
            get
            {
                return btnSelectedColor.BackColor;
            }
            set
            {
                btnSelectedColor.BackColor = value;
                lbColorCode.Text = value == Color.Transparent ? "none" : value.ToArgb().ToString("X8");

                bool found = false;

                foreach (Control c in this.Controls)
                {
                    if (c is Button)
                    {
                        Button b = c as Button;
                        if (b.Tag != null)
                        {
                            if (b.BackColor.ToArgb() == btnSelectedColor.BackColor.ToArgb())
                            {
                                BigButton = b;
                                found = true;
                                break;
                            }
                        }
                    }
                }

                if (!found)
                    BigButton = null;

                this.SelectionChanged?.Invoke(this, new SelectionChangedEventArgs(this.btnSelectedColor.BackColor));
            }
        }

        [System.ComponentModel.Category("ColorPicker Settings")]
        [System.ComponentModel.DisplayName("ShowColorCode")]
        [System.ComponentModel.Description("Show Color Code of selected color in Hex")]
        public bool ShowColorCode
        {
            get
            {
                return lbColorCode.Visible;
            }
            set
            {
                lbColorCode.Visible = value;
                lbColorCodeDescript.Visible = value;
            }
        }

        private Button BigButton
        {
            get
            {
                return bigButton;
            }
            set
            {
                if (bigButton != null && bigButton != value)
                {
                    bigButton.Left = bigButton.Left + 4;
                    bigButton.Top = bigButton.Top + 4;
                    bigButton.Width = bigButton.Width - 8;
                    bigButton.Height = bigButton.Height - 8;
                }

                bigButton = value;

                if (bigButton != null)
                {
                    bigButton.Left = bigButton.Left - 4;
                    bigButton.Top = bigButton.Top - 4;
                    bigButton.Width = bigButton.Width + 8;
                    bigButton.Height = bigButton.Height + 8;
                }
            }
        }

        private Button bigButton = null;

        private static Color[] colors = new Color[] {
            Color.FromArgb(255,255,255),
            Color.FromArgb(0,0,0),
            Color.FromArgb(255,127,0),
            Color.FromArgb(255,255,0),
            Color.FromArgb(127,255,0),
            Color.FromArgb(0,255,0),
            Color.FromArgb(0,255,127),
            Color.FromArgb(0,255,255),
            Color.FromArgb(0,127,255),
            Color.FromArgb(0,0,255),
            Color.FromArgb(127,0,255),
            Color.FromArgb(255,0,255),
            Color.FromArgb(255,0,127)
        };

        private static Color[,] Gradient = new Color[,] {
            {
                Color.FromArgb(43, 0, 0),
                Color.FromArgb(85, 0, 0),
                Color.FromArgb(128, 0, 0),
                Color.FromArgb(171, 0, 0),
                Color.FromArgb(213, 0, 0),
                Color.FromArgb(255, 0, 0),
                Color.FromArgb(255, 43, 43),
                Color.FromArgb(255, 85, 85),
                Color.FromArgb(255, 128, 128),
                Color.FromArgb(255, 171, 171),
                Color.FromArgb(255, 213, 213)
            },
            {
                Color.FromArgb(35, 18, 0),
                Color.FromArgb(72, 36, 0),
                Color.FromArgb(103, 52, 0),
                Color.FromArgb(145, 72, 0),
                Color.FromArgb(182, 91, 0),
                Color.FromArgb(218, 108, 0),
                Color.FromArgb(255, 127, 0),
                Color.FromArgb(255, 153, 50),
                Color.FromArgb(255, 179, 101),
                Color.FromArgb(255, 205, 153),
                Color.FromArgb(255, 230, 204)
            },
            {
                Color.FromArgb(31, 31, 0),
                Color.FromArgb(63, 63, 0),
                Color.FromArgb(95, 95, 0),
                Color.FromArgb(127, 128, 0),
                Color.FromArgb(159, 159, 0),
                Color.FromArgb(191, 191, 0),
                Color.FromArgb(223, 223, 0),
                Color.FromArgb(255, 255, 0),
                Color.FromArgb(255, 255, 63),
                Color.FromArgb(255, 255, 127),
                Color.FromArgb(255, 255, 191)
            },
            {
                Color.FromArgb(0, 0, 0),
                Color.FromArgb(0, 0, 0),
                Color.FromArgb(27, 27, 27),
                Color.FromArgb(55, 55, 55),
                Color.FromArgb(84, 84, 84),
                Color.FromArgb(112, 112, 112),
                Color.FromArgb(141, 141, 141),
                Color.FromArgb(169, 169, 169),
                Color.FromArgb(197, 197, 197),
                Color.FromArgb(225, 225, 225),
                Color.FromArgb(255, 255, 255)
            },
        };

        Button[,] Buttons = new Button[colors.Length, rows];

        Button focusButton = null;

        private int CalcColor(int check, int altCheck, int row, int rows, float step)
        {
            int color;
            int color2 = 0;
            if (check == 255 && altCheck == 0)
                color = (int)((row + 1) * step - 1);
            else if (check == 255 && altCheck == 255)
            {
                color = (int)((row + 1) * step) * 2 / 3 - 1;
            }
            else if (check == 0 && altCheck == 510)
            {
                color = (int)((row - (rows * 2 / 3)) * step * 2) / 3 - 1;
            }
            else if (check == 0 && altCheck == 382)
            {
                color = (int)((row - (rows / 2)) * step) - 1;
            }
            else if (check == 255)
            {
                color = (int)((row + 1) * step);
                color = color > 256 ? 256 : color < 0 ? 0 : color;
                color2 = (int)((row - (rows / 2)) * step);
                color2 = color2 > 256 ? 256 : color2 < 0 ? 0 : color2;
                color = (color * 2 + color2) / 3 - 1;
            }
            else
            {
                color = (int)((row + 1) * step);
                color = color > 256 ? 256 : color < 0 ? 0 : color;
                color2 = (int)((row - (rows / 2)) * step);
                color2 = color2 > 256 ? 256 : color2 < 0 ? 0 : color2;
                color = (color + color2 * 2) / 3 - 1;
            }
            return color > 255 ? 255 : color < 0 ? 0 : color;
        }


        public ColorPickerControl()
        {
            InitializeComponent();

            this.SuspendLayout();

            List<Button> buttons = new List<Button>();

            for (int column = 0; column < colors.Length; column++)
            {
                for (int row = 1; row < rows; row++)
                {
                    Button btn = new Button();
                    btn.Location = new System.Drawing.Point(10 + column * 25, 10 + (row - 1) * 25);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Name = "btn" + row + column;
                    btn.Size = new System.Drawing.Size(20, 20);
                    btn.TabIndex = row * colors.Length + column;
                    btn.Text = "";
                    btn.Click += Btn_Click;
                    btn.UseVisualStyleBackColor = true;

                    Color x = colors[column];

                    int r = CalcColor(x.R, x.G + x.B, row, rows, step);
                    int g = CalcColor(x.G, x.R + x.B, row, rows, step);
                    int b = CalcColor(x.B, x.R + x.G, row, rows, step);

                    if (column == 0)
                    {
                        r = Gradient[3, row].R;
                        g = Gradient[3, row].G;
                        b = Gradient[3, row].B;
                    }
                    if (column == 1)
                    {
                        r = Gradient[0, row].R;
                        g = Gradient[0, row].G;
                        b = Gradient[0, row].B;
                    }
                    if (column == 2)
                    {
                        r = Gradient[1, row].R;
                        g = Gradient[1, row].G;
                        b = Gradient[1, row].B;
                    }
                    if (column == 3)
                    {
                        r = Gradient[2, row].R;
                        g = Gradient[2, row].G;
                        b = Gradient[2, row].B;
                    }
                    if (column == 4)
                    {
                        r = Gradient[1, row].G;
                        g = Gradient[1, row].R;
                        b = Gradient[1, row].B;
                    }
                    if (column == 5)
                    {
                        r = Gradient[0, row].B;
                        g = Gradient[0, row].R;
                        b = Gradient[0, row].G;
                    }
                    if (column == 6)
                    {
                        r = Gradient[1, row].B;
                        g = Gradient[1, row].R;
                        b = Gradient[1, row].G;
                    }
                    if (column == 7)
                    {
                        r = Gradient[2, row].B;
                        g = Gradient[2, row].G;
                        b = Gradient[2, row].R;
                    }
                    if (column == 8)
                    {
                        r = Gradient[1, row].B;
                        g = Gradient[1, row].G;
                        b = Gradient[1, row].R;
                    }
                    if (column == 9)
                    {
                        r = Gradient[0, row].B;
                        g = Gradient[0, row].G;
                        b = Gradient[0, row].R;
                    }
                    if (column == 10)
                    {
                        r = Gradient[1, row].G;
                        g = Gradient[1, row].B;
                        b = Gradient[1, row].R;
                    }
                    if (column == 11)
                    {
                        r = Gradient[2, row].R;
                        g = Gradient[2, row].B;
                        b = Gradient[2, row].G;
                    }
                    if (column == 12)
                    {
                        r = Gradient[1, row].R;
                        g = Gradient[1, row].B;
                        b = Gradient[1, row].G;
                    }

                    btn.BackColor = Color.FromArgb(r, g, b);
                    btn.Tag = btn.BackColor;

                    if (btnSelectedColor.BackColor == btn.BackColor)
                        BigButton = btn;

                    buttons.Add(btn);
                }
            }

            this.Controls.AddRange(buttons.ToArray());

            this.ResumeLayout();

            if (focusButton != null)
            {
                this.ActiveControl = focusButton;
                focusButton.Focus();
            }

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            lbColorCode.Text = (sender as Button).BackColor.ToArgb().ToString("X8");
            this.btnSelectedColor.BackColor = (sender as Button).BackColor;
            BigButton = sender as Button;

            this.SelectionChanged?.Invoke(this, new SelectionChangedEventArgs(this.btnSelectedColor.BackColor));
        }

    }
}
