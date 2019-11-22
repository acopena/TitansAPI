using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TitansAPI.Command.Models;
using TitansAPI.Model;

namespace TitansAPI.Command.Action
{
    public interface IMemberEvent
    {        
        Task<MemberUrlModel> GetMemberInfo(string FirstName, string LastName, string gender, DateTime BirthDate, IMapper _mapper, titansContext context);
        Task<MemberUrlModel> GetMemberById(int Id, IMapper _mapper, titansContext context);
        Task<CartModel> GetCart(int userId, IMapper _mapper, titansContext context);
        Task<CartModel> GetNewCart(int userId, int seasonId, IMapper _mapper, titansContext context);
        Task<int> SaveMember(MemberUrlModel data, IMapper _mapper, titansContext context);
        Task SaveCart(CartModel data, titansContext context);
    }
}
