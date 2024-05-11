using ApiDevBP.Business.Contract;
using ApiDevBP.Model.OutputDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDevBP.Business.Implementation
{
    public class UserBusiness : IUserBusiness
    {
        public Task<IEnumerable<UserModelOutputDTO>> DeleteUser()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveUser()
        {
            throw new NotImplementedException();
        }
    }
}
