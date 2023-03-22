using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Systems
{
    public class Gvsz : BaseEntity
    {
        public long WeekId { get; set; }
        public Week Week { get; set; }
        public long ExerciseId { get; set; }
        public Exercise Exercises { get; set; }
        public long SubjectId { get; set; }
        public Subject Subject { get; set; }
        public long GroupId { get; set; }
        public Group Group { get; set; }
    }
}
