using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.DTOs.Subject
{
    public class SubjectCUD
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
        public long AcademicDegreeId { get; set; }
    }
}
