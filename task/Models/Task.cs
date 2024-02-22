using System;
using System.Collections.Generic;

namespace task
{
    public partial class Task
    {
        public long Id { get; set; }
        public string? Taskname { get; set; }
        public string? Description { get; set; }
        public string? Datepublic { get; set; }
        public long? IdUserCreate { get; set; }
        public long? IdUserAccept { get; set; }
        public long? IdStatus { get; set; }

        public virtual StatusTask? IdStatusNavigation { get; set; }
        public virtual User? IdUserAcceptNavigation { get; set; }
        public virtual User? IdUserCreateNavigation { get; set; }
    }
}
