﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace StoreMarket_V1
{
    public partial class MainForm : Form
    {
        #region CodeClick
        const int HT_CAPTION = 0x2;
        const int WM_NCLBUTTONDOWN = 0xA1;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {    //  MouseDown

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult= MessageBox.Show("میخواهید برنامه بسته شود؟", "درخواست" ,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            AccessCodeForm ACF = new AccessCodeForm();
            ACF.ADMINNUMBER.Text = ADMINNUMBER.Text;
            ACF.ADMINNAME.Text = ADMINNAME.Text;
            ACF.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show(ADMINNUMBER.Text);
        }
    }
}