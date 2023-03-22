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
    public class DepartmentRepository : Generic<Department>, IDepartment
    {
        public DepartmentRepository(DataContext context) : base(context)
        {
        }
    }
}
