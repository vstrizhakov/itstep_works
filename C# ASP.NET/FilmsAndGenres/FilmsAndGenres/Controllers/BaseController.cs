using FilmsAndGenres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmsAndGenres.Controllers
{
	public class BaseController : Controller
	{
        protected CinemaContext dataBase = new CinemaContext();

		protected void LoadVisitedFilms()
		{
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
			List<FilmForShow> films = new List<FilmForShow>();
			foreach (string view in viewed)
			{
				FilmForShow f = (from film in dataBase.Films
								 join genre in dataBase.Genres on film.GenreId equals genre.Id
								 where film.Id.ToString() == view
									 select new FilmForShow()
									 {
										 Id = film.Id,
										 Name = film.Name,
										 Year = film.Year.Year.ToString(),
										 Genre = genre.Name
									 }).FirstOrDefault();
				films.Add(f);
			}
			ViewBag.ViewedFilms = films;
		}
	}
}