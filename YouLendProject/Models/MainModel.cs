﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YouLendProject.Models
{
    public class MainModel
    {
        public MainModel() { }
        
        public int loan { get; set; }
        public int loanId { get; set; }
        public String borrowerName { get; set; }
        public int repaymentAmount;

        public double getRepaymentAmount(int loan)
        {
            return loan * 1.1;
        }

    }

}