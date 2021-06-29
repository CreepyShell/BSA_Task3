using AutoMapper;
using LINQ.Common.DTOModels;
using LINQ.DataAccess;
using LINQ.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace LINQ.BL.Services
{
    public class TeamService : BaseService<Team>
    {
        private IMapper _mapper;
        public TeamService(IMapper mapper)
        {
            methods = new RepositoryMethods<Team>(listModels.Teams.ToList());
            _mapper = mapper;
        }
        public IEnumerable<TeamDTO> Read()
        {
            IEnumerable<Team> Teams = BaseRead();
            var TeamsDTO = _mapper.Map<IEnumerable<TeamDTO>>(Teams);
            return TeamsDTO;
        }

        public TeamDTO ReadById(int id)
        {
            return _mapper.Map<TeamDTO>(base.BaseReadById(id));
        }

        public void Create(TeamDTO TeamDTO)
        {
            var Team = _mapper.Map<Team>(TeamDTO);
            base.BaseCreate(Team);
        }

        public void Update(TeamDTO newTeam, int id)
        {
            var Team = _mapper.Map<Team>(newTeam);
            base.BaseUpdate(Team, id);
        }

        public void Delete(int id)
        {
            base.BaseDelete(id);
        }
    }
}
