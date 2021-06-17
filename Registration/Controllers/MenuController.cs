using Microsoft.AspNetCore.Mvc;
using Registration.Contract;
using Registration.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
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
            dynamic employees;
            try
            {
                employees = await _employeeRepo.GetEmployees();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
            return View(employees);
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
        public async Task<IActionResult> CreateEmployee(EmployeeForCreationDto employee)
        {
            try
            {
                var createdEmployee = await _employeeRepo.CreateEmployee(employee);
                return CreatedAtRoute("EmployeeById", new { id = createdEmployee.Id }, createdEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Edit()
        {
            return View("~/Views/Menu/EditEmployee.cshtml");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, EmployeeForEditDto employee)
        {
            try
            {
                var dbEmployee = await _employeeRepo.GetEmployee(id);
                if (dbEmployee == null)
                    return NotFound();
                await _employeeRepo.UpdateEmployee(id, employee);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteAsync()
        {
            return View("~/Views/Menu/DeleteEmployee.cshtml");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var dbEmployee = await _employeeRepo.GetEmployee(id);
                if (dbEmployee == null)
                    return NotFound();
                await _employeeRepo.DeleteEmployee(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
