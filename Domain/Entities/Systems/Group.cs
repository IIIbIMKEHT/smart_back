using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Systems
{
    public class Group : BaseEntity
    {
        public long DepartmentId { get; set; }
        public Department Department { get; set; }
        public long SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
        public string TitleKz { get; set; }
        public string TitleRu { get; set; }
        public string TitleEn { get; set; }
        public int Year { get; set; }
        public long LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
