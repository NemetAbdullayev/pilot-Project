
using AutoMapper;
using EntityLayer.Concrete.Building;
using EntityLayer.Concrete.Point;
using EntityLayer.Concrete.Road;
using EntityLayer.ViewModels;
using EntityLayer.ViewModels.BuildingsViewModels;
using EntityLayer.ViewModels.PoiViewModels;
using EntityLayer.ViewModels.RoadsViewModel;
using EntityLayer.ViewModels.RoadsViewModels;
using NetTopologySuite.Geometries;

namespace BusinessLayer.Mapper
{
    public class Automapper : Profile
    {
        public Automapper()
        {


            CreateMap<PoiViewModel, EntityLayer.Concrete.Point.Poi>().ReverseMap();
            CreateMap<PoiFeatureListViewModel, PoiFeature>().ReverseMap();
            CreateMap<PoiFeatureViewModel, PoiFeatureListViewModel>().ReverseMap();
            CreateMap<PoiFeature, PoiFeatureViewModel>().ReverseMap();

            CreateMap<BuildingFeatureViewModel, BuildingFeature>().ReverseMap();
            CreateMap<BuildingFeatureListViewModel, BuildingFeature>().ReverseMap();
           CreateMap<BuildingFeatureViewModel, BuildingFeatureListViewModel>().ReverseMap();
            CreateMap<Building, BuildingViewModel>().ReverseMap();
            CreateMap<Building, BuildingShowViewModel>().ReverseMap();
            CreateMap<RoadFeatureViewModel, RoadFeature>().ReverseMap();
            CreateMap<RoadFeatureListViewModel, RoadFeature>().ReverseMap();
            CreateMap<RoadFeatureViewModel, RoadFeatureListViewModel>().ReverseMap();
            CreateMap<Road, RoadViewModel>().ReverseMap();

        }
    }
}
