using System;
using System.Collections.Generic;

namespace HSBank.DTO
{
    public partial class PaymentDetails
    {
        public int Pid { get; set; }
        public int AccountId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public int? TransactionAmount { get; set; }

        public virtual AccountDetails Account { get; set; }
    }
}
