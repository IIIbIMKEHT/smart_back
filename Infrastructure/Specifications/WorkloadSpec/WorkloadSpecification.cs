using Domain.Entities.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Specifications.WorkloadSpec
{
    public class WorkloadSpecification : BaseSpecification<Workload>
    {
        public WorkloadSpecification() 
        {
            AddInclude("User");
            AddInclude("Language");
            AddInclude("AcademicYear");
            AddInclude("Department");
            AddInclude("Subject");
        }
    }
}
