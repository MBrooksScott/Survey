using Dapper;
using Microsoft.Extensions.Configuration;
using Survey.Data.Interfaces;
using Survey.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Survey.Data
{
    public class PersonRepo : IPersonRepo
    {
        private string _connectionString;
        public PersonRepo(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("default");
        }

        public Person GetPerson(int Id)
        {
            //SqlConnection connection = new SqlConnection(_connectionString);
            //connection.Open();
            //SqlCommand command = connection.CreateCommand();
            //command.CommandText = "dbo.GetPerson";
            //command.Parameters.Add(new SqlParameter("PersonId", System.Data.SqlDbType.Int) { Value = Id, IsNullable=true });
            //SqlDataReader reader = command.ExecuteReader();
            //Person output = new Person();
            //while (reader.Read())
            //{
            //    output.Id = reader.GetInt32(0);
            //    output.Name = reader.GetString(1);
            //    output.Birthdate = reader.GetDateTime(2);
            //}
            //reader.Close();
            //command.Dispose();
            //connection.Close();
            //connection.Dispose();
            //return output;
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirst<Person>("dbo.GetPerson", new { PersonId = Id }, commandType: System.Data.CommandType.StoredProcedure);
            }

        }

        public IEnumerable<Person> GetPeople(int? PersonId = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Person>("dbo.GetPerson", new { PersonId }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
