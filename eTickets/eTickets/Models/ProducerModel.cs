using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class ProducerModel
    {
        [Key] // this pk needs the import of DataAnnotations
        public int Producer_ID { get; set; }

        [Display(Name ="Profile Picture")]
        public string ProfilePicURL { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        public string Biography { get; set; }

        // Relationship
        public List<MovieModel> Movies { get; set; }
    }
}
