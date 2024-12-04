using BookShelf.DataAccess.Repository.IRepository;
using BookShelf.Models;
using BookShelf.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BookShelf.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    /* [Authorize(Roles= SD.Role_Admin)]*/
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IActionResult List()

        {

            List<company> objCompanyList = _unitOfWork.Company.GetAll().ToList();


            return View(objCompanyList);

        }

        public IActionResult Upsert(int? id)
        {

            if (id == 0 || id == null)
            {
                //create
                return View(new company());
            }
            else
            {
                //update
                company companyObj = _unitOfWork.Company.GET(u => u.Id == id);
                return View(companyObj);

            }


        }

        [HttpPost]
        public IActionResult Upsert(company companyObj)
        {

            if (ModelState.IsValid)
            {


                if (companyObj.Id == 0)
                {
                    _unitOfWork.Company.Add(companyObj);
                    TempData["Success"] = "Company Created Successfully";

                }
                else
                {
                    _unitOfWork.Company.update(companyObj);
                    TempData["Success"] = "Company Updated Successfully";
                }

                _unitOfWork.Save();

                return RedirectToAction("List", "Company");


            }
            else
            {


                return View(companyObj);
            }

        }




        #region API CALLS


        [HttpGet]
        public IActionResult GetAll(int id)
        {
            List<company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = objCompanyList });
        }


        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var CompanyToBeDeleted = _unitOfWork.Company.GET(u => u.Id == id);
            if (CompanyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error While deleting" });
            }


            _unitOfWork.Company.Remove(CompanyToBeDeleted);
            _unitOfWork.Save();


            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion


    }
}
