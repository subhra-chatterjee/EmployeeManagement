using System.ComponentModel.DataAnnotations;

namespace EmployeeInfo
{
    public class Employee
    {
        
        public int EmployeeID { get; set; } // Unique identifier for the employee
        [Required]
        public string FirstName { get; set; } // Employee's first name
        [Required]
        public string LastName { get; set; } // Employee's last name
        [EmailAddress]
        public string Email { get; set; } // Contact email address
        [Required]
        public string PhoneNumber { get; set; } // Contact phone number
        [Required]
        public string Department { get; set; } // Department the employee works in
        [Required]
        public string Position { get; set; } // Job title or position
        [Required]
        public decimal Salary { get; set; } // Salary of the employee
        [Required]
        public DateTime DateOfJoining { get; set; } // Employee's hire date
        public bool IsActive { get; set; } // Employment status (active/inactive)
    }
}
