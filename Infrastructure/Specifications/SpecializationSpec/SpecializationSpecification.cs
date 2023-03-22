using Domain.Entities.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Specifications.SpecializationSpec
{
    public class SpecializationSpecification : BaseSpecification<Specialization>
    {
        public SpecializationSpecification()
        {
            AddInclude("Profession");
            AddInclude("Department");
        }
    }
}
