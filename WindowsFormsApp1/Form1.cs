using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    
   
    public partial class Form1 : Form
    {
        private Byte CurrCMD = 0x00;
        private SerialPort port;
        private Thread threadRCV;
        private List<string> uidList = new List<string>();
        private string[] CurrUID = new string[0];
        private Boolean IsOpen = false;

        String back = null;   //卡号数据
        Boolean t = false;    //判断密码
        Boolean Bor = false;   //判断用户是否存在
        Boolean Borb = false;  //判断借阅
        Boolean up = false;    //判断归还
        string con = "Data Source=DESKTOP-N2IUNJM;Initial Catalog=RFIDBook;Integrated Security=True";  //数据库连接符
        string sql;            //sql语句

        /*
         * 委托函数
         */
        private delegate void AddListCallback(String str);
        private delegate void AddUIDListCallback(List<String> uidList);
        private delegate void AddTagCallback();
        private delegate void setName(string data);



        public Form1()
        {
            InitializeComponent();
        }
     

        private void Form1_Load(object sender, EventArgs e)
        {

            string[] PortNames = SerialPort.GetPortNames();    //获取本机串口名称，存入PortNames数组中

            for (int i = 0; i < PortNames.Count(); i++)

            {

                cbxComPort.Items.Add(PortNames[i]);   //将数组内容加载到comboBox控件中

            }



        }
        //打开串口
        private void btn_port_Click(object sender, EventArgs e)
        {
            if(!IsOpen)
            {
                if(cbxComPort.SelectedIndex < 0)
                {
                    AddList(String.Format("错误：请选要打开的串口！"));
                    cbxComPort.Focus();
                    return;
                }
                if(cbxBaudRate.SelectedIndex < 0)
                {
                    AddList(String.Format("错误：请选择要使用的波特率"));
                    cbxBaudRate.Focus();
                    return;
                }
                String PortName = cbxComPort.Text.Trim();
                Int32 BaudRata = Int32.Parse(cbxBaudRate.Text.Trim());
                try
                {
                    port = new SerialPort(PortName);
                    port.BaudRate = BaudRata;
                    port.DataBits = 8;
                    port.StopBits = StopBits.One;
                    port.Parity = Parity.None;
                    port.Encoding = System.Text.Encoding.ASCII;
                    port.Open();
                    if (port.IsOpen)
                    {
                        AddList(String.Format("串口{0}打开成功", PortName));
                        IsOpen = true;
                        
                        threadRCV = new Thread(new ThreadStart(Receive_15693));
                        threadRCV.IsBackground = true;
                        threadRCV.Start();
                    }
                    else
                    {
                        AddList(String.Format("错误：串口{0}打开失败！", PortName));
                    }
                }
                catch
                {
                    AddList(String.Format("错误：串口{0}打开失败！", PortName));
                }
            }
            else
            {
                AddList(String.Format("错误：串口已经处于打开状态！"));
            }
        }

        /*
         * 15693接收的线程
         */
        private void Receive_15693()
        {
            Byte[] RcvData = new Byte[20];
            while (IsOpen)
            {
                try
                {

                    if (port.BytesToRead > 0)
                    {
                        Thread.Sleep(100);
                        int count = port.Read(RcvData, 0, RcvData.Length);
                        ProcessAFrame(RcvData, count);
                    }

                }
                catch (Exception ex)
                {
                    AddList(String.Format("接收线程出现异常"));
                    IsOpen = false;
                    break;
                }
                Thread.Sleep(10);
            }
            try
            {
                port.Close();
                port = null;
                AddList(String.Format("串口关闭成功！"));
            }
            catch
            { }
        }
        private void ProcessAFrame(byte[] framedata, int count)
        {
                AddList(String.Format("返回：{0}", getHexStr(framedata, 0, count)));
                Int32 DataLength = count;
                Byte ReturnFlag = 0x00;
                if (DataLength > 0)
                {
                    ReturnFlag = framedata[3]; //Convert.ToByte(DataByte.Substring(0, 2), 16);
                }
                //处理数据
                switch (CurrCMD)
                {
                    case 0x01:
                        if (DataLength >= 8)
                        {
                            Byte TagCount = (Byte)(DataLength / 8);
                            uidList.Clear();
                            CurrUID = new String[TagCount];
                            AddList(String.Format("寻卡执行成功，找到了{0}个卡片：", TagCount));
                            for (Byte i = 0; i < TagCount; i++)
                            {

                            //String struid = getHexStr(framedata, 6, 8);
                                String struid = getStr(framedata, 6, 8);
                                back = struid;
                                uidList.Add(struid);
                                CurrUID[i] = struid;
                                AddList(struid);
                                AddUIDList(uidList);
                            }

                        }
                        else
                        {
                            AddList(String.Format("寻卡执行失败！"));
                        }
                        break;
                    case 0x02:  //读取数据块返回
                        if (DataLength >= 8)
                        {
                            AddList(String.Format("读取数据块命令执行成功！"));
                            string str = getHexStr(framedata, 15, 4);
                            AddList(String.Format("读取到的数据为：{0}",str));
                            
                    }
                        else
                        {
                            AddList(String.Format("读取多个数据块命令执行失败！"));
                        }
                        break;
                    case 0x03:  //写数据块返回
                        if(DataLength>=5)
                        {
                            AddList(String.Format("写卡成功！"));
                        }

                        break;
                    case 0x04:
                        if(DataLength >=5)
                        {
                            AddList(String.Format("识别成功!"));
                            string a = getStr(framedata, 15, 1); int aa = Convert.ToInt32(a, 16);
                            string b = getStr(framedata, 16, 1); int bb = Convert.ToInt32(b, 16);
                            string c = getStr(framedata, 17, 1); int cc = Convert.ToInt32(c, 16);
                            string d = getStr(framedata, 18, 1); int dd = Convert.ToInt32(d, 16);
                            string e = String.Format("{0}{1}{2}{3}", aa, bb, cc, dd);

                            AddList(String.Format("用户密码为：{0}",e ));
                            Mi(e);
                            t = Mi(e);
                        


                    }
                    break;

                    default:
                        break;
                }
            
            CurrCMD = 0x00;

        }
        //发送一帧数据
        private void sendAFrame(Byte command, Byte[] data)
        {
            if (!IsOpen)
            {
                AddList(String.Format("错误：请先通过串口连接设备！"));
                return;
            }
            Byte[] frame = new Byte[data.Length + 3];
            frame[0] = 0xff;
            frame[1] = 0xfe;


            for (Int32 i = 0; i < data.Length; i++)
            {
                frame[2 + i] += data[i];
            }
            CalculateCRC(ref frame, 0, data.Length + 2);
            try
            {
                port.Write(frame, 0, frame.Length);
                AddList(String.Format("发送的信息为:{0}", getHexStr(frame, 0, frame.Length)));
                CurrCMD = command;
            }
            catch (Exception ex)
            {
                AddList(String.Format("错误：数据发送异常！错误信息为:{0}", ex.Message));
                IsOpen = false;
            }

        }
        //CalculateCRC
        private void CalculateCRC(ref Byte[] frame, Int32 offset, Int32 datalength)
        {
            int sum = 0;
            for (int i = offset; i < datalength; i++)
            {
                sum += frame[i];
            }
            frame[datalength] = (byte)(sum % 256);
        }

        /*
         *将寻到的卡加入表中 
         */
        private void AddUIDList(List<String> uidList)
        {
            if (comboBox1.InvokeRequired)
            {
                AddUIDListCallback addUIDList = new AddUIDListCallback(AddUIDList);
                this.Invoke(addUIDList, uidList);
            }
            else
            {
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(uidList.ToArray());
                comboBox1.SelectedIndex = 0;
                comboBox4.Items.Clear();
                comboBox4.Items.AddRange(uidList.ToArray());
                comboBox4.SelectedIndex = 0;
                comboBox5.Items.Clear();
                comboBox5.Items.AddRange(uidList.ToArray());
                comboBox5.SelectedIndex = 0;
            }
 
        }
        private void AddList(String str)
        {
            if (listBox1.InvokeRequired)
            {
                AddListCallback d = new AddListCallback(AddList);
                this.Invoke(d, str);
            }
            else
            {
                listBox1.Items.Add(str);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                listBox1.ClearSelected();
            }
    
        }
        /*private void Addname(string data)
        {
            if(comboBox4.InvokeRequired)
            {
                setName d = new setName(Addname);
                comboBox4.Invoke(d, new object[] { data });
            }
            else
            {
                comboBox4.Items.Clear();
                comboBox4.Items.Add(data);
                comboBox4.SelectedIndex = 0;
                comboBox5.Items.Clear();
                comboBox5.Items.Add(data);
                comboBox5.SelectedIndex = 0;
            }
        }*/


        /*
         * byte转十六进制
         */
        private String getHexStr(byte[] bytes, int start, int length)
        {
            StringBuilder str = new StringBuilder();
            for (int i = start; i < length + start; i++)
            {
                str.Append(bytes[i].ToString("X2"));
                str.Append(" ");
            }
            return str.ToString();

        }

        /*
         * 不加空格的数据
         */
        private string getStr(byte[] bytes, int start, int length)
        {
            StringBuilder str = new StringBuilder();
          
            for (int i = start; i < length + start; i++)
            {
                str.Append(bytes[i].ToString("X2"));
            }
            return str.ToString();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (IsOpen)
            {
                IsOpen = false;
                AddList(String.Format("成功关闭串口！"));
            }
            else
            {
                AddList(String.Format("错误：串口已经关闭！"));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!IsOpen)
            {
                AddList(String.Format("错误：请先通过串口连接设备！"));
                return;
            }
            Byte[] data = new Byte[] { 0x03, 0x00, 0x01 };
            sendAFrame(0x01, data);
            CurrCMD = 0x01;
            
        }

        //读卡
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("地址不能为空。");
            }
            else if (uidList.Count < 1)
            {
                AddList("错误：未发现卡片，请先寻卡！");
                return;
            }
            else if (comboBox1.SelectedIndex < 0)
            {
                AddList("错误：请选择您要读取的卡片！");
                comboBox1.Focus();
                return;
            }
            else {
                Byte[] data = new Byte[] { 0x03, 0x01, 0x02, 0x01 };

                data[3] = Byte.Parse(textBox1.Text.Trim());
                sendAFrame(0x02, data);
            }
            

        }

        
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //写卡
        private void button4_Click(object sender, EventArgs e)
        {
            if (text0.Text.Trim() == "" || text1.Text.Trim() == "" || text2.Text.Trim() == "" || text3.Text.Trim() == "")
            {
                MessageBox.Show("数据不能为空");
            }
            else if (uidList.Count < 1)
            {
                AddList("错误：未发现卡片，请先寻卡！");
                return;
            }
            else if (comboBox1.SelectedIndex < 0)
            {
                AddList("错误：请选择您要读取的卡片！");
                comboBox1.Focus();
                return;
            }
            else {
                byte[] data = new byte[] { 0x03, 0x05, 0x03, 0x01, 0x31, 0x32, 0x32, 0x38 };
                data[4] = Byte.Parse(text0.Text.Trim());
                data[5] = Byte.Parse(text1.Text.Trim());
                data[6] = Byte.Parse(text2.Text.Trim());
                data[7] = Byte.Parse(text3.Text.Trim());
                sendAFrame(0x03, data);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        //判断密码是否正确
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("密码不能为空");
            }
            else if (uidList.Count < 1)
            {
                AddList("错误：未发现卡片，请先寻卡！");
                return;
            }
            else if (comboBox1.SelectedIndex < 0)
            {
                AddList("错误：未识别到卡片！");
                comboBox1.Focus();
                return;
            }
            else 
            {
                Byte[] data = new Byte[] { 0x03, 0x01, 0x02, 0x01 };  //固定读取的数据块为01
                sendAFrame(0x02, data);
                CurrCMD = 0x04;
            }

        }

        private Boolean Mi(string da)
        {
            if (da == textBox2.Text)
            {
                MessageBox.Show("输入的密码正确！");
                return true;
            }
            else
            {
                MessageBox.Show("输入的密码不正确");
                return false;
            }
        }


        //用户注册
        private void button11_Click(object sender, EventArgs e)
        {
            Add form2 = new Add();
            form2.Show();
            if (back == null)
            {
                MessageBox.Show("未进行寻卡操作或寻卡失败！！");
            }
            else {
                form2.Card1(back);
            }
            
        }

        //管理员添加书籍
        private void button10_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(con);   //创建连接
            SqlCommand command = new SqlCommand();
            cn.Open();
            command.Connection = cn;
            Book Form3 = new Book();

            if (back == null)
            {
                MessageBox.Show("未进行寻卡操作或寻卡失败！！");
            }
            else
            {
                try
                {
                    sql = "Select * from Root where Card='"+back+"'";
                    command.CommandText = sql;
                    SqlDataReader sdr;
                    sdr = command.ExecuteReader();  //返回结果
                    if (sdr.Read())
                    {
                        Form3.Show();
                    }
                    else
                    {
                        MessageBox.Show("当前用户不是管理员");
                    }
                    cn.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //书籍查询
        private void button8_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            SqlConnection cn = new SqlConnection(con);   //创建连接
            SqlCommand command = new SqlCommand();
            cn.Open();
            command.Connection = cn;
            try
            {
                string a = "未借出";
                sql = "Select * from Book where Borrow='"+a+"'";
                command.CommandText = sql;
                SqlDataReader sdr;
                sdr = command.ExecuteReader();  //返回结果
                while (sdr.Read())
                {
                    string name = sdr.GetString(sdr.GetOrdinal("BookName"));
                    comboBox2.Items.Add(name);           
                }
                cn.Close();
                comboBox2.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(con);   //创建连接
            SqlCommand command = new SqlCommand();
            cn.Open();
            command.Connection = cn;
            if (t)   //判断密码
            {
                if (comboBox2.Text == "")  //判断书籍
                {
                    MessageBox.Show("请选择要借阅的书籍");
                }
                else 
                {                    
                    try
                    {
                        string sql1 = "Select * from Root where Card='" + back + "' union select * from Student where Card1='" + back + "'";
                        command.CommandText = sql1;
                        SqlDataReader d1;
                        d1 = command.ExecuteReader();
                        if (d1.Read())     //判断用户是否存在
                        {
                            Bor = true;
                        }
                        else { MessageBox.Show("当前卡号用户不存在，请先进行注册"); }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    cn.Close();
                    BorrowB();
                }
                
            }
            else { MessageBox.Show("请先点击识别密码是否正确"); }
            
        }

        //添加借阅信息
        private void BorrowB()
        {
            SqlConnection cn = new SqlConnection(con);   //创建连接
            SqlCommand command = new SqlCommand();
            cn.Open();
            command.Connection = cn;
            if (Bor)
            {
                try
                {
                    string sql1 = "Select * from Root where Card='" + back + "' union select * from Student where Card1='" + back + "'";
                    command.CommandText = sql1;
                    string time = DateTime.Now.ToString();
                    try
                    {
                        sql = "Insert Into Borrow(Card,BookName,Time) values(@ID,@BookName,@Time)";

                        command.CommandText = sql;
                        command.Parameters.Add("@ID", SqlDbType.NChar).Value = comboBox4.Text;
                        command.Parameters.Add("@BookName", SqlDbType.NChar).Value = comboBox2.Text;
                        command.Parameters.Add("@Time", SqlDbType.NChar).Value = time;
                        int n = command.ExecuteNonQuery();
                        if (n != 0)
                        {
                            MessageBox.Show("借阅成功");
                            cn.Close();
                            Borb = true;
                            BoorowC();
                        }
                        else
                        {
                            MessageBox.Show("借阅失败");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            
        }
        //更新
        private void BoorowC()
        {
            SqlConnection cn = new SqlConnection(con);   //创建连接
            SqlCommand command = new SqlCommand();
            string one = "已借出";
            cn.Open();
            command.Connection = cn;
            if (Borb)
            {
                try
                {
                    string sql1 = "UPDATE Book SET Borrow = '" + one + "' WHERE BookName='" + comboBox2.Text + "'";
                    command.CommandText = sql1;
                    int n = command.ExecuteNonQuery();
                    if (n != 0)
                    {
                        AddList(String.Format("书籍数据更新成功！"));

                    }
                    else
                    {
                        AddList(String.Format("书籍数据更新失败！"));
                    }
                }
                 catch (Exception ex)
                {
                     MessageBox.Show(ex.Message);
                }

            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            SqlConnection cn = new SqlConnection(con);   //创建连接
            SqlCommand command = new SqlCommand();
            cn.Open();
            command.Connection = cn;
            if (comboBox5.Text != "")
            {
                try
                {
                    string sql1 = "select * from Borrow where Card='" + comboBox5.Text + "'";
                    command.CommandText = sql1;
                    SqlDataReader sdr;
                    sdr = command.ExecuteReader();  //返回结果
                    while (sdr.Read())
                    {
                        string name = sdr.GetString(sdr.GetOrdinal("BookName"));
                        comboBox3.Items.Add(name);
                    }
                    cn.Close();
                    comboBox3.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("卡为空，请先进行寻卡");
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(con);   //创建连接
            SqlCommand command = new SqlCommand();
            cn.Open();
            command.Connection = cn;
            if (comboBox5.Text != "" && comboBox3.Text != "")
            {
                try
                {
                    string sql1 = "delete from Borrow where Card='"+comboBox5.Text+"' And BookName='"+comboBox3.Text+"'";
                    command.CommandText = sql1;
                    int n = command.ExecuteNonQuery();
                    if (n != 0)
                    {
                        AddList(String.Format("删除成功！"));
                        MessageBox.Show("归还成功！");
                        up = true;
                        Update();
                    }
                    else
                    {
                        AddList(String.Format("删除失败！"));
                        MessageBox.Show("归还失败！");
                    }
                    cn.Close();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Update()
        {
            SqlConnection cn = new SqlConnection(con);   //创建连接
            SqlCommand command = new SqlCommand();
            cn.Open();
            command.Connection = cn;
            if (up)
            {
                string sql1 = "UPDATE Book SET Borrow = '未借出' WHERE BookName='" + comboBox3.Text + "'";
                command.CommandText = sql1;
                int n = command.ExecuteNonQuery();
                if (n != 0)
                {
                    AddList(String.Format("更新成功！"));
                }
                else
                {
                    AddList(String.Format("更新失败！"));
                }
                cn.Close();
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Show();
        }
    }
    

}
