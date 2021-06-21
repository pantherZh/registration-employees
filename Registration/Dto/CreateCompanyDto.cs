using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Dto
{
    public class CreateCompanyDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Form { get; set; }
    }
}
