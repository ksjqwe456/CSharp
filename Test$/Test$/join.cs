using MySql.Data.MySqlClient;
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
    public partial class join : Form
    {
        MySqlConnection connection =
new MySqlConnection("Server=localhost;Database=member1;Uid=root;Pwd=1234;");

        public join()
        {
            InitializeComponent();
        }

        public MySqlConnection Connection { get => connection; set => connection = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            Form log = new log();
            log.Show();
            Visible = false;


            string insertQuery = "INSERT INTO login_tb(name,passwd) VALUES('" + NameBox.Text + "'," + Pass.Text + ")";
            string insertQuery1 = "insert into member_tb2(number, text, total, date, id) values(0, '0', '0', '0','" + log.Name + "');";


            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            try
            {
                if(command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("회원가입 완료");

                }
                else
                {
                    MessageBox.Show("비정상");

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MySqlCommand command1 = new MySqlCommand(insertQuery1, connection);

            try
            {
                if (command1.ExecuteNonQuery() == 1)
                {


                }
                else
                {


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();


        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void Pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '-'))

            {

                e.Handled = true;

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form log = new log();
            log.Show();
            Visible = false;
        }
    }
}
