using System;
using System.Text;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using DataHelperLibrary;
using DataHelperLibrary.Models;

namespace DapperCrudNorthwind
{
    class DataAccess
    {

        /// <summary>
        /// [1] SELECT - All customers from customers table
        /// </summary>       


        public List<CustomerModel> GetAllCustomers()
        {
            using IDbConnection connection = new SqlConnection(Tools.CnnValue("Northwind"));
            {
                return connection.Query<CustomerModel>($"select * from Customers").ToList();                
            }
        }

        /// <summary>
        /// [2] SELECT (with parameter usage) - All customers from city of X from customers table
        /// </summary>

        public List<CustomerModel> GetCustomerByCity(string city)
        {
            using IDbConnection connection = new SqlConnection(Tools.CnnValue("Northwind"));
            {
                return connection.Query<CustomerModel>($"select * from Customers where City = '{ city }'").ToList();
                //return connection.Query<Person>("dbo.People_GetByLastName @LastName", new { City = city }).ToList();
            }
        }

        /// <summary>
        /// [3] INSERT (with parameter usage) - A full customer account
        /// </summary>

        public void InsertCustomer(string customerId, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax)
        {
            using IDbConnection connection = new SqlConnection(Tools.CnnValue("Northwind"));
            {
                // create list of people to be inserted
                List<CustomerModel> customer = new List<CustomerModel>();
                customer.Add(new CustomerModel
                { 
                        CustomerId = customerId, 
                        CompanyName = companyName, 
                        ContactName = contactName, 
                        ContactTitle = contactTitle,
                        Address = address,
                        City = city,
                        Region = region,
                        PostalCode = postalCode,
                        Country = country,
                        Phone = phone,
                        Fax = fax

                    }
                );                
                connection.Execute("dbo.usp_Customer_Insert @CustomerId, @CompanyName, @contactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax", customer);
            }
        }
    }
}
