using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiDevBP.DataAccess.Entities
{
    [Table("Users")]
    public class UserEntity
    {
        [PrimaryKey, AutoIncrement]
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
    }
}
