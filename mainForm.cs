using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System;

namespace Draw_bin_tree
{
    public partial class mainForm : Form
    {

        public mainForm()
        {
            InitializeComponent();
        }

        private void board_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Point temp = PointToClient(Cursor.Position);
            Graphics g = board.CreateGraphics();

            Tree tree = new Tree(temp,g);

            Thread t = new Thread(new ThreadStart(tree.DrawTree));

            t.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            board.Refresh();
        }
    }
}
