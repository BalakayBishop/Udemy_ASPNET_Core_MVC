using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class ActorModel
    {
        [Key]
        public int Actor_ID { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePicURL { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        public string Biography { get; set; }

        // Relationship
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
