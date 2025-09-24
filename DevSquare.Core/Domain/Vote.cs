using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSquare.Core.Domain
{
    public class Vote
    {
        // Foreign Keys
        public int UserId { get; set; }
        public Guid PostId { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public Post Post { get; set; }
    }
}
