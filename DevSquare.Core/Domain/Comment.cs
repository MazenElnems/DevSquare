using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSquare.Core.Domain
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        // Foeign Keys
        public Guid? ParentCommentId { get; set; }
        public Guid PostId { get; set; }
        public int UserId { get; set; }

        // Navigation Properties
        public Post Post { get; set; }
        public User User { get; set; }
        public Comment? ParentComment { get; set; }
        public List<Comment> Replies { get; set; }  = new();
    }
}
