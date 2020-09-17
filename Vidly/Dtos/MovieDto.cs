using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public GenreDto Genre { get; set; }

        public byte GenreId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? DateAdded { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 20)]
        public byte? NumberInStock { get; set; }
    }
}