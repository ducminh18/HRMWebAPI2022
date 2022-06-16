using HRMWebAPI2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HRMWebAPI2022.Controllers
{
    [BasicAuthentication]
    public class DepartmentsController : ApiController
    {

        HRMDBEntities5 db = new HRMDBEntities5();

        // GET api/<controller>
        public IEnumerable<Departments> Get()
        {
            using(HRMDBEntities5 db = new HRMDBEntities5())
            {
                return db.Departments.ToList();
            }
            
        }

        // GET api/<controller>/5
        public Departments Get(int id)
        {
            using (HRMDBEntities5 db = new HRMDBEntities5())
            {
                return db.Departments.SingleOrDefault(d=>d.DepartmentID==id); 
            }
        }

        // POST api/<controller>
        public void Post([FromBody] Departments department)
        {
            using (HRMDBEntities5 db = new HRMDBEntities5())
            {
                db.Departments.Add(department);
                db.SaveChanges();
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put([FromBody] Departments department)
        {
            using (HRMDBEntities5 db = new HRMDBEntities5())
            {
                try
                {
                    //lấy về 1 phòng ban theo ID
                    Departments d = db.Departments.SingleOrDefault(x => x.DepartmentID == department.DepartmentID);
                    //sửa
                    d.DepartmentName = department.DepartmentName;
                    db.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.NoContent);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Vui lòng kiểm tra lỗi sau" + ex.Message);
                }

            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            using (HRMDBEntities5 db = new HRMDBEntities5())
            {
                Departments d = db.Departments.SingleOrDefault(x => x.DepartmentID == id);
                db.Departments.Remove(d);
                db.SaveChanges();    
            }
        }
        [HttpGet]
        [Route("api/Departments/search")]
        public List<Departments> Search(string keyword)
        {
            using (HRMDBEntities5 db = new HRMDBEntities5())
            {
                List<Departments> departments = db.Departments.Where(d=>d.DepartmentName.Contains(keyword) || d.DepartmentID.ToString().Contains(keyword)).ToList();
                return departments;
            }
        }
        [HttpGet]
        [Route("api/Departments/Export")]
        public List<EmployeeDTO> Export(int id)
        {
            using (HRMDBEntities5 db = new HRMDBEntities5())
            {
                var data = from e in db.Employees
                           where e.DepartmentID == id
                           select new { e.EmployeeID, e.FullName, e.Departments.DepartmentName };
                return data.ToList().Select(e => new EmployeeDTO(e.EmployeeID, e.FullName, e.DepartmentName)).ToList();
            }
        }
    }
}