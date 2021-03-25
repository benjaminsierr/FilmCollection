using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
//Category
//Title
//Year
//Director
//Rating
//Edited
//Lent To:
//Notes
namespace FilmCollection.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Category { get; set; }
        [Required(ErrorMessage = "This field is required")]
        //[RegularExpression("^((?!Independence Day).)*$", ErrorMessage = "Independence Day is not a Valid Movie")]
        public string Title { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int Year { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Director { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Rating { get; set; }
        public bool? Edited { get; set; }
        public string LentTo { get; set; }
        public string Notes { get; set; }


    }
}
