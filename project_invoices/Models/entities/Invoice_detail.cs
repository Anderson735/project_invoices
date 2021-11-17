using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_invoices.Models.entities
{
    public class Invoice_detail
    {
        public int id { get; set; }
        public int id_invoice { get; set; }
        public string description { get; set; }
        public decimal valor { get; set; }
    }
}
