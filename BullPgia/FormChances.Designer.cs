
using System.Windows.Forms;

namespace BoolPgia
{
    partial class FormChances
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonChances = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.CenterToScreen();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(478, 323);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(263, 71);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonChances
            // 
            this.buttonChances.Location = new System.Drawing.Point(12, 53);
            this.buttonChances.Name = "buttonChances";
            this.buttonChances.Size = new System.Drawing.Size(776, 84);
            this.buttonChances.TabIndex = 1;
            this.buttonChances.Text = "Number of Chances: 4";
            this.buttonChances.UseVisualStyleBackColor = true;
            this.buttonChances.Click += new System.EventHandler(this.buttonChances_Click);
            // 
            // FormChances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonChances);
            this.Controls.Add(this.buttonStart);
            this.Name = "FormChances";
            this.Text = "Bool Pgia";
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonChances;
    }
}