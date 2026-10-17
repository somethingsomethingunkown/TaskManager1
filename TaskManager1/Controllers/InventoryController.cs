using Microsoft.AspNetCore.Mvc;
using TaskManager1.Data;
using TaskManager1.Models;

namespace TaskManager1.Controllers
{
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        


        public IActionResult Index()
        {
            var tasks = _context.Tasks.ToList();
            return View(tasks);
        }
    }
}
