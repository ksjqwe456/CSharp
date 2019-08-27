using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Test_
{
    public partial class log : Form
    {
        
        public static string name, id;
        MySqlConnection connection =
new MySqlConnection("Server=localhost;Database=member1;Uid=root;Pwd=1234;");
        MySqlDataReader rd;



        public log()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form join = new join();
            join.Show();
            Visible = false;
        }

        private void log_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void JoinButton_Click(object sender, EventArgs e)
        {

            string  passwd;
            try
            {
                connection.Open();

                name = NameBox.Text.ToString() ;
                passwd = Pass.Text;
                
                string insertQuery = "select * from login_tb where name = '" + name + "';";
                MySqlCommand command = new MySqlCommand(insertQuery, connection);
                rd = command.ExecuteReader();
              
                if (!rd.Read())
                {
                    MessageBox.Show("회원정보가 존재하지 않습니다.");

                }
                else
                {
                    string NameBox = (string)rd["name"];
                    string Pass = (string)rd["passwd"];

                    if (Pass.Equals(passwd))
                    {
                        
                        MessageBox.Show(name + "님이 접속 하셨습니다.", "로그인 성공");
                        Form Form1 = new Form1();
                        Form1.Show();
                        Visible = false;

                    }
                    else
                    {
                        MessageBox.Show("아이디와 패스워드를 다시 확인해주세요!", "로그인 실패");

                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}