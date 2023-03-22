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
    public class GroupRepository : Generic<Group>, IGroup
    {
        public GroupRepository(DataContext context) : base(context)
        {
        }
    }
}
