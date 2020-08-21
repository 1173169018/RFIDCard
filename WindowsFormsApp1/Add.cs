using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Add : Form
    {
        string Con = "Data Source=DESKTOP-N2IUNJM;Initial Catalog=RFIDBook;Integrated Security=True";
        string sql;
        public Add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(Con);   //创建连接
            SqlCommand command = new SqlCommand();
            cn.Open();
            command.Connection = cn;
            try
            {
                sql = "Insert Into Student(Card1,Name1) values(@ID,@Name)";
                command.CommandText = sql;
                command.Parameters.Add("@ID", SqlDbType.NChar).Value = comboBox1.Text;
                command.Parameters.Add("@Name", SqlDbType.NChar).Value = textBox1.Text;
                int n = command.ExecuteNonQuery();
                if (n != 0)
                {
                    MessageBox.Show("添加成功");
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
                cn.Close();

            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(Con);   //创建连接
            cn.Open();
            
            try
            {
                sql = "Insert Into Root(Card,Name) values(@ID,@Name)";
                SqlCommand command = new SqlCommand(sql,cn);
                command.CommandText = sql;
                command.Parameters.Add("@ID", SqlDbType.NChar).Value = comboBox1.Text;
                command.Parameters.Add("@Name", SqlDbType.NChar).Value = textBox1.Text;
                int n = command.ExecuteNonQuery();
                if (n != 0)
                {
                    MessageBox.Show("添加成功");
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void Card1(string d)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add(d);
            comboBox1.SelectedIndex = 0;

        }
    }
}
