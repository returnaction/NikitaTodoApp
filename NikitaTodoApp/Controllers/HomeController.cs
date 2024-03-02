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
