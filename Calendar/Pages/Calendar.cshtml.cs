using Calendar.Infrastructure.Models;
using Calendar.Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Calendar.Pages
{
    public class CalendarModel : PageModel
    {
        private readonly AppDbContext Context;

        public List<Appointment> AppointmentList { get; set; } = new List<Appointment>();

        public List<string> MonthList { get; set; }

        public int? Month { get; set; }

        public CalendarModel(AppDbContext context)
        {
            Context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? month)
        {
            MonthList = new List<string> { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            Month = month;

            if (month.HasValue)
            {
                AppointmentList = await Context.Appointment.Where(a => a.Date.Month == month).ToListAsync();
            }

            return Page();
        }
    }
}
