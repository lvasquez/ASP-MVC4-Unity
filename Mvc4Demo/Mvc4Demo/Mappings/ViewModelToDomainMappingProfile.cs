namespace Mvc4Demo.Mappings
{
    using AutoMapper;
    using DataModel;
    using Mvc4Demo.Models;

    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CategoriesViewModel, Categories>();
        }
    }
}