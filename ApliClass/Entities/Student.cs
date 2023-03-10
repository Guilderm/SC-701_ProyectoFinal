using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Student
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }

        public virtual Class Class { get; set; }
        public virtual User StudentNavigation { get; set; }
    }
}
