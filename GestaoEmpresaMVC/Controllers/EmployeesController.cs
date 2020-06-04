using GestaoEmpresaMVC.Data;
using GestaoEmpresaMVC.Models;
using GestaoEmpresaMVC.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GestaoEmpresaMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly GestaoEmpresaMVCContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public EmployeesController(GestaoEmpresaMVCContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _webHostEnvironment = hostEnvironment;

        }

        // GET: Employees
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        
        {

            ViewBag.NameSortParm = sortOrder == "name_desc" ? "name_asc" : "name_desc";
            ViewBag.GenderSortParm = sortOrder == "gender_asc" ? "gender_desc" : "gender_asc";
            ViewBag.DepartmentSortParm = sortOrder == "department_asc" ? "department_desc" : "department_asc";

            var employees = from e in _context.Employee.Include(d => d.Department) select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                //A caixa de texto permite que você insira uma cadeia de
                //caracteres a ser pesquisada nos campos nome e sobrenome.
                employees = employees.Where(s => s.FirstName.Contains(searchString)
                                       || s.LastName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    employees = employees.OrderByDescending(e => e.FirstName);
                    break;
                case "name_asc":
                    employees = employees.OrderBy(e => e.FirstName);
                    break;
                case "gender_asc":
                    employees = employees.OrderBy(e => e.Gender);
                    break;
                case "gender_desc":
                    employees = employees.OrderByDescending(e => e.Gender);
                    break;
                case "department_asc":
                    employees = employees.OrderBy(e => e.Department.DepartmentName);
                    break;
                case "department_desc":
                    employees = employees.OrderByDescending(e => e.Department.DepartmentName);
                    break;
                default:
                    employees = employees.OrderBy(e => e.Id);
                    break;
            }
            //return View(employees.ToList());            
            return View(await employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "DepartmentName");
            return View();
        }



        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeesViewModel model)
        /*[Bind("Id,FirstName,LastName,Age,Gender,DepartmentId,Salary,ProfilePicture")] Employee employee,*/
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                Employee employee = new Employee
                {
                    Age = model.Employee.Age,
                    Department = model.Employee.Department,
                    DepartmentId = model.Employee.DepartmentId,
                    FirstName = model.Employee.FirstName,
                    Gender = model.Employee.Gender,
                    Id = model.Employee.Id,
                    LastName = model.Employee.LastName,
                    Salary = model.Employee.Salary,
                    ProfilePicture = uniqueFileName,
                };

                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "DepartmentName", employee.DepartmentId);
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "DepartmentName", model.Employee.DepartmentId);
            //return View(employee);
            return View(model);
        }

        private string UploadedFile(EmployeesViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Age,Gender,DepartmentId,Salary,ProfilePicture")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}
