using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using S_cart.Models;
using System.Web.Configuration;

namespace S_cart.DB
{
    public class PurchaseData : Data
    {
        //Handle all queries relating to purchase
        public static List<Purchase> purchasesdb()
        {
            List<Purchase> product1 = new List<Purchase>();
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select p.product_id, count(p.product_id) as Quantity,  p.product_name,p.image_url, p.product_description from cart_info c join product_info p on c.product_id = p.product_id where c.user_id = 1 and c.status_code = 0 group by p.product_id,p.product_name,p.image_url,p.unit_price,p.product_description", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                product prod = new product();
                {
                    prod.product_name = (string)rdr1["product_name"];
                    prod.unit_price = (int)rdr1["unit_price"];
                    prod.product_description = (string)rdr1["product_description"];
                    prod.image = (string)rdr1["image_url"];


                }
                product1.Add(prod);
            }
            con1.Close();
            return product1;

        }  
}