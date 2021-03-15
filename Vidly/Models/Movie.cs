using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; private set; }

        [Required, StringLength(byte.MaxValue)]
        public string Name { get; set; }

        public virtual Genre Genre { get; set; }
        [Required, Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateAdded { get; set; }

        [Required, Display(Name = "Release Date"), DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        [Required, Display(Name = "Number In Stock"), Range(1, 20)]
        public byte? NumberInStock { get; set; }

        public byte? NumberAvailable { get; set; }

        //[Phone]public string PhoneNumber { get; set; }
        //[Url] public string Website { get; set; }
    }
}

