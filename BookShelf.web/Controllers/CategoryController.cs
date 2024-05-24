using BookShelf.web.Data;
using BookShelf.web.Models.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShelf.web.Controllers
{


    
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        
        public IActionResult List()

        {
            
            List<category> objCategoryList=dbContext.Categories.ToList();
            return View(objCategoryList);

        }
    }
}
