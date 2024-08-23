using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReserve.Application.Features.Companies.Dtos
{
    public class CreatedCompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public int IndustryTypeId { get; set; }

    }
}
