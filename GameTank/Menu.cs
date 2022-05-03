using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameTank
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            Game game = new Game();
            Hide();
            game.ShowDialog();
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {

        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
