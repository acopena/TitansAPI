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

            CreateMap<BTeam, TeamModel>()
                .ForMember(dest => dest.DivisionName, opt => opt.MapFrom(src => src.Division.DivisionName))
                .ForMember(dest => dest.TotalRosters, opt => opt.MapFrom(src => src.BTeamPlayers.Count))
                .ReverseMap(); 






            CreateMap<MemberUrlModel, BMember>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => new DateTime(src.BirthYear, src.BirthMonth, src.BirthDay, 0, 0, 0)))
                .ForMember(dest => dest.AssociationId, opt => opt.MapFrom(src => 1)).ReverseMap();

            //CreateMap<BMember, MemberUrlModel>()
            //    .ForMember(dest => dest.BirthYear, opt => opt.MapFrom(src => src.DateOfBirth.Value.Year))
            //    .ForMember(dest => dest.BirthMonth, opt => opt.MapFrom(src => src.DateOfBirth.Value.Month))
            //    .ForMember(dest => dest.BirthDay, opt => opt.MapFrom(src => src.DateOfBirth.Value.Day));
                //.ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.BMemberContactInfo.ToList()))
                //.ForMember(dest => dest.EmergencyInfo, opt => opt.MapFrom(src => src.BMemberEmergencyContact))
                

            CreateMap<BContent, ContentModel>()
                 .ForMember(dest => dest.ContentTypeDesc, opt => opt.MapFrom(src => src.ContentType.ContentTypeName))
                 .ForMember(dest => dest.PageContentTitle, opt => opt.MapFrom(src => src.PageContent.PageContentTitle))
            .ReverseMap();

            CreateMap<BContent, ContentParamModel>()
           .ReverseMap();

            CreateMap<BUsers, UsersModel>();




        }
    }
}
