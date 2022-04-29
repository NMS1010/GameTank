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
    public partial class Game : Form
    {
        BufferedGraphics bufferedGraphics;
        BufferedGraphicsContext bufferedGraphicsContext;
        Timer renderTimer;
        Timer enemyFireTimer;
        Timer enemyMoveTimer;
        public Game()
        {
            InitializeComponent();
            
        }

        public void InitGraphics()
        {
            bufferedGraphicsContext = BufferedGraphicsManager.Current;
            bufferedGraphicsContext.MaximumBuffer = new Size(mainGamePnl.Width, mainGamePnl.Height);    
            bufferedGraphics = bufferedGraphicsContext.Allocate(mainGamePnl.CreateGraphics(), mainGamePnl.DisplayRectangle);
            
        }
        public void ClearGraphics()
        {
            bufferedGraphics.Graphics.Dispose();
            bufferedGraphics.Dispose();
            bufferedGraphicsContext.Invalidate();
        }
        private void Render()
        {
            if (GameStage.PlayerTank == null)
                return;
            //InitGraphics();
            bufferedGraphics.Graphics.Clear(Color.Black);
            playerTankDamageLabel.Text = GameStage.PlayerTank.BulletDamage.ToString();
            playerTankAttackSpeedLabel.Text = GameStage.PlayerTank.BulletDamage.ToString();
            GameStage.PlayerTank.DrawTank(bufferedGraphics.Graphics);
            GameStage.PlayerTank.DrawBullets(bufferedGraphics.Graphics);

            if (GameStage.NumberEnemy == 0)
            {
                enemyMoveTimer.Stop();
                enemyMoveTimer.Tick -= EnemyMoveTimer_Tick;
                enemyFireTimer.Stop();
                enemyFireTimer.Tick -= EnemyFireTimer_Tick;

                //GameStage.PlayerTank.Bullets.Clear();
                //GameStage.PlayerTank.DrawBullets(bufferedGraphics.Graphics);
            }
            else
                EnemySpawner.Spawn(bufferedGraphics.Graphics);

            bufferedGraphics.Render();
            //ClearGraphics();
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
            using (Image nextBtnImg = Image.FromFile("../../Image/nextBtn.jpg"))
            {
                nextStagePtrb.Image = new Bitmap(nextBtnImg);
            }
            using (Image againBtnImg = Image.FromFile("../../Image/replayBtn.jpg"))
            {
                againPtrb.Image = new Bitmap(againBtnImg);
            }
            using (Image homeBtnImg = Image.FromFile("../../Image/homeBtn.jpg"))
            {
                homePtrb.Image = new Bitmap(homeBtnImg);
            }
            using (Image cupImg = Image.FromFile("../../Image/cup.png"))
            {
                cupPtrb.Image = new Bitmap(cupImg);
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
            GameStage.CurrentNumberEnemyContainer = numberEnemyContainerPanel;
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
            if (GameStage.NumberEnemy == 0)
            {
                //await Task.Delay(4000);
                renderTimer.Stop();
                renderTimer.Tick -= renderTimer_Tick;
                modalPanel.Visible = true;
                modalPanel.BringToFront();
            }
        }

        private void homePtrb_Click(object sender, EventArgs e)
        {

        }

        private async void nextStagePtrb_Click(object sender, EventArgs e)
        {
            GameStage.ClearStage();
            GameStage.Stage2();
            await Task.Delay(2000);
            modalPanel.SendToBack();
            modalPanel.Visible = false;
            SetTimer();
        }

        private void againPtrb_Click(object sender, EventArgs e)
        {

        }
    }
}
