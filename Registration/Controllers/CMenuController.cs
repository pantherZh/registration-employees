using Microsoft.AspNetCore.Mvc;
using Registration.Contract;
using Registration.Dto;
using System;
using System.Threading.Tasks;

namespace Registration.Controllers
{
    public class CMenuController : Controller
    {
        private readonly ICompanyRepository _companyRepo;

        public CMenuController(ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }

        [HttpGet]
        public async Task<IActionResult> CompanyAsync()
        {
            try
            {
                var companies = await _companyRepo.SelectAll();
                return View(companies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyDto company)
        {
            try
            {
                var createdCompany = await _companyRepo.Insert(company);
                CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);
                return RedirectToAction("Company");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public async Task<ActionResult> EditAsync(int id)
        {
            var dbCompany = await _companyRepo.SelectById(id);
            if (dbCompany == null)
                return NotFound();
            return View(dbCompany);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditCompanyDto company)
        {
            try
            {
                var dbCompany = await _companyRepo.SelectById(id);
                if (dbCompany == null)
                    return NotFound();
                await _companyRepo.Update(id, company);
                return RedirectToAction("Company");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var dbCompany = await _companyRepo.SelectById(id);
                if (dbCompany == null)
                    return NotFound();
                return View(dbCompany);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            try
            {
                var dbCompany = await _companyRepo.SelectById(id);
                if (dbCompany == null)
                    return NotFound();
                await _companyRepo.DeleteById(id);
                return RedirectToAction("Company");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
