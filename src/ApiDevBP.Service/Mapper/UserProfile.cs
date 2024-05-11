using ApiDevBP.DataAccess.Entities;
using ApiDevBP.Model.InputDTO;
using ApiDevBP.Model.OutputDTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDevBP.Service.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserModelInputDTO, UserEntity>();
            CreateMap<UserEntity, UserModelOutputDTO>();
        }
    }
}
