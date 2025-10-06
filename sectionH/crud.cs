using System;
using System.Data.SqlClient;
namespace AdoNetConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=SampleDB2;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connected successfully!");
                    //create
                    string insertq = "insert into Clients (ClientName,Email) values (@Name,@Email)";
                    using (SqlCommand cmd1 = new SqlCommand(insertq, conn))
                    {
                        cmd1.Parameters.AddWithValue("@Name", "Leo Das");
                        cmd1.Parameters.AddWithValue("@Email", "leo@example.com");
                        cmd1.ExecuteNonQuery();
                        //Console.WriteLine($"{rowsAffected} row(s) inserted.");
                    }
                    //update
                    string updateq = "update Clients set Email=@Email where ClientID=@ID";
                    using (SqlCommand cmd2 = new SqlCommand(updateq, conn))
                    {
                        cmd2.Parameters.AddWithValue("@Email", "updated@example.com");
                        cmd2.Parameters.AddWithValue("@ID", 1);
                        cmd2.ExecuteNonQuery();
                    }
                    //delete
                    string deletePurchases = "DELETE FROM Purchases WHERE ClientID=@ID";
                    using (SqlCommand cmdd = new SqlCommand(deletePurchases, conn))
                    {
                        cmdd.Parameters.AddWithValue("@ID", 2);
                        cmdd.ExecuteNonQuery();
                    }
                    string deleteq = "delete from Clients where ClientID=@ID";
                    using (SqlCommand cmd3 = new SqlCommand(deleteq, conn))
                    {
                        cmd3.Parameters.AddWithValue("ID", 2);
                        cmd3.ExecuteNonQuery();
                    }
                    //read
                    string query = "SELECT * FROM Clients";
                    using(SqlCommand cmd = new SqlCommand(query, conn))
                    { 
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["ClientID"],-2} | {reader["ClientName"],-18} | {reader["Email"]}");
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
