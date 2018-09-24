namespace CharacterCreator
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
            this.textOutput = new System.Windows.Forms.TextBox();
            this.Export = new System.Windows.Forms.Button();
            this.nodeControl = new nodeControl.UserControl1();
            this.SuspendLayout();
            // 
            // textOutput
            // 
            this.textOutput.AccessibleName = "";
            this.textOutput.Location = new System.Drawing.Point(651, 12);
            this.textOutput.Multiline = true;
            this.textOutput.Name = "textOutput";
            this.textOutput.Size = new System.Drawing.Size(268, 228);
            this.textOutput.TabIndex = 1;
            this.textOutput.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Export
            // 
            this.Export.Location = new System.Drawing.Point(677, 310);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(75, 23);
            this.Export.TabIndex = 2;
            this.Export.Text = "Export";
            this.Export.UseVisualStyleBackColor = true;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // nodeControl
            // 
            this.nodeControl.AccessibleName = "nodeControl";
            this.nodeControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.nodeControl.Location = new System.Drawing.Point(12, 12);
            this.nodeControl.Name = "nodeControl";
            this.nodeControl.Size = new System.Drawing.Size(552, 522);
            this.nodeControl.TabIndex = 3;
            this.nodeControl.Load += new System.EventHandler(this.nodeControl_Load);
            this.nodeControl.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 546);
            this.Controls.Add(this.nodeControl);
            this.Controls.Add(this.Export);
            this.Controls.Add(this.textOutput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textOutput;
        private System.Windows.Forms.Button Export;
        private nodeControl.UserControl1 nodeControl;
    }
}