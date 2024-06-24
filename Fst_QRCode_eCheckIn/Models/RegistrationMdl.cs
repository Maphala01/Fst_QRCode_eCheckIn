using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fst_QRCode_eCheckIn.Models
{
    public class RegistrationMdl
    {
        public int SelectedDepartmentId { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        [Required]
        public string empName { get; set; }
        public string empDepartment { get; set; }
        public string QRCodeTotp { get; set; }
        public string qrCodeImgUrl { get; set; }
        public string Department { get; set; }
        public List<Department> DepartmentList { get; set; } = new List<Department>();
        public List<Employee> EmployeeList { get; set; } = new List<Employee>();
    }

    public class Department
    {
        public string DepartmentName { get; set; }
    }
    public class Employee
    {
        public string EmployeeName { get; set; }
    }
  
}