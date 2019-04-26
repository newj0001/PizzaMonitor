using PizzaMonitor.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace PizzaMonitor
{
    class DataAccessLayer
    {

        private static SqlConnection connection = new SqlConnection();
        static string connString = "Data Source=sql.itcn.dk\\EADANIA; Initial Catalog=newj0001.EADANIA; User id=newj0001.EADANIA; Password=A0k2hHeA36";
        static void OpenConnection()
        {
            connection = new SqlConnection(connString);
            connection.Open();
        }

        static void CloseConnection()
        {
            if (connection != null && connection.State == ConnectionState.Open)
                connection.Close();
        }

        public static System.Drawing.Image GetPizza()
        {
            try
            {

                List<PizzaModel> pizzaList = new List<PizzaModel>();
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Pizza", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                PizzaModel pizza = new PizzaModel();
                while (reader.Read())
                {
                    pizza = new PizzaModel();
                    pizza.Id = reader.GetInt64(0);

                    pizza.byteArray = new byte[70];
                    pizza.byteArray = (byte[])reader[1];
                    MemoryStream ms = new MemoryStream(pizza.byteArray);

                    //ms.Seek(0, SeekOrigin.Begin);
                    Bitmap bmp = new Bitmap(ms);
                        
                            pizza.image = bmp;
                        


                    //bitmapImage.BeginInit();
                    //bitmapImage.StreamSource = new MemoryStream(pizza.byteArray);
                    //bitmapImage.EndInit();
                    

                    pizzaList.Add(pizza);
                }
                return pizzaList[0].image;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
