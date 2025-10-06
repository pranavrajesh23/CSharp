using System;
using System.Data.SqlClient;
namespace AdoNetConnection{
    class Program{
        static void Main(string[] args){
            string connectionString = "Data Source=localhost;Initial Catalog=SampleDB2;Integrated Security=True;";
            string query = "SELECT * FROM Clients"; 
            using (SqlConnection conn = new SqlConnection(connectionString)){
                try{
                    conn.Open();
                    Console.WriteLine("Connected successfully!");
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()){
                        Console.WriteLine($"{reader["ClientID"],-2} | {reader["ClientName"],-18} | {reader["Email"]}");
                    }
                    reader.Close();
                }
                catch (Exception ex){
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
