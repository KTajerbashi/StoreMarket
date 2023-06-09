﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BEE;
using BLL;

namespace StoreMarket_V1
{
    public partial class SellFactor : UserControl
    {
        public SellFactor()
        {
            InitializeComponent();
        }
        Functions Fun = new Functions();
        BLLCode blc = new BLLCode();
        AAdmin AdminA = new AAdmin();
        BAdmin AdminB = new BAdmin();
        int ID1 = 0, ID2 = 0, counter1 = 1, counter2 = 1, NO1 = 0, NO2 = 0;
        #region Function
        public void GetFactorNumber()
        {
            if (AdminNumber.Text=="1")
            {
                FactorNumber.Text = blc.GetLastSellFactorNumberA().ToString();
            }
            else
            {
                FactorNumber.Text = blc.GetLastSellFactorNumberB().ToString();
            }
        }
        public void GetFactorCode()
        {
            if (AdminNumber.Text == "1")
            {
                FactorCode.Text = blc.GetLastSellFactorCodeA().ToString();
            }
            else
            {
                FactorCode.Text = blc.GetLastSellFactorCodeB().ToString();
            }
        }
        public void GetAdminFullName()
        {
            if (AdminNumber.Text=="1")
            {
                AdminA = blc.GetAdminsA().Where(c => c.Username == AdminName.Text).FirstOrDefault();
                ADMINNAMESHOW.Text = AdminA.FullName;
            }
            else
            {
                AdminB = blc.GetAdminsB().Where(c => c.Username == AdminName.Text).FirstOrDefault();
                ADMINNAMESHOW.Text = AdminB.FullName;
            }
        }
        public void AddProductToDGV2(int ID)
        {
            if (AdminNumber.Text == "1")
            {
                AProduct Product = blc.GetProductA(ID);
                if (Product == null)
                {
                    ResultText2.Text = "محصول را انتخاب کنید";
                }
                else if (Product.Mojodi>0)
                {
                    DGV2.Rows.Add(Product.id, counter2, Product.Name, Product.Type, Product.Brand, Product.sellPrice.ToString("#,0"), 0, 000);
                }
                else
                {
                    ResultText2.Text = "موجود در انبار کافی نیست";
                }
            }
            else
            {
                BProduct Product = blc.GetProductB(ID);
                if (Product == null)
                {
                    ResultText2.Text = "محصول را انتخاب کنید";
                }
                else if(Product.Mojodi > 0)
                {
                    DGV2.Rows.Add(Product.id, counter2, Product.Name, Product.Type, Product.Brand, Product.sellPrice.ToString("#,0"), 0, 000);
                }
                else
                {
                    ResultText2.Text = "موجود در انبار کافی نیست";
                }
            }
            NO2 = counter2;
            counter2++;
        }

        #endregion
        
        #region CodeMouse
        private void Okay_MouseEnter(object sender, EventArgs e)
        {
            Okay.TextColor = Color.Black;
        }

        private void Okay_MouseLeave(object sender, EventArgs e)
        {
            Okay.TextColor = Color.White;
        }

        private void Searchbtn_MouseEnter(object sender, EventArgs e)
        {
            Searchbtn.TextColor = Color.Black;

        }

        private void Searchbtn_MouseLeave(object sender, EventArgs e)
        {
            Searchbtn.TextColor = Color.White;

        }

        private void Addbtn_MouseEnter(object sender, EventArgs e)
        {
            Addbtn.TextColor = Color.Black;

        }

        private void Addbtn_MouseLeave(object sender, EventArgs e)
        {
            Addbtn.TextColor = Color.White;

        }

        private void Deletebtn_MouseEnter(object sender, EventArgs e)
        {
            Deletebtn.TextColor = Color.Black;

        }

        private void Deletebtn_MouseLeave(object sender, EventArgs e)
        {
            Deletebtn.TextColor = Color.White;

        }

        private void CloseFactor_MouseEnter(object sender, EventArgs e)
        {
            CloseFactor.TextColor = Color.Black;

        }

        private void CloseFactor_MouseLeave(object sender, EventArgs e)
        {
            CloseFactor.TextColor = Color.White;

        }

        private void OpenFactor_MouseEnter(object sender, EventArgs e)
        {
            OpenFactor.TextColor = Color.Black;

        }

