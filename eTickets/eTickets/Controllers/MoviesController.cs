using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            return View(allMovies);
        }

        // Get: Movies/Details/ID
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _service.GetMovieIDAsync(id);
            return View(movieDetail);
        }

        // Get: Movies/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewMovieDropDownsValues();

            ViewBag.Cinema_ID = new SelectList(movieDropdownsData.Cinemas, "ID", "Name");
            ViewBag.Producer_ID = new SelectList(movieDropdownsData.Producers, "ID", "FullName");
            ViewBag.Actor_ID = new SelectList(movieDropdownsData.Actors, "ID", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if(!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropDownsValues();
                ViewBag.Cinema_ID = new SelectList(movieDropdownsData.Cinemas, "ID", "Name");
                ViewBag.Producer_ID = new SelectList(movieDropdownsData.Producers, "ID", "FullName");
                ViewBag.Actor_ID = new SelectList(movieDropdownsData.Actors, "ID", "FullName");
                return View(movie);
            }

            await _service.AddNewMovieAsync(movie);
            
            return RedirectToAction(nameof(Index));
        }

        // Get: Movies/Edit/ID
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieIDAsync(id);
            if(movieDetails == null) return View("NotFound");

            var response = new NewMovieVM()
            {
                ID = movieDetails.ID,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                Start_Date = movieDetails.Start_Date,
                End_Date = movieDetails.End_Date,
                MovieCategory = movieDetails.MovieCategory,
                Cinema_ID = movieDetails.Cinema_ID,
                Producer_ID = movieDetails.Producer_ID,
                Actor_IDs = movieDetails.Actors_Movies.Select(n => n.Actor_ID).ToList(),
                ImageURL = movieDetails.ImageURL
            };

            var movieDropdownsData = await _service.GetNewMovieDropDownsValues();

            ViewBag.Cinema_ID = new SelectList(movieDropdownsData.Cinemas, "ID", "Name");
            ViewBag.Producer_ID = new SelectList(movieDropdownsData.Producers, "ID", "FullName");
            ViewBag.Actor_ID = new SelectList(movieDropdownsData.Actors, "ID", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.ID) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropDownsValues();
                ViewBag.Cinema_ID = new SelectList(movieDropdownsData.Cinemas, "ID", "Name");
                ViewBag.Producer_ID = new SelectList(movieDropdownsData.Producers, "ID", "FullName");
                ViewBag.Actor_ID = new SelectList(movieDropdownsData.Actors, "ID", "FullName");
                return View(movie);
            }

            await _service.UpdateMovieAsync(movie);

            return RedirectToAction(nameof(Index));
        }
    }
}
