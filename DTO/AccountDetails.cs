using System;
using System.Collections.Generic;

namespace HSBank.DTO
{
    public partial class AccountDetails
    {
        public AccountDetails()
        {
            PaymentDetails = new HashSet<PaymentDetails>();
        }

        public int AccountId { get; set; }
        public string Name { get; set; }
        public int? MontlyCl { get; set; }

        public virtual ICollection<PaymentDetails> PaymentDetails { get; set; }
    }
}
