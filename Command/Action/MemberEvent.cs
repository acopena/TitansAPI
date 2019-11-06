using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TitansAPI.Command.Models;
using TitansAPI.Common;
using TitansAPI.Model;

namespace TitansAPI.Command.Action
{
    public class MemberEvent : IMemberEvent
    {
        public async Task<MemberUrlModel> GetMemberInfo(string FirstName, string LastName, string gender, DateTime BirthDate, IMapper _mapper, titansContext context)
        {
            MemberUrlModel model = new MemberUrlModel();
            var memberInfo = await context.BMember
             .Include(s => s.BMemberContactInfo)
             .Include(s => s.BMemberEmergencyContact)
             .Where(s => s.FirstName == FirstName && s.LastName == LastName
             && s.Gender == gender
             && s.DateOfBirth.Value.Year == BirthDate.Year
             && s.DateOfBirth.Value.Month == BirthDate.Month
             && s.DateOfBirth.Value.Day == BirthDate.Day)
             .Select(s => s).FirstOrDefaultAsync();

            if (memberInfo != null)
            {
                try
                {
                    model = _mapper.Map<MemberUrlModel>(memberInfo);
                    model.MemberId = memberInfo.MemberId;
                    model.BirthYear = memberInfo.DateOfBirth.Value.Year;
                    model.BirthMonth = memberInfo.DateOfBirth.Value.Month;
                    model.BirthDay = memberInfo.DateOfBirth.Value.Day;
                    var eInfo = memberInfo.BMemberEmergencyContact.FirstOrDefault();

                    model.EmergencyInfo = _mapper.Map<EmergencyInfoModel>(eInfo);
                    var cInfo = memberInfo.BMemberContactInfo.ToList();
                    model.ContactInfo = _mapper.Map<List<ContactInfoModel>>(cInfo);
                }
                catch (Exception err)
                {
                    string errmsg = err.Message;
                }
            }
            else
            {
                model.MemberId = 0;
                model.FirstName = "";
                model.LastName = "";
            }

            return model;
        }

        public async Task<MemberUrlModel> GetMemberById(int Id, IMapper _mapper, titansContext context)
        {
            MemberUrlModel model = new MemberUrlModel();

            var memberInfo = await context.BMember
                .Include(s => s.BMemberContactInfo)
                .Include(s => s.BMemberEmergencyContact)
                .Where(s => s.MemberId == Id)
                .Select(s => s).FirstOrDefaultAsync();
            if (memberInfo != null)
            {
                try
                {
                    model = _mapper.Map<MemberUrlModel>(memberInfo);
                    model.BirthYear = memberInfo.DateOfBirth.Value.Year;
                    model.BirthMonth = memberInfo.DateOfBirth.Value.Month;
                    model.BirthDay = memberInfo.DateOfBirth.Value.Day;
                    var eInfo = memberInfo.BMemberEmergencyContact.FirstOrDefault();

                    model.EmergencyInfo = _mapper.Map<EmergencyInfoModel>(eInfo);
                    var cInfo = memberInfo.BMemberContactInfo.ToList();
                    model.ContactInfo = _mapper.Map<List<ContactInfoModel>>(cInfo);
                }
                catch (Exception err)
                {
                    string errmsg = err.Message;
                }
            }
            else
            {
                model.MemberId = 0;
                model.FirstName = "";
                model.LastName = "";
            }

            return model;
        }


        public async Task<CartModel> GetCart(int userId, titansContext context)
        {
            CartModel cart = new CartModel();

            var userInfo = await context.BUsers.Where(s => s.UserId == userId).Select(s => s).FirstOrDefaultAsync();

            if (userInfo != null)
            {

                var content = await context.BCart
                    .Include(s => s.BMemberRegistration)
                    .Where(s => s.UserId == userInfo.UserId && s.CartStatusId == 1)
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
                        m.DivisionName = await context.BDivision.Where(s => s.DivisionId == c.DivisionId).Select(s => s.DivisionName).FirstOrDefaultAsync();
                        var member = context.BMember.Single(s => s.MemberId == m.MemberId);
                        m.LastName = member.LastName;
                        m.FirstName = member.FirstName;
                        m.Gender = member.Gender;
                        m.DateOfBirth = member.DateOfBirth.Value;

                        cart.CartList.Add(m);
                    }
                }
                else
                {
                    int CurrentSeason = context.BSeasonSetting.Where(s => s.AssociationId == 1).Select(s => s).FirstOrDefault().SeasonId;
                    cart = await GetNewCart(userId, CurrentSeason, context);
                }
            }

