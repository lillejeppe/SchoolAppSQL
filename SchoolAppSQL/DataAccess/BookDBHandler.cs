using System.Configuration;
using System.Data.SqlClient;
using SchoolAppSQL.Models;

namespace SchoolAppSQL.DataAccess
{
    internal class BookDBHandler
    {
        string connString;

        public BookDBHandler()
        {
            connString = ConfigurationManager.ConnectionStrings["Default"].ToString();
        }


        public List<Book> Get()
        {
            List<Book> bookList = new List<Book>();
            string command = "SELECT * FROM BOOKS";
            using SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(command, conn);

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["ID"];
                    string title = (string)reader["Title"];
                    string description = (string)reader["Description"];
                    double productionPrice = (double)reader["ProductionPrice"];
                    double profitMargin = (double)reader["ProfitMargin"];
                    Book book = new Book(id, title, description, productionPrice, profitMargin);
                    bookList.Add(book);
                }
            }
            catch (Exception e)
            {
                throw new Exception("ERROR; " + e.Message + e.StackTrace + e.Source);
            }
            finally { conn.Close(); }

            return bookList;
        }

        public Book Get(int ID)
        {
            Book TargetBook = new Book();
            string command = $"SELECT * FROM BOOKS WHERE ID = {ID}";
            using SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(command, conn);

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["ID"];
                    string title = (string)reader["Title"];
                    string description = (string)reader["Description"];
                    double productionPrice = (double)reader["ProductionPrice"];
                    double profitMargin = (double)reader["ProfitMargin"];
                    TargetBook = new Book(id, title, description, productionPrice, profitMargin);
                }
            }
            catch (Exception e)
            {
                throw new Exception("ERROR; " + e.Message + e.StackTrace + e.Source);
            }
            finally { conn.Close(); }

            return TargetBook;
        }
    }

}
