using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime EmploymentDate { get; set; }
        public Position Position { get; set; }
        public int CompanyId { get; set; }
    }
    public enum Position
    {
        Developer,
        Tester,
        BA,
        Manager
    }
}
