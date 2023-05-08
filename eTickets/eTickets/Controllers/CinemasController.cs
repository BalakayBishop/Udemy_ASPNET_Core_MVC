using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;

        public CinemasController(ICinemasService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var allCinemas = await _service.GetAllAsync();
            return View(allCinemas);
        }

        // Get: Cinemas/Create
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] CinemaModel cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        // Get: Cinemas/Details/ID
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetail = await _service.GetByIDAsync(id);
            if (cinemaDetail == null) return View("NotFound");

            return View(cinemaDetail);
        }

        // Get: Cinemas/Edit/ID
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetail = await _service.GetByIDAsync(id);
            if (cinemaDetail == null) return View("NotFound");

            return View(cinemaDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Logo,Name,Description")] CinemaModel cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            await _service.UpdateAsync(id, cinema);

            return RedirectToAction(nameof(Index));
        }

        // Get: Cinemas/Delete/ID
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetail = await _service.GetByIDAsync(id);
            if (cinemaDetail == null) return View("NotFound");

            return View(cinemaDetail);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
