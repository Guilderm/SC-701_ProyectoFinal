using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Grade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public string Name { get; set; }
        public double Grade1 { get; set; }
        public double Percentage { get; set; }

        public virtual Class Class { get; set; }
        public virtual User Student { get; set; }
    }
}
