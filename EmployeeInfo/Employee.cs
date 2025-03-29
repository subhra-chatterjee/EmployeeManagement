namespace EmployeeInfo
{
    public class Employee
    {
        public int EmployeeID { get; set; } // Unique identifier for the employee
        public string FirstName { get; set; } // Employee's first name
        public string LastName { get; set; } // Employee's last name
        public string Email { get; set; } // Contact email address
        public string PhoneNumber { get; set; } // Contact phone number
        public string Department { get; set; } // Department the employee works in
        public string Position { get; set; } // Job title or position
        public decimal Salary { get; set; } // Salary of the employee
        public DateTime DateOfJoining { get; set; } // Employee's hire date
        public bool IsActive { get; set; } // Employment status (active/inactive)
    }
}
