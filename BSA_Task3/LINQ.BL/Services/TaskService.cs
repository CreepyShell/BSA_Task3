using AutoMapper;
using LINQ.Common.DTOModels;
using LINQ.DataAccess;
using LINQ.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace LINQ.BL.Services
{
    public class TaskService : BaseService<Task>
    {
        private IMapper _mapper;
        public TaskService(IMapper mapper)
        {
            methods = new RepositoryMethods<Task>(listModels.Tasks.ToList());
            _mapper = mapper;
        }
        public IEnumerable<TaskDTO> Read()
        {
            IEnumerable<Task> Tasks = BaseRead();
            var TasksDTO = _mapper.Map<IEnumerable<TaskDTO>>(Tasks);
            return TasksDTO;
        }

        public TaskDTO ReadById(int id)
        {
            return _mapper.Map<TaskDTO>(base.BaseReadById(id));
        }

        public void Create(TaskDTO TaskDTO)
        {
            var Task = _mapper.Map<Task>(TaskDTO);
            base.BaseCreate(Task);
        }

        public void Update(TaskDTO newTask, int id)
        {
            var Task = _mapper.Map<Task>(newTask);
            base.BaseUpdate(Task, id);
        }

        public void Delete(int id)
        {
            base.BaseDelete(id);
        }
    }
}
