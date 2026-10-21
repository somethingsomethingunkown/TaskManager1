using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FlowAnalysis;
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

  
        public IActionResult Delete()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
