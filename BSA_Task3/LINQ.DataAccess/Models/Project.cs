
using System;

namespace LINQ.DataAccess.Models
{
    public class Project : BaseModel
    {
        public int AuthorId { get; set; }
        public int TeamId { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
