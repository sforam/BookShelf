using BookShelf.web.Data;
using BookShelf.web.Models.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(category obj)
        {

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "DisplayOrder cannot exactly match the name");
            }




            if (ModelState.IsValid)
            {
                dbContext.Categories.Add(obj);
                dbContext.SaveChanges();
                return RedirectToAction("List", "Category");


            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {

            if(id==0 || id == null)
            {
                return NotFound();

            }
            category? categoryFromDb = dbContext.Categories.Find(id);
         /*   category? categoryFromDb1 = dbContext.Categories.FirstOrDefault(u=>u.Id==id);
            category? categoryFromDb2 = dbContext.Categories.Where(u => u.Id == id).FirstOrDefault();*/
            if (categoryFromDb == null)
            {
                return NotFound();
            }


            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(category obj)
        {

         
            if (ModelState.IsValid)
            {
                dbContext.Categories.Update(obj);
                dbContext.SaveChanges();
                return RedirectToAction("List", "Category");


            }

            return View(obj);
        }

    }


}

