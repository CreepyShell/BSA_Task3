
using System;

namespace LINQ.DataAccess.Models
{
    public  class Task : BaseModel
    {
        public int ProjectId { get; set; }
        public int PerformerId { get; set; }
        public string Description { get; set; }
        public int State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
    }
}
