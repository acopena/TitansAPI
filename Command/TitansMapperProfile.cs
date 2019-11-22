using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TitansAPI.Model;
using TitansAPI.Command.Models;

namespace TitansAPI.Command
{
    public class TitansAPIMapperProfile : Profile
    {
        public TitansAPIMapperProfile()
        {
           
            CreateMap<BTeam, TeamTitansModel>()
                .ForMember(dest => dest.DivisionName, opt => opt.MapFrom(src => src.Division.DivisionName))
                .ForMember(dest => dest.TotalRosters, opt => opt.MapFrom(src => src.BTeamPlayers.Count))
                .ReverseMap();


            // ********* Cart 
            CreateMap<BCart, CartModel>().ReverseMap();
            CreateMap<BMemberRegistration, CartListModel>()
                .ForMember(dest => dest.DivisionName, opt => opt.MapFrom(src => src.Division.DivisionName))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Member.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Member.LastName))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Member.Gender))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.Member.DateOfBirth))
                .ReverseMap();
            //*************


            CreateMap<BDivision, DivisionModel>();

            // *** Member mapping
            
            CreateMap<ContactInfoModel, BMemberContactInfo>()
               .ForMember(dest => dest.ContactTypeId, opt => opt.MapFrom(src => int.Parse(src.contactTypeID)))
          .ReverseMap();

            CreateMap<EmergencyInfoModel, BMemberEmergencyContact>()
           .ReverseMap();

            CreateMap<BMember, MemberUrlModel>()
                .ForMember(dest => dest.BirthYear, opt => opt.MapFrom(src => src.DateOfBirth.Value.Year))
                .ForMember(dest => dest.BirthMonth, opt => opt.MapFrom(src => src.DateOfBirth.Value.Month))
                .ForMember(dest => dest.BirthDay, opt => opt.MapFrom(src => src.DateOfBirth.Value.Day));

            CreateMap<MemberUrlModel, BMember>()
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => new DateTime(src.BirthYear, src.BirthMonth, src.BirthDay, 0, 0, 0)))
            .ForMember(dest => dest.AssociationId, opt => opt.MapFrom(src => 1));

            // *****************************


            // Content

            CreateMap<BContent, ContentModel>()
                 .ForMember(dest => dest.ContentTypeDesc, opt => opt.MapFrom(src => src.ContentType.ContentTypeName))
                 .ForMember(dest => dest.PageContentTitle, opt => opt.MapFrom(src => src.PageContent.PageContentTitle))
            .ReverseMap();

            CreateMap<BContent, ContentParamModel>()
           .ReverseMap();

            CreateMap<ContentParamModel, BContent>()
                .ForMember(dest => dest.PublishedStartDate, opt => opt.MapFrom(src => new DateTime(src.PublishStartYear, src.PublishStartMonth, src.PublishStartDay, 0, 0, 0)))
                .ForMember(dest => dest.PublishedEndDate, opt => opt.MapFrom(src => new DateTime(src.PublishedEndYear, src.PublishedEndMonth, src.PublishedEndDay, 0, 0, 0)));



            // ******************

            CreateMap<BUsers, UsersModel>()
                .ForMember(dest => dest.AssociationName, opt => opt.MapFrom(src => src.Association.AssociationName));

            CreateMap<BOfficial, OfficialModel>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.OfficialFirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.OfficialLastName))
                .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.Position.PositionName)).ReverseMap();

            //CreateMap<BOfficial, OfficialModel>()
            //    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.OfficialFirstName))
            //    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.OfficialLastName))
            //    .ReverseMap();

            CreateMap<BCalendar, CalendarModel>()
                .ForMember(dest => dest.Start, opt => opt.MapFrom(src => src.DateTimeStart))
                .ForMember(dest => dest.End, opt => opt.MapFrom(src => src.DateTimeEnd))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Subject))
                .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Notes))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => ""))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.PostedById))
                .ForMember(dest => dest.DatePosted, opt => opt.MapFrom(src => src.DatePosted));

            CreateMap<BCalendar, CalendarModel>()
               .ForMember(dest => dest.Start, opt => opt.MapFrom(src => src.DateTimeStart))
               .ForMember(dest => dest.End, opt => opt.MapFrom(src => src.DateTimeEnd))
               .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Subject))
               .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Notes))
               .ForMember(dest => dest.Color, opt => opt.MapFrom(src => ""))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.PostedById))
               .ForMember(dest => dest.DatePosted, opt => opt.MapFrom(src => src.DatePosted))
               .ReverseMap();



            CreateMap<BTeamGame, TeamGameModel>()
                .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.TeamName))
                .ForMember(dest => dest.TeamScore, opt => opt.MapFrom(src => src.BTeamStat.Sum(r => r.Points)));


            CreateMap<BTeamStat, TeamStatModel>()
                 .ForMember(dest => dest.MemberId, opt => opt.MapFrom(src => src.Member.MemberId))
                 .ForMember(dest => dest.MemberName, opt => opt.MapFrom(src => src.Member.FirstName + ' ' + src.Member.LastName));

            CreateMap<TeamStatModel, BTeamStat>()
               .ForMember(dest => dest.Member, opt => opt.Ignore())
               .ForMember(dest => dest.TeamGame, opt => opt.Ignore());

            CreateMap<TeamGameModel, BTeamGame>()
             .ForMember(dest => dest.Team, opt => opt.Ignore())
             .ForMember(dest => dest.PostedBy, opt => opt.Ignore());
        }
    }
}
