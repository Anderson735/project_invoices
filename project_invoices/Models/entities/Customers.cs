using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_invoices.Models.entities
{
    public class Customers
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int factura { get; set; }
    }
}
