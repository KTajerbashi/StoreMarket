﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BEE;
namespace StoreMarket_V1
{
    public partial class AccessCodeForm : Form
    {
        public AccessCodeForm()
        {
            InitializeComponent();
        }

        BLLCode blc = new BLLCode();
        private void button1_Click(object sender, EventArgs e)
        {
            bool OwnerKey=blc.OwnerKey(textBox1.Text);
            int AdminKey=blc.AdminKey(textBox1.Text, ADMINNAME.Text);

            if (OwnerKey || AdminKey != 0)
            {
                ManageForm SMF = new ManageForm();
                SMF.ADMINNAME.Text = ADMINNAME.Text;
                SMF.ADMINNUMBER.Text = ADMINNUMBER.Text;
                SMF.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("دسترسی ندارید");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AccessCodeForm_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void AccessCodeForm_Load(object sender, EventArgs e)
        {
        }
    }
}
