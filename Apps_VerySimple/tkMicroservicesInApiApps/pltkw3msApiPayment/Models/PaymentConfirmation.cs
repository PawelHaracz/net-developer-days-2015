using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pltkw3msApiPayment.Models
{
    public class PaymentConfirmation
    {
        public int OrderId { get; set; }
        public string PaymentType { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}