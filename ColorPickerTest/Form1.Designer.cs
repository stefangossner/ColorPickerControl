namespace ColorPickerTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorPickerControl1 = new StefanG.Controls.ColorPickerControl();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // colorPickerControl1
            // 
            this.colorPickerControl1.Location = new System.Drawing.Point(12, 12);
            this.colorPickerControl1.Name = "colorPickerControl1";
            this.colorPickerControl1.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorPickerControl1.ShowColorCode = true;
            this.colorPickerControl1.Size = new System.Drawing.Size(337, 321);
            this.colorPickerControl1.TabIndex = 0;
            this.colorPickerControl1.SelectionChanged += new StefanG.Controls.ColorPickerControl.SelectionChangedEventHandler(this.ColorPickerControl1_SelectionChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(212, 353);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Show Selected Color";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 389);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.colorPickerControl1);
            this.Name = "Form1";
            this.Text = "ColorPickerTest";
            this.ResumeLayout(false);

        }

        #endregion

        private StefanG.Controls.ColorPickerControl colorPickerControl1;
        private System.Windows.Forms.Button button1;
    }
}

