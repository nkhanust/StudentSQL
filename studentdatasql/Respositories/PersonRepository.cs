using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using studentdatasql.Models;
using System;
using System.Data;
using System.Data.SqlClient;


namespace studentdatasql.Respositories
{
    public class PersonRepository : IPersonRepository
    {
        //Adding new person to database
        private IConfiguration Configuration;

        public PersonRepository(IConfiguration_configuration)
        {
            Configuration = _configuration;
        }

        //for httpget
        public void GetPerson()
        {

            try
            {
                string Connectionstrings = this.Configuration.GetConnectionString("MyConnection"); // calls appsetting.json and obtaining the connection string
                using (SqlConnection con = new SqlConnection(ConnectionString)) // settign up sql connection
                {
                    con.Open(); //initialising the connection
                    SqlCommand command = new SqlCommand("selectallprersons", con); //calling procedure of selectallprersons that shortcut to select all student database
                    command.CommandType = CommandType.StoredProcedure; // specifying a stored procedure
                    using (SqlDataReader reader = command.ExecuteReader())
                    { //readinng the command
                        while (reader.Read())
                        {
                            Console.WriteLine(String.Format("{0} {1} {2} {3} {4} {5}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5])); //want information to be siplayed in this format
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
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
                    string query = "INSERT INTO dbo.studentdata ([Id], [FirstName], [LastName], [SupervisorId], [BranchId]) VALUES (@Id, @FirstName, @LastName, @SupervisorId, @BranchId);";
                    using (SqlCommand command = new SqlCommand(query, con))
                    {

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



        //for httpput
        public string PutPerson([FromBody] Person person)
        {

            string ConnectionString = this.Configuration.GetConnectionString("MyConnection");

            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    //string query = "UPDATE INTO dbo.studentdata SET NAME = @" +
                    //    "([Id], [FirstName], [LastName], [SupervisorId], [BranchId]) VALUES " +
                    //    "(@Id, @FirstName, @LastName, @SupervisorId, @BranchId);";
                    using (SqlCommand command = new SqlCommand(query, con))
                    {

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
        public string DeletePerson(Person person)
        {
            string ConnectionString = this.Configuration.GetConnectionString("MyConnection");

            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                   con.Open();
                   string query = "DELETE FROM dbo.studentdata WHERE [Id] = @id"
                   using (SqlCommand command = new SqlCommand(query, con))
                   {

                    command.Parameters.Add("@Id", SqlDbType.Int).Value = person.Id;
                    int rowDeleted = command.ExecuteNonQuery();

                        if (rowDeleted > 0)
                        {
                            return "Working. WELLDONE";

                        }

                   }
                }
            }
        }


    }
}
