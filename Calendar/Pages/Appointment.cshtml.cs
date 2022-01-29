using Calendar.Application.Models;
using Calendar.Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Pages
{
    public class AppointmentModel : PageModel
    {
        private readonly AppDbContext Context;

        public List<Appointment> AppointmentList { get; set; } = new List<Appointment>();

        public Appointment Appointment { get; set; }

        public List<string> MonthList { get; set; }

        public AppointmentModel(AppDbContext context)
        {
            Context = context;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            MonthList = new List<string> { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

            Appointment = await Context.Appointment.FindAsync(id);

            AppointmentList = await Context.Appointment.Include(a => a.Attendees).Where(a => a.Date.Month == Appointment.Date.Month).ToListAsync();

            return Page();
        }
    }
}
