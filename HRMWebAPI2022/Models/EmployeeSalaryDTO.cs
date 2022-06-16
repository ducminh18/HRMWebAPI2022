using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMWebAPI2022.Models
{
    public class EmployeeSalaryDTO
    {
        int employeeId;
        string fullName;
        string departmentName;
        int basicSalary;
        int otherSalary;
        int total;

        public EmployeeSalaryDTO(int employeeId, string fullName, string departmentName, int basicSalary, int otherSalary, int total)
        {
            this.employeeId = employeeId;
            this.fullName = fullName;
            this.departmentName = departmentName;
            this.basicSalary = basicSalary;
            this.otherSalary = otherSalary;
            this.total = total;
        }

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string DepartmentName { get => departmentName; set => departmentName = value; }
        public int BasicSalary { get => basicSalary; set => basicSalary = value; }
        public int OtherSalary { get => otherSalary; set => otherSalary = value; }
        public int Total { get => total; set => total = value; }
    }
}