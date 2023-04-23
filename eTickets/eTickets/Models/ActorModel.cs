using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class ActorModel
    {
        // This model needs a unique identifier for this class, but also for table roles

        [Key] // this pk needs the import of DataAnnotations
        public int Actor_ID { get; set; }

        public string ProfilePicURL { get; set; }
        public string FullName { get; set; }
        public string Biography { get; set; }
    }
}
