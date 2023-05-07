using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Policy;
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

        // Get: Producers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName", "ProfilePicURL", "Biography")]ProducerModel producer)
        {
            if (!ModelState.IsValid) return View(producer);

            await _service.AddAsync(producer);
            
            return RedirectToAction(nameof(Index));
        }

        // Get: Producers/Edit/ID
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetByIDAsync(id);
            if (producerDetails == null) return View("NotFound");
            
            return View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ID", "FullName", "ProfilePicURL", "Biography")] ProducerModel producer)
        {
            if (!ModelState.IsValid) return View(producer);

            if(id == producer.ID) 
            {
                await _service.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }

            return View(producer);
        }

        // Get: Producers/Delete/ID
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _service.GetByIDAsync(id);
            if (producerDetails == null) return View("NotFound");

            return View(producerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await _service.GetByIDAsync(id);
            if (producerDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
