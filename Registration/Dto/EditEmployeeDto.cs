using Registration.Models;
using System;

namespace Registration.Dto
{
    public class EditEmployeeDto
    {
        public int Id { get; set; }

        public string SurName { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public DateTime EmploymentDate { get; set; }

        public Position Position { get; set; }

        public int CompanyId { get; set; }
    }
}
