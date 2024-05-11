using ApiDevBP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDevBP.Business.Contract
{
    public interface IUserBusiness
    {
        Task<int> SaveUser();
        Task<IEnumerable<UserModel>> DeleteUser();
    }
}
