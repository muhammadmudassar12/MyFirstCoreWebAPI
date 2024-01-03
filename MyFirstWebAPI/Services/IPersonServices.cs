namespace MyFirstWebAPI.Model
{
    public interface IPersonServices
    {
        Task<List<Person>> GetAllPersons();
        Task<Person> GetPersonById(int id);
        Task<int> CreatePerson(Person person);
        Task<int> UpdatePerson(Person person);
        Task<int> DeletePerson(int id);


        }
}
