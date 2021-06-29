using AutoMapper;
using LINQ.Common.DTOModels;
using LINQ.DataAccess;
using LINQ.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace LINQ.BL.Services
{
    public class UserService : BaseService<User>
    {
        private IMapper _mapper;
        public UserService(IMapper mapper)
        {
            methods = new RepositoryMethods<User>(listModels.Users.ToList());
            _mapper = mapper;
        }
        public IEnumerable<UserDTO> Read()
        {
            IEnumerable<User> Users = BaseRead();
            var UsersDTO = _mapper.Map<IEnumerable<UserDTO>>(Users);
            return UsersDTO;
        }

        public UserDTO ReadById(int id)
        {
            return _mapper.Map<UserDTO>(base.BaseReadById(id));
        }

        public void Create(UserDTO UserDTO)
        {
            var User = _mapper.Map<User>(UserDTO);
            base.BaseCreate(User);
        }

        public void Update(UserDTO newUser, int id)
        {
            var User = _mapper.Map<User>(newUser);
            base.BaseUpdate(User, id);
        }

        public void Delete(int id)
        {
            base.BaseDelete(id);
        }
    }
}
