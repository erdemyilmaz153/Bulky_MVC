using Bulky.Data;
using Microsoft.AspNetCore.Mvc;
using Bulky.Models;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bulky.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Bulky.Utility;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();

            return View(objCompanyList);
        }
        public IActionResult Upsert(int? id)
        {

            if (id == null || id == 0)
            {
                //create
                return View(new Company());
            }
            else
            {
                //update
                Company companyObj = _unitOfWork.Company.Get(u => u.Id == id);
                return View(companyObj);
            }

        }
        [HttpPost]
        public IActionResult Upsert(Company CommpanyObj)
        {
            if (ModelState.IsValid)
            {

                if (CommpanyObj.Id == 0)
                {
                    _unitOfWork.Company.Add(CommpanyObj);
                }
                else
                {
                    _unitOfWork.Company.Update(CommpanyObj);
                }

                _unitOfWork.Save();
                TempData["success"] = "Company created/updated successfully.";
                return RedirectToAction("Index");
            }
            else
            {
                return View(CommpanyObj);
            }
        }



        #region API CALLS

        [HttpGet]
        public IActionResult GetAll() 
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = objCompanyList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {

            var companyToBeDeleted = _unitOfWork.Company.Get(u=>u.Id == id);
            if (companyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Company.Remove(companyToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success=true, message = "Delete Successful" });
        }

        #endregion

    }
} 
