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
    public class WorkloadRepository : Generic<Workload>, IWorkload
    {
        public WorkloadRepository(DataContext context) : base(context)
        {
        }
    }
}
