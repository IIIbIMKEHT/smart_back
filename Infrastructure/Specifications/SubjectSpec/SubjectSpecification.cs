using Domain.Entities.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Specifications.SubjectSpec
{
    public class SubjectSpecification : BaseSpecification<Subject>
    {
        public SubjectSpecification()
        {
            AddInclude("Department");
            AddInclude("AcademicDegree");
        }
    }
}
