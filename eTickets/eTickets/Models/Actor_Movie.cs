using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Actors_Movies
    {
        public int Movie_ID { get; set; }
        public MovieModel Movie { get; set; }

        public int Actor_ID { get; set; }
        public ActorModel Actor { get; set; }
    }
}
