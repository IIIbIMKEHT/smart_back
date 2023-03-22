using Application.Core.DTOs.AcademicYear;
using Application.Core.DTOs.Department;
using Application.Core.DTOs.Language;
using Application.Core.DTOs.Subject;
using Application.Core.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.DTOs.Workload
{
    public class WorkloadRDTO : BaseDTO
    {
        public long UserId { get; set; }
        public UserRDTO User { get; set; }
        public long LanguageId { get; set; }
        public LanguageRDTO Language { get; set; }
        public long AcademicYearId { get; set; }
        public AcademicYearRDTO AcademicYear { get; set; }
        public long DepartmentId { get; set; }
        public DepartmentRDTO Department { get; set; }
        public long SubjectId { get; set; }
        public SubjectRDTO Subject { get; set; }
    }
}
