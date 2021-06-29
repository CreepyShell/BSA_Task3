using LINQ.Common.DTOModels;
using LINQ.DataAccess;
using LINQ.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace LINQ.BL.Services
{
    public class ProjectService : BaseService<Project>
    {
        private IMapper _mapper;
        public ProjectService(IMapper mapper)
        {
            _mapper = mapper;
            methods = new RepositoryMethods<Project>(listModels.Projects.ToList());
        }
        public IEnumerable<ProjectDTO> Read()
        {
            IEnumerable<Project> projects = BaseRead();
            var projectsDTO = _mapper.Map<IEnumerable<ProjectDTO>>(projects);
            return projectsDTO;
        }

        public ProjectDTO ReadById(int id)
        {
            return _mapper.Map<ProjectDTO>(base.BaseReadById(id));
        }

        public void Create(ProjectDTO projectDTO)
        {
            var project = _mapper.Map<Project>(projectDTO);
            base.BaseCreate(project);
        }

        public void Update(ProjectDTO newProject, int id)
        {
            var project = _mapper.Map<Project>(newProject);
            base.BaseUpdate(project, id);
        }

        public void Delete(int id)
        {
            base.BaseDelete(id);
        }
    }
}
