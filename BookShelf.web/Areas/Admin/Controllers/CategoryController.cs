using BookShelf.DataAccess.Repository.IRepository;
using BookShelf.DataAccess.Data;
using BookShelf.DataAccess.Repository;
using BookShelf.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookShelf.Utility;


namespace BookShelf.web.Areas.Admin.Controllers
{
    [Area("Admin")]

   /* [Authorize(Roles= SD.Role_Admin)]*/
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult List()

        {

            List<category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
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
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Category Created Successfully";
                return RedirectToAction("List", "Category");


            }

            return View();
        }

        public IActionResult Edit(int? id)
        {

            if (id == 0 || id == null)
            {
                return NotFound();

            }
            category? categoryFromDb = _unitOfWork.Category.GET(u => u.Id == id);
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
                _unitOfWork.Category.update(obj);
                _unitOfWork.Save();
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
            category? categoryFromDb = _unitOfWork.Category.GET(u => u.Id == id);

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

            category? obj = _unitOfWork.Category.GET(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Category Deleted Successfully";
            return RedirectToAction("List", "Category");





        }







    }


}

