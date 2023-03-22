using Application.Core.DTOs.AcademicDegree;
using Application.Core.DTOs.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.DTOs.Subject
{
    public class SubjectRDTO : BaseDTO
    {
        public string TitleKz { get; set; }
        public string TitleRu { get; set; }
        public string TitleEn { get; set; }
        public string DescriptionKz { get; set; }
        public string DescriptionRu { get; set; }
        public string DescriptionEn { get; set; }
        public string CodeKz { get; set; }
        public string CodeRu { get; set; }
        public string CodeEn { get; set; }
        public long DepartmentId { get; set; }
        public virtual DepartmentRDTO Department { get; set; }
        public long AcademicDegreeId { get; set; }
        public virtual AcademicDegreeRDTO AcademicDegree { get; set; }
    }
}
