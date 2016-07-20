using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace stockone
{
    class Program

    {
        private static string connection = Convert.ToString( ConfigurationManager.ConnectionStrings["DefaultConnection"]);
        static void Main(string[] args)
        {
            //creates a connection string 
            DataSet CustomersDataSet = new DataSet();
            SqlDataAdapter da;
            SqlCommandBuilder cmdBuilder;
            
            using (SqlConnection conn = new SqlConnection())
            {
               // conn.ConnectionString = "Server=[DEV-PC]; Database=[console.nic];User Id=sa;Password=kagwa18$$;";
                conn.ConnectionString = connection;
                conn.Open();
                //creats a command of inserting into a table in sql database.
                Console.WriteLine("INSERT INTO command");
                SqlCommand insertCommand = new SqlCommand("INSERT INTO console_nic(name,descriptione,phoneNumber)VALUES(@0,@1,@2)", conn);
                
                // user name.
                Console.WriteLine("enter your name : ");
                string name = Console.ReadLine();
                //enter user description
                Console.WriteLine("Enter user description : ");
                string description = Console.ReadLine();
                //price to the bid.
                Console.WriteLine("price of the bid : ");
                int price = Convert.ToInt32(Console.ReadLine());
                // discount of 10%
                var discountInPercentage = 0.1;
                double discount = price * discountInPercentage;

                insertCommand.Parameters.Add(new SqlParameter("0", name));

                insertCommand.Parameters.Add(new SqlParameter("1", description));
                insertCommand.Parameters.Add(new SqlParameter("2", price));

                Console.WriteLine("commands executed! Total rows affected are " + insertCommand.ExecuteNonQuery());
                Console.WriteLine("Done! press enter to move to the next step");
                Console.ReadLine();

                SqlCommand command = new SqlCommand("SELECT * FROM console_nic", conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("FirstColumn \t\tSecond Column \t\t  \tThird Column");
                    while (reader.Read())
                    {
                        Console.WriteLine(string.Format("{0}  \t\t\t | {1}  \t\t\t | {2}  \t\t", reader[0], reader[1], reader[2]));
                        Console.ReadLine();
                    }
                }

                Console.WriteLine("enter (A) to add a record, or enter (V) to view a record or Enter (D) to delete or Enter (E) to edit");
                ///now as for the input
                string A = Console.ReadLine();
                string V = Console.ReadLine();
                string D = Console.ReadLine();
                string E = Console.ReadLine();



                
            }  
        }
    }
}
