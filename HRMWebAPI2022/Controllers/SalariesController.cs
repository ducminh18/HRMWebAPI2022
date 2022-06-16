using HRMWebAPI2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HRMWebAPI2022.Controllers
{
    public class SalariesController : ApiController
    {

        HRMDBEntities5 db = new HRMDBEntities5();

        // GET api/<controller>
        public IEnumerable<Salaries> Get()
        {
            using (HRMDBEntities5 db = new HRMDBEntities5())
            {
                return db.Salaries.ToList();
            }
        }

        // GET api/<controller>/5
        public Salaries Get(int id)
        {
            using (HRMDBEntities5 db = new HRMDBEntities5())
            {
                return db.Salaries.SingleOrDefault(s => s.EmployeeID == id);
            }
        }

        // POST api/<controller>
        public void Post([FromBody] Salaries salary)
        {
            using (HRMDBEntities5 db = new HRMDBEntities5())
            {
                db.Salaries.Add(salary);
                db.SaveChanges();
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] Salaries salary)
        {
            using (HRMDBEntities5 db = new HRMDBEntities5())
            {
                Salaries s = db.Salaries.SingleOrDefault(x => x.EmployeeID == salary.EmployeeID);
                s.BasicSalary = salary.BasicSalary;
                db.SaveChanges();
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            using (HRMDBEntities5 db = new HRMDBEntities5())
            {
                Salaries s = db.Salaries.SingleOrDefault(x => x.EmployeeID == id);
                db.Salaries.Remove(s);
                db.SaveChanges();
            }
        }
        [HttpGet]
        [Route("api/Salaries/search")]
        public List<Salaries> Search(string keyword)
        {
            using (HRMDBEntities5 db = new HRMDBEntities5())
            {
                List<Salaries> salaries = db.Salaries.Where(s => s.EmployeeID.ToString().Contains(keyword) || s.EmployeeID.ToString().Contains(keyword)).ToList();
                return salaries;
            }
        }
    }
}