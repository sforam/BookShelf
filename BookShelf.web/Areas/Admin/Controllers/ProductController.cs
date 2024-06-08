using BookShelf.DataAccess.Repository.IRepository;
using BookShelf.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.web.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult List()

        {

            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
            return View(objProductList);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product obj)
        {

           /* if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "DisplayOrder cannot exactly match the name");
            }
*/



            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Product Created Successfully";
                return RedirectToAction("List", "Product");


            }

            return View();
        }

        public IActionResult Edit(int? id)
        {

            if (id == 0 || id == null)
            {
                return NotFound();

            }
            Product? ProductFromDb = _unitOfWork.Product.GET(u => u.Id == id);
            /*   category? categoryFromDb1 = dbContext.Categories.FirstOrDefault(u=>u.Id==id);
               category? categoryFromDb2 = dbContext.Categories.Where(u => u.Id == id).FirstOrDefault();*/
            if (ProductFromDb == null)
            {
                return NotFound();
            }


            return View(ProductFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {


            if (ModelState.IsValid)
            {
                _unitOfWork.Product.update(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Product updated Successfully";
                return RedirectToAction("List", "Product");


            }

            return View();
        }

        public IActionResult Delete(int? id)
        {

            if (id == 0 || id == null)
            {
                return NotFound();

            }
            Product? ProductFromDb = _unitOfWork.Product.GET(u => u.Id == id);

            /*   category? categoryFromDb1 = dbContext.Categories.FirstOrDefault(u=>u.Id==id);
               category? categoryFromDb2 = dbContext.Categories.Where(u => u.Id == id).FirstOrDefault();*/
            if (ProductFromDb == null)
            {
                return NotFound();
            }


            return View(ProductFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {

            Product? obj = _unitOfWork.Product.GET(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Product Deleted Successfully";
            return RedirectToAction("List", "Product");





        }





    }
}
