using System;

namespace Billing52Group.Models
{
    public class ContractPayment
    {
        public int Id { get; set; }

        public double Summa { get; set; }

        public string Comment { get; set; }

        public int PaymentId { get; set; }

        public int ContractId { get; set; }

        public virtual Contract Contract { get; set; }

        public virtual PaymentType PaymentType { get; set; }
        
        public DateTime? Date { get; set; }
    }
}
