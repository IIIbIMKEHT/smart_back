using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Systems
{
    public class Specialization : BaseEntity
    {
        public long ProfessionId { get; set; }
        public Profession Profession { get; set; }
        public long DepartmentId { get; set; }
        public Department Department { get; set; }
        public string Code { get; set; }
        public string TitleKz { get; set; }
        public string TitleRu { get; set; }
        public string TitleEn { get; set; }
    }
}
