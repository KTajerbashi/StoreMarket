﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BEE;
using BLL;
namespace StoreMarket_V1
{
    public partial class CustomerPanel : UserControl
    {
        public CustomerPanel()
        {
            InitializeComponent();
        }
        BLLCode bll = new BLLCode();
        Functions Fun=new Functions();
        int ID = -1;
        bool SW = true;
        public void PrintCustomer(String Name)
        {
            DGV1.Rows.Clear();
            if (Name=="1")
            {
                var DB = bll.GetCustomersA();
                foreach (var item in DB)
                {
                    DGV1.Rows.Add(item.id,item.FullName,item.Phone,item.BuyCost.ToString("#,0"));
                }
            }
            else
            {
                var DB = bll.GetCustomersB();
                foreach (var item in DB)
                {
                    DGV1.Rows.Add(item.id, item.FullName,item.Phone, item.BuyCost.ToString("#,0"));
                }
            }
        }
        public void PrintSerchResult(String Admin,String Word)
        {
            DGV1.Rows.Clear();
            if (Admin=="1")
            {
                var DB = bll.PrintSerchResultCustomerA(Word);
                foreach (var item in DB)
                {
                    DGV1.Rows.Add(item.id,item.FullName,item.Phone,item.BuyCost.ToString("#,0"));
                }
            }
            else
            {
                var DB = bll.PrintSerchResultCustomerB(Word);
                foreach (var item in DB)
                {
                    DGV1.Rows.Add(item.id, item.FullName, item.Phone, item.BuyCost.ToString("#,0"));
                }
            }
        }
        private void SAVEBTN_Click(object sender, EventArgs e)
        {
            if (NAME.Text.Trim().Length==0)
            {
                errorProvider1.SetError(NAME,"نام را وارد کنید");
                NAME.Focus();
            }
            else if (PHONE.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(PHONE, "تلفن را وارد کنید");
                PHONE.Focus();
            }
            else if (NEWBUY.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(NEWBUY, "مبلغ را وارد کنید");
                NEWBUY.Focus();
            }
            else
            {
                if (ADMIN.Text == "1")
                {
                    ACustomer customer = new ACustomer();
                    if (SW)
                    {   //ذخیره
                        customer.FullName = NAME.Text;
                        customer.Phone = Fun.ChangeToEnglishNumber(PHONE.Text);
                        customer.BuyCost = Int64.Parse(Fun.ChangeToEnglishNumber(NEWBUY.Text));
                        if (bll.CreateCustomerA(customer))
                        {
                            Result.Text = "ذخیره شد";
                            PrintCustomer(ADMIN.Text);
                            Fun.ClearTextBoxes(this.Controls);
                        }
                        else
                        {
                            Result.Text = "ذخیره نشد";
                        }
                    }
                    else
                    {
                        customer.FullName = NAME.Text;
                        customer.Phone = Fun.ChangeToEnglishNumber(PHONE.Text);
                        customer.BuyCost = Int64.Parse(Fun.ChangeToEnglishNumber(NEWBUY.Text));
                        if (bll.EditCustomerA(customer, ID))
                        {
                            Result.Text = "ویرایش شد";
                            PrintCustomer(ADMIN.Text);
                            Fun.ClearTextBoxes(this.Controls);
                            SAVEBTN.Text = "ذخیره";
                            SW = true;
                        }
                        else
                        {
                            Result.Text = "ویرایش نشد";
                        }
                    }
                }
                else
                {
                    BCustomer customer = new BCustomer();
                    if (SW)
                    {
                        customer.FullName = NAME.Text;
                        customer.Phone = Fun.ChangeToEnglishNumber(PHONE.Text);
                        customer.BuyCost = Convert.ToDouble(Fun.ChangeToEnglishNumber(NEWBUY.Text));
                        if (bll.CreateCustomerB(customer))
                        {
                            Result.Text = "ذخیره شد";
                            PrintCustomer(ADMIN.Text);
                            Fun.ClearTextBoxes(this.Controls);
                        }
                        else
                        {
                            Result.Text = "ذخیره نشد";
                        }
                    }
                    else
                    {
                        customer.FullName = NAME.Text;
                        customer.Phone = Fun.ChangeToEnglishNumber(PHONE.Text);
                        customer.BuyCost = Convert.ToDouble(Fun.ChangeToEnglishNumber(NEWBUY.Text));
                        if (bll.EditCustomerB(customer, ID))
                        {
                            Result.Text = "ویرایش شد";
                            PrintCustomer(ADMIN.Text);
                            Fun.ClearTextBoxes(this.Controls);
                            SAVEBTN.Text = "ذخیره";
                            SW = true;
                        }
                        else
                        {
                            Result.Text = "ویرایش نشد";
                        }
                    }
                }

            }

        }

        private void CustomerPanel_Load(object sender, EventArgs e)
        {
            PrintCustomer(ADMIN.Text);
        }

        private void DGV1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left)
                {
                    ID = int.Parse(DGV1.CurrentRow.Cells[0].Value.ToString());
                }
                if (e.Button == MouseButtons.Right)
                {
                    contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
            catch
            {
            }
            
        }
        private void NAME_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Clear();
        }
        private void SEABTN_Click(object sender, EventArgs e)
        {
            PrintSerchResult(ADMIN.Text, Search.Text);
        }
        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ADMIN.Text == "1")
            {
                bll.DeleteCustomerA(ID);
                PrintCustomer(ADMIN.Text);
            }
            else
            {
                bll.DeleteCustomerB(ID);
                PrintCustomer(ADMIN.Text);
            }
            Result.Text ="اطلاعات مشتری مورد نظر حذف شد!!!";
        }
        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ID = int.Parse(DGV1.CurrentRow.Cells[0].Value.ToString());
            NAME.Text = DGV1.CurrentRow.Cells[1].Value.ToString();
            PHONE.Text = DGV1.CurrentRow.Cells[2].Value.ToString();
            NEWBUY.Text = DGV1.CurrentRow.Cells[3].Value.ToString();
            SAVEBTN.Text = "بروزرسانی";
            SW = false;
        }

        private void SAVEBTN_MouseEnter(object sender, EventArgs e)
        {
            SAVEBTN.ForeColor = Color.Black;
        }

        private void SAVEBTN_MouseLeave(object sender, EventArgs e)
        {
            SAVEBTN.ForeColor = Color.White;
        }

        private void SEABTN_MouseEnter(object sender, EventArgs e)
        {
            SEABTN.ForeColor = Color.Black;
        }

        private void SEABTN_MouseLeave(object sender, EventArgs e)
        {
            SEABTN.ForeColor = Color.White;
        }

        private void NEWBUY_TextChanged(object sender, EventArgs e)
        {
            try
            {
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalDigits = 0;
                NEWBUY.Text = Int64.Parse(NEWBUY.Text, NumberStyles.AllowThousands).ToString("N", nfi);
                NEWBUY.Select(NEWBUY.Text.Length, 0);
            }
            catch
            {
            }
        }
    }
}
