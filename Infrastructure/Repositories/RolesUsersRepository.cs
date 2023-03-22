using Application.Core.Interfaces;
using Domain.Entities.Systems;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RolesUsersRepository : Generic<RolesUsers>, IRolesUsers
    {
        public RolesUsersRepository(DataContext context) : base(context)
        {
        }
    }
}
