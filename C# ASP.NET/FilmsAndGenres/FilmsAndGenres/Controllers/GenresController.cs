using FilmsAndGenres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmsAndGenres.Controllers
{
    public class GenresController : BaseController
	{
        public ActionResult Index()
        {
            ViewBag.Genres = dataBase.Genres;
			LoadVisitedFilms();
			return View();
        }


        public ActionResult Add()
        {
			LoadVisitedFilms();
            return View();
		}

        [HttpPost]
        public ActionResult Add(Genre genre)
        {
            dataBase.Genres.Add(genre);
            dataBase.SaveChanges();
            return Redirect("/Genres/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            IEnumerable<Film> filmsInGenre = from film in dataBase.Films
                                             where film.GenreId == id
                                             select film;
            if (filmsInGenre.Count() > 0)
            {
                return Redirect("/Genres/Index");
            }

            Genre genreToDelete = (from genre in dataBase.Genres
                          where genre.Id == id
                          select genre).FirstOrDefault();
            dataBase.Genres.Remove(genreToDelete);
            dataBase.SaveChanges();
            return Redirect("/Genres/Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Genre genreToEdit = (from genre in dataBase.Genres
                                   where genre.Id == id
                                   select genre).FirstOrDefault();
            if (genreToEdit == null)
            {
                return Redirect("/Genres/Index");
            }
            ViewBag.Genre = genreToEdit;
			LoadVisitedFilms();
            return View();
		}

        [HttpPost]
        public ActionResult Edit(Genre genre)
        {
            Genre genreToEdit = (from g in dataBase.Genres
                                 where g.Id == genre.Id
                                 select g).FirstOrDefault();
            genreToEdit.Name = genre.Name;
            dataBase.SaveChanges();
            return Redirect("/Genres/Index");
        }
    }
}