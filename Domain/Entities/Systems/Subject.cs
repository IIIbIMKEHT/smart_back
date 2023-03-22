using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Systems
{
    public class Subject : BaseEntity
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
        public Department Department { get; set; }
        public long AcademicDegreeId { get; set; }
        public AcademicDegree AcademicDegree { get; set; }
    }
}
