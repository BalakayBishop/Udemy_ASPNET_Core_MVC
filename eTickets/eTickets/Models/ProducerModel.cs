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

        public string ProfilePicURL { get; set; }
        public string FullName { get; set; }
        public string Biography { get; set; }

        // Relationship
        public List<MovieModel> Movies { get; set; }
    }
}
