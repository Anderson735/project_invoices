using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_invoices.Models.entities
{
    public class Invoices
    {
        public int id { get; set; }
        public string id_client { get; set; }
        public string codigo { get; set; }
        public List<Invoice_detail> details { get; set; }
    }
}
