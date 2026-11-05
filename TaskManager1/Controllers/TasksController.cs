using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FlowAnalysis;
using TaskManager1.Data;
using TaskManager1.Models;
using Microsoft.AspNetCore.Authorization;


namespace TaskManager1.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {

        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet("Home/AccessDenied")]
        public IActionResult DenyAccess()
        {
            ViewData["ErrorMessage"] = "You do not have the required administrative role to access this function.";
            return View();
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
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskModel task)
        {
            if (task != null && ModelState.IsValid)
            {

                _context.Tasks.Add(task);
                _context.SaveChanges();


                TempData["SuccessMessage"] = "Your task was saved!";


                return RedirectToAction("Index");
            }

            return View(task);
        }



        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Edit(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Edit(TaskModel task)
        {
            if (task != null && ModelState.IsValid)
            {
                _context.Tasks.Update(task);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Your task was updated!";

                return RedirectToAction("Index");
            }

            return View(task);
        }

  



        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Task deleted!";

            }
            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult CompleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);

     

                _context.SaveChanges();
                TempData["SuccessMessage"] = $"Task {id} was marked as complete and removed!";
            }
            return RedirectToAction("Index");
        }

    }
}
