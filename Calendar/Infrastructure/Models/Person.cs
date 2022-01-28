namespace Calendar.Infrastructure.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
