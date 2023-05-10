using eTickets.Controllers;
using eTickets.Models;
using System.Collections.Generic;

namespace eTickets.Data.ViewModels
{
    public class NewMovieDropDownVM
    {
        public NewMovieDropDownVM()
        {
            Producers = new List<ProducerModel>();
            Cinemas = new List<CinemaModel>();
            Actors = new List<ActorModel>();
        }

        public List<ProducerModel> Producers { get; set; }
        public List<CinemaModel> Cinemas { get; set; }
        public List<ActorModel> Actors { get; set; }
    }
}
