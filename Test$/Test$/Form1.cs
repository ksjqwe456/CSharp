using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Test_
{
    public partial class Form1 : Form
    {
        MySqlConnection connection =
new MySqlConnection("Server=localhost;Database=member1;Uid=root;Pwd=1234;");


        int C_total = 0;
        string dt;
        int price;



        public Form1()
        {
            InitializeComponent();
        }
        public MySqlConnection Connection { get => connection; set => connection = value; }
        int num = 0;
        int num1 = 0;

        ListViewItem lvi = new ListViewItem(new string[] { });

        public string C_Number { get; private set; }
        public string C_Number2 { get; private set; }
        public string C_aaa { get; private set; }
        public string C_aaa2 { get; private set; }
                               
        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                MessageBox.Show("내용을 입력하세요");
            }
            else
            { 
                num = Int32.Parse(textBox1.Text.ToString());
                C_aaa = textBox2.Text;

                C_total = Convert.ToInt32(C_total) + Convert.ToInt32(num);
                price = price + num;
                //MessageBox.Show(C_total + " " + price);
                String dt = dateTimePicker1.Value.ToShortDateString();
                
                lvi = new ListViewItem(new string[] { textBox1.Text, C_aaa, Convert.ToString(price), dt.ToString() });
                
                lvi.ForeColor = Color.Blue;
                listView1.Items.Add(lvi);

                textBox1.Clear();
                textBox2.Clear();
                //    monthCalendar1.get
                //string insertQuery = "INSERT INTO member_tb(number,text,total,date) VALUES(" + num + ",'" + C_aaa + "'," + C_total + ",'" + dt + "');";
                //  insert into member_tb2 values(0,1000,'dsajkdsja',((select distinct total from member_tb2 a order by idx desc limit 1)+1000), now() );
                //insert into member_tb2 values(0,1000,'dsajkdsja',(select distinct IFNULL(total, 0) +1000 from member_tb2 a order by idx desc limit 1), now());
                //insert into member_tb2 values(0,1000,'dsajkdsja',(select distinct IFNULL(total, 0) +1000 from member_tb2 a order by idx desc limit 1), now());

                //string insertQuery = "INSERT INTO member_tb2 values(0,"+num+",'"+C_aaa+"',(select distinct IFNULL(total, 0) +num from member_tb2 a order by idx desc limit 1)+num), now() );";
                //string insertQuery = "INSERT INTO member_tb2 values(0," + num + ",'" + C_aaa + "',((select distinct total from member_tb2 a order by idx desc limit 1)"+num+"), now() );";


                string insertQuery = "insert into member_tb2 values(0," +num +",'"+ C_aaa +"',(select distinct IFNULL(total, 0)+"+num+" from member_tb2 a order by idx desc limit 1), '"+dt+"','"+log.name+"');";
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                try
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("입력");

                    }
                    else
                    {
                     //   MessageBox.Show("비정상");

                    }


                }
                catch (Exception ex)
                {
                   // MessageBox.Show(ex.Message);
                }
                connection.Close();

            }
            
        }




        private void button2_Click(object sender, EventArgs e)
        {


            if (textBox3.Text.Equals("") || textBox4.Text.Equals(""))
            {
                MessageBox.Show("내용을 입력하세요");
            }
            else
            {
                num = Int32.Parse(textBox3.Text.ToString());
                C_aaa2 = textBox4.Text;
                //MessageBox.Show(C_total + "");

                    C_total = Convert.ToInt32(C_total) - Convert.ToInt32(num);
                    price = price - num;
                
                
                String dt = dateTimePicker2.Value.ToShortDateString();
                //MessageBox.Show(price + " "+C_total);
                lvi = new ListViewItem(new string[] { textBox3.Text, C_aaa2, Convert.ToString(price), dt.ToString() });
                lvi.ForeColor = Color.Red;
                listView1.Items.Add(lvi);

           


                textBox3.Clear();
                textBox4.Clear();
                string insertQuery = "insert into member_tb2 values(0," + num + ",'" + C_aaa2 + "',(select distinct IFNULL(total, 0) -" + num + " from member_tb2 a order by idx desc limit 1), '" + dt + "','"+log.name+"');";
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                try
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("입력");

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
                connection.Close();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int nm;
            string tt = "";
            int to;
            //int itx;
            string de;
            

            try
            {
                MySqlConnection dbcon = new MySqlConnection();
                dbcon.ConnectionString = "Server=localhost;Database=member1;Uid=root;Pwd=1234;";
               String sql = "Select * from member1.member_tb2 where id = '" + log.name+ "';";
              
                dbcon.Open();
                MySqlCommand dbcmd = new MySqlCommand(sql, dbcon);



                MySqlDataReader reader = dbcmd.ExecuteReader();
                int flag = 0;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (flag != 0)
                        {
                            //itx = int.Parse(reader["idx"].ToString());
                            nm = int.Parse(reader["number"].ToString());
                            tt = reader["text"].ToString();
                            to = int.Parse(reader["total"].ToString());
                            de = reader["date"].ToString();
                            
                            lvi = new ListViewItem(new String[] { nm.ToString(), tt, to.ToString(), de });
                            listView1.Items.Add(lvi);
                            
                        }
                        flag += 1;
                        
                        }

                        String s = listView1.Items[listView1.Items.Count-1].SubItems[2].ToString().Split('{')[1];
                        s = s.Split('}')[0];
                       price = int.Parse(s);

                }


                else
                {
                    MessageBox.Show("회원가입을 축하합니다.!");
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '-'))

            {

                e.Handled = true;

            }

        }

        private void tabControl1_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '-'))

            {

                e.Handled = true;

            }
        }



        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dt = dateTimePicker1.Value.ToShortDateString();
            Console.WriteLine(dt);

        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dt = dateTimePicker2.Value.ToShortDateString();
            Console.WriteLine(dt);
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        //삭제
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine(" cheched row 총 수 = {0}", listView1.CheckedItems.Count);
            foreach (ListViewItem item in listView1.CheckedItems)
            {
                Console.WriteLine("삭제되는 checked row index = {0}", item.Index);
                listView1.Items.Remove(item);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(price + "");

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int index = listView1.FocusedItem.Index;
            listView1.Items.RemoveAt(index);
        }
    }
}

                