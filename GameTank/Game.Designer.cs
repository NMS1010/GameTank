namespace GameTank
{
    partial class Game
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
            this.modalPanel = new System.Windows.Forms.Panel();
            this.scoreTurnLabel = new System.Windows.Forms.Label();
            this.timeTurnScoreLabel = new System.Windows.Forms.Label();
            this.cupPtrb = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.againPtrb = new System.Windows.Forms.PictureBox();
            this.nextStagePtrb = new System.Windows.Forms.PictureBox();
            this.homePtrb = new System.Windows.Forms.PictureBox();
            this.totalTimeLabel = new System.Windows.Forms.Label();
            this.totalScoreLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.playerTankDamageLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.currentHealthPtrb = new System.Windows.Forms.PictureBox();
            this.totalHealthPtrb = new System.Windows.Forms.PictureBox();
            this.playerTankAttackSpeedLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.heartPtrb = new System.Windows.Forms.PictureBox();
            this.numberEnemyContainerPanel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.barPtrb = new System.Windows.Forms.PictureBox();
            this.stageLabel = new System.Windows.Forms.Label();
            this.countDownLabel = new System.Windows.Forms.Label();
            this.exitPtrb = new System.Windows.Forms.PictureBox();
            this.modalPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cupPtrb)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.againPtrb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextStagePtrb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.homePtrb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentHealthPtrb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalHealthPtrb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heartPtrb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barPtrb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitPtrb)).BeginInit();
            this.SuspendLayout();
            // 
            // mainGamePnl
            // 
            this.mainGamePnl.Location = new System.Drawing.Point(16, 66);
            this.mainGamePnl.Name = "mainGamePnl";
            this.mainGamePnl.Size = new System.Drawing.Size(799, 621);
            this.mainGamePnl.TabIndex = 0;
            this.mainGamePnl.Paint += new System.Windows.Forms.PaintEventHandler(this.mainGamePnl_Paint);
            this.mainGamePnl.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.mainGamePnl_PreviewKeyDown);
            // 
            // modalPanel
            // 
            this.modalPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.modalPanel.Controls.Add(this.scoreTurnLabel);
            this.modalPanel.Controls.Add(this.timeTurnScoreLabel);
            this.modalPanel.Controls.Add(this.cupPtrb);
            this.modalPanel.Controls.Add(this.panel1);
            this.modalPanel.Controls.Add(this.totalTimeLabel);
            this.modalPanel.Controls.Add(this.totalScoreLabel);
            this.modalPanel.Controls.Add(this.statusLabel);
            this.modalPanel.Location = new System.Drawing.Point(16, 66);
            this.modalPanel.Name = "modalPanel";
            this.modalPanel.Size = new System.Drawing.Size(799, 621);
            this.modalPanel.TabIndex = 1;
            this.modalPanel.Visible = false;
            // 
            // scoreTurnLabel
            // 
            this.scoreTurnLabel.AutoSize = true;
            this.scoreTurnLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreTurnLabel.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreTurnLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.scoreTurnLabel.Location = new System.Drawing.Point(144, 334);
            this.scoreTurnLabel.Name = "scoreTurnLabel";
            this.scoreTurnLabel.Size = new System.Drawing.Size(201, 45);
            this.scoreTurnLabel.TabIndex = 15;
            this.scoreTurnLabel.Text = "Score in turn";
            // 
            // timeTurnScoreLabel
            // 
            this.timeTurnScoreLabel.AutoSize = true;
            this.timeTurnScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeTurnScoreLabel.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeTurnScoreLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.timeTurnScoreLabel.Location = new System.Drawing.Point(506, 334);
            this.timeTurnScoreLabel.Name = "timeTurnScoreLabel";
            this.timeTurnScoreLabel.Size = new System.Drawing.Size(195, 45);
            this.timeTurnScoreLabel.TabIndex = 16;
            this.timeTurnScoreLabel.Text = "Time in turn";
            // 
            // cupPtrb
            // 
            this.cupPtrb.Location = new System.Drawing.Point(288, 103);
            this.cupPtrb.Name = "cupPtrb";
            this.cupPtrb.Size = new System.Drawing.Size(262, 276);
            this.cupPtrb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cupPtrb.TabIndex = 5;
            this.cupPtrb.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.againPtrb);
            this.panel1.Controls.Add(this.nextStagePtrb);
            this.panel1.Controls.Add(this.homePtrb);
            this.panel1.Location = new System.Drawing.Point(484, 498);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 93);
            this.panel1.TabIndex = 18;
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
            // totalTimeLabel
            // 
            this.totalTimeLabel.AutoSize = true;
            this.totalTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.totalTimeLabel.Font = new System.Drawing.Font("MV Boli", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTimeLabel.ForeColor = System.Drawing.Color.BurlyWood;
            this.totalTimeLabel.Location = new System.Drawing.Point(35, 524);
            this.totalTimeLabel.Name = "totalTimeLabel";
            this.totalTimeLabel.Size = new System.Drawing.Size(224, 49);
            this.totalTimeLabel.TabIndex = 17;
            this.totalTimeLabel.Text = "Total Time";
            // 
            // totalScoreLabel
            // 
            this.totalScoreLabel.AutoSize = true;
            this.totalScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.totalScoreLabel.Font = new System.Drawing.Font("MV Boli", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalScoreLabel.ForeColor = System.Drawing.Color.BurlyWood;
            this.totalScoreLabel.Location = new System.Drawing.Point(35, 453);
            this.totalScoreLabel.Name = "totalScoreLabel";
            this.totalScoreLabel.Size = new System.Drawing.Size(235, 49);
            this.totalScoreLabel.TabIndex = 14;
            this.totalScoreLabel.Text = "Total Score";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.BackColor = System.Drawing.Color.Transparent;
            this.statusLabel.Font = new System.Drawing.Font("MV Boli", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.Red;
            this.statusLabel.Location = new System.Drawing.Point(248, 15);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(333, 85);
            this.statusLabel.TabIndex = 13;
            this.statusLabel.Text = "YOU WIN";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Location = new System.Drawing.Point(821, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(266, 674);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("MV Boli", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(898, 23);
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
            this.playerTankDamageLabel.Location = new System.Drawing.Point(1004, 101);
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
            this.label2.Location = new System.Drawing.Point(839, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 28);
            this.label2.TabIndex = 9;
            this.label2.Text = "Damage";
            // 
            // currentHealthPtrb
            // 
            this.currentHealthPtrb.BackColor = System.Drawing.Color.Crimson;
            this.currentHealthPtrb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currentHealthPtrb.Location = new System.Drawing.Point(839, 54);
            this.currentHealthPtrb.Name = "currentHealthPtrb";
            this.currentHealthPtrb.Size = new System.Drawing.Size(201, 34);
            this.currentHealthPtrb.TabIndex = 8;
            this.currentHealthPtrb.TabStop = false;
            // 
            // totalHealthPtrb
            // 
            this.totalHealthPtrb.BackColor = System.Drawing.Color.White;
            this.totalHealthPtrb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalHealthPtrb.Location = new System.Drawing.Point(839, 54);
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
            this.playerTankAttackSpeedLabel.Location = new System.Drawing.Point(1004, 129);
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
            this.label4.Location = new System.Drawing.Point(839, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 28);
            this.label4.TabIndex = 11;
            this.label4.Text = "Bullet Speed";
            // 
            // heartPtrb
            // 
            this.heartPtrb.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.heartPtrb.Location = new System.Drawing.Point(1046, 54);
            this.heartPtrb.Name = "heartPtrb";
            this.heartPtrb.Size = new System.Drawing.Size(34, 34);
            this.heartPtrb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.heartPtrb.TabIndex = 5;
            this.heartPtrb.TabStop = false;
            // 
            // numberEnemyContainerPanel
            // 
            this.numberEnemyContainerPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.numberEnemyContainerPanel.Location = new System.Drawing.Point(840, 219);
            this.numberEnemyContainerPanel.Name = "numberEnemyContainerPanel";
            this.numberEnemyContainerPanel.Size = new System.Drawing.Size(200, 276);
            this.numberEnemyContainerPanel.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Font = new System.Drawing.Font("MV Boli", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Magenta;
            this.label9.Location = new System.Drawing.Point(839, 181);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 25);
            this.label9.TabIndex = 14;
            this.label9.Text = "Enemy";
            // 
            // barPtrb
            // 
            this.barPtrb.BackColor = System.Drawing.Color.Fuchsia;
            this.barPtrb.Location = new System.Drawing.Point(16, 13);
            this.barPtrb.Name = "barPtrb";
            this.barPtrb.Size = new System.Drawing.Size(799, 47);
            this.barPtrb.TabIndex = 15;
            this.barPtrb.TabStop = false;
            // 
            // stageLabel
            // 
            this.stageLabel.AutoSize = true;
            this.stageLabel.BackColor = System.Drawing.Color.Fuchsia;
            this.stageLabel.Font = new System.Drawing.Font("MS PGothic", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stageLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.stageLabel.Location = new System.Drawing.Point(22, 14);
            this.stageLabel.Name = "stageLabel";
            this.stageLabel.Size = new System.Drawing.Size(135, 37);
            this.stageLabel.TabIndex = 16;
            this.stageLabel.Text = "STAGE";
            // 
            // countDownLabel
            // 
            this.countDownLabel.AutoSize = true;
            this.countDownLabel.BackColor = System.Drawing.Color.Fuchsia;
            this.countDownLabel.Font = new System.Drawing.Font("MS PGothic", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countDownLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.countDownLabel.Location = new System.Drawing.Point(307, 14);
            this.countDownLabel.Name = "countDownLabel";
            this.countDownLabel.Size = new System.Drawing.Size(0, 37);
            this.countDownLabel.TabIndex = 17;
            // 
            // exitPtrb
            // 
            this.exitPtrb.BackColor = System.Drawing.Color.Fuchsia;
            this.exitPtrb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.exitPtrb.Location = new System.Drawing.Point(763, 14);
            this.exitPtrb.Name = "exitPtrb";
            this.exitPtrb.Size = new System.Drawing.Size(45, 45);
            this.exitPtrb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exitPtrb.TabIndex = 18;
            this.exitPtrb.TabStop = false;
            this.exitPtrb.Click += new System.EventHandler(this.exitPtrb_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(1099, 699);
            this.Controls.Add(this.exitPtrb);
            this.Controls.Add(this.countDownLabel);
            this.Controls.Add(this.stageLabel);
            this.Controls.Add(this.modalPanel);
            this.Controls.Add(this.barPtrb);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numberEnemyContainerPanel);
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
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Game";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.modalPanel.ResumeLayout(false);
            this.modalPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cupPtrb)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.againPtrb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextStagePtrb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.homePtrb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentHealthPtrb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalHealthPtrb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heartPtrb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barPtrb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitPtrb)).EndInit();
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
        public System.Windows.Forms.Panel modalPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox againPtrb;
        private System.Windows.Forms.PictureBox nextStagePtrb;
        private System.Windows.Forms.PictureBox homePtrb;
        private System.Windows.Forms.Label totalTimeLabel;
        private System.Windows.Forms.Label timeTurnScoreLabel;
        private System.Windows.Forms.Label scoreTurnLabel;
        private System.Windows.Forms.Label totalScoreLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.PictureBox heartPtrb;
        private System.Windows.Forms.Panel numberEnemyContainerPanel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox barPtrb;
        private System.Windows.Forms.PictureBox cupPtrb;
        private System.Windows.Forms.Label stageLabel;
        private System.Windows.Forms.Label countDownLabel;
        private System.Windows.Forms.PictureBox exitPtrb;
    }
}

