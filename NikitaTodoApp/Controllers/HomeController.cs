using Microsoft.AspNetCore.Mvc;
using NikitaTodoApp.Models;
using NikitaTodoApp.Repository.IRepository;
using System.Diagnostics;

namespace NikitaTodoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Todo>? todos = _unitOfWork.Todo.GetAll().ToList();
            return View(todos);
        }

        public IActionResult Details(int id)
        {
            Todo? todo = _unitOfWork.Todo.Get(todo => todo.Id == id);
            return View(todo);
        }

        public IActionResult Upsert(int? id)
        {
            if (id is null || id == 0)
            {
                Todo todo = new();
                return View(todo);
            }
            else
            {
                Todo? todo = _unitOfWork.Todo.Get(todo => todo.Id == id);
                return View(todo);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return View(todo);
            }

            // for create
            if (todo.Id == 0)
            {
                _unitOfWork.Todo.Add(todo);
                _unitOfWork.Save();

                TempData["success"] = $"Todo {todo.Title} is created";
            }
            // for update
            else
            {
                _unitOfWork.Todo.Update(todo);
                _unitOfWork.Save();

                TempData["success"] = $"Todo {todo.Title} is updated";
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Todo? todo = _unitOfWork.Todo.Get(todo => todo.Id == id);
            return View(todo);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteAction(int id)
        {
            Todo? todo = _unitOfWork.Todo.Get(todo => todo.Id == id);
            _unitOfWork.Todo.Remove(todo);
            _unitOfWork.Save();

            TempData["success"] = $"Todo {todo.Title} is deleted";

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Complete(int id)
        {
            Todo? todo = _unitOfWork.Todo.Get(todo => todo.Id == id);

            if (todo.IsCompleted)
                todo.IsCompleted = false;
            else
                todo.IsCompleted = true;

            _unitOfWork.Todo.Update(todo);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
