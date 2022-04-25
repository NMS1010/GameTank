using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using GameTank.MyObjects;
using GameTank.Constants;
using System.Threading.Tasks;

namespace GameTank
{
    public partial class Form1 : Form
    {
        BufferedGraphics bufferedGraphics;
        BufferedGraphicsContext bufferedGraphicsContext;
        Graphics grp;
        Timer renderTimer;
        Timer enemyFireTimer;
        Timer enemyMoveTimer;
        public Form1()
        {
            InitializeComponent();

        }

        public void InitGraphics()
        {
            bufferedGraphicsContext = BufferedGraphicsManager.Current;
            bufferedGraphicsContext.MaximumBuffer = new Size(Width, Height);    
            bufferedGraphics = bufferedGraphicsContext.Allocate(mainGamePnl.CreateGraphics(), mainGamePnl.DisplayRectangle);
            bufferedGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            grp = bufferedGraphics.Graphics;
        }
        private void Render()
        {
            if (GameStage.PlayerTank == null)
                return;
            bufferedGraphics.Graphics.Clear(Color.Black);

            playerTankDamageLabel.Text = GameStage.PlayerTank.BulletDamage.ToString();
            playerTankAttackSpeedLabel.Text = GameStage.PlayerTank.BulletDamage.ToString();
            GameStage.PlayerTank.DrawTank(grp);
            GameStage.PlayerTank.DrawBullets(grp);

            if (GameStage.numberEnemy == 0)
            {
                enemyMoveTimer.Stop();
                enemyFireTimer.Stop();

                GameStage.PlayerTank.Bullets.Clear();
                GameStage.PlayerTank.DrawBullets(grp);
            }
            else
                EnemySpawner.Spawn(grp);

            bufferedGraphics.Render();
        }
        private void mainGamePnl_Paint(object sender, PaintEventArgs e)
        {
            Render();
            mainGamePnl.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitGraphics();
            InitGame();
        }

        private void mainGamePnl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    GameStage.PlayerTank.Move(ACTION.MOVEUP);
                    break;
                case Keys.Down:
                    GameStage.PlayerTank.Move(ACTION.MOVEDOWN);
                    break;
                case Keys.Left:
                    GameStage.PlayerTank.Move(ACTION.MOVELEFT);
                    break;
                case Keys.Right:
                    GameStage.PlayerTank.Move(ACTION.MOVERIGHT);
                    break;
                case Keys.Space:
                    GameStage.PlayerTank.Fire();
                    break;

            }
            Render();
        }

        private void SetTimer()
        {
            renderTimer = new Timer();
            renderTimer.Tick += renderTimer_Tick;

            enemyFireTimer = new Timer();
            enemyFireTimer.Tick += EnemyFireTimer_Tick;
            enemyFireTimer.Interval = 1500;

            enemyMoveTimer = new Timer();
            enemyMoveTimer.Tick += EnemyMoveTimer_Tick;

            enemyFireTimer.Start();
            enemyMoveTimer.Start();
            renderTimer.Start();
        }

        private void SetImage()
        {
            using (Image heartImg = Image.FromFile("../../Image/heart.png"))
            {
                heartPtrb.Image = new Bitmap(heartImg);
            }
            using (Image nextBtnImg = Image.FromFile("../../Image/nextBtn.png"))
            {
                nextStagePtrb.Image = new Bitmap(nextBtnImg);
            }
            using (Image againBtnImg = Image.FromFile("../../Image/againBtn.png"))
            {
                againPtrb.Image = new Bitmap(againBtnImg);
            }
            using (Image homeBtnImg = Image.FromFile("../../Image/homeBtn.png"))
            {
                homePtrb.Image = new Bitmap(homeBtnImg);
            }
        }
        private void InitGame()
        {
            SetImage();
            PlayerTank playerTank = new PlayerTank(loc: new Point(400, 400), isOfPlayer: true, bulletColor: Color.Yellow, bulletSpeed: 100, bulletDamage: 20, health: 1000);
            GameStage.PlayerTank = playerTank;
            GameStage.MainGamePnl = this.mainGamePnl;
            GameStage.TotalPlayerHealth = totalHealthPtrb;
            GameStage.CurrentPlayerHealth = currentHealthPtrb;

            GameStage.Stage1();

            SetTimer();
        }

        private void EnemyMoveTimer_Tick(object sender, EventArgs e)
        {
            GameStage.EnemyTanks.ForEach(o => {
                if (!o.LockMove)
                    o.Move((ACTION)Utilities.ChooseEnemyDirection(o));
            });
            Render();
        }

        private void EnemyFireTimer_Tick(object sender, EventArgs e)
        {
            GameStage.EnemyTanks.ForEach(o => {
                if (!o.LockMove)
                    o.Fire();
            });
            Render();
        }

        private async void renderTimer_Tick(object sender, EventArgs e)
        {
            Render();
            if(GameStage.numberEnemy == 0)
            {
                await Task.Delay(2000);
                modalPtrb.Visible = true;
                (sender as Timer).Stop();
            }
        }

        private void homePtrb_Click(object sender, EventArgs e)
        {

        }

        private async void nextStagePtrb_Click(object sender, EventArgs e)
        {
            GameStage.ClearStage();
            GameStage.Stage2();
            await Task.Delay(1000);
            modalPtrb.Visible = false;

            SetTimer();
        }

        private void againPtrb_Click(object sender, EventArgs e)
        {

        }
    }
}
