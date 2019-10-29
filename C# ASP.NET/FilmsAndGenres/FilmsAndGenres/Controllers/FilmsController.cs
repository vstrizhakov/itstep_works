using FilmsAndGenres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmsAndGenres.Controllers
{
    public class FilmsController : BaseController
    {
        public ActionResult Index()
        {
            IEnumerable<FilmForShow> films = from film in dataBase.Films
                                             join genre in dataBase.Genres on film.GenreId equals genre.Id
                                             select new FilmForShow()
                                             {
                                                 Id = film.Id,
                                                 Name = film.Name,
                                                 Year = film.Year.Year.ToString(),
                                                 Genre = genre.Name
                                             };
            ViewBag.Films = films;
			LoadVisitedFilms();
            return View();
		}

        public ActionResult Add()
        {
            ViewBag.Genres = dataBase.Genres;
			LoadVisitedFilms();
            return View();
		}

        [HttpPost]
        public ActionResult Add(FilmForShow filmForShow)
        {
            Genre genre = (from g in dataBase.Genres
                           where g.Name == filmForShow.Genre
                           select g).FirstOrDefault();
            if (genre != null)
            {
                DateTime year = DateTime.Now;
                if (Int32.TryParse(filmForShow.Year, out int yearInt) && yearInt <= 9999 && yearInt >= 1)
                {
                    year = new DateTime(yearInt, 1, 1);
                }

                Film film = new Film();
                film.Id = filmForShow.Id;
                film.Name = filmForShow.Name;
                film.GenreId = genre.Id;
                film.Year = year;

                dataBase.Films.Add(film);
                dataBase.SaveChanges();
            }
            return Redirect("/Films/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Film filmToDelete = (from film in dataBase.Films
                                 where film.Id == id
                                 select film).FirstOrDefault();
            dataBase.Films.Remove(filmToDelete);
            dataBase.SaveChanges();
			LoadVisitedFilms();
            return Redirect("/Films/Index");
		}

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Film filmToEdit = (from film in dataBase.Films
                               where film.Id == id
                               select film).FirstOrDefault();
            if (filmToEdit == null)
            {
                return Redirect("/Films/Index");
            }

            Genre genre = (from g in dataBase.Genres
                           where g.Id == filmToEdit.GenreId
                           select g).FirstOrDefault();

            ViewBag.Film = new FilmForShow()
            {
                Id = filmToEdit.Id,
                Name = filmToEdit.Name,
                Genre = genre.Name,
                Year = filmToEdit.Year.Year.ToString()
            };
            ViewBag.Genres = dataBase.Genres;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(FilmForShow filmForShow)
        {
            Genre genre = (from g in dataBase.Genres
                           where g.Name == filmForShow.Genre
                           select g).FirstOrDefault();
            if (genre != null)
            {
                DateTime year = DateTime.Now;
                if (Int32.TryParse(filmForShow.Year, out int yearInt) && yearInt <= 9999 && yearInt >= 1)
                {
                    year = new DateTime(yearInt, 1, 1);
                }

                Film film = (from f in dataBase.Films
                             where f.Id == filmForShow.Id
                             select f).FirstOrDefault();
                if (film == null)
                {
                    return Redirect("/Films/Index");
                }
                film.Name = filmForShow.Name;
                film.GenreId = genre.Id;
                film.Year = year;

                dataBase.SaveChanges();
            }
            return Redirect("/Films/Index");
        }

		[HttpGet]
		public ActionResult Film(int id)
		{
			FilmForShow film = (from f in dataBase.Films
											 join genre in dataBase.Genres on f.GenreId equals genre.Id
											 where f.Id == id
											 select new FilmForShow()
											 {
												 Id = f.Id,
												 Name = f.Name,
												 Year = f.Year.Year.ToString(),
												 Genre = genre.Name
											 }).FirstOrDefault();
			HttpCookie cookie = null;
			if (Request.Cookies["viewed"] == null)
			{
				cookie = new HttpCookie("viewed", "");
			}
			else
			{
				cookie = Request.Cookies["viewed"];
			}
			List<string> viewed = cookie.Value.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
			viewed.Add(id.ToString());
			viewed = viewed.Distinct().ToList();
			cookie.Value = String.Join("|", viewed.ToArray());

			if (Response.Cookies["viewed"] == null)
			{
				Response.Cookies.Add(cookie);
			}
			else
			{
				Response.Cookies["viewed"].Value = cookie.Value;
			}

			LoadVisitedFilms();
			return View(film);
		}
    }
}