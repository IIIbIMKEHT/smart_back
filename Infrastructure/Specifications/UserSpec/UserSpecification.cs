using Domain.Entities;
using Domain.Entities.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Specifications.UserSpec
{
    public class UserSpecification : BaseSpecification<User>
    {
        public UserSpecification()
        {
            AddInclude("RolesUsers.Role");
            AddInclude("Faculty");
            AddInclude("Department");
        }
    }
}
