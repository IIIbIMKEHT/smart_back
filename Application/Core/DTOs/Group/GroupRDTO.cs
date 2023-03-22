using Application.Core.DTOs.Department;
using Application.Core.DTOs.Language;
using Application.Core.DTOs.Specialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.DTOs.Group
{
    public class GroupRDTO : BaseDTO
    {
        public string TitleKz { get; set; }
        public string TitleRu { get; set; }
        public string TitleEn { get; set; }
        public int Year { get; set; }
        public long DepartmentId { get; set; }
        public virtual DepartmentRDTO Department { get; set; }
        public long SpecializationId { get; set; }
        public virtual SpecializationRDTO Specialization { get; set; }
        public long LanguageId { get; set; }
        public virtual LanguageRDTO Language { get; set; }
    }
}
