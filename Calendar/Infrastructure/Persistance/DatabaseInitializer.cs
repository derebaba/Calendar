using Calendar.Application.Models;

namespace Calendar.Infrastructure.Persistance
{
    public static class DatabaseInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            List<Person> personList = new List<Person>
            {
                new Person
                {
                    Id = 1,
                    Name = "Erdem"
                },
                new Person
                {
                    Id = 2,
                    Name = "John"
                },
                new Person
                {
                    Id = 3,
                    Name = "Alice"
                }
            };

            context.Person.AddRange(personList);

            Appointment app = new Appointment
            {
                Id = 1,
                Organizer = "Erdem",
                Subject = "Fun",
                Date = new DateTime(2022, 2, 1, 12, 0, 0),
                Attendees = personList
            };

            //personList.ForEach(p => p.Appointments.Add(app));

            context.Appointment.Add(app);

            personList = new List<Person>
            {
                new Person
                {
                    Id = 4,
                    Name = "Name1"
                },
                new Person
                {
                    Id = 5,
                    Name = "Name2"
                }
            };

            context.Person.AddRange(personList);

            app = new Appointment
            {
                Id = 2,
                Organizer = "Boss",
                Subject = "Meeting",
                Date = new DateTime(2022, 2, 15, 14, 20, 0),
                Attendees = personList
            };

            //personList.ForEach(p => p.Appointments.Add(app));

            context.Appointment.Add(app);

            personList = new List<Person>
            {
                new Person
                {
                    Id = 6,
                    Name = "Monkey"
                },
                new Person
                {
                    Id = 7,
                    Name = "Elephant"
                },
                new Person
                {
                    Id = 8,
                    Name = "Giraffe"
                }
            };

            context.Person.AddRange(personList);

            app = new Appointment
            {
                Id = 3,
                Organizer = "Lion",
                Subject = "Forest",
                Date = new DateTime(2022, 2, 22, 18, 30, 0),
                Attendees = personList
            };

            //personList.ForEach(p => p.Appointments.Add(app));

            context.Appointment.Add(app);

            personList = new List<Person>
            {
                new Person
                {
                    Id = 9,
                    Name = "Father"
                },
                new Person
                {
                    Id = 10,
                    Name = "Mother"
                },
                new Person
                {
                    Id = 11,
                    Name = "Brother"
                },
                new Person
                {
                    Id = 12,
                    Name = "Sister"
                }
            };

            context.Person.AddRange(personList);

            app = new Appointment
            {
                Id = 4,
                Organizer = "Me",
                Subject = "Family",
                Date = new DateTime(2022, 3, 22, 4, 45, 0),
                Attendees = personList
            };

            //personList.ForEach(p => p.Appointments.Add(app));

            context.Appointment.Add(app);

            context.SaveChanges();
        }
    }
}
