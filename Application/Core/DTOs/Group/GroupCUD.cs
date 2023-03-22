using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.DTOs.Group
{
    public class GroupCUD
    {
        public string TitleKz { get; set; }
        public string TitleRu { get; set; }
        public string TitleEn { get; set; }
        public int Year { get; set; }
        public long SpecializationId { get; set; }
        public long DepartmentId { get; set; }
        public long LanguageId { get; set; }
    }
}
