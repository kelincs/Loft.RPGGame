using AutoMapper;
using Loft.RPGGame.Domain.Entities;
using Loft.RPGGame.Domain.Enums;
using Loft.RPGGame.WebAPI.Contracts;

namespace Loft.RPGGame.WebAPI.Mappings
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<Character, CharacterResult>()
                .ForMember(
                    dest => dest.OccupationName,
                    opt => opt.MapFrom(src => $"{src.Occupation.OccupationType}")
                )
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                )
                .ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => src.IsAlived ? StatusTypeEnum.Alive : StatusTypeEnum.Dead)
                );

            CreateMap<Character, CharacterDetailResult>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                )
                .ForMember(
                    dest => dest.OccupationName,
                    opt => opt.MapFrom(src => $"{src.Occupation.OccupationType}")
                )
                .ForMember(
                    dest => dest.Strenght,
                    opt => opt.MapFrom(src => src.Occupation.Attributes.AttributesDic[AttributeTypeEnum.Strenght])
                )
                .ForMember(
                    dest => dest.Dexterity,
                    opt => opt.MapFrom(src => src.Occupation.Attributes.AttributesDic[AttributeTypeEnum.Dexterity])
                )
                .ForMember(
                    dest => dest.HealthPoints,
                    opt => opt.MapFrom(src => src.Occupation.Attributes.AttributesDic[AttributeTypeEnum.HealthPoints])
                )
                .ForMember(
                    dest => dest.Intelligence,
                    opt => opt.MapFrom(src => src.Occupation.Attributes.AttributesDic[AttributeTypeEnum.Intelligence])
                )
                .ForMember(
                    dest => dest.Speed,
                    opt => opt.MapFrom(src => src.Occupation.BattleModifiers.BattleBonusSpeed)
                )                
                .ForMember(
                    dest => dest.Strike,
                    opt => opt.MapFrom(src => src.Occupation.BattleModifiers.BattleBonusStrike)
                );
        }

        
    }
}
