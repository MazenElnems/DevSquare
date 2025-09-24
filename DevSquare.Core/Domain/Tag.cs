using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSquare.Core.Domain
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Properties
        public List<Post> Posts { get; set; } = new();
    }
}
