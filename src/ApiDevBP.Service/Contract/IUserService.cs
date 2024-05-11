using ApiDevBP.Model.InputDTO;
using ApiDevBP.Model.OutputDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDevBP.Service.Contract
{
    public interface IUserService
    {
        Task<int> SaveUser(UserModelInputDTO user);
        Task<IEnumerable<UserModelOutputDTO>> GetUsers();
    }
}