        private void OpenFactor_MouseLeave(object sender, EventArgs e)
        {
            OpenFactor.TextColor = Color.White;

        }

        private void AcceptFactor_MouseEnter(object sender, EventArgs e)
        {
            AcceptFactor.TextColor = Color.Black;

        }

        private void AcceptFactor_MouseLeave(object sender, EventArgs e)
        {
            AcceptFactor.TextColor = Color.White;

        }

        private void SaveFactor_MouseEnter(object sender, EventArgs e)
        {
            SaveFactor.TextColor = Color.Black;

        }

        private void SaveFactor_MouseLeave(object sender, EventArgs e)
        {
            SaveFactor.TextColor = Color.White;

        }
        #endregion

        private void FactorCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void SellFactor_Load(object sender, EventArgs e)
        {
            //  زمان آپلود شدن فرم
            GetAdminFullName();
            GetFactorNumber();
            GetFactorCode();
            DayDate.Text = Fun.CLOCK();
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            NO1 = 1;
            NO2 = 1;
        }

        private void Searchbtn_Click(object sender, EventArgs e)
        {
            if (AdminNumber.Text=="1")
            {
                DGV1.Rows.Clear();
                var DB = blc.GetProductsA().Where(c => c.Name.Contains(Search.Text)).OrderBy(i => i.ExpireDate);
                foreach (var item in DB)
                {
                    DGV1.Rows.Add(item.id, counter1, item.Name, item.Type, item.Brand, item.ExpireDate, item.sellPrice.ToString("#,0"), item.Mojodi);
                    counter1++;
                }
            }
            else
            {
                DGV1.Rows.Clear();
                var DB = blc.GetProductsB().Where(c => c.Name.Contains(Search.Text)).OrderBy(i => i.ExpireDate);
                foreach (var item in DB)
                {
                    DGV1.Rows.Add(item.id, counter1, item.Name, item.Type, item.Brand, item.ExpireDate, item.sellPrice.ToString("#,0"), item.Mojodi);
                    counter1++;
                }
            }
        }

        private void Okay_Click(object sender, EventArgs e)
        {
            if (CustomerName.Text.Trim().Length==0)
            {
                ResultStatus.Text = "نام مشتری را وارد کنید";
                CustomerName.Focus();
            }
            else if (PhoneNumber.Text.Trim().Length == 0)
            {
                ResultStatus.Text = "تلفن مشتری را وارد کنید";
                PhoneNumber.Focus();

            }
            else if (FactorNumber.Text.Trim().Length == 0)
            {
                ResultStatus.Text = "شماره فاکتور را وارد کنید";
                FactorNumber.Focus();

            }
            else if (FactorCode.Text.Trim().Length == 0)
            {
                ResultStatus.Text = "کد فاکتور را وارد کنید";
                FactorCode.Focus();

            }
            else if (DayDate.Text.Trim().Length == 0)
            {
                ResultStatus.Text = "تاریخ را وارد کنید";
                DayDate.Focus();

            }
            else if (!R1.Checked && !R2.Checked)
            {
                ResultStatus.Text = "نوع پرداخت را انتخاب کنید";
            }
            else
            {
                if (AdminNumber.Text=="1")
                {
                    ACustomer customer = new ACustomer();
                    customer.FullName = CustomerName.Text;
                    customer.Phone = Fun.ChangeToEnglishNumber(PhoneNumber.Text);
                    if (blc.CreateCustomerA(customer))
                    {
                        //  موجود نیست و ثبت نام میشود
                        ResultStatus.Text = "جدید بود و ثبت نام شد";
                    }
                    else
                    {
                        //  موجود است و آنرا بگیرد
                        //ACustomer customerN = blc.GetCustomersA().Where(c => c.FullName == CustomerName.Text).FirstOrDefault();
                        ResultStatus.Text = "مشتری از قبل ثبت شده است";
                    }
                }
                else
                {
                    BCustomer customer = new BCustomer();
                    customer.FullName = CustomerName.Text;
                    customer.Phone = Fun.ChangeToEnglishNumber(PhoneNumber.Text);
                    if (blc.CreateCustomerB(customer))
                    {
                        //  موجود نیست و ثبت نام میشود
                        ResultStatus.Text = "جدید بود و ثبت نام شد";
                    }
                    else
                    {
                        //  موجود است و آنرا بگیرد
                        //ACustomer customerN = blc.GetCustomersA().Where(c => c.FullName == CustomerName.Text).FirstOrDefault();
                        ResultStatus.Text = "مشتری از قبل ثبت شده است";
                    }
                }
                
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
            }

        }

