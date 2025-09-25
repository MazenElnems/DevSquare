using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSquare.Core.Domain
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }

        // Foeign Keys
        public int UserId { get; set; }

        // Navigation Properties
        public User User { get; set; }  
        public List<Comment> Comments { get; set; } = new();
        public List<Tag> Tags { get; set; } = new();
        public List<Vote> Votes { get; set; } = new();
    }
}
