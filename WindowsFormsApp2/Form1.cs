using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private int i = 0;
        public Form1()
        {
            InitializeComponent();
            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = 100;
            toolStripProgressBar1.Step = 1;

        }
        /// <summary>
        /// 去除toolStript控件下面的白色细线，采用重绘的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip1_Paint(object sender, PaintEventArgs e)
        {
            if ((sender as ToolStrip).RenderMode == ToolStripRenderMode.System)
            {
                Rectangle rect = new Rectangle(0, 0, this.toolStrip1.Width, this.toolStrip1.Height - 3);
                e.Graphics.SetClip(rect);
            }
        }

        private void toolStrip2_Paint(object sender, PaintEventArgs e)
        {
            if ((sender as ToolStrip).RenderMode == ToolStripRenderMode.System)
            {
                Rectangle rect = new Rectangle(0, 0, this.toolStrip2.Width, this.toolStrip2.Height - 1);
                e.Graphics.SetClip(rect);
            }
        }

        private void toolStripButtonConnectionMysql_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string connectStr = "server=139.196.226.165;port=3306;database=test;user=admin;password=admin";
            MySqlConnection conn = new MySqlConnection(connectStr);
            try
            {
                conn.Open();    //建立连接，打开数据库

                string sqlcmd = "SELECT COUNT(*) FROM OrderList";   //获取数据库中有多少条数据
                MySqlCommand QueryCMD = new MySqlCommand(sqlcmd, conn);
                //int RowNum = Convert.ToInt32(QueryCMD.ExecuteScalar());
                toolStripProgressBar1.Maximum = Convert.ToInt32(QueryCMD.ExecuteScalar());

                string sqlstr = "SELECT * FROM OrderList";  //选择数据库表
                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);
                /* cmd.ExecuteReader();     //执行一些查询
                   cmd.ExecuteScalar();     //执行一些查询，返回一个单个的值
                   cmd.ExecuteNonQuery();   //插入删除   */

                toolStripProgressBar1.Value = 0;
                                
                //相当于数据读出流  理解为一本书
                MySqlDataReader reader = cmd.ExecuteReader();
                

                //reader.Read();  //读取下一页数据 ，读取成功，返回true，下一页没有数据则返回false表示到了最后一页
                while (reader.Read())   //遍历表中的数据
                {
                    //reader.Read();  //读数据并打印
                    //索引是一行有几个数据
                    //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString() + reader[3].ToString());
                    //还可以使用Getxxx方式去写 参数（索引）
                    //Console.WriteLine(reader.GetInt32(0) + reader.GetString(1) + reader.GetString(2));
                    //Getxxx方法的重载  参数(列名)
                    //Console.WriteLine(reader.GetInt32("NO") + reader.GetString("OrderNum") + reader.GetString("OrderDate"));

                    this.listView1.BeginUpdate();

                    ListViewItem item = new ListViewItem();
                    item.SubItems.Clear();
                    item.SubItems[0].Text = reader.GetInt32("NO").ToString();
                    item.SubItems.Add(reader.GetString("OrderNum"));
                    item.SubItems.Add(reader.GetString("OrderDate"));
                    item.SubItems.Add(reader.GetString("Customer"));
                    item.SubItems.Add(reader.GetString("U8Coding"));
                    item.SubItems.Add(reader.GetString("ProductDes"));
                    item.SubItems.Add(reader.GetString("PackForm"));
                    item.SubItems.Add(reader.GetString("ChipVer"));
                    item.SubItems.Add(reader.GetString("PlanQuantity"));
                    item.SubItems.Add(reader.GetString("SpareNum"));
                    item.SubItems.Add(reader.GetString("Project"));
                    item.SubItems.Add(reader.GetString("DeliveryDate"));
                    item.SubItems.Add(reader.GetString("Testing"));
                    item.SubItems.Add(reader.GetString("ProgramVer"));
                    item.SubItems.Add(reader.GetString("CheckSum"));
                    item.SubItems.Add(reader.GetString("PrintingType"));
                    item.SubItems.Add(reader.GetString("LabelType"));
                    item.SubItems.Add(reader.GetString("Salesperson"));
                    item.SubItems.Add(reader.GetString("ProjectEng"));
                    item.SubItems.Add(reader.GetString("Packing"));
                    item.SubItems.Add(reader.GetString("TubeLabel"));
                    item.SubItems.Add(reader.GetString("Note2"));
                    item.SubItems.Add(reader.GetString("OrderStatus"));
                    item.SubItems.Add(reader.GetString("CompletedNum"));
                    item.SubItems.Add(reader.GetString("SalesOrderNum"));
                    item.SubItems.Add(reader.GetString("CustomerCode"));

                    listView1.Items.Add(item);

                    toolStripProgressBar1.PerformStep();

                    this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。
                }
                this.listView1.Items[this.listView1.Items.Count - 1].EnsureVisible();   //竖直滚动条拉到最下面

                toolStripStatusLabel4.Text = "第  1  页";
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            finally
            {
                conn.Close();   //关闭数据库连接
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TreeNode treeNoderoot1 = this.treeView1.Nodes.Add("一月份订单");
            for (int i = 1; i < 32; i++)
            {
                treeNoderoot1.Nodes.Add(i.ToString() + "号订单");
            }

            TreeNode treeNoderoot2 = this.treeView1.Nodes.Add("二月份订单");
            for (int i = 1; i < 32; i++)
            {
                treeNoderoot2.Nodes.Add(i.ToString() + "号订单");
            }

            TreeNode treeNoderoot3 = this.treeView1.Nodes.Add("三月份订单");
            for (int i = 1; i < 32; i++)
            {
                treeNoderoot3.Nodes.Add(i.ToString() + "号订单");
            }

            TreeNode treeNoderoot4 = this.treeView1.Nodes.Add("四月份订单");
            for (int i = 1; i < 32; i++)
            {
                treeNoderoot4.Nodes.Add(i.ToString() + "号订单");
            }

            TreeNode treeNoderoot5 = this.treeView1.Nodes.Add("五月份订单");
            for (int i = 1; i < 32; i++)
            {
                treeNoderoot5.Nodes.Add(i.ToString() + "号订单");
            }

            TreeNode treeNoderoot6 = this.treeView1.Nodes.Add("六月份订单");
            for (int i = 1; i < 32; i++)
            {
                treeNoderoot6.Nodes.Add(i.ToString() + "号订单");
            }

            TreeNode treeNoderoot7 = this.treeView1.Nodes.Add("七月份订单");
            for (int i = 1; i < 32; i++)
            {
                treeNoderoot7.Nodes.Add(i.ToString() + "号订单");
            }

            TreeNode treeNoderoot8 = this.treeView1.Nodes.Add("八月份订单");
            for (int i = 1; i < 32; i++)
            {
                treeNoderoot8.Nodes.Add(i.ToString() + "号订单");
            }

            TreeNode treeNoderoot9 = this.treeView1.Nodes.Add("九月份订单");
            for (int i = 1; i < 32; i++)
            {
                treeNoderoot9.Nodes.Add(i.ToString() + "号订单");
            }

            TreeNode treeNoderoot10 = this.treeView1.Nodes.Add("十月份订单");
            for (int i = 1; i < 32; i++)
            {
                treeNoderoot10.Nodes.Add(i.ToString() + "号订单");
            }

            TreeNode treeNoderoot11 = this.treeView1.Nodes.Add("十一月份订单");
            for (int i = 1; i < 32; i++)
            {
                treeNoderoot11.Nodes.Add(i.ToString() + "号订单");
            }

            TreeNode treeNoderoot12 = this.treeView1.Nodes.Add("十二月份订单");
            for (int i = 1; i < 32; i++)
            {
                treeNoderoot12.Nodes.Add(i.ToString() + "号订单");
            }

            treeView1.SelectedNode = null;

            this.listView1.GridLines = true;    //表格是否显示网格线
            this.listView1.FullRowSelect = true;    //是否选中整行
            this.listView1.View = View.Details;     //设置显示方式
            this.listView1.Scrollable = true;   //是否自动显示滚动条
            this.listView1.MultiSelect = false; //是否选中多行

            this.listView1.Columns.Add("#", 40, HorizontalAlignment.Center);
            this.listView1.Columns.Add("订单编号", 60, HorizontalAlignment.Center);
            this.listView1.Columns.Add("订单日期", 80, HorizontalAlignment.Center);
            this.listView1.Columns.Add("业务伙伴名称", 150, HorizontalAlignment.Center);
            this.listView1.Columns.Add("U8物料编码", 120, HorizontalAlignment.Center);
            this.listView1.Columns.Add("产品描述", 160, HorizontalAlignment.Center);
            this.listView1.Columns.Add("封装形式", 60, HorizontalAlignment.Center);
            this.listView1.Columns.Add("芯片版本", 60, HorizontalAlignment.Center);
            this.listView1.Columns.Add("计划数量", 80, HorizontalAlignment.Center);
            this.listView1.Columns.Add("备品数", 60, HorizontalAlignment.Center);
            this.listView1.Columns.Add("项目编号/  客户编码", 180, HorizontalAlignment.Center);
            this.listView1.Columns.Add("交货日期", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("测试", 40, HorizontalAlignment.Center);
            this.listView1.Columns.Add("程序版本", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("校验和", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("印字种类", 160, HorizontalAlignment.Center);
            this.listView1.Columns.Add("外盒标签", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("销售员姓名", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("工程师", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("包装形式", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("料管标签", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("备注2", 300, HorizontalAlignment.Center);
            this.listView1.Columns.Add("生产订单状态", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("完成数量", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("销售单号", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("客户代码", 100, HorizontalAlignment.Center);

            this.listView1.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度

            //for (int i = 0; i < 10; i++)   //添加10行数据
            //{
            //    ListViewItem lvi = new ListViewItem();

            //    //lvi.ImageIndex = i;     //通过与imageList绑定，显示imageList中第i项图标

            //    lvi.Text = "subitem" + i;

            //    lvi.SubItems.Add("第2列,第" + i + "行");

            //    lvi.SubItems.Add("第3列,第" + i + "行");

            //    this.listView1.Items.Add(lvi);
            //}

            //添加表格内容

            //for (int i = 0; i < 6; i++)
            //{
            //    ListViewItem item = new ListViewItem();
            //    item.SubItems.Clear();
            //    item.SubItems[0].Text = "产品" + i.ToString();
            //    item.SubItems.Add(i.ToString());
            //    item.SubItems.Add((i + 7).ToString());
            //    item.SubItems.Add((i * i).ToString());
            //    listView1.Items.Add(item);
            //}


            this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。

            this.listView1.ContextMenuStrip = contextMenuStrip1;

            this.toolStripStatusLabel1.Text = System.DateTime.Now.ToString();
            timer1.Interval = 1000;
            timer1.Start();
            timer2.Start();
        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.listView1.FocusedItem != null)//这个if必须的，不然会得到值但会报错
                {
                    //MessageBox.Show(this.listView1.FocusedItem.SubItems[0].Text);
                    //this.textBox1.Text = this.listView1.FocusedItem.SubItems[0].Text;//获得的listView的值显示在文本框里
                    //this.listView1.FocusedItem.SubItems[0].Text;
                    OrderDetails form = new OrderDetails
                    {
                        No = this.listView1.FocusedItem.SubItems[0].Text,
                        OrderNum = this.listView1.FocusedItem.SubItems[1].Text,
                        OrderDate = this.listView1.FocusedItem.SubItems[2].Text,
                        Customer = this.listView1.FocusedItem.SubItems[3].Text,
                        U8Coding = this.listView1.FocusedItem.SubItems[4].Text,
                        ProductDes = this.listView1.FocusedItem.SubItems[5].Text,
                        PackForm = this.listView1.FocusedItem.SubItems[6].Text,
                        ChipVer = this.listView1.FocusedItem.SubItems[7].Text,
                        PlanQuantity = this.listView1.FocusedItem.SubItems[8].Text,
                        SpareNum = this.listView1.FocusedItem.SubItems[9].Text,
                        Project = this.listView1.FocusedItem.SubItems[10].Text,
                        DeliveryDate = this.listView1.FocusedItem.SubItems[11].Text,
                        Testing = this.listView1.FocusedItem.SubItems[12].Text,
                        ProgramVer = this.listView1.FocusedItem.SubItems[13].Text,
                        CheckSum = this.listView1.FocusedItem.SubItems[14].Text,
                        PrintingType = this.listView1.FocusedItem.SubItems[15].Text,
                        LabelType = this.listView1.FocusedItem.SubItems[16].Text,
                        Salesperson = this.listView1.FocusedItem.SubItems[17].Text,
                        ProjectEng = this.listView1.FocusedItem.SubItems[18].Text,
                        Packing = this.listView1.FocusedItem.SubItems[19].Text,
                        TubeLabel = this.listView1.FocusedItem.SubItems[20].Text,
                        Note2 = this.listView1.FocusedItem.SubItems[21].Text,
                        OrderStatus = this.listView1.FocusedItem.SubItems[22].Text,
                        CompletedNum = this.listView1.FocusedItem.SubItems[23].Text,
                        SalesOrderNum = this.listView1.FocusedItem.SubItems[24].Text,
                        CustomerCode = this.listView1.FocusedItem.SubItems[25].Text
                    };
                    form.ShowDialog(this);
                    toolStripButton1.PerformClick();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = System.DateTime.Now.ToString();
        }

        public void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(listView1.FocusedItem != null)
            {
                //int row = listView1.FocusedItem.Index;
                //string str = row.ToString();
                string strOrderNum = listView1.FocusedItem.SubItems[1].Text;

                string connectStr = "server=139.196.226.165;port=3306;database=test;user=admin;password=admin";
                MySqlConnection conn = new MySqlConnection(connectStr);
                try
                {
                    conn.Open();    //建立连接，打开数据库

                    //string sqlcmd = "SELECT COUNT(*) FROM OrderList";   //获取数据库中有多少条数据
                    //MySqlCommand QueryCMD = new MySqlCommand(sqlcmd, conn);
                    ////int RowNum = Convert.ToInt32(QueryCMD.ExecuteScalar());
                    //toolStripProgressBar1.Maximum = Convert.ToInt32(QueryCMD.ExecuteScalar());
                    string sqlQuery = "SELECT * FROM OrderList WHERE OrderNum='"+ strOrderNum + "'";
                    //string sqlstr = "SELECT * FROM OrderList";  //选择数据库表
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                    //cmd.ExecuteReader();     //执行一些查询
                    //cmd.ExecuteScalar();     //执行一些查询，返回一个单个的值
                    //cmd.ExecuteNonQuery();   //插入删除

                    //相当于数据读出流  理解为一本书
                    MySqlDataReader reader = cmd.ExecuteReader();

                    //reader.Read();  //读取下一页数据 ，读取成功，返回true，下一页没有数据则返回false表示到了最后一页

                    reader.Read();
                    listView1.SelectedItems[0].SubItems[0].Text = reader.GetInt32("No").ToString();
                    listView1.SelectedItems[0].SubItems[1].Text = reader.GetString("OrderNum");
                    listView1.SelectedItems[0].SubItems[2].Text = reader.GetString("OrderDate");
                    listView1.SelectedItems[0].SubItems[3].Text = reader.GetString("Customer");
                    listView1.SelectedItems[0].SubItems[4].Text = reader.GetString("U8Coding");
                    listView1.SelectedItems[0].SubItems[5].Text = reader.GetString("ProductDes");
                    listView1.SelectedItems[0].SubItems[6].Text = reader.GetString("PackForm");
                    listView1.SelectedItems[0].SubItems[7].Text = reader.GetString("ChipVer");
                    listView1.SelectedItems[0].SubItems[8].Text = reader.GetString("PlanQuantity");
                    listView1.SelectedItems[0].SubItems[9].Text = reader.GetString("SpareNum");
                    listView1.SelectedItems[0].SubItems[10].Text = reader.GetString("Project");
                    listView1.SelectedItems[0].SubItems[11].Text = reader.GetString("DeliveryDate");
                    listView1.SelectedItems[0].SubItems[12].Text = reader.GetString("Testing");
                    listView1.SelectedItems[0].SubItems[13].Text = reader.GetString("ProgramVer");
                    listView1.SelectedItems[0].SubItems[14].Text = reader.GetString("CheckSum");
                    listView1.SelectedItems[0].SubItems[15].Text = reader.GetString("PrintingType");
                    listView1.SelectedItems[0].SubItems[16].Text = reader.GetString("LabelType");
                    listView1.SelectedItems[0].SubItems[17].Text = reader.GetString("Salesperson");
                    listView1.SelectedItems[0].SubItems[18].Text = reader.GetString("ProjectEng");
                    listView1.SelectedItems[0].SubItems[19].Text = reader.GetString("Packing");
                    listView1.SelectedItems[0].SubItems[20].Text = reader.GetString("TubeLabel");
                    listView1.SelectedItems[0].SubItems[21].Text = reader.GetString("Note2");
                    listView1.SelectedItems[0].SubItems[22].Text = reader.GetString("OrderStatus");
                    listView1.SelectedItems[0].SubItems[23].Text = reader.GetString("CompletedNum");
                    listView1.SelectedItems[0].SubItems[24].Text = reader.GetString("SalesOrderNum");
                    listView1.SelectedItems[0].SubItems[25].Text = reader.GetString("CustomerCode");

                    //while (reader.Read())   //遍历表中的数据
                    //{
                    //    //reader.Read();  //读数据并打印
                    //    //索引是一行有几个数据
                    //    //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString() + reader[3].ToString());
                    //    //还可以使用Getxxx方式去写 参数（索引）
                    //    //Console.WriteLine(reader.GetInt32(0) + reader.GetString(1) + reader.GetString(2));
                    //    //Getxxx方法的重载  参数(列名)
                    //    //Console.WriteLine(reader.GetInt32("NO") + reader.GetString("OrderNum") + reader.GetString("OrderDate"));

                    //    this.listView1.BeginUpdate();

                    //    ListViewItem item = new ListViewItem();
                    //    item.SubItems.Clear();
                    //    item.SubItems[0].Text = reader.GetInt32("NO").ToString();
                    //    item.SubItems.Add(reader.GetString("OrderNum"));
                    //    item.SubItems.Add(reader.GetString("OrderDate"));
                    //    item.SubItems.Add(reader.GetString("Customer"));
                    //    item.SubItems.Add(reader.GetString("U8Coding"));
                    //    item.SubItems.Add(reader.GetString("ProductDes"));
                    //    item.SubItems.Add(reader.GetString("PackForm"));
                    //    item.SubItems.Add(reader.GetString("ChipVer"));
                    //    item.SubItems.Add(reader.GetString("PlanQuantity"));
                    //    item.SubItems.Add(reader.GetString("SpareNum"));
                    //    item.SubItems.Add(reader.GetString("Project"));
                    //    item.SubItems.Add(reader.GetString("DeliveryDate"));
                    //    item.SubItems.Add(reader.GetString("Testing"));
                    //    item.SubItems.Add(reader.GetString("ProgramVer"));
                    //    item.SubItems.Add(reader.GetString("CheckSum"));
                    //    item.SubItems.Add(reader.GetString("PrintingType"));
                    //    item.SubItems.Add(reader.GetString("LabelType"));
                    //    item.SubItems.Add(reader.GetString("Salesperson"));
                    //    item.SubItems.Add(reader.GetString("ProjectEng"));
                    //    item.SubItems.Add(reader.GetString("Packing"));
                    //    item.SubItems.Add(reader.GetString("TubeLabel"));
                    //    item.SubItems.Add(reader.GetString("Note2"));
                    //    item.SubItems.Add(reader.GetString("OrderStatus"));
                    //    item.SubItems.Add(reader.GetString("CompletedNum"));
                    //    item.SubItems.Add(reader.GetString("SalesOrderNum"));
                    //    item.SubItems.Add(reader.GetString("CustomerCode"));

                    //    listView1.Items.Add(item);

                    //    toolStripProgressBar1.PerformStep();

                    //    this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。
                    //}
                    //this.listView1.Items[this.listView1.Items.Count - 1].EnsureVisible();   //竖直滚动条拉到最下面

                    //toolStripStatusLabel4.Text = "第  1  页";
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                finally
                {
                    conn.Close();   //关闭数据库连接
                }

            }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            i++;
            if (i > 5)
            {
                i = 0;
            }
            //toolStripStatusLabel7.Image = imageList1.Images[i++];
            if(i == 0)
            {
                toolStripStatusLabel7.Image = WindowsFormsApp2.Properties.Resources.Internet_download;
                toolStripStatusLabel7.Text = GetLocalIP();
            }
            if (i == 1)
            {
                toolStripStatusLabel7.Image = WindowsFormsApp2.Properties.Resources.Internet_grey_download;
                toolStripStatusLabel7.Text = GetLocalIP();
            }
            if (i == 2)
            {
                toolStripStatusLabel7.Image = WindowsFormsApp2.Properties.Resources.Internet_update;
                toolStripStatusLabel7.Text = GetLocalIP();
            }
            if (i == 3)
            {
                toolStripStatusLabel7.Image = WindowsFormsApp2.Properties.Resources.Internet_grey_update;
                toolStripStatusLabel7.Text = "139.196.226.165";
            }
            if (i == 4)
            {
                toolStripStatusLabel7.Image = WindowsFormsApp2.Properties.Resources.Internet_upload;
                toolStripStatusLabel7.Text = "139.196.226.165";
            }
            if (i == 5)
            {
                toolStripStatusLabel7.Image = WindowsFormsApp2.Properties.Resources.Internet_grey_upload;
                toolStripStatusLabel7.Text = "139.196.226.165";
            }

        }

        public static string GetLocalIP()
        {
            try
            {
                string HostName = Dns.GetHostName(); //得到主机名
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                for (int i = 0; i < IpEntry.AddressList.Length; i++)
                {
                    //从IP地址列表中筛选出IPv4类型的IP地址
                    //AddressFamily.InterNetwork表示此IP为IPv4,
                    //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                    if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        return IpEntry.AddressList[i].ToString();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取本机IP出错:" + ex.Message);
                return "";
            }
        }
    }
}
