using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System;

namespace Draw_bin_tree
{
    public partial class mainForm : Form
    {
        public mainForm(int angle, int length, bool doRandom)
        {
            InitializeComponent();
            _angle = angle; _length = length;
            _doRandom = doRandom;
        }
        int _angle;
        int _length;
        bool _doRandom;

        private void board_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Point temp = PointToClient(Cursor.Position);
            Graphics g = board.CreateGraphics();

            Tree tree = new Tree(temp, _angle, _length, g, _doRandom);

            Thread t = new Thread(new ThreadStart(tree.DrawTree));

            t.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            board.Refresh();
        }
    }
}
