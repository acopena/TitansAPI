using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using System.Text;
using TitansAPI.Model;
using Microsoft.EntityFrameworkCore;
using TitansAPI.Command.Models;

namespace TitansAPI.Command.Action
{
    public class UsersEvent : IUsersEvent
    {
        public async Task<List<UsersModel>> GetList(IMapper _mapper, titansContext context)
        {
            List<UsersModel> userList = new List<UsersModel>();

            var users = await context.BUsers
                .Include(s => s.Association)
                .Include(s => s.UserType)
                .Select(s => s).ToListAsync();

            foreach (var r in users)
            {
                UsersModel model = _mapper.Map<UsersModel>(r);
                userList.Add(model);
            }
            return userList;
        }

        public async Task<UsersModel> GetAuthenticateUser(string UserName, string password, IMapper _mapper, titansContext context)
        {
            UsersModel model = new UsersModel();
            try
            {

                var user = await context.BUsers
                    .Include(s => s.Association)
                    .Include(s => s.UserType)
                    .Where(s => s.UserName == UserName && s.AccessCode == password)
                    .Select(s => s).FirstOrDefaultAsync();

                if (user != null)
                {
                    model = await GetUser(user, context);

                    var cart = await context.BCart.Where(s => s.UserId == user.UserId).Select(s => s).FirstOrDefaultAsync();
                    if (cart != null)
                    {
                        model.cartGuid = cart.CartGuid;
                    }
                    else
                    {
                        model.cartGuid = null;
                    }

                }
                else
                {
                    model = new UsersModel()
                    {
                        UserId = 0,
                        UserName = "",
                        FirstName = "",
                        LastName = "",
                        AssociationId = 0,
                        AssociationName = "",
                        cartGuid = null


                    };

                }
            }
            catch (Exception err)
            {
                string errmsg = err.Message;
            }
            return model;
        }

        public async Task<UsersModel> GetUserById(int Id, titansContext context)
        {
            UsersModel model = new UsersModel();

            var user = await context.BUsers
                .Include(s => s.Association)
                .Include(s => s.UserType)
                .Where(s => s.UserId == Id)
                .Select(s => s).FirstOrDefaultAsync();

            if (user != null)
            {
                model = await GetUser(user, context);
            }
            else
            {
                model = new UsersModel()
                {
                    UserId = 0,
                    UserName = "",
                    FirstName = "",
                    LastName = "",
                    AssociationId = 0,
                    AssociationName = ""

                };

            }

            return model;
        }

        static async Task<UsersModel> GetUser(BUsers src, titansContext ctx)
        {
            UsersModel model = new UsersModel();
            model.UserId = src.UserId;
            model.UserName = src.UserName;
            model.FirstName = src.FirstName;
            model.LastName = src.LastName;
            model.CellPhone = "613";
            model.AssociationId = src.AssociationId;
            model.AssociationName = src.Association.AssociationName;
            model.AccessCode = "xxxx";
            model.BlockAccount = src.BlockAccount;
            model.UserTypeId = src.UserTypeId;
            model.UserTypeName = ctx.BUserType.Where(s => s.UserTypeId == src.UserTypeId).Select(s => s.UserTypeName).FirstOrDefault();

            var season = await ctx.BSeasonSetting
                    .Where(s => s.AssociationId == 1)
                    .Select(s => s).FirstOrDefaultAsync();

            if (season != null)
            {
                model.SeasonId = season.SeasonId;
                model.SeasonName = season.SeasonId.ToString() + "-" + (season.SeasonId + 1).ToString();
            }

            return model;
        }


        public async Task<UsersModel> PostUser(UserUrlModel value, titansContext context)
        {
            int userId = 0;
            UsersModel model = new UsersModel();

            var dta = await (from p in context.BUsers
                             where p.UserName == value.UserName
                             select p).FirstOrDefaultAsync();

            if (dta == null)
            {
                BUsers p = new BUsers();
                p.UserName = value.UserName;
                p.FirstName = value.FirstName;
                p.LastName = value.LastName;
                p.BlockAccount = false;
                p.AssociationId = 1;
                p.AccessCode = value.Password;
                p.DateCreated = DateTime.Now;
                p.UserTypeId = 5;
                context.BUsers.Add(p);
                context.SaveChanges();
                userId = p.UserId;
            }
            else
            {
                userId = dta.UserId;
            }

            model = await GetUserById(userId, context);
            return model;
        }


        public async Task<UsersModel> PostUpdateUser(UsersModel value, titansContext context)
        {
            int userId = 0;
            UsersModel model = new UsersModel();

            var dta = await (from p in context.BUsers
                             where p.UserName == value.UserName
                             select p).FirstOrDefaultAsync();
            if (dta != null)
            {
                userId = dta.UserId;
                dta.BlockAccount = value.BlockAccount;
                dta.LastName = value.LastName;
                dta.FirstName = value.FirstName;
                dta.UserName = value.UserName;
                context.SaveChanges();
            }

            model = await GetUserById(userId, context);
            return model;
        }
    }
}
