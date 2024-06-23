using AutoMapper;
using EntityLayer.Concrete;

namespace Projects.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Örneğin, User ve UserDto arasında haritalama yapma
            CreateMap<ProjectNewListModel, ProjectNew>();
            CreateMap<ProjectNew, ProjectNewListModel>();
            CreateMap<Section, SectionModel>();
            CreateMap<SectionModel, Section>();
            CreateMap<SectionDetailModel, SectionDetail>();
            CreateMap<SectionDetail, SectionDetailModel>();
            CreateMap<Category, CategoryVm>().ReverseMap();

        }
    }
}
