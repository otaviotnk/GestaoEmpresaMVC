using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEmpresaMVC.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
                public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public double Salary { get; set; }
        public string ProfilePicture { get; set; }

        public Employee()
        {

        }

        public Employee(int id, string firstName, string lastName, int age, string gender,  double salary, string profilePicture)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
            
            Salary = salary;
            ProfilePicture = profilePicture;
        }
    }
}