            return cart;
        }
        public async Task<CartModel> GetNewCart(int userId, int seasonId, titansContext context)
        {
            try
            {
                CartModel cart = new CartModel();

                Guid cartGuid = Guid.NewGuid();
                BCart _cart = new BCart();
                _cart.CartGuid = cartGuid;
                _cart.CartDate = DateTime.Now;
                _cart.CartStatusId = 1;
                _cart.SeasonId = seasonId;
                _cart.UserId = userId;
                _cart.AssociationId = 1;
                await context.BCart.AddAsync(_cart);
                await context.SaveChangesAsync();

                cart.CartGuid = cartGuid;
                cart.CartDate = DateTime.Now;
                cart.SeasonId = seasonId;
                cart.UserId = userId;
                cart.AssociationId = 1;
                return cart;
            }
            catch (Exception err)
            {
                string error = err.Message;
            }
            return null;
        }

        public async Task<int> SaveMember(MemberUrlModel data, IMapper _mapper, titansContext context)
        {
            int memberId = 0;
            BMember member = new BMember();


            if (data.MemberId > 0)
            {
                member = await (from p in context.BMember
                                .Include(s => s.BMemberContactInfo)
                                .Include(s => s.BMemberEmergencyContact)
                                where p.MemberId == data.MemberId
                                select p).FirstOrDefaultAsync();
            }
            else
            {
                member = await (from p in context.BMember
                                .Include(s => s.BMemberContactInfo)
                                .Include(s => s.BMemberEmergencyContact)
                                where p.FirstName == data.FirstName && p.LastName == data.LastName && p.Gender == data.Gender
                                    && p.DateOfBirth.Value.Year == data.BirthYear
                                    && p.DateOfBirth.Value.Month == data.BirthMonth
                                    && p.DateOfBirth.Value.Day == data.BirthDay
                                select p).FirstOrDefaultAsync();
            }

            if (member == null)
            {

                BMember m = _mapper.Map<BMember>(data);
                m.DateCreated = DateTime.Now;
                await context.BMember.AddAsync(m);

                foreach (var r in data.ContactInfo)
                {
                    if (!String.IsNullOrEmpty(r.memberContactName) && !String.IsNullOrEmpty(r.contactTypeID))
                    {
                        BMemberContactInfo c = _mapper.Map<BMemberContactInfo>(r);
                        c.MemberId = m.MemberId;
                        await context.BMemberContactInfo.AddAsync(c);
                    }
                }

                if (!String.IsNullOrEmpty(data.EmergencyInfo.emergencyContactName))
                {
                    BMemberEmergencyContact e = _mapper.Map<BMemberEmergencyContact>(data.EmergencyInfo);
                    e.MemberId = m.MemberId;
                    await context.BMemberEmergencyContact.AddAsync(e);
                }
                await context.SaveChangesAsync();
                memberId = m.MemberId;
            }
            else
            {
                memberId = member.MemberId;
                member = SetMemberInfo(member, data);
                context.BMember.Update(member);

                foreach (var r in data.ContactInfo)
                {
                    if (!String.IsNullOrEmpty(r.memberContactName) && !String.IsNullOrEmpty(r.contactTypeID))
                    {
                        var cInfo = member.BMemberContactInfo.Where(s => s.MemberContactId == r.memberContactId).Select(s => s).FirstOrDefault();
                        if (cInfo != null)
                        {
                            cInfo = SetContactInfo(cInfo, r);
                            cInfo.MemberId = data.MemberId;
                            context.BMemberContactInfo.Update(cInfo);
                        }
                        else
                        {
                            BMemberContactInfo _cInfo = new BMemberContactInfo();
                            _cInfo = _mapper.Map<BMemberContactInfo>(r);
                            _cInfo.MemberId = data.MemberId;
                            await context.BMemberContactInfo.AddAsync(_cInfo);
                        }
                    }
                }
                if (!String.IsNullOrEmpty(data.EmergencyInfo.emergencyContactName))
                {
                    var eInfo = member.BMemberEmergencyContact.Where(s => s.EmergencyContactId == data.EmergencyInfo.emergencyContactId).Select(s => s).FirstOrDefault();
                    if (eInfo != null)
                    {
                        eInfo = SetEmergencyInfo(eInfo, data.EmergencyInfo);
                        eInfo.MemberId = data.MemberId;
                        context.BMemberEmergencyContact.Update(eInfo);
                    }
                    else
                    {
                        BMemberEmergencyContact _eInfo = new BMemberEmergencyContact();
                        _eInfo = _mapper.Map<BMemberEmergencyContact>(data.EmergencyInfo);
                        await context.BMemberEmergencyContact.AddAsync(_eInfo);
                    }
                }

            }
            await context.SaveChangesAsync();


            int CurrentSeason = context.BSeasonSetting.Single(s => s.AssociationId == 1).SeasonId;
            Guid cartGuid = new Guid();

            //Get UserInfo if there is a GUid open if not then create one.

            var CartInfo = await context.BCart.Where(s => s.UserId == data.UserId && s.CartStatusId == 1).Select(s => s).FirstOrDefaultAsync();
            if (CartInfo == null)
            {
                cartGuid = Guid.NewGuid();
                BCart _cart = new BCart();
                _cart.CartGuid = cartGuid;
                _cart.CartDate = DateTime.Now;
                _cart.CartStatusId = 1;
                _cart.SeasonId = CurrentSeason;
                _cart.UserId = data.UserId;
                _cart.AssociationId = 1;
                await context.BCart.AddAsync(_cart);
                await context.SaveChangesAsync();
            }
            else
            {
                cartGuid = CartInfo.CartGuid;
            }

            //Update the MemberRegistration Here

            var mReg = await context.BMemberRegistration.Where(s => s.MemberId == memberId && s.SeasonId == CurrentSeason).Select(s => s).FirstOrDefaultAsync();
            if (mReg == null)
            {
                BMemberRegistration reg = new BMemberRegistration();
                reg.MemberId = memberId;
                reg.UserId = data.UserId;
                reg.SeasonId = CurrentSeason;
                reg.WaiverId = 1;
                reg.DateReg = DateTime.Now;
                reg.CartGuid = cartGuid;
                reg.DivisionId = await CommonEvent.GetDivisionId(data.BirthYear, context);
                reg.WaiverIagree = true;
                await context.BMemberRegistration.AddAsync(reg);

            }
            else
            {
                mReg.CartGuid = cartGuid;
                mReg.DateReg = DateTime.Now;
                mReg.UserId = data.UserId;
            }
            await context.SaveChangesAsync();

            return data.MemberId;
        }

        static BMember SetMemberInfo(BMember dest, MemberUrlModel src)
        {
            dest.FirstName = src.FirstName;
            dest.LastName = src.LastName;
            dest.Gender = src.Gender;
            dest.DateOfBirth = new DateTime(src.BirthYear, src.BirthMonth, src.BirthDay, 0, 0, 0);
            dest.AssociationId = 1;
            dest.DateUpdated = DateTime.Now;
            dest.UserId = src.UserId;
            dest.MemberNotes = src.MemberNotes;
            dest.JerseyNo = src.JerseyNo;
            dest.Address = src.Address;
            return dest;
        }

        static BMemberContactInfo SetContactInfo(BMemberContactInfo dest, ContactInfoModel src)
        {
            dest.MemberContactName = src.memberContactName;
            dest.MemberHomePhone = src.memberHomePhone;
            dest.MemberCellPhone = src.memberCellPhone;
            dest.MemberEmail = src.memberEmail;
            dest.ContactTypeId = int.Parse(src.contactTypeID);
            dest.PrimaryContact = src.primaryContact;

            return dest;
        }

        static BMemberEmergencyContact SetEmergencyInfo(BMemberEmergencyContact dest, EmergencyInfoModel src)
        {
            dest.EmergencyContactName = src.emergencyContactName;
            dest.EmergencyAddress = src.emergencyAddress;
            dest.EmergencyContactNo = src.emergencyContactNo;
            dest.EmergencyRelationShip = src.emergencyRelationShip;
            return dest;
        }


        public async Task SaveCart(CartModel data, titansContext context)
        {
            var cart = await context.BCart
                .Where(s => s.CartGuid == data.CartGuid)
                .Select(s => s).FirstOrDefaultAsync();
            if (cart != null)
            {
                //Close the cart.
                cart.CartStatusId = 2;
                await context.SaveChangesAsync();
            }
            return;
        }
    }
}
