using BookShelf.DataAccess.Repository;
using BookShelf.DataAccess.Repository.IRepository;
using BookShelf.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookShelf.web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties:"category");
            return View(productList);
        }
        public IActionResult Details(int productId)
        {
            Product product = _unitOfWork.Product.GET(u => u.Id == productId, includeProperties: "category");
            return View(product);
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
