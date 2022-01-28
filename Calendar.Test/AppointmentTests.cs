using Calendar.Infrastructure.Persistance;
using Calendar.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calendar.Test
{
    public class AppointmentTests
    {
        [Fact]
        public async Task WhenAppointmentIdDoesNotExist_ExpectThrowsException()
        {
            using var db = new AppDbContext(Utilities.TestDbContextOptions());
            DatabaseInitializer.Initialize(db);

            var appointmentModel = new AppointmentModel(db);

            await Assert.ThrowsAsync<InvalidOperationException>(() => appointmentModel.OnGetAsync(-1));
        }
    }
}
