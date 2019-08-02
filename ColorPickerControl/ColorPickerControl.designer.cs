namespace StefanG.Controls
{
    partial class ColorPickerControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbColorCode = new System.Windows.Forms.Label();
            this.btnSelectedColor = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbColorCodeDescript = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // lbColorCode
            //
            this.lbColorCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbColorCode.AutoSize = true;
            this.lbColorCode.Location = new System.Drawing.Point(275, 290);
            this.lbColorCode.Name = "lbColorCode";
            this.lbColorCode.Size = new System.Drawing.Size(55, 13);
            this.lbColorCode.TabIndex = 8;
            this.lbColorCode.Text = "FFFFFFFF";
            this.lbColorCode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            //
            // btnSelectedColor
            //
            this.btnSelectedColor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSelectedColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSelectedColor.Enabled = false;
            this.btnSelectedColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectedColor.Location = new System.Drawing.Point(10, 279);
            this.btnSelectedColor.Name = "btnSelectedColor";
            this.btnSelectedColor.Size = new System.Drawing.Size(34, 34);
            this.btnSelectedColor.TabIndex = 9;
            this.btnSelectedColor.TabStop = false;
            this.btnSelectedColor.UseVisualStyleBackColor = false;
            //
            // label4
            //
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Selected Color";
            //
            // lbColorCodeDescript
            //
            this.lbColorCodeDescript.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbColorCodeDescript.AutoSize = true;
            this.lbColorCodeDescript.Location = new System.Drawing.Point(203, 290);
            this.lbColorCodeDescript.Name = "lbColorCodeDescript";
            this.lbColorCodeDescript.Size = new System.Drawing.Size(62, 13);
            this.lbColorCodeDescript.TabIndex = 11;
            this.lbColorCodeDescript.Text = "Color Code:";
            //
            // ColorPickerControl
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbColorCodeDescript);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSelectedColor);
            this.Controls.Add(this.lbColorCode);
            this.Name = "ColorPickerControl";
            this.Size = new System.Drawing.Size(337, 321);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbColorCode;
        private System.Windows.Forms.Button btnSelectedColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbColorCodeDescript;
    }
}
