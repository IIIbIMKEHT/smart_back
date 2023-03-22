using Domain.Entities.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Specifications.RolesUsersSpec
{
    public class RolesUsersSpecification : BaseSpecification<RolesUsers>
    {
        public RolesUsersSpecification() 
        {
            AddInclude("Users");
            AddInclude("Roles");
        }
    }
}
