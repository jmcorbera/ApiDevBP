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
        Task<UserModelOutputDTO> SaveUser(UserModelInputDTO user);
        Task<IEnumerable<UserModelOutputDTO>> GetUsers();
        Task<UserModelOutputDTO> GetUserById(int id);
        Task<UserModelOutputDTO> UpdateUser(UserModelInputDTO inUser);
        Task DeleteUser(int id);
    }
}
