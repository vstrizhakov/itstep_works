using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FilmsAndGenres.Models
{
    public class CinemaDbCreator : DropCreateDatabaseAlways<CinemaContext>
    {
        protected override void Seed(CinemaContext context)
        {
            context.Genres.Add(new Genre()
            {
                Name = "Комедии"
            });

            context.Genres.Add(new Genre()
            {
                Name = "Трагедии"
            });

            context.Genres.Add(new Genre()
            {
                Name = "Приключения"
            });

            context.Genres.Add(new Genre()
            {
                Name = "Фантастика"
            });

            context.Films.Add(new Film()
            {
                Name = "Фильм 1",
                Year = new DateTime(1993, 1, 1),
                GenreId = 3
            });

            context.Films.Add(new Film()
            {
                Name = "Фильм 2",
                Year = new DateTime(2017, 1, 1),
                GenreId = 0
            });

            context.Films.Add(new Film()
            {
                Name = "Фильм 3",
                Year = new DateTime(2005, 1, 1),
                GenreId = 1
            });

            context.Films.Add(new Film()
            {
                Name = "Фильм 4",
                Year = new DateTime(2007, 1, 1),
                GenreId = 2
            });

            context.Films.Add(new Film()
            {
                Name = "Фильм 5",
                Year = new DateTime(2013, 1, 1),
                GenreId = 0
            });
        }
    }
}