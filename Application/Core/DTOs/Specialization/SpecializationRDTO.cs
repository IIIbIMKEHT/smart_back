using Application.Core.DTOs.Department;
using Application.Core.DTOs.Profession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.DTOs.Specialization
{
    public class SpecializationRDTO : BaseDTO
    {
        public long ProfessionId { get; set; }
        public virtual ProfessionRDTO Profession { get; set; }
        public long DepartmentId { get; set; }
        public virtual DepartmentRDTO Department { get; set; }
        public string Code { get; set; }
        public string TitleKz { get; set; }
        public string TitleRu { get; set; }
        public string TitleEn { get; set; }
    }
}
