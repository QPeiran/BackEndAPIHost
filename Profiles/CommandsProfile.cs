using AutoMapper;
using BackEndAPIHost.DTOs;
using BackEndAPIHost.Models;

namespace BackEndAPIHost.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandReadDTO>();
        }
    }
}