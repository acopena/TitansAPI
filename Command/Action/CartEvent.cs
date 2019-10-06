using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitansAPI.Command.Models;
using TitansAPI.Model;

namespace TitansAPI.Command.Action
{
    public class CartEvent : ICartEvent
    {
        public async Task<CartModel> GetCart(int userId)
        {
            CartModel cart  = new CartModel();
            using (var ctx = new titansContext())
            {
                var userInfo = await ctx.BUsers.Where(s => s.UserId == userId).Select(s=>s).FirstOrDefaultAsync();

                if (userInfo != null)
                {

                    var content = await ctx.BCart
                        .Include(s => s.BMemberRegistration)
                        .Where(s=>s.UserId == userInfo.UserId && s.CartStatusId == 1)
                        .Select(s => s).FirstOrDefaultAsync();

                    if (content != null)
                    {
                        cart.AssociationId = content.AssociationId.Value;
                        cart.CartDate = content.CartDate;
                        cart.CartGuid = content.CartGuid;
                        cart.CartStatusId = content.CartStatusId;
                        cart.SeasonId = content.SeasonId.Value;
                        cart.UserId = content.UserId;

                        cart.CartList = new List<CartListModel>();
                        foreach (var c in content.BMemberRegistration)
                        {
                            CartListModel m = new CartListModel();
                            m.MemberId = c.MemberId;
                            m.DivisionId = c.DivisionId.Value;
                            m.DivisionName = await ctx.BDivision.Where(s => s.DivisionId == c.DivisionId).Select(s => s.DivisionName).FirstOrDefaultAsync();
                            var member = ctx.BMember.Single(s => s.MemberId == m.MemberId);
                            m.LastName = member.LastName;
                            m.FirstName = member.FirstName;
                            m.Gender = member.Gender;
                            m.DateOfBirth = member.DateOfBirth.Value;
                            
                            cart.CartList.Add(m);
                        }
                    }
                    else
                    {
                        int CurrentSeason = ctx.BSeasonSetting.Where(s => s.AssociationId == 1).Select(s => s).FirstOrDefault().SeasonId;
                        cart = await GetNewCart(userId,  CurrentSeason);
                    }
                }
            }
            return cart;
        }
        public async Task<CartModel> GetNewCart(int userId, int seasonId)
        {
            CartModel cart = new CartModel();
            using (var ctx = new titansContext())
            {
                Guid cartGuid = new Guid();
                BCart  _cart = new BCart();
                _cart.CartGuid = cartGuid;
                _cart.CartDate = DateTime.Now;
                _cart.SeasonId = seasonId;
                _cart.UserId = userId;
                _cart.AssociationId = 1;
                await ctx.BCart.AddAsync(_cart);
                await ctx.SaveChangesAsync();

                cart.CartGuid = cartGuid;
                cart.CartDate = DateTime.Now;
                cart.SeasonId = seasonId;
                cart.UserId = userId;
                cart.AssociationId = 1;

            }
            return cart;
        }
    }
}
