using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FloraEmployeeInfo.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace FloraEmployeeInfo.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly FloraEmployeeDBContext db;
        private readonly IWebHostEnvironment _hostEnv;

        public EmployeesController(FloraEmployeeDBContext db, IWebHostEnvironment hostEnv)
        {
            this.db = db;
            this._hostEnv = hostEnv;
        }
        public IActionResult Index()
        {
            ViewBag.departments = db.Department.ToList();
            ViewBag.designations = db.Designation.ToList();

            return View(db.Employee.ToList());
        }

        // For Create

        public IActionResult Create()
        {
            ViewBag.departments = db.Department.ToList();
            ViewBag.designations = db.Designation.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee
                {
                    EmployeeName = emp.EmployeeName,
                    DepartmentId = emp.DepartmentId,
                    DesignationId = emp.DesignationId,
                    Email = emp.Email,
                    Phone = emp.Phone,
                    JoinDate = emp.JoinDate
                };
                db.Employee.Add(employee);
                db.SaveChanges();
                return PartialView("_success");
            }

            ViewBag.departments = db.Department.ToList();
            ViewBag.designations = db.Designation.ToList();
            return PartialView("_error");
        }

        // For Edit

        public IActionResult Edit(int? id)
        {
            Employee e = db.Employee.Find(id);
            Employee emp = new Employee
            {
                EployeeId = e.EployeeId,
                EmployeeName = e.EmployeeName,
                DepartmentId = e.DepartmentId,
                DesignationId = e.DesignationId,
                Email = e.Email,
                Phone = e.Phone,
                JoinDate = e.JoinDate
            };
            ViewBag.departments = db.Department.ToList();
            ViewBag.designations = db.Designation.ToList();
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {

                Employee e = new Employee
                {
                    EployeeId = emp.EployeeId,
                    EmployeeName = emp.EmployeeName,
                    DepartmentId = emp.DepartmentId,
                    DesignationId = emp.DesignationId,
                    Email = emp.Email,
                    Phone = emp.Phone,
                    JoinDate = emp.JoinDate
                };
                db.Entry(e).State = EntityState.Modified;
                db.SaveChanges();
                return PartialView("_updateSuccess");
            }
            else
            {
                Employee e = new Employee
                {
                    EployeeId = emp.EployeeId,
                    EmployeeName = emp.EmployeeName,
                    DepartmentId = emp.DepartmentId,
                    DesignationId = emp.DesignationId,
                    Email = emp.Email,
                    Phone = emp.Phone,
                    JoinDate = emp.JoinDate
                };
                db.Entry(e).State = EntityState.Modified;
                db.SaveChanges();
            }
            ViewBag.departments = db.Department.ToList();
            ViewBag.designations = db.Designation.ToList();
            return PartialView("_updateSuccess");
        }

        // For Delete

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Employee c = db.Employee.Find(id);
                db.Employee.Remove(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }



    }
}
