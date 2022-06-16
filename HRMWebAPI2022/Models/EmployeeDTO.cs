using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMWebAPI2022.Models
{
    public class EmployeeDTO
    {
        int employeeId;
        string fullName;
        string departmentName;

        public EmployeeDTO(int employeeId, string fullName, string departmentName)
        {
            this.employeeId = employeeId;
            this.fullName = fullName;
            this.departmentName = departmentName;
        }

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string DepartmentName { get => departmentName; set => departmentName = value; }
    }
}