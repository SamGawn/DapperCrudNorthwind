using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataHelperLibrary.Models;

namespace DapperCrudNorthwind
{
    class Program
    {
        static void Main(string[] args)
        {

            /// <summary>
            /// [1] SELECT - All customers from customers table
            /// </summary>   

            //DataAccess db = new DataAccess();
            //var output = db.GetAllCustomers();
            //Console.WriteLine(output.Count);
            //for (int i = 0; i < output.Count; i++)
            //{
            //    Console.WriteLine(output[i].CompanyName);
            //}
            //Console.ReadLine();

            /// <summary>
            /// [2] SELECT (with parameter usage) - All customers from city of X from customers table
            /// </summary>


            //DataAccess db = new DataAccess();
            //var output = db.GetCustomerByCity("London");
            //Console.WriteLine(output.Count);
            //for (int i = 0; i < output.Count; i++)
            //{
            //    Console.WriteLine(output[i].CompanyName);
            //}
            //Console.ReadLine();


            /// <summary>
            /// [3] INSERT (with parameter usage) - All customers from city of X from customers table
            /// </summary>

            DataAccess db = new DataAccess();
            db.InsertCustomer("GAWNS", "Chelsea FC", "Sam Gawn", "AppSupport", "Imperial Palace", "Borehamwood", "UK", "SG18 OLM", "England", "01903785914", "unknown");    
        }
    }
}
