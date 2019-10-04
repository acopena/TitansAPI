using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TitansAPI.Model;

namespace TitansAPI.Command.Action
{
    public interface IDivisionModel
    {
        Task<List<BDivision>> GetList();
        Task<BDivision> GetDivisionById(int id);
        Task<IEnumerable<BDivision>> GetDivisionByTypeId(int id);

    }
}
