 using eTickets.Data;
using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class NewMovieVM
    {
        public int ID { get; set; }

        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Movie Art URL")]
        [Required(ErrorMessage = "Movie cover art URL is required")]
        public string ImageURL { get; set; }
        
        [Display(Name = "Movie Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Movie Start Date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime Start_Date { get; set; }

        [Display(Name = "Movie End Date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime End_Date { get; set; }

        [Display(Name = "Movie Category")]
        [Required(ErrorMessage = "Movie category is required")]
        public MovieCategory MovieCategory { get; set; }

        [Display(Name = "Movie actor(s) is required")]
        [Required(ErrorMessage = "Select one or more actor(s)")]
        public List<int> Actor_IDs { get; set; }

        // Cinema
        [Display(Name = "Select a Cinema")]
        [Required(ErrorMessage = "Cinema is required")]
        public int Cinema_ID { get; set; }

        // Producer
        [Display(Name = "Select a Producer")]
        [Required(ErrorMessage = "Producer is required")]
        public int Producer_ID { get; set; }
    }
}
