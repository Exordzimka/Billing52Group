﻿using System;

namespace Billing52Group.Server.Models
{
    public class ContractCharge
    {
        public int Id { get; set; }

        public double Summa { get; set; }

        public string Comment { get; set; }

        public int Contractid { get; set; }

        public DateTime Date { get; set; }

        public virtual Contract Contract { get; set; }
    }
}
