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
            //Path til DB, Tjek App.Config for detaljer
            connString = ConfigurationManager.ConnectionStrings["Default"].ToString();
        }


        public List<Book> Get()
        {
            List<Book> bookList = new List<Book>();
            //SQL QUARY to send to DB
            string command = "SELECT * FROM BOOKS";
            //SqlConnection sets up the connection as conn
            using SqlConnection conn = new SqlConnection(connString);
            try
            {
                //Tell the connection to open, allowing us to send quaries
                conn.Open();
                //Send pre-made Sql Quary down our set up connection
                SqlCommand cmd = new SqlCommand(command, conn);

                //Reads the rows from the current sql tuple
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
            //Makes sure to close the sql connection
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

        public bool Create(Book book)
        {
            bool success;
            int rowsAffected;
            string command = $"INSERT INTO BOOKS VALUES ({book.Id}, '{book.Title}', '{book.Description}', {book.ProductionPrice}, {book.ProfitMargin});";
            using SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(command, conn);
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR; " + e.Message + e.StackTrace + e.Source);
            }
            finally { conn.Close(); }
            if (rowsAffected > 0) { success = true; }
            else { success = false; }

            return success;
        }

        public bool Update(Book book, int ID)
        {
            bool success;
            int rowsAffected;
            string command = $"UPDATE BOOKS SET ID = {book.Id}, Title = '{book.Title}', Description = '{book.Description}', ProductionPrice = {book.ProductionPrice}, ProfitMargin = {book.ProfitMargin} WHERE ID = {ID};";
            using SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(command, conn);
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR; " + e.Message + e.StackTrace + e.Source);
            }
            finally { conn.Close(); }
            if (rowsAffected > 0) { success = true; }
            else { success = false; }

            return success;
        }

        public bool Delete(int ID)
        {
            bool success;
            int rowsAffected;
            string command = $"DELETE FROM BOOKS WHERE ID = {ID};";
            using SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(command, conn);
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR; " + e.Message + e.StackTrace + e.Source);
            }
            finally { conn.Close(); }
            if (rowsAffected > 0) { success = true; }
            else { success = false; }

            return success;
        }

    }
}
