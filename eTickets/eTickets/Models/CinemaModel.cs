﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class CinemaModel
    {
        [Key]
        public int Cinema_ID { get; set; }

        public string Logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //Relationship
        public List<MovieModel> Movies { get; set; }
    }
}