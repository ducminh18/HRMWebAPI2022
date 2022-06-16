using HRMWebAPI2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HRMWebAPI2022.Controllers
{
    public class EmployeesController : ApiController
    {
        HRMDBEntities5 db = new HRMDBEntities5();

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<EmployeeDTO> ListEmployee()
        {
            using (HRMDBEntities5 db = new HRMDBEntities5())
            {
                var data = from e in db.Employees
                           select new {e.EmployeeID, e.FullName, e.Departments.DepartmentName };

                return data.ToList().Select(e=> new EmployeeDTO(e.EmployeeID, e.FullName, e.DepartmentName)).ToList();
            }
        }

        [HttpGet]
        public IEnumerable<EmployeeSalaryDTO> GetListSalary(int year, int month)
        {
            using (HRMDBEntities5 db = new HRMDBEntities5())
            {
                var data = from s in db.Salaries
                           where s.Year == year && s.Month == month
                           select new {s.EmployeeID, s.Employees.FullName, s.Employees.Departments.DepartmentName, s.BasicSalary, s.OtherSalary, total = s.BasicSalary + s.OtherSalary};

                return data.ToList().Select(s => new EmployeeSalaryDTO(s.EmployeeID, s.FullName, s.DepartmentName, s.BasicSalary.Value, s.OtherSalary.Value, s.total.Value)).ToList();
            }
        }


        public List<GetSalaries_Result> GetEmployeeSalaries(int year, int month)
        {
            using (HRMDBEntities5 db = new HRMDBEntities5())
            {
                return db.GetSalaries(year, month).ToList();
            }
        }

        // GET api/<controller>/5
        public List<Employees> Get()
        {
            using (HRMDBEntities5 db = new HRMDBEntities5())
            {
                return db.Employees.ToList();
            }
        }

        // POST api/<controller>
        public void Post([FromBody] Employees employee)
        {
            using (HRMDBEntities5 db = new HRMDBEntities5())
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] Employees employee)
        {
            using (HRMDBEntities5 db = new HRMDBEntities5())
            {
                Employees e = db.Employees.SingleOrDefault(x => x.EmployeeID == employee.EmployeeID);
                e.FullName = employee.FullName;
                db.SaveChanges();
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            using (HRMDBEntities5 db = new HRMDBEntities5())
            {
                Employees e = db.Employees.SingleOrDefault(x => x.EmployeeID == id);
                db.Employees.Remove(e);
                db.SaveChanges();
            }
        }
        [HttpGet]
        [Route("api/Employees/search")]
        public Employees[] Search(string keyword)
        {
            using (HRMDBEntities5 db = new HRMDBEntities5())
            {
                return db.Employees.Where(e => e.FullName.Contains(keyword) || e.EmployeeID.ToString().Contains(keyword)).ToArray();
            }
        }
    }
}