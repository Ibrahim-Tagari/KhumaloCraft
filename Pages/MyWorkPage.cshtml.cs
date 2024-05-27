using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace KhumaloCraftWebApp.Pages
{
    public class MyWorkPageModel : PageModel
    {
        public List<InvoiceInfo> listInvoice = new List<InvoiceInfo>();
        public InvoiceInfo newInvoiceItem = new InvoiceInfo();
        public List<CartInfo> cartInfo = new List<CartInfo>();

        public void OnGet()
        {
            GetCartdata();
            try
            {
                string connectionString = "Data Source=labVMH8OX\\SQLEXPRESS;Initial Catalog=KhumaloCraftsEmp2;Integrated Security=True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Products;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                InvoiceInfo InvoiceInfo = new InvoiceInfo();
                                InvoiceInfo.ProductID = "" + reader.GetInt32(0);
                                InvoiceInfo.UserID = "" + reader.GetInt32(1);
                                InvoiceInfo.Name = reader.GetString(2);
                                InvoiceInfo.Description = reader.GetString(3);
                                InvoiceInfo.Price = reader.GetInt32(4).ToString();
                                InvoiceInfo.CategoryID = reader.GetInt32(5).ToString();

                                listInvoice.Add(InvoiceInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }

        public void OnPost(string ProductID)
        {
            int productID = int.Parse(ProductID);
            try
            {
                string connectionString = "Data Source=labVMH8OX\\SQLEXPRESS;Initial Catalog=KhumaloCraftsEmp2;Integrated Security=True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Cart (ProductID, Name, Price, Description, CategoryID) " +
                                 "Select ProductID, Name, Price, Description, CategoryID " +
                                 "FROM Products " +
                                 "WHERE ProductID = @ProductID; ";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@ProductID", productID));
                        command.ExecuteNonQuery();
                    }
                }
                Response.Redirect("/MyWorkpage");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }

        public void GetCartdata()
        {
            try
            {
                string connectionString = "Data Source=labVMH8OX\\SQLEXPRESS;Initial Catalog=KhumaloCraftsEmp2;Integrated Security=True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Cart;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CartInfo cartinfo = new CartInfo();
                                cartinfo.ProductID = "" + reader.GetInt32(0);
                                cartinfo.Name = reader.GetString(1);
                                cartinfo.Price = reader.GetInt32(2).ToString();
                                cartinfo.Description = reader.GetString(3);
                                cartinfo.CategoryID = reader.GetInt32(4).ToString();

                                cartInfo.Add(cartinfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
        public class InvoiceInfo
        {
            public string ProductID;
            public string UserID;
            public string Name;
            public string Description;
            public string Price;
            public string CategoryID;
        }

        public class CartInfo
        {
            public string ProductID;
            public string Name;
            public string Description;
            public string Price;
            public string CategoryID;
        }
    }
} 
