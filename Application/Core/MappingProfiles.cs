using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Note, Note>();
            CreateMap<Appointment, Appointment>();
            CreateMap<Status, Status>();
        }
    }
}