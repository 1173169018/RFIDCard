using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        private void User_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“rFIDBookDataSet3.Borrow”中。您可以根据需要移动或删除它。
            this.borrowTableAdapter.Fill(this.rFIDBookDataSet3.Borrow);
            // TODO: 这行代码将数据加载到表“rFIDBookDataSet2.Book”中。您可以根据需要移动或删除它。
            this.bookTableAdapter.Fill(this.rFIDBookDataSet2.Book);
            // TODO: 这行代码将数据加载到表“rFIDBookDataSet11.Root”中。您可以根据需要移动或删除它。
            this.rootTableAdapter.Fill(this.rFIDBookDataSet11.Root);
            // TODO: 这行代码将数据加载到表“rFIDBookDataSet.Student”中。您可以根据需要移动或删除它。
            this.studentTableAdapter.Fill(this.rFIDBookDataSet.Student);

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.studentTableAdapter.FillBy(this.rFIDBookDataSet.Student);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
