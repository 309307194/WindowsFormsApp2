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
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
