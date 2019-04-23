using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITC303Group3Demo.Models;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace ITC303Group3Demo.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<Product> productList = new List<Product>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mysql = new MySqlConnection(conn);
            string query = "SELECT * FROM Product;";
            MySqlCommand comm = new MySqlCommand(query);
            comm.Connection = mysql;
            mysql.Open();

            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                productList.Add(new Product
                {
                    idProduct = Convert.ToInt32(reader["idProduct"]),
                    productName = reader["productName"].ToString(),
                    productDesc = reader["productDesc"].ToString(),
                    productPrice = Convert.ToDouble(reader["productPrice"]),
                    productAvailability = reader["productAvailability"].ToString(),
                    productImg = reader["productImg"].ToString()
                    
                 }); 
            }
            mysql.Close();
            return View(productList);
        }
    }
}