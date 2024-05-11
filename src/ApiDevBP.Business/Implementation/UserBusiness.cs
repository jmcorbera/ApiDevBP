using ApiDevBP.Business.Contract;
using ApiDevBP.Model.InputDTO;
using ApiDevBP.Model.OutputDTO;
using ApiDevBP.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDevBP.Business.Implementation
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserService _userService;

        public UserBusiness(IUserService userService) 
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public Task DeleteUser(int id)
        {
            return _userService.DeleteUser(id);
        }

        public Task<UserModelOutputDTO> GetUserById(int id)
        {
            return _userService.GetUserById(id);
        }

        public async Task<IEnumerable<UserModelOutputDTO>> GetUsers()
        {
            return await _userService.GetUsers();
        }

        public async Task<UserModelOutputDTO> SaveUser(UserModelInputDTO user)
        {
            return await _userService.SaveUser(user);
        }

        public async Task<UserModelOutputDTO> UpdateUser(UserModelInputDTO inUser)
        {
            return await _userService.UpdateUser(inUser);
        }
    }
}
