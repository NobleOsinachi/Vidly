using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
                        
        public virtual Genre Genre { get; set; }
        public byte GenreId { get; set; }
        [Required]
        [Display(Name = "Genres")]

        [DataType(DataType.DateTime)]
        public DateTime? DateAdded { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public byte? NumberInStock { get; set; }

        //[Phone]public string PhoneNumber { get; set; }
        //[Url] public string Website { get; set; }
    }
}

