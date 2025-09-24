using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSquare.Core.Domain
{
    public class Notification
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }

        // Foreign Keys
        public int UserId { get; set; }
        public Guid PostId { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public Post Post { get; set; }
    }
}
