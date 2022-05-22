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
        Timer countDownTimer;
        int m, s, h;
        PictureBox currSkin;
        bool getFire = false;

        public Game()
        {
            InitializeComponent();
            
        }
        public void InitGraphics()
        {
            bufferedGraphicsContext = BufferedGraphicsManager.Current;
            bufferedGraphicsContext.MaximumBuffer = new Size(mainGamePnl.Width, mainGamePnl.Height);    
            bufferedGraphics = bufferedGraphicsContext.Allocate(mainGamePnl.CreateGraphics(), mainGamePnl.DisplayRectangle);
            bufferedGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
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
            {
                enemyMoveTimer.Stop();
                enemyMoveTimer.Tick -= EnemyMoveTimer_Tick;
                enemyFireTimer.Stop();
                enemyFireTimer.Tick -= EnemyFireTimer_Tick;
                return;
            }
            bufferedGraphics.Graphics.Clear(Color.Black);
            playerTankDamageLabel.Text = GameStage.PlayerTank.BulletDamage.ToString();
            playerTankAttackSpeedLabel.Text = GameStage.PlayerTank.BulletSpeed.ToString();
            GameStage.PlayerTank.DrawTank(bufferedGraphics.Graphics);
            GameStage.PlayerTank.DrawBullets(bufferedGraphics.Graphics);

            if (GameStage.NumberEnemy == 0)
            {
                enemyMoveTimer.Stop();
                enemyMoveTimer.Tick -= EnemyMoveTimer_Tick;
                enemyFireTimer.Stop();
                enemyFireTimer.Tick -= EnemyFireTimer_Tick;

            }
            else
                EnemySpawner.Spawn(bufferedGraphics.Graphics);
            try
            {
                bufferedGraphics.Render();
            }
            catch { }
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
            
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        GameStage.PlayerTank?.Move(ACTION.MOVEUP);
                        break;
                    case Keys.Down:
                        GameStage.PlayerTank?.Move(ACTION.MOVEDOWN);
                        break;
                    case Keys.Left:
                        GameStage.PlayerTank?.Move(ACTION.MOVELEFT);
                        break;
                    case Keys.Right:
                        GameStage.PlayerTank?.Move(ACTION.MOVERIGHT);
                        break;
                    case Keys.Space:
                        if (!getFire)
                            return;
                        getFire = false;
                        GameStage.PlayerTank?.Fire();
                        break;
                }
            }
            catch { }
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

            countDownTimer = new Timer();
            m = 0;
            s = 0;
            h = 0;
            countDownTimer.Tick += CountDownTimer_Tick;
            countDownTimer.Interval = 1000;

            enemyFireTimer.Start();
            enemyMoveTimer.Start();
            renderTimer.Start();
            countDownTimer.Start();
        }

        private void CountDownTimer_Tick(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                s++;
                if(s == 60)
                {
                    s = 0;
                    m++;
                }
                if( m == 60)
                {
                    m = 0;
                    h++;
                }
                countDownLabel.Text = String.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
            }));
            getFire = true;
        }

        private void SetImage()
        {
            using (Image heartImg = Properties.Resources.heart)
            {
                heartPtrb.Image = new Bitmap(heartImg);
            }
            using (Image nextBtnImg = Properties.Resources.nextBtn)
            {
                nextStagePtrb.Image = new Bitmap(nextBtnImg);
            }
            using (Image againBtnImg = Properties.Resources.replayBtn)
            {
                againPtrb.Image = new Bitmap(againBtnImg);
            }
            using (Image homeBtnImg = Properties.Resources.homeBtn)
            {
                homePtrb.Image = new Bitmap(homeBtnImg);
            }
            using (Image exitImg = Properties.Resources.exitBtn)
            {
                exitPtrb.Image = new Bitmap(exitImg);
            }
            using (Image img = Properties.Resources.skin1player)
            {
                skin1playerPtrb.Image = new Bitmap(img);
                skin1playerPtrb.Tag = Properties.Resources.skin1player;
            }
            using (Image img = Properties.Resources.skin2player)
            {
                skin2playerPtrb.Image = new Bitmap(img);
                skin2playerPtrb.Tag = Properties.Resources.skin2player;
            }
            using (Image img = Properties.Resources.skin3player)
            {
                skin3playerPtrb.Image = new Bitmap(img);
                skin3playerPtrb.Tag = Properties.Resources.skin3player;
            }
        }
        private void InitGame()
        {
            SetImage();
            currSkin = skin1playerPtrb;
            currSkin.Parent.BackColor = Color.White;
            GameStage.PlayerSkin = currSkin;
            GameStage.MainGamePnl = this.mainGamePnl;
            GameStage.TotalPlayerHealth = totalHealthPtrb;
            GameStage.CurrentPlayerHealth = currentHealthPtrb;
            GameStage.CurrentNumberEnemyContainer = numberEnemyContainerPanel;
            GameStage.CurrentStage = 0;
            GameStage.CurrentStage++;
            GameStage.NextState();
            stageLabel.Text = "STAGE " + GameStage.CurrentStage.ToString();
            
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

        private void renderTimer_Tick(object sender, EventArgs e)
        {
            Render();
            if (GameStage.NumberEnemy == 0|| GameStage.PlayerTank == null)
            {
                statusLabel.Text = "You Win";
                using (Image cupImg = Properties.Resources.cup)
                {
                    cupPtrb.Image = new Bitmap(cupImg);
                }
                countDownTimer.Stop();
                timeTurnScoreLabel.Text = "Time in turn\n\t" + (h * 60 + m * 60 + s).ToString() + "s";
                scoreTurnLabel.Text = "Score in turn\n\t" + ((GameStage.MaxNumberEnemy - GameStage.NumberEnemy) * 10).ToString();
                if (GameStage.CurrentStage != GameStage.TotalScore.Count)
                {
                    GameStage.TotalTime.Add(h * 60 + m * 60 + s);
                    GameStage.TotalScore.Add((GameStage.MaxNumberEnemy - GameStage.NumberEnemy) * 10);
                }
                else
                {
                    GameStage.TotalTime[GameStage.CurrentStage - 1] = h * 60 + m * 60 + s;
                    GameStage.TotalScore[GameStage.CurrentStage - 1] = (GameStage.MaxNumberEnemy - GameStage.NumberEnemy) * 10;
                }
                totalScoreLabel.Text = "Total Score: " + GameStage.TotalScore.Sum().ToString();
                totalTimeLabel.Text = "Total Time: " + GameStage.TotalTime.Sum().ToString() + "s";
                renderTimer.Stop();
                
                renderTimer.Tick -= renderTimer_Tick;
                modalPanel.Visible = true;
                modalPanel.BringToFront();
                nextStagePtrb.Enabled = true;
                homePtrb.Location = new Point(nextStagePtrb.Location.X + 97, nextStagePtrb.Location.Y);
                if (GameStage.PlayerTank == null)
                {
                    statusLabel.Text = "You Lose";
                    using (Image loseImg = Properties.Resources.lose)
                    {
                        cupPtrb.Image = new Bitmap(loseImg);
                    }
                    nextStagePtrb.Enabled = false;
                    homePtrb.Location = nextStagePtrb.Location;
                    homePtrb.BringToFront();
                    GameStage.HealthPlayer = (int)TANK.PLAYER_HEALTH;
                    GameStage.DamagePlayer = 20;
                    GameStage.BulletSpeedPlayer = 100;
                }
            }
            else
            {
                GameStage.HealthPlayer = GameStage.PlayerTank.Health;
                GameStage.DamagePlayer = GameStage.PlayerTank.BulletDamage;
                GameStage.BulletSpeedPlayer = GameStage.PlayerTank.BulletSpeed;
            }
        }

        private void homePtrb_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn về màn hình chính ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                OffTimer();
                EnemySpawner.spawnLocation.Clear();
                Close();
            }
            
        }

        private void exitPtrb_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thoát game ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                OffTimer();
                EnemySpawner.spawnLocation.Clear();
                Close();
                this.Owner.Close();
            }
        }
        private void OffTimer()
        {
            renderTimer.Stop();
            renderTimer.Tick -= EnemyMoveTimer_Tick;
            enemyFireTimer.Stop();
            enemyFireTimer.Tick -= EnemyMoveTimer_Tick;
            enemyMoveTimer.Stop();
            enemyMoveTimer.Tick -= EnemyMoveTimer_Tick;
            countDownTimer.Stop();
            countDownTimer.Tick -= EnemyMoveTimer_Tick;
        }

        private void ChangeSkinTank(object sender, EventArgs e)
        {
            currSkin.Parent.BackColor = SystemColors.ActiveCaptionText;
            currSkin = (sender as PictureBox);
            currSkin.Parent.BackColor = Color.White;
            GameStage.PlayerSkin = currSkin;
            GameStage.PlayerTank?.UpdateAvatar(currSkin.Tag as Image);
        }

        private async void nextStagePtrb_Click(object sender, EventArgs e)
        {
            GameStage.ClearStage();
            GameStage.CurrentStage++;
            if(GameStage.CurrentStage > GameStage.MaxStage)
            {
                GameStage.CurrentStage = GameStage.MaxStage;
            }
            GameStage.NextState();
            stageLabel.Text = "STAGE " + GameStage.CurrentStage.ToString();
            await Task.Delay(2000);
            modalPanel.SendToBack();
            modalPanel.Visible = false;
            SetTimer();
        }

        private async void againPtrb_Click(object sender, EventArgs e)
        {
            OffTimer();
            GameStage.ClearStage();
            GameStage.NextState();
            await Task.Delay(2000);
            modalPanel.SendToBack();
            modalPanel.Visible = false;
            SetTimer();
        }
    }
}
