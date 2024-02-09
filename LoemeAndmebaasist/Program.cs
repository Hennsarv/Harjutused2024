using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LoemeAndmebaasist
{
// kõige lihtsam viis midagi andmebaasist kätte saada
    internal class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection conn =
                new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=c:\\test\\database.mdf;Integrated Security=True;Connect Timeout=30"))
            //                new SqlConnection("Data Source=valiitsql.database.windows.net;Initial Catalog=NOrthwind;Persist Security Info=True;User=student;Password=Pa$$w0rd;Encrypt=False")            )
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select * from asjad", conn))
                {
                    SqlDataReader R = cmd.ExecuteReader();

                    while (R.Read())
                    {
                        Console.WriteLine($"asi number {R["ID"]} on {R["Name"]}");
                    }

                }
            }
            ;


        }
    }
}
