using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class CinemasService : EntityBaseRepository<CinemaModel>, ICinemasService
    {
        public CinemasService(AppDbContext context) : base(context) { }
    }
}
