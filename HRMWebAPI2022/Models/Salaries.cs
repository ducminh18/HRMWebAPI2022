//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRMWebAPI2022.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Salaries
    {
        public int EmployeeID { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public Nullable<int> BasicSalary { get; set; }
        public Nullable<int> OtherSalary { get; set; }
    
        public virtual Employees Employees { get; set; }
    }
}
