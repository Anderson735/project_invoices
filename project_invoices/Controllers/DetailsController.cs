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
    public class DetailsController : Controller
    {
        public IEnumerable<Invoice_detail> Index(string id)
        {
            string sql = " SELECT descripcion,valor FROM invoice_details";

            DataBase db = new DataBase();

            DataTable dt = db.getTabla(sql);
            List<Invoice_detail> invoice = new List<Invoice_detail>();


            invoice = (from DataRow dr in dt.Rows
                           select new Invoice_detail()
                           {
                               description = dr["descripcion"].ToString(),
                               valor = Convert.ToDecimal(dr["valor"]),
                               id_invoice = Convert.ToInt32(dr["id_invoice"])
                           }).ToList();
                           





            return invoice;
        }


        [HttpPost]
        public string Create([FromBody] Invoice_detail invoice)
        {

            string sql = "insert into invoice_detail(id_invoice, descripcion, valor) values((Select Max(id) from invoice),'"+ invoice.description +"','"+ invoice.valor +"')";
            DataBase db = new DataBase();
            string result = db.consultaSQL(sql);

            return result;
        }

        // GET: ClienteController/Details/5

        /*[HttpPatch]
        public string Update([FromBody] Invoice_detail invoice)
        {
            string sql = "UPDATE cliente SET nombre = ('" + client.Name + "'), apellidos = ('" + client.Last_Name + "') WHERE id = ('" + client.ID + "')";
            DataBase db = new DataBase();
            string result = db.consultaSQL(sql);
            return result;
        }



        [HttpDelete]

        public string Delete([FromBody] Invoice_detail invoice)
        {
            string sql = "DELETE FROM users WHERE id = ('" + client.ID + "')";
            DataBase db = new DataBase();
            string result = db.consultaSQL(sql);
            return result;
        }*/
    }
}
