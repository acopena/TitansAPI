using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TitansAPI.Command.Models;

namespace TitansAPI.Command.Action
{
    public interface ICartEvent
    {
        Task<CartModel> GetCart(int userId);
        Task<CartModel> GetNewCart(int userId, int seasonId);
    }
}
