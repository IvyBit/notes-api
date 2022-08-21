using AutoMapper;
using notes_api.Data.Entities;

namespace notes_api.DTO
{
    public class DTOMappingProfile : Profile
    {
        public DTOMappingProfile()
        {
            CreateMap<DTONote, Note>().ForMember(e => e.Id, opt => opt.Ignore());
            CreateMap<Note, DTONote>();
        }
    }
}
