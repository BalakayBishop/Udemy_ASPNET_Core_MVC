 using eTickets.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class MovieModel
    {
        [Key]
        public int Movie_ID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }

        public double Price { get; set; }

        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }

        // using the custom enum from /data/MovieCategory.cs
        public MovieCategory MovieCategory { get; set; }

        // Relationship
        public List<Actor_Movie> Actors_Movies { get; set; }

        // Cinema
        public int Cinema_ID { get; set; }

        [ForeignKey("Cinema_ID")]
        public CinemaModel Cinema { get; set; }

        // Producer
        public int Producer_ID { get; set; }

        [ForeignKey("Producer_ID")]
        public ProducerModel Producer { get; set; }
    }
}
