using System;
using System.ComponentModel.DataAnnotations;

namespace VidlyReborn.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Genre Genre { get; set; }
        [Required]
        public int GenreId { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }
        public DateTime? DateAdded { get; set; }
        [Required]
        [Range(1,20)]
        public int NumberInStock { get; set; }

    }
}