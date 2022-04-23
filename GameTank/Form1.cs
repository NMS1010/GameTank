using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        PlayerTank playerTank;
        STAGE currState;
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
            bufferedGraphics.Graphics.Clear(Color.Black);
            playerTank.DrawTank(grp);
            playerTank.DrawBullets(grp);
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
                    playerTank.Move(ACTION.UP);
                    break;
                case Keys.Down:
                    playerTank.Move(ACTION.DOWN);
                    break;
                case Keys.Left:
                    playerTank.Move(ACTION.LEFT);
                    break;
                case Keys.Right:
                    playerTank.Move(ACTION.RIGHT);
                    break;
            }
            Render();
        }
        private void InitGame()
        {
            currState = STAGE.STAGE1;
            playerTank= new PlayerTank(new Point(400, 400), currState);
            GameStage.MainGamePnl = this.mainGamePnl;
            GameStage.State1(grp);
            Bound.DrawBound();
        }

        private void bulletTimer_Tick(object sender, EventArgs e)
        {
            Render();
        }

        private void mainGamePnl_Click(object sender, EventArgs e)
        {
            playerTank.Fire();
            bulletTimer.Tick += bulletTimer_Tick;
            bulletTimer.Start();
        }

        private void mainGamePnl_MouseUp(object sender, MouseEventArgs e)
        {
            
        }
    }
}
