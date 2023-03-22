using Domain.Entities.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Specifications.ProfessionSpec
{
    public class ProfessionSpecification : BaseSpecification<Profession>
    {
        public ProfessionSpecification()
        {
            AddInclude("Department");
        }
    }
}
