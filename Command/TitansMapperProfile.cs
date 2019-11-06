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
            //CreateMap<BUsers, UsersModel>()
            //     .ForMember(dest => dest.AssociationName, opt => opt.MapFrom(src => src.Association.AssociationName))
            //     .ForMember(dest => dest.UserTypeName, opt => opt.MapFrom(src => src.UserType.UserTypeName))
            //.ReverseMap();

            CreateMap<BMember, MemberModel>()
            .ReverseMap();

            CreateMap<ContactInfoModel, BMemberContactInfo>()
                 .ForMember(dest => dest.ContactTypeId, opt => opt.MapFrom(src => int.Parse(src.contactTypeID)))
            .ReverseMap();

            CreateMap<EmergencyInfoModel, BMemberEmergencyContact>()
           .ReverseMap();

            CreateMap<BTeam, TeamTitansModel>()
                .ForMember(dest => dest.DivisionName, opt => opt.MapFrom(src => src.Division.DivisionName))
                .ForMember(dest => dest.TotalRosters, opt => opt.MapFrom(src => src.BTeamPlayers.Count))
                .ReverseMap();



            //CreateMap<BMember, MemberUrlModel>()
            //    .ForMember(dest => dest.BirthYear, opt => opt.MapFrom(src => src.DateOfBirth.Value.Year))
            //    .ForMember(dest => dest.BirthMonth, opt => opt.MapFrom(src => src.DateOfBirth.Value.Month))
            //    .ForMember(dest => dest.BirthDay, opt => opt.MapFrom(src => src.DateOfBirth.Value.Day))
            //    .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.BMemberContactInfo.ToList()))
            //    .ForMember(dest => dest.EmergencyInfo, opt => opt.MapFrom(src => src.BMemberEmergencyContact));

            CreateMap<MemberUrlModel, BMember>()
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => new DateTime(src.BirthYear, src.BirthMonth, src.BirthDay, 0, 0, 0)))
            .ForMember(dest => dest.AssociationId, opt => opt.MapFrom(src => 1)).ReverseMap();


            CreateMap<BContent, ContentModel>()
                 .ForMember(dest => dest.ContentTypeDesc, opt => opt.MapFrom(src => src.ContentType.ContentTypeName))
                 .ForMember(dest => dest.PageContentTitle, opt => opt.MapFrom(src => src.PageContent.PageContentTitle))
            .ReverseMap();

            CreateMap<BContent, ContentParamModel>()
           .ReverseMap();

            CreateMap<BUsers, UsersModel>();

            CreateMap<BOfficial, OfficialModel>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.OfficialFirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.OfficialLastName))
                .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.Position.PositionName));

            CreateMap<BOfficial, OfficialModel>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.OfficialFirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.OfficialLastName))
                .ReverseMap();

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

        }
    }
}
