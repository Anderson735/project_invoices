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
    public class InvoicesController : Controller
    {
        DataBase db = new DataBase();
        public IEnumerable<Invoices> Index()
        {   
            string sql = "SELECT * FROM invoice, invoice_detail GROUP BY invoice.id"; 


            DataBase db = new DataBase();

            DataTable dt = db.getTabla(sql);
            List<Invoices> detailsList = new List<Invoices>();


            detailsList = (from DataRow dr in dt.Rows
                           select new Invoices()
                           {
                               id_client = dr["cliente"].ToString(),
                               codigo = dr["cod"].ToString(),
                               details = new List<Invoice_detail>()
                               {
                                   new Invoice_detail
                                   {
                                     description = dr["descripcion"].ToString(),
                                     valor = Convert.ToDecimal(dr["valor"])
                                   }
                               }
                           }).ToList();



            return detailsList;
        }



        [HttpPost]
        public string Create([FromBody] Invoices invoice)
        {
            string sql = "INSERT INTO invoice(cod,cliente) VALUES('" + invoice.codigo + "','" + invoice.id_client + "');" + Environment.NewLine; 
            foreach (Invoice_detail id in invoice.details)
            {
                sql += "insert into invoice_detail(id_invoice, descripcion, valor) values((Select Max(id) from invoice),'" + id.description + "','" + id.valor + "');" + Environment.NewLine;
            }
            sql += "" + Environment.NewLine;

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
