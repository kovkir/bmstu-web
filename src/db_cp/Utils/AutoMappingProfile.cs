using AutoMapper;
using db_cp.DTO;
using db_cp.ModelsBL;
using db_cp.Models;

namespace db_cp.Utils
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Agent, AgentBL>().ReverseMap();
            CreateMap<Club, ClubBL>().ReverseMap();
            CreateMap<Coach, CoachBL>().ReverseMap();
            CreateMap<Player, PlayerBL>().ReverseMap();
            CreateMap<Squad, SquadBL>().ReverseMap();
            CreateMap<SquadPlayer, SquadPlayerBL>().ReverseMap();
            CreateMap<User, UserBL>().ReverseMap();

            CreateMap<AgentBaseDto, AgentBL>().ReverseMap();
            CreateMap<AgentDto, AgentBL>().ReverseMap();
            CreateMap<ClubBaseDto, ClubBL>().ReverseMap();
            CreateMap<ClubDto, ClubBL>().ReverseMap();
            CreateMap<CoachBaseDto, CoachBL>().ReverseMap();
            CreateMap<CoachDto, CoachBL>().ReverseMap();
            CreateMap<PlayerBaseDto, PlayerBL>().ReverseMap();
            CreateMap<PlayerDto, PlayerBL>().ReverseMap();
            CreateMap<SquadBaseDto, SquadBL>().ReverseMap();
            CreateMap<SquadDto, SquadBL>().ReverseMap();
            CreateMap<SquadPlayerBaseDto, SquadPlayerBL>().ReverseMap();
            CreateMap<SquadPlayerDto, SquadPlayerBL>().ReverseMap();
            CreateMap<UserBaseDto, UserBL>().ReverseMap();
            CreateMap<UserDto, UserBL>().ReverseMap();
            CreateMap<UserPasswordDto, UserBL>().ReverseMap();
            CreateMap<UserIdPasswordDto, UserBL>().ReverseMap();
        }
    }
}
