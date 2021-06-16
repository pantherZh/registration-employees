using Microsoft.AspNetCore.Mvc;
using Registration.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Controllers
{
    //[Route("api/companies")]
    //[ApiController]
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
                //log error
                return StatusCode(500, ex.Message);
            }
            return View(companies);
        }
    }
}
