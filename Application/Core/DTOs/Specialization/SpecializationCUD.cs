using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.DTOs.Specialization
{
    public class SpecializationCUD
    {
        public long ProfessionId { get; set; }
        public long DepartmentId { get; set; }
        public string Code { get; set; }
        public string TitleKz { get; set; }
        public string TitleRu { get; set; }
        public string TitleEn { get; set; }
    }
}
