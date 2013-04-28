
namespace Mvc4Demo.Mappings
{
    using AutoMapper;
    using DataModel;
    using Mvc4Demo.Models;

    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Categories, CategoriesViewModel>();
        }
    }



}