        private void CloseFactor_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            OpenFactor.Enabled = true;
            AcceptFactor.Enabled = true;
        }

        private void OpenFactor_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            OpenFactor.Enabled = false;
            AcceptFactor.Enabled = false;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Double Total = 0d;
            for (int i = 0; i < DGV2.RowCount; i++)
            {
                Total += int.Parse(DGV2.Rows[i].Cells[7].Value.ToString());
            }
            TotalPriceFactor.Text = Total.ToString("#,0");
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            //  حذف از فاکتور
            try
            {
                DGV2.Rows.RemoveAt(NO2-1);
                counter2 = DGV2.RowCount+1;

                for (int i = 0; i < DGV2.RowCount; i++)
                {
                    DGV2.Rows[i].Cells[1].Value = i + 1;
                }
            }
            catch
            {

            }
        }
        private void AcceptFactor_Click(object sender, EventArgs e)
        {
            SaveFactor.Enabled = true;
            if (AdminNumber.Text=="1")
            {
                ASellFactor Factor = new ASellFactor();
                Factor.FactorCode = int.Parse(Fun.ChangeToEnglishNumber(FactorCode.Text));
                Factor.FactorNumber = int.Parse(Fun.ChangeToEnglishNumber(FactorNumber.Text));
                Factor.admin = blc.GetAdminsA().Where(c => c.FullName == ADMINNAMESHOW.Text).FirstOrDefault();


                for (int i = 0; i < DGV2.RowCount; i++)
                {
                    int IDN = int.Parse(DGV2.Rows[i].Cells[0].Value.ToString());
                    AProduct product = blc.GetProductA(IDN);
                    Factor.Products.Add(product);

                    product.Mojodi -= int.Parse(DGV2.Rows[i].Cells[6].Value.ToString());
                    product.SellCount += int.Parse(DGV2.Rows[i].Cells[6].Value.ToString());
                    blc.SaveEditForBuyFactorProductA(product);
                }
                blc.CreateSellFactorA(Factor);
            }
            else
            {
                BSellFactor Factor = new BSellFactor();
                Factor.FactorCode = int.Parse(Fun.ChangeToEnglishNumber(FactorCode.Text));
                Factor.FactorNumber = int.Parse(Fun.ChangeToEnglishNumber(FactorNumber.Text));
                Factor.admin = blc.GetAdminsB().Where(c => c.FullName == ADMINNAMESHOW.Text).FirstOrDefault();


                for (int i = 0; i < DGV2.RowCount; i++)
                {
                    int IDN = int.Parse(DGV2.Rows[i].Cells[0].Value.ToString());
                    BProduct product = blc.GetProductB(IDN);
                    Factor.Products.Add(product);

                    product.Mojodi -= int.Parse(DGV2.Rows[i].Cells[6].Value.ToString());
                    product.SellCount += int.Parse(DGV2.Rows[i].Cells[6].Value.ToString());
                    blc.SaveEditForBuyFactorProductB(product);
                }
                blc.CreateSellFactorB(Factor);
            }


        }

        private void SaveFactor_Click(object sender, EventArgs e)
        {
            if (AdminNumber.Text=="1")
            {
                ASellFactor Factor = blc.GetSellFactorsA().Where(c => c.FactorCode == int.Parse(Fun.ChangeToEnglishNumber(FactorCode.Text))).FirstOrDefault();
                ACustomer customer = blc.GetCustomerByPhoneA(Fun.ChangeToEnglishNumber(PhoneNumber.Text));
                Factor.Customer = customer;
                customer.BuyCost += Convert.ToDouble(TotalPriceFactor.Text);
                blc.SaveEditCustomerA(customer);
                Factor.RegisterDate = Fun.ChangeToEnglishNumber(DayDate.Text);
                Factor.TotalPrice = Convert.ToDouble(TotalPriceFactor.Text);
                Factor.CashType = R1.Checked ? true : false;    //  نقدی
                blc.SaveLastChangesOnSellFacotrA(Factor);
                NO1 = counter1 = 1;
                NO2 = counter2 = 1;
                DGV1.Rows.Clear();
                DGV2.Rows.Clear();
                GetFactorNumber();
                GetFactorCode();
                DayDate.Text = Fun.CLOCK();
                SaveFactor.Enabled = false;
                AcceptFactor.Enabled = false;
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
            }
            else
            {
                BSellFactor Factor = blc.GetSellFactorsB().Where(c => c.FactorCode == int.Parse(Fun.ChangeToEnglishNumber(FactorCode.Text))).FirstOrDefault();
                BCustomer customer = blc.GetCustomerByPhoneB(Fun.ChangeToEnglishNumber(PhoneNumber.Text));
                Factor.Customer = customer;
                customer.BuyCost += Convert.ToDouble(TotalPriceFactor.Text);
                blc.SaveEditCustomerB(customer);
                Factor.RegisterDate = Fun.ChangeToEnglishNumber(DayDate.Text);
                Factor.TotalPrice = Convert.ToDouble(TotalPriceFactor.Text);
                Factor.CashType = R1.Checked ? true : false;    //  نقدی
                blc.SaveLastChangesOnSellFacotrB(Factor);
                NO1 = counter1 = 1;
                NO2 = counter2 = 1;
                DGV1.Rows.Clear();
                DGV2.Rows.Clear();
                GetFactorNumber();
                GetFactorCode();
                DayDate.Text = Fun.CLOCK();
                SaveFactor.Enabled = false;
                AcceptFactor.Enabled = false;
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            //groupBox3.Enabled = true;
            bool SW = false;
            for (int i=0;i<DGV2.RowCount;i++)
            {
                if (ID1 == int.Parse(DGV2.Rows[i].Cells[0].Value.ToString()))
                {
                    SW = true;
                }
                
            }
            if (!SW)
            {
                AddProductToDGV2(ID1);
            }
            else
            {
                ResultText2.Text = "در فاکتور موجود است";
            }
        }

        private void AddMojodi_Click(object sender, EventArgs e)
        {
            try
            {
                if (AdminNumber.Text=="1")
                {
                    AProduct product = blc.GetProductA(ID2);
                    if (product == null)
                    {
                        ResultText2.Text = "محصول را انتخاب کنید";
                    }
                    else if (product.Mojodi >= Tehdad.Value)
                    {
                        DGV2.Rows[NO2 - 1].Cells[6].Value = int.Parse(Tehdad.Value.ToString());
                        DGV2.Rows[NO2 - 1].Cells[7].Value = int.Parse(Tehdad.Value.ToString()) * Convert.ToDouble(DGV2.Rows[NO2 - 1].Cells[5].Value.ToString());
                    }
                    else
                    {
                        ResultText2.Text = "موجودی در انبار کافی نیست";
                    }
                }
                else
                {
                    BProduct product = blc.GetProductB(ID2);
                    if (product == null)
                    {
                        ResultText2.Text = "محصول را انتخاب کنید";
                    }
                    else if (product.Mojodi >= Tehdad.Value)
                    {
                        DGV2.Rows[NO2 - 1].Cells[6].Value = int.Parse(Tehdad.Value.ToString());
                        DGV2.Rows[NO2 - 1].Cells[7].Value = int.Parse(Tehdad.Value.ToString()) * Convert.ToDouble(DGV2.Rows[NO2 - 1].Cells[5].Value.ToString());
                    }
                    else
                    {
                        ResultText2.Text = "موجودی در انبار کافی نیست";
                    }
                }
            }
            catch
            {

            }

        }

        private void DGV1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button==MouseButtons.Right || e.Button==MouseButtons.Left)
            {
                ID1 = int.Parse(DGV1.CurrentRow.Cells[0].Value.ToString());
                NO1 = int.Parse(DGV1.CurrentRow.Cells[1].Value.ToString());
            }
        }
        private void DGV2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left)
            {
                ID2 = int.Parse(DGV2.SelectedCells[0].Value.ToString());
                NO2 = int.Parse(DGV2.SelectedCells[1].Value.ToString());
            }
        }
    
    }
}
