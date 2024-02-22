using System;
using System.Collections.Generic;

namespace task
{
    public partial class User
    {
        public User()
        {
            TaskIdUserAcceptNavigations = new HashSet<Task>();
            TaskIdUserCreateNavigations = new HashSet<Task>();
        }

        public long Id { get; set; }
        public string? Family { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public byte[]? Foto { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }

        public virtual ICollection<Task> TaskIdUserAcceptNavigations { get; set; }
        public virtual ICollection<Task> TaskIdUserCreateNavigations { get; set; }
    }
}
