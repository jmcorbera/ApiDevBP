using ApiDevBP.Model.InputDTO;
using ApiDevBP.Model.OutputDTO;
using ApiDevBP.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDevBP.Service.Implementation
{
    public class UserService : IUserService
    {
        public Task<IEnumerable<UserModelOutputDTO>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveUser(UserModelInputDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
