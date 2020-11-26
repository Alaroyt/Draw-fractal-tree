using System;
using System.Windows.Forms;

namespace Draw_bin_tree
{
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (doRandom) { textBox1.Text = "0"; textBox2.Text = "100"; }
                mainForm fpaw = new mainForm(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), doRandom);
                fpaw.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        bool doRandom = false;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                doRandom = true;
            }
            else
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                doRandom = false;
            }
        }
    }
}
