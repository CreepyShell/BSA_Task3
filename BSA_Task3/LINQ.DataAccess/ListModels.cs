using LINQ.DataAccess.Models;
using System.Collections.Generic;

namespace LINQ.DataAccess
{
    public class ListModels
    {
        private static ListModels listModels;
        public static ListModels GetListModels()
        {
            if (listModels != null)
                return listModels;
            listModels = new ListModels();
            return listModels;
        }
        private ListModels() { }
        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
        public IEnumerable<Project> Projects { get; set; }
    }
}
