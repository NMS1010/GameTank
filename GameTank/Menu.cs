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
            game.Owner = this;
            Hide();
            game.ShowDialog();
            if(!this.IsDisposed)
                Show();
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đồ án giữa kì môn Lập Trình Windows.\nĐề tài: Game bắn xe tank cổ điển với các chức năng đơn giản\nHọ và tên thành viên:\n" +
                "1. Nguyễn Minh Sơn - 20110713\n2. Nguyễn Đức Thành - 20110307\n3. Mai Bảo Huy -\nGVHD: TS. Lê Văn Vinh", "Thông tin chi tiết", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
