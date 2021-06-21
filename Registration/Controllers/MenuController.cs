using Microsoft.AspNetCore.Mvc;
using Registration.Contract;
using Registration.Dto;
using System;
using System.Threading.Tasks;

namespace Registration.Controllers
{
    public class MenuController : Controller
    {
        private readonly ICompanyRepository _companyRepo;
        private readonly IEmployeeRepository _employeeRepo;

        public MenuController(ICompanyRepository companyRepo, IEmployeeRepository employeeRepo)
        {
            _companyRepo = companyRepo;
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeAsync()
        {
            try
            {
                var employees = await _employeeRepo.Include();
                return View(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> CompanyAsync()
        {
            dynamic companies;
            try
            {
                companies = await _companyRepo.GetCompanies();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return View(companies);
        }

        [HttpPost]
        public ActionResult Add()
        {
            return View("~/Views/Menu/AddEmployee.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto employee)
        {
            try
            {
                var createdEmployee = await _employeeRepo.Insert(employee);
                CreatedAtRoute("EmployeeById", new { id = createdEmployee.Id }, createdEmployee);
                return RedirectToAction("Employee");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public async Task<ActionResult> EditAsync(int id)
        {
            var dbEmployee = await _employeeRepo.SelectById(id);
            if (dbEmployee == null)
                return NotFound();
            return View("~/Views/Menu/EditEmployee.cshtml", dbEmployee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditEmployeeDto employee)
        {
            try
            {
                var dbEmployee = await _employeeRepo.SelectById(id);
                if (dbEmployee == null)
                    return NotFound();
                await _employeeRepo.Update(id, employee);
                return RedirectToAction("Employee");
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
                var dbEmployee = await _employeeRepo.SelectById(id);
                if (dbEmployee == null)
                    return NotFound();
                return View(dbEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var dbEmployee = await _employeeRepo.SelectById(id);
                if (dbEmployee == null)
                    return NotFound();
                await _employeeRepo.DeleteById(id);
                return RedirectToAction("Employee");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
