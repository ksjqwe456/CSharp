using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_
{
    public partial class intro : Form
    {
        public intro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form log = new log();
            log.Show();
            Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form join = new join();
            join.Show();
            Visible = false;

        }
    }
}
