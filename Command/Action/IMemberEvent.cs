using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TitansAPI.Command.Models;

namespace TitansAPI.Command.Action
{
    public interface IMemberEvent
    {
        Task<MemberUrlModel> GetMemberInfo(string FirstName, string LastName, string gender, DateTime BirthDate, IMapper _mapper);
        Task<MemberUrlModel> GetMemberById(int Id, IMapper _mapper);
        Task<int> SaveMember(MemberUrlModel data, IMapper _mapper);
    }
}
