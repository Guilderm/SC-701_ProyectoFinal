using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class StudentId
    {
        public int Id { get; set; }
        public int StudentId1 { get; set; }
        public int Class { get; set; }

        public virtual Class ClassNavigation { get; set; }
        public virtual User StudentId1Navigation { get; set; }
    }
}
