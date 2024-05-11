using ApiDevBP.DataAccess.Contract;
using ApiDevBP.DataAccess.Entities;
using ApiDevBP.DataAccess.Settings;
using ApiDevBP.Model.InputDTO;
using ApiDevBP.Model.OutputDTO;
using Microsoft.Extensions.Options;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace ApiDevBP.DataAccess.Implementation
{
    public class UserDataAccess : IUserDataAccess
    {
        private readonly SQLiteAsyncConnection _db;
        private readonly IOptions<DBOptions> _settings;

        public UserDataAccess(IOptions<DBOptions> settings) 
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));

            string localDb = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), _settings.Value.DataBaseName);
            _db = new SQLiteAsyncConnection(localDb);
            _db.CreateTableAsync<UserEntity>();
        }
        public Task<IEnumerable<UserEntity>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveUser(UserEntity user)
        {
            throw new NotImplementedException();
        }
    }
}
