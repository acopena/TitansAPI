using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TitansAPI.Command.Models;
using TitansAPI.Model;

namespace TitansAPI.Command.Action
{
    public interface IUsersEvent
    {
        Task<List<UsersModel>> GetList(IMapper _mapper, titansContext context);
        Task<UsersModel> GetAuthenticateUser(string UserName, string password, IMapper _mapper, titansContext context);
        Task<UsersModel> GetUserById(int Id, titansContext context);
        Task<UsersModel> PostUser(UserUrlModel value, titansContext context);
        Task<UsersModel> PostUpdateUser(UsersModel value, titansContext context);
    }
}
