namespace GameTank
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.playerTankDamageLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.currentHealthPtrb = new System.Windows.Forms.PictureBox();
            this.totalHealthPtrb = new System.Windows.Forms.PictureBox();
            this.playerTankAttackSpeedLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.modalPtrb = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.homePtrb = new System.Windows.Forms.PictureBox();
            this.nextStagePtrb = new System.Windows.Forms.PictureBox();
            this.againPtrb = new System.Windows.Forms.PictureBox();
            this.heartPtrb = new System.Windows.Forms.PictureBox();
            this.mainGamePnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentHealthPtrb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalHealthPtrb)).BeginInit();
            this.modalPtrb.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.homePtrb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextStagePtrb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.againPtrb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heartPtrb)).BeginInit();
            this.SuspendLayout();
            // 
            // mainGamePnl
            // 
            this.mainGamePnl.Controls.Add(this.modalPtrb);
            this.mainGamePnl.Location = new System.Drawing.Point(13, 13);
            this.mainGamePnl.Name = "mainGamePnl";
            this.mainGamePnl.Size = new System.Drawing.Size(799, 621);
            this.mainGamePnl.TabIndex = 0;
            this.mainGamePnl.Paint += new System.Windows.Forms.PaintEventHandler(this.mainGamePnl_Paint);
            this.mainGamePnl.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.mainGamePnl_PreviewKeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Location = new System.Drawing.Point(818, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(260, 621);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("MV Boli", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(891, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = "Health";
            // 
            // playerTankDamageLabel
            // 
            this.playerTankDamageLabel.AutoSize = true;
            this.playerTankDamageLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.playerTankDamageLabel.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerTankDamageLabel.ForeColor = System.Drawing.Color.Red;
            this.playerTankDamageLabel.Location = new System.Drawing.Point(997, 107);
            this.playerTankDamageLabel.Name = "playerTankDamageLabel";
            this.playerTankDamageLabel.Size = new System.Drawing.Size(36, 27);
            this.playerTankDamageLabel.TabIndex = 10;
            this.playerTankDamageLabel.Text = "20";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Font = new System.Drawing.Font("MV Boli", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(832, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 28);
            this.label2.TabIndex = 9;
            this.label2.Text = "Damage";
            // 
            // currentHealthPtrb
            // 
            this.currentHealthPtrb.BackColor = System.Drawing.Color.Lime;
            this.currentHealthPtrb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currentHealthPtrb.Location = new System.Drawing.Point(832, 70);
            this.currentHealthPtrb.Name = "currentHealthPtrb";
            this.currentHealthPtrb.Size = new System.Drawing.Size(201, 34);
            this.currentHealthPtrb.TabIndex = 8;
            this.currentHealthPtrb.TabStop = false;
            // 
            // totalHealthPtrb
            // 
            this.totalHealthPtrb.BackColor = System.Drawing.Color.White;
            this.totalHealthPtrb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalHealthPtrb.Location = new System.Drawing.Point(832, 70);
            this.totalHealthPtrb.Name = "totalHealthPtrb";
            this.totalHealthPtrb.Size = new System.Drawing.Size(201, 34);
            this.totalHealthPtrb.TabIndex = 6;
            this.totalHealthPtrb.TabStop = false;
            // 
            // playerTankAttackSpeedLabel
            // 
            this.playerTankAttackSpeedLabel.AutoSize = true;
            this.playerTankAttackSpeedLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.playerTankAttackSpeedLabel.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerTankAttackSpeedLabel.ForeColor = System.Drawing.Color.Yellow;
            this.playerTankAttackSpeedLabel.Location = new System.Drawing.Point(997, 135);
            this.playerTankAttackSpeedLabel.Name = "playerTankAttackSpeedLabel";
            this.playerTankAttackSpeedLabel.Size = new System.Drawing.Size(36, 27);
            this.playerTankAttackSpeedLabel.TabIndex = 12;
            this.playerTankAttackSpeedLabel.Text = "20";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Font = new System.Drawing.Font("MV Boli", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(832, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 28);
            this.label4.TabIndex = 11;
            this.label4.Text = "Bullet Speed";
            // 
            // modalPtrb
            // 
            this.modalPtrb.BackColor = System.Drawing.Color.Teal;
            this.modalPtrb.Controls.Add(this.panel1);
            this.modalPtrb.Controls.Add(this.label8);
            this.modalPtrb.Controls.Add(this.label7);
            this.modalPtrb.Controls.Add(this.label6);
            this.modalPtrb.Controls.Add(this.label5);
            this.modalPtrb.Controls.Add(this.label3);
            this.modalPtrb.Location = new System.Drawing.Point(0, 0);
            this.modalPtrb.Name = "modalPtrb";
            this.modalPtrb.Size = new System.Drawing.Size(799, 621);
            this.modalPtrb.TabIndex = 1;
            this.modalPtrb.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Teal;
            this.label3.Font = new System.Drawing.Font("MV Boli", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(248, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(333, 85);
            this.label3.TabIndex = 13;
            this.label3.Text = "YOU WIN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MV Boli", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.BurlyWood;
            this.label5.Location = new System.Drawing.Point(192, 328);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(235, 49);
            this.label5.TabIndex = 14;
            this.label5.Text = "Total Score";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label6.Location = new System.Drawing.Point(74, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 45);
            this.label6.TabIndex = 15;
            this.label6.Text = "Score in turn";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label7.Location = new System.Drawing.Point(74, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(195, 45);
            this.label7.TabIndex = 16;
            this.label7.Text = "Time in turn";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MV Boli", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.BurlyWood;
            this.label8.Location = new System.Drawing.Point(192, 386);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(224, 49);
            this.label8.TabIndex = 17;
            this.label8.Text = "Total Time";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.againPtrb);
            this.panel1.Controls.Add(this.nextStagePtrb);
            this.panel1.Controls.Add(this.homePtrb);
            this.panel1.Location = new System.Drawing.Point(273, 476);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 93);
            this.panel1.TabIndex = 18;
            // 
            // homePtrb
            // 
            this.homePtrb.Location = new System.Drawing.Point(202, 16);
            this.homePtrb.Name = "homePtrb";
            this.homePtrb.Size = new System.Drawing.Size(65, 61);
            this.homePtrb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.homePtrb.TabIndex = 2;
            this.homePtrb.TabStop = false;
            this.homePtrb.Click += new System.EventHandler(this.homePtrb_Click);
            // 
            // nextStagePtrb
            // 
            this.nextStagePtrb.Location = new System.Drawing.Point(105, 16);
            this.nextStagePtrb.Name = "nextStagePtrb";
            this.nextStagePtrb.Size = new System.Drawing.Size(65, 61);
            this.nextStagePtrb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.nextStagePtrb.TabIndex = 3;
            this.nextStagePtrb.TabStop = false;
            this.nextStagePtrb.Click += new System.EventHandler(this.nextStagePtrb_Click);
            // 
            // againPtrb
            // 
            this.againPtrb.Location = new System.Drawing.Point(12, 16);
            this.againPtrb.Name = "againPtrb";
            this.againPtrb.Size = new System.Drawing.Size(65, 61);
            this.againPtrb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.againPtrb.TabIndex = 4;
            this.againPtrb.TabStop = false;
            this.againPtrb.Click += new System.EventHandler(this.againPtrb_Click);
            // 
            // heartPtrb
            // 
            this.heartPtrb.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.heartPtrb.Location = new System.Drawing.Point(1039, 70);
            this.heartPtrb.Name = "heartPtrb";
            this.heartPtrb.Size = new System.Drawing.Size(34, 34);
            this.heartPtrb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.heartPtrb.TabIndex = 5;
            this.heartPtrb.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 646);
            this.Controls.Add(this.heartPtrb);
            this.Controls.Add(this.playerTankAttackSpeedLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playerTankDamageLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.currentHealthPtrb);
            this.Controls.Add(this.totalHealthPtrb);
            this.Controls.Add(this.mainGamePnl);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainGamePnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentHealthPtrb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalHealthPtrb)).EndInit();
            this.modalPtrb.ResumeLayout(false);
            this.modalPtrb.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.homePtrb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextStagePtrb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.againPtrb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heartPtrb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel mainGamePnl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label playerTankDamageLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox currentHealthPtrb;
        private System.Windows.Forms.PictureBox totalHealthPtrb;
        private System.Windows.Forms.Label playerTankAttackSpeedLabel;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Panel modalPtrb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox againPtrb;
        private System.Windows.Forms.PictureBox nextStagePtrb;
        private System.Windows.Forms.PictureBox homePtrb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox heartPtrb;
    }
}

