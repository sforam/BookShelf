using BookShelf.DataAccess.Repository.IRepository;
using BookShelf.Models;
using BookShelf.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

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
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()

            };
            return View(productVM);

        }

        [HttpPost]
        public IActionResult Create(ProductVM productVM)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(productVM.Product);
                _unitOfWork.Save();
                TempData["Success"] = "Product Created Successfully";
                return RedirectToAction("List", "Product");


            }
            else
            {

                productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                
                return View(productVM);
            }
            
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
