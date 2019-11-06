using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TitansAPI.Command.Models;
using TitansAPI.Model;

namespace TitansAPI.Command.Action
{
    public interface IDivisionEvent
    {
        Task<List<DivisionModel>> GetList(IMapper mapper, titansContext context);
        Task<DivisionModel> GetDivisionById(int id, IMapper mapper, titansContext context);
        Task<List<DivisionModel>> GetDivisionByTypeId(int id, IMapper mapper, titansContext context);

    }
}
