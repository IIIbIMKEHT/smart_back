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
    public class WorkloadCUD
    {
        public long UserId { get; set; }
        public long LanguageId { get; set; }
        public long AcademicYearId { get; set; }
        public long DepartmentId { get; set; }
        public long SubjectId { get; set; }
    }
}
