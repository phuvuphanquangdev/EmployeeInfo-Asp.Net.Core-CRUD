using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FloraEmployeeInfo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FloraEmployeeInfo.Controllers
{
    public class EmployeeController : Controller
    {
        private FloraEmployeeDBContext context;

        public EmployeeController(FloraEmployeeDBContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            ViewBag.departmentList = new SelectList(context.Department, "DepartmentId", "DepartmentName");
            ViewBag.designationList = new SelectList(context.Designation, "DesignationId", "DesignationName");

            return View(context.Employee.ToList());
     
        }

        [HttpPost]
        public IActionResult Insert(Employee employee)
        {
        
                Employee model = new Employee()
                {
                    EmployeeName = employee.EmployeeName,
                    DepartmentId = employee.DepartmentId,
                    DesignationId =employee.DesignationId,
                    Email = employee.Email,
                    Phone = employee.Phone,
                    JoinDate = employee.JoinDate
                };
                this.context.InsertEmployee(model);
            ViewBag.departmentList = new SelectList(context.Department, "DepartmentId", "DepartmentName");
            ViewBag.designationList = new SelectList(context.Designation, "DesignationId", "DesignationName");
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            Employee model = new Employee()
            {
                EployeeId = employee.EployeeId,
                EmployeeName = employee.EmployeeName,
                DepartmentId = employee.DepartmentId,
                DesignationId = employee.DesignationId,
                Email = employee.Email,
                Phone = employee.Phone,
                JoinDate = employee.JoinDate
            };
            this.context.UpdateEmployee(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            this.context.DeleteCustomer(employee.EployeeId);
            return RedirectToAction("Index");
        }

    }
}
