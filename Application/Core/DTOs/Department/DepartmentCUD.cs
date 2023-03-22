using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.DTOs.Department
{
    public class DepartmentCUD
    {
        public string TitleKz { get; set; }
        public string TitleRu { get; set; }
        public string? TitleEn { get; set; }
        public long FacultyId { get; set; }
    }
}
