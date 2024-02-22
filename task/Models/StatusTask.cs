using System;
using System.Collections.Generic;

namespace task
{
    public partial class StatusTask
    {
        public StatusTask()
        {
            Tasks = new HashSet<Task>();
        }

        public long Id { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
