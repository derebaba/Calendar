namespace Calendar.Infrastructure.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public string Organizer { get; set; }

        public string Subject { get; set; }

        public List<Person> Attendees { get; set; }

        public DateTime Date { get; set; }
    }
}
