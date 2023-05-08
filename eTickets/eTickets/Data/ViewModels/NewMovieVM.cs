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
        [Required(ErrorMessage = "Name is required")]
        [Display(Description = "Movie Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Description = "Movie Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Movie cover art URL is required")]
        [Display(Description = "Movie Cover Art URL")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Display(Description = "Movie Price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        [Display(Description = "Movie Start Date")]
        public DateTime Start_Date { get; set; }

        [Required(ErrorMessage = "End date is required")]
        [Display(Description = "Movie End Date")]
        public DateTime End_Date { get; set; }

        [Required(ErrorMessage = "Movie category is required")]
        [Display(Description = "Movie Category")]
        public MovieCategory MovieCategory { get; set; }

        [Required(ErrorMessage = "Select one or more actor(s)")]
        [Display(Description = "Movie actor(s) is required")]
        public List<int> Actor_IDs { get; set; }

        // Cinema
        [Required(ErrorMessage = "Cinema is required")]
        [Display(Description = "Select a Cinema")]
        public int Cinema_ID { get; set; }

        // Producer
        [Required(ErrorMessage = "Producer is required")]
        [Display(Description = "Select a Producer")]
        public int Producer_ID { get; set; }
    }
}
