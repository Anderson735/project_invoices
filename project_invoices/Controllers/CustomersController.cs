using Microsoft.AspNetCore.Mvc;
using project_invoices.Models;
using project_invoices.Models.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace project_invoices.Controllers
{
    public class CustomersController : Controller
    {
        public IEnumerable<Customers> Index()
        {
            string sql = "SELECT * FROM cliente AS c INNER JOIN invoice AS i ON c.factura = i.id INNER JOIN invoice_detail AS id ON i.id = id.id_invoice;";

            DataBase db = new DataBase();

            DataTable dt = db.getTabla(sql);
            List<Customers> detailsList = new List<Customers>();

            detailsList = (from DataRow dr in dt.Rows
                           select new Customers()
                           {
                               id = dr["id"].ToString(),
                               nombre = dr["nombre"].ToString(),
                               apellido = dr["apellido"].ToString(),
                               factura = Convert.ToInt32(dr["factura"])
                           }).ToList();




            return detailsList;
        }

        [HttpPost]
        public string Create([FromBody] Customers customers)
        {
            string id = "select max(id) from invoice";

            string sql = "insert into cliente (id, nombre, apellido, factura) values ('" + customers.id + "','" + customers.nombre + "','" + customers.apellido + "','" + Convert.ToInt32(id) + "')";
            DataBase db = new DataBase();
            string result = db.consultaSQL(sql);

            return result;
        }
    }
}
