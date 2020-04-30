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

namespace WindowsFormsApp2
{
    public partial class OrderDetails : Form
    {
        public String No;
        public String OrderNum;
        public String OrderDate;
        public String Customer;
        public String U8Coding;
        public String ProductDes;
        public String PackForm;
        public String ChipVer;
        public String PlanQuantity;
        public String SpareNum;
        public String Project;
        public String DeliveryDate;
        public String Testing;
        public String ProgramVer;
        public String CheckSum;
        public String PrintingType;
        public String LabelType;
        public String Salesperson;
        public String ProjectEng;
        public String Packing;
        public String TubeLabel;
        public String Note2;
        public String OrderStatus;
        public String CompletedNum;
        public String SalesOrderNum;
        public String CustomerCode;
        public String DocumentPath;

        //Order orderold = new Order();
        Order orderold;

        public OrderDetails()
        {
            InitializeComponent();
        }

        private void OrderDetails_Load(object sender, EventArgs e)
        {
            
            textBoxNo.Text = No;
            textBoxOrderNum.Text = OrderNum;
            textBoxOrderDate.Text = OrderDate;
            textBoxCustomer.Text = Customer;
            textBoxU8Coding.Text = U8Coding;
            textBoxProductDes.Text = ProductDes;
            textBoxPackForm.Text = PackForm;
            textBoxChipVer.Text = ChipVer;
            textBoxPlanQuantity.Text = PlanQuantity;
            textBoxSpareNum.Text = SpareNum;
            textBoxProject.Text = Project;
            textBoxDeliveryDate.Text = DeliveryDate;
            textBoxTesting.Text = Testing;
            textBoxProgramVer.Text = ProgramVer;
            textBoxCheckSum.Text =CheckSum;
            textBoxPrintingType.Text = PrintingType;
            textBoxLabelType.Text = LabelType;
            textBoxSalesperson.Text = Salesperson;
            textBoxProjectEng.Text= ProjectEng;
            textBoxPacking.Text = Packing;
            textBoxTubeLabel.Text = TubeLabel;
            textBoxNote2.Text = Note2;
            textBoxOrderStatus.Text = OrderStatus;
            textBoxCompletedNum.Text = CompletedNum;
            textBoxSalesOrderNum.Text = SalesOrderNum;
            textBoxCustomerCode.Text = CustomerCode;
            textBoxDocumentPath.Text = DocumentPath;

            orderold.No = No;
            orderold.OrderNum = OrderNum;
            orderold.OrderDate = OrderDate;
            orderold.Customer = Customer;
            orderold.U8Coding = U8Coding;
            orderold.ProductDes = ProductDes;
            orderold.PackForm = PackForm;
            orderold.ChipVer = ChipVer;
            orderold.PlanQuantity = PlanQuantity;
            orderold.SpareNum = SpareNum;
            orderold.Project = Project;
            orderold.DeliveryDate = DeliveryDate;
            orderold.Testing = Testing;
            orderold.ProgramVer = ProgramVer;
            orderold.CheckSum = CheckSum;
            orderold.PrintingType = PrintingType;
            orderold.LabelType = LabelType;
            orderold.Salesperson = Salesperson;
            orderold.ProjectEng = ProjectEng;
            orderold.Packing = Packing;
            orderold.TubeLabel = TubeLabel;
            orderold.Note2 = Note2;
            orderold.OrderStatus = OrderStatus;
            orderold.CompletedNum = CompletedNum;
            orderold.SalesOrderNum = SalesOrderNum;
            orderold.CustomerCode = CustomerCode;
            orderold.DocumentPath = DocumentPath;
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void OrderDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Order ordernew = new Order();
            Order ordernew;

            ordernew.No = textBoxNo.Text;
            ordernew.OrderNum = textBoxOrderNum.Text;
            ordernew.OrderDate = textBoxOrderDate.Text;
            ordernew.Customer = textBoxCustomer.Text;
            ordernew.U8Coding = textBoxU8Coding.Text;
            ordernew.ProductDes = textBoxProductDes.Text;
            ordernew.PackForm = textBoxPackForm.Text;
            ordernew.ChipVer = textBoxChipVer.Text;
            ordernew.PlanQuantity = textBoxPlanQuantity.Text;
            ordernew.SpareNum = textBoxSpareNum.Text;
            ordernew.Project = textBoxProject.Text;
            ordernew.DeliveryDate = textBoxDeliveryDate.Text;
            ordernew.Testing = textBoxTesting.Text;
            ordernew.ProgramVer = textBoxProgramVer.Text;
            ordernew.CheckSum = textBoxCheckSum.Text;
            ordernew.PrintingType = textBoxPrintingType.Text;
            ordernew.LabelType = textBoxLabelType.Text;
            ordernew.Salesperson = textBoxSalesperson.Text;
            ordernew.ProjectEng = textBoxProjectEng.Text;
            ordernew.Packing = textBoxPacking.Text;
            ordernew.TubeLabel = textBoxTubeLabel.Text;
            ordernew.Note2 = textBoxNote2.Text;
            ordernew.OrderStatus = textBoxOrderStatus.Text;
            ordernew.CompletedNum = textBoxCompletedNum.Text;
            ordernew.SalesOrderNum = textBoxSalesOrderNum.Text;
            ordernew.CustomerCode = textBoxCustomerCode.Text;
            ordernew.DocumentPath = textBoxDocumentPath.Text;

            if (!ordernew.Equals(orderold))
            {
                DialogResult dr = MessageBox.Show("您要保存对此数据的改变吗", "确认", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if (dr == DialogResult.Yes)
                {

                    string connectStr = "server=139.196.226.165;port=3306;database=test;uid=admin;pwd=admin;Charset=utf8";
                    MySqlConnection conn = new MySqlConnection(connectStr);
                    try
                    {
                        conn.Open();    //建立连接，打开数据库

                        //string sqlQuery = "SELECT * FROM OrderList WHERE OrderNum='" + strOrderNum + "'";
                        string sqlUpdate = string.Format(
                            "UPDATE OrderList SET NO={0},OrderDate='{1}',Customer='{2}',U8Coding='{3}',ProductDes='{4}',PackForm='{5}',ChipVer='{6}',PlanQuantity='{7}',SpareNum='{8}',Project='{9}',DeliveryDate='{10}',Testing='{11}',ProgramVer='{12}',CheckSum='{13}',PrintingType='{14}',LabelType='{15}',Salesperson='{16}',ProjectEng='{17}',Packing='{18}',TubeLabel='{19}',Note2='{20}',OrderStatus='{21}',CompletedNum='{22}',SalesOrderNum='{23}',CustomerCode='{24}',DocumentPath='{25}' WHERE OrderNum='{26}'",
                            Convert.ToInt32(ordernew.No),
                            ordernew.OrderDate,
                            ordernew.Customer,
                            ordernew.U8Coding,
                            ordernew.ProductDes,
                            ordernew.PackForm,
                            ordernew.ChipVer,
                            ordernew.PlanQuantity,
                            ordernew.SpareNum,
                            ordernew.Project,
                            ordernew.DeliveryDate,
                            ordernew.Testing,
                            ordernew.ProgramVer,
                            ordernew.CheckSum,
                            ordernew.PrintingType,
                            ordernew.LabelType,
                            ordernew.Salesperson,
                            ordernew.ProjectEng,
                            ordernew.Packing,
                            ordernew.TubeLabel,
                            ordernew.Note2,
                            ordernew.OrderStatus,
                            ordernew.CompletedNum,
                            ordernew.SalesOrderNum,
                            ordernew.CustomerCode,
                            ordernew.DocumentPath,
                            ordernew.OrderNum
                            );
                        //string sqlstr = "SELECT * FROM OrderList";  //选择数据库表
                        MySqlCommand cmd = new MySqlCommand(sqlUpdate, conn);
                        //cmd.ExecuteReader();     //执行一些查询
                        //cmd.ExecuteScalar();     //执行一些查询，返回一个单个的值
                        //cmd.ExecuteNonQuery();   //插入删除

                        //相当于数据读出流  理解为一本书
                        MySqlDataReader reader = cmd.ExecuteReader();

                        //reader.Read();  //读取下一页数据 ，读取成功，返回true，下一页没有数据则返回false表示到了最后一页

                        reader.Read();


                        
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
            
        }
    }
}
