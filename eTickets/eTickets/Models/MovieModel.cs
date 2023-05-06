﻿ using eTickets.Data;
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
        public int ID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }

        public double Price { get; set; }

        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }

        public MovieCategory MovieCategory { get; set; }

        // Relationship
        public List<Actor_Movie> Actors_Movies { get; set; }

        // Cinema
        public int CinemaID { get; set; }
        [ForeignKey("Cinema_ID")]
        public CinemaModel Cinema { get; set; }

        // Producer
        public int ProducerID { get; set; }
        [ForeignKey("Producer_ID")]
        public ProducerModel Producer { get; set; }
    }
}
