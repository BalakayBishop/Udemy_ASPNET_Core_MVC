﻿using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;

        public ProducersController(IProducersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAllAsync();
            return View(allProducers);
        }

        // Get: Producers/details/id
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetByIDAsync(id);
            if (producerDetails == null) return View("NotFound");

            return View(producerDetails);
        }
    }
}
