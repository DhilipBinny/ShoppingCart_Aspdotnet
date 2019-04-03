using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using S_cart.Models;
using System.Web.Configuration;
using System.Diagnostics;

namespace S_cart.DB
{
    public class PurchaseData : Data
    {
        //Handle all queries relating to purchase
        public static List<Purchase> purchasesdb()
        {
            List<Purchase> purchase1 = new List<Purchase>();
            
            //Instantiate the connection
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            conn.Open();
            
            //Instantiate a new command with a query and connection
            string cmdtext = @"select p.product_id, count(p.product_id) as Quantity, p.product_name,p.image_url, p.product_description, c.date_time" +
                                            " from cart_info c join product_info p on c.product_id = p.product_id" +
                                            " where c.status_code = 1" +
                                            " group by c.date_time, p.product_id, p.product_name, p.image_url, p.unit_price, p.product_description" +
                                            " order by c.date_time, p.product_id, p.product_name, p.image_url, p.unit_price, p.product_description";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);

            //Call Execute reader to get query results
            SqlDataReader sdr = cmd.ExecuteReader();

            //Print out each record
            while (sdr.Read())
            {
                Purchase purc = new Purchase();
                {
                    purc.productid = (int)sdr["product_id"];
                    purc.quantity = (int)sdr["Quantity"];
                    purc.product_name = (string)sdr["product_name"];
                    purc.image = (string)sdr["image_url"];
                    purc.productdesc = (string)sdr["product_description"];
                    purc.purchasedate = (string)sdr["date_time"];
                }
                purchase1.Add(purc);
                Debug.WriteLine(sdr["product_id"]);
            }

            return purchase1;
        }
    }
}