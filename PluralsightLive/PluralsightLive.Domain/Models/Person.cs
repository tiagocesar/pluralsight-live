namespace PluralsightLive.Domain.Models
{
    public abstract class Person
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string Email { get; set; }
    }
}