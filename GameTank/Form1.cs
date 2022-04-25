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

namespace GameTank
{
    public partial class Form1 : Form
    {
        BufferedGraphics bufferedGraphics;
        BufferedGraphicsContext bufferedGraphicsContext;
        Graphics grp;
        
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
            GameStage.PlayerTank.DrawTank(grp);
            GameStage.PlayerTank.DrawBullets(grp);
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
            }
            Render();
        }
        private void InitGame()
        {
            PlayerTank playerTank = new PlayerTank(new Point(400, 400), isOfPlayer: true);
            GameStage.PlayerTank = playerTank;
            GameStage.MainGamePnl = this.mainGamePnl;
            GameStage.State1();
            
            Timer renderTimer = new Timer();
            renderTimer.Tick += renderTimer_Tick;

            Timer enemyTimer = new Timer();
            enemyTimer.Tick += EnemyTimer_Tick;
            enemyTimer.Interval = 1500;
            enemyTimer.Start(); 
            renderTimer.Start();
        }

        private void EnemyTimer_Tick(object sender, EventArgs e)
        {
            GameStage.EnemyTankStage.ForEach(o => {
                if(!o.LockMove)
                    o.Fire();
            });
            Render();
        }

        private void renderTimer_Tick(object sender, EventArgs e)
        {
            GameStage.EnemyTankStage.ForEach(o => {
                if (!o.LockMove)
                    o.Move((ACTION)Utilities.ChooseEnemyDirection(o));
            });
            Render();
        }

        private void mainGamePnl_Click(object sender, EventArgs e)
        {
            GameStage.PlayerTank.Fire();
        }

        private void mainGamePnl_MouseUp(object sender, MouseEventArgs e)
        {
            
        }
    }
}
