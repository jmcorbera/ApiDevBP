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

        public async Task DeleteUser(int id)
        {
            try
            {
                var user = await _userDataAccess.GetUserById(id) ?? throw new Exception("Id User Not Found");
                await _userDataAccess.DeleteUser(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<UserModelOutputDTO> GetUserById(int id)
        {
            try
            {
                var user = await _userDataAccess.GetUserById(id);
                return _mapper.Map<UserModelOutputDTO>(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<IEnumerable<UserModelOutputDTO>> GetUsers()
        {
            try
            {

                var users = await _userDataAccess.GetUsers();
                if (!users.Any())
                    return null;

                return _mapper.Map<IEnumerable<UserModelOutputDTO>>(users);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<UserModelOutputDTO> SaveUser(UserModelInputDTO user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);

            try
            {
                return _mapper.Map<UserModelOutputDTO>(await _userDataAccess.SaveUser(userEntity));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<UserModelOutputDTO> UpdateUser(UserModelInputDTO user)
        {
            try
            {
                var userModel = await _userDataAccess.GetUserById(user.Id) ?? throw new Exception("User Not Found");

                userModel.Name = userModel.Name;
                userModel.Lastname = userModel.Lastname;

                var userUpdated = await _userDataAccess.UpdateUser(userModel);
                return _mapper.Map<UserModelOutputDTO>(userUpdated);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
