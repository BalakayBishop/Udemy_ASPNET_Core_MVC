using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Create()
        {
            return View();
        }


    }
}
