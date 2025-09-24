using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSquare.Core.Domain
{
    public class User
    {
        // Navigation Properties
        public List<Post> Posts { get; set; } = new();
        public List<Comment> Comments { get; set; } = new();
        public List<Vote> Votes { get; set; } = new();
        public List<Notification> Notifications { get; set; } = new();
    }
}
