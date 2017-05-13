using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsClient
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) => new FormAddUser().ShowDialog();

        private void button2_Click(object sender, EventArgs e) => new FormAddCard().ShowDialog();

        private void button3_Click(object sender, EventArgs e) => new FormPay().ShowDialog();

        private void button4_Click(object sender, EventArgs e) => new FormWriteOff().ShowDialog();

        private void button5_Click(object sender, EventArgs e) => new FormAllUsers().ShowDialog();

        private void button6_Click(object sender, EventArgs e) => new FormFullInfo().ShowDialog();

        private void button7_Click(object sender, EventArgs e) => new FormAllWriteOff().ShowDialog();

        private void button8_Click(object sender, EventArgs e) => new FormSettings().ShowDialog();
    }
}
