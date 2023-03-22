using Application.Core.DTOs.Faculty;
using Domain.Entities.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.DTOs.Department
{
    public class DepartmentRDTO : BaseDTO
    {
        public string TitleKz { get; set; }
        public string TitleRu { get; set; }
        public string TitleEn { get; set; }
        public long FacultyId { get; set; }
        public virtual FacultyRDTO Faculty { get; set; }
    }
}
