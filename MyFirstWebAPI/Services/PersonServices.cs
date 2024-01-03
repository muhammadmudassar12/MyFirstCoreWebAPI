using System.Data.Common;
using System.Data;
using Dapper;
using System.Data.SqlClient;
namespace MyFirstWebAPI.Model
{
    public class PersonServices : IPersonServices
    {
        public async Task<List<Person>> GetAllPersons()
        {
            var query = "SELECT * FROM Person;";

            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                var employees = await connection.QueryAsync<Person>(query);
                return employees.ToList();
            }
        }
        public async Task<Person> GetPersonById(int id)
        {
            var query = $"SELECT * FROM Person where Id ={id}";

            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                var person = await connection.QueryAsync<Person>(query);
                return person.FirstOrDefault();
            }
        }
        public async Task<int> CreatePerson(Person person)
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                var query = $"insert into Person (Name, FatherName, Age) values " +
                                  $"('{person.Name}','{person.FatherName}','{person.Age}');";
                var result = await connection.ExecuteAsync(query);
                return result;
            }
        }
        public async Task<int> UpdatePerson(Person person)
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                var query = $"update Person set Name= '{person.Name}', FatherName = '{person.FatherName}', Age = '{person.Age}' " +
                                  $"where Id ={person.Id}";
                var result = await connection.ExecuteAsync(query);
                return result;
            }
        }
        public async Task<int> DeletePerson(int Id)
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.dbConnectionString))
            {
                var query = $"Delete from Person  " +
                                  $"where Id ={Id}";
                var result = await connection.ExecuteAsync(query);
                return result;
            }
        }
    }
}
