using Application.Core.DTOs.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.DTOs.Profession
{
    public class ProfessionRDTO : BaseDTO
    {
        public long DepartmentId { get; set; }
        public virtual DepartmentRDTO Department { get; set; }
        public string TitleKz { get; set; }
        public string TitleRu { get; set; }
        public string TitleEn { get; set; }
        public string Code { get; set; }
    }
}
