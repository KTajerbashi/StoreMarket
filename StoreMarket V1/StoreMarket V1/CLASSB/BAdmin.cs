﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace StoreMarket_V1
{
    public class BAdmin : Person
    {
        public int id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String accessCode { get; set; }
        public bool DeleteStatus { get; set; }
        public OWNER owner { get; set; }    // 1:N with owner
        public List<BAdminBankAccount> bAdminBankAccounts { get; set; } = new List<BAdminBankAccount>();
    }


}