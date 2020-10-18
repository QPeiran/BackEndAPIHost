using AutoMapper;
using BackEndAPIHost.DTOs;
using BackEndAPIHost.Models;

namespace BackEndAPIHost.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //Source -> Destination
            CreateMap<Command, CommandReadDTO>();
            CreateMap<CommandCreateDTO, Command>();
            CreateMap<CommandUpdateDTO, Command>();
        }
    }
}