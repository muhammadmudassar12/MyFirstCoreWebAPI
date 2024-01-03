namespace MyFirstWebAPI.Model
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public string FatherName { get; set; }
        public int Age { get; set; }
    }
}
