using Calendar.Infrastructure.Persistance;
using Calendar.Pages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calendar.Test
{
    public class CalendarTests
    {
        [Fact]
        public async Task WhenMonthIsNull_ExpectEmptyAppointmentList()
        {
            using var db = new AppDbContext(Utilities.TestDbContextOptions());
            DatabaseInitializer.Initialize(db);

            var calendarModel = new CalendarModel(db);

            await calendarModel.OnGetAsync(null);

            Assert.Empty(calendarModel.AppointmentList);
        }

        [Fact]
        public async Task WhenMonthIsNotNull_ExpectAppointmentListHasAppointment()
        {
            using var db = new AppDbContext(Utilities.TestDbContextOptions());
            DatabaseInitializer.Initialize(db);

            var calendarModel = new CalendarModel(db);

            await calendarModel.OnGetAsync(3);

            Assert.Single(calendarModel.AppointmentList);
            Assert.Equal(4, calendarModel.AppointmentList[0].Attendees.Count);
        }
    }
}
