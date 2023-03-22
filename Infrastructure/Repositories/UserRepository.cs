using Application.Core.Interfaces;
using Domain.Entities;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : Generic<User>, IUser
    {
        public UserRepository(DataContext context) : base(context)
        {
        }
    }
}
