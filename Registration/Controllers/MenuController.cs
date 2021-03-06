using Microsoft.AspNetCore.Mvc;
using Registration.Contract;
using Registration.Dto;
using System;
using System.Threading.Tasks;

namespace Registration.Controllers
{
    public class MenuController : Controller
    {
        private readonly IEmployeeRepository _employeeRepo;

        public MenuController(IEmployeeRepository employeeRepo)
        {
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

        [HttpPost]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeDto employee)
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
            return View(dbEmployee);
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
        public async Task<IActionResult> Delete(int id)
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
