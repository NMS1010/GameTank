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
            Bound.DrawBound(grp);
            GameStage.State1(6, grp);
            bufferedGraphics.Render();
        }
        private void mainGamePnl_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitGraphics();
        }

    }
}
