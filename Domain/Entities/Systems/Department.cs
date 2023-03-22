using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Systems
{
    public class Department : BaseEntity
    {
        public string TitleKz { get; set; }
        public string TitleRu { get; set; }
        public string? TitleEn { get; set; }
        public long FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }
}
