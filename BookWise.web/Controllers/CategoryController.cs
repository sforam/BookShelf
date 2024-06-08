
using BookWise.DataAccess.Data;
using BookWise.DataAccess.Repository.IRepository;
using BookWise.Models;
using Microsoft.AspNetCore.Mvc;


namespace BookWise.web.Controllers
{


    
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository dbContext)
        {
            this._categoryRepo = dbContext;
        }
        public IActionResult List()

        {
            
            List<category> objCategoryList = _categoryRepo.GetAll().ToList();
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
				_categoryRepo.Add(obj);
				_categoryRepo.Save();
                TempData["Success"] = "Category Created Successfully";
                return RedirectToAction("List", "Category");


            }

            return View();
        }

        public IActionResult Edit(int? id)
        {

            if(id==0 || id == null)
            {
                return NotFound();

            }
            category? categoryFromDb = _categoryRepo.Get(u => u.Id == id);
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
				_categoryRepo.Update(obj);
				_categoryRepo.Save();
				TempData["Success"] = "Category updated Successfully";
				return RedirectToAction("List", "Category");


            }

            return View();
        }

        public IActionResult Delete(int? id)
        {

            if (id == 0 || id == null)
            {
                return NotFound();

            }
            category? categoryFromDb = _categoryRepo.Get(u => u.Id == id);
			/*   category? categoryFromDb1 = dbContext.Categories.FirstOrDefault(u=>u.Id==id);
               category? categoryFromDb2 = dbContext.Categories.Where(u => u.Id == id).FirstOrDefault();*/
			if (categoryFromDb == null)
            {
                return NotFound();
            }


            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {

            category? obj = _categoryRepo.Get(u => u.Id == id);
			if (obj == null)
            {
                return NotFound();
            }
			_categoryRepo.Remove(obj);
			_categoryRepo.Save();
			    TempData["Success"] = "Category Deleted Successfully";
			    return RedirectToAction("List", "Category");


            

            
        }







    }


}

