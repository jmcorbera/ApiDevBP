using ApiDevBP.DataAccess.Contract;
using ApiDevBP.DataAccess.Entities;
using ApiDevBP.Model.InputDTO;
using ApiDevBP.Model.OutputDTO;
using ApiDevBP.Service.Contract;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiDevBP.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserDataAccess _userDataAccess;

        public UserService(IMapper mapper, IUserDataAccess userDataAccess)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userDataAccess = userDataAccess ?? throw new ArgumentNullException(nameof(userDataAccess));
        }
        public async Task<IEnumerable<UserModelOutputDTO>> GetUsers()
        {
            var users = await _userDataAccess.GetUsers();
            if (!users.Any())
                return null;

            return _mapper.Map<IEnumerable<UserModelOutputDTO>>(users);
        }

        public async Task<UserModelOutputDTO> SaveUser(UserModelInputDTO user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);

            return _mapper.Map<UserModelOutputDTO>(await _userDataAccess.SaveUser(userEntity));
        }
    }
}
