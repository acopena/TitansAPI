using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TitansAPI.Command.Models;

namespace TitansAPI.Command.Action
{
    public interface IUsersEvent
    {
        Task<List<UsersModel>> GetList(IMapper _mapper);
        Task<UsersModel> GetAuthenticateUser(string UserName, string password, IMapper _mapper);
        Task<UsersModel> GetUserById(int Id);
        Task<UsersModel> PostUser(UserUrlModel value);
        Task<UsersModel> PostUpdateUser(UsersModel value);
    }
}
