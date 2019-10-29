using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmsAndGenres.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public int GenreId { get; set; }
    }

    public class FilmForShow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
    }
}