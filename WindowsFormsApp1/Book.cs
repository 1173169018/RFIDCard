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
    public partial class Book : Form
    {
        string Con = "Data Source=DESKTOP-N2IUNJM;Initial Catalog=RFIDBook;Integrated Security=True";
        string sql;
        public Book()
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
                sql = "Insert Into Book(ID,BookName,BookAuthor,Borrow) values(@ID,@BookName,@BookAuthor,@Borrow)";
                command.CommandText = sql;
                command.Parameters.Add("@ID", SqlDbType.NChar).Value = textBox1.Text;
                command.Parameters.Add("@BookName", SqlDbType.NChar).Value = textBox2.Text;
                command.Parameters.Add("@BookAuthor", SqlDbType.NChar).Value = textBox3.Text;
                command.Parameters.Add("@Borrow", SqlDbType.NChar).Value = "未借出";
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
    }
}
