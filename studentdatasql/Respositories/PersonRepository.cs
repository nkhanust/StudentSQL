using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using studentdatasql.Interfaces;
using studentdatasql.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace studentdatasql.Respositories
{
    public class PersonRepository : IPersonRepository
    {
        //Adding new person to database
        private IConfiguration Configuration;
        List<string> collectionOfPersons = new List<string>();

        public PersonRepository(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        //for httpget
        public List<string> GetPersons()
        {
            string tempor;
            try
            {
                string connectionString = this.Configuration.GetConnectionString("MyConnection");      // calls appsetting.json and obtaining the connection string
                using (SqlConnection con = new SqlConnection(connectionString))                        // settign up sql connection
                {
                    con.Open();                                                                        //initialising the connection
                    SqlCommand command = new SqlCommand("selectallpersons", con);                      //calling procedure of selectallprersons that shortcut to select all student database
                    command.CommandType = CommandType.StoredProcedure;                                 //specifying a stored procedure
                    using (SqlDataReader reader = command.ExecuteReader())
                    {    
                        while (reader.Read())
                        {
                            tempor = (String.Format("{0} {1} {2} {3} {4}", reader[0], reader[1], reader[2], reader[3], reader[4]));
                            collectionOfPersons.Add(tempor);
                        }
                    }

                    con.Close();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return collectionOfPersons;
        }

        //for httppost
        public string PostPerson(Person person)
        {
            string ConnectionString = this.Configuration.GetConnectionString("MyConnection");
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("postallpersons", con);
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = person.FirstName;
                        command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = person.LastName;
                        command.Parameters.Add("@SupervisorId", SqlDbType.Int).Value = person.SupervisorId;
                        command.Parameters.Add("@BranchId ", SqlDbType.Int).Value = person.BranchId;

                        int rowAdded = command.ExecuteNonQuery();
                        if (rowAdded > 0)
                        {
                            return "Working. WELLDONE";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return "NOT WORKING. FIX IT. idk why";
        }



        //for httpput
        public string PutPerson([FromBody] Person person)
        {
            string ConnectionString = this.Configuration.GetConnectionString("MyConnection");

            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("putallpersons", con);
                   
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@Id", SqlDbType.Int).Value = person.Id;
                        command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = person.FirstName;
                        command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = person.LastName;
                        command.Parameters.Add("@SupervisorId", SqlDbType.Int).Value = person.SupervisorId;
                        command.Parameters.Add("@BranchId ", SqlDbType.Int).Value = person.BranchId;

                        int rowAdded = command.ExecuteNonQuery();
                        if (rowAdded > 0)
                        {
                            return "Working. WELLDONE";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return "NOT WORKING. FIX IT. idk why";
        }




        //for httpdelete
        public string DeletePerson( int Id) 
        {
            string ConnectionString = this.Configuration.GetConnectionString("MyConnection");

            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("deleteallpersons", con);
                  
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                        int rowDeleted = command.ExecuteNonQuery();

                        if (rowDeleted > 0)
                        {
                            return "Working. WELLDONE";

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return "NOT WORKING. FIX IT. idk why";

        }

    }
}   
