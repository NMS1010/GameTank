﻿namespace GameTank
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
            this.mainGamePnl = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // mainGamePnl
            // 
            this.mainGamePnl.Location = new System.Drawing.Point(13, 13);
            this.mainGamePnl.Name = "mainGamePnl";
            this.mainGamePnl.Size = new System.Drawing.Size(880, 621);
            this.mainGamePnl.TabIndex = 0;
            this.mainGamePnl.Paint += new System.Windows.Forms.PaintEventHandler(this.mainGamePnl_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 646);
            this.Controls.Add(this.mainGamePnl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel mainGamePnl;
    }
}

