using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TaskManager1.Data;
using TaskManager1.Models;


namespace TaskManager1.Controllers
{
    public class TasksController : Controller
    {

        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }




        public IActionResult Index()
        {
            var tasks = _context.Tasks.ToList();


            return View(tasks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskModel task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

       
    }
}
