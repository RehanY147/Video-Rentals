using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodOrder.Models {
    public class Movie {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public Genre Genre { get; set; }

        [Display(Name="Genre")]
        public byte GenreId { get; set; }

        [Display(Name="Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name="Number In Stock")]
        [Required]
        [Range(1,10)]
        public byte NumberInStock { get; set; }
    }
}