using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Systems
{
    public class Workload : BaseEntity
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public long LanguageId { get; set; }
        public Language Language { get; set; }
        public long AcademicYearId { get; set; }
        public AcademicYear AcademicYear { get; set; }
        public long DepartmentId { get; set; }
        public Department Department { get; set; }
        public long SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
