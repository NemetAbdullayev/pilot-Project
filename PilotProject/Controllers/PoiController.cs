
using AutoMapper;
using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using GeoJSON.Net.Geometry;
using Microsoft.Data.SqlClient;
using Npgsql;
using Npgsql.Internal;
using System.Xml.Linq;
using BusinessLayer.Abstract.PoiAbstractServices;
using EntityLayer.ViewModels.PoiViewModels;
using NetTopologySuite.Index.HPRtree;
using EntityLayer.Concrete.Building;
using EntityLayer.Concrete.Point;
using DataAccessLayer.Abstract.DapperInterface;
using EntityLayer.ViewModels.BuildingsViewModels;

namespace PilotProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoiController : ControllerBase
    {
        public readonly IPoiService _poiService;
        public readonly IPoiFeatureService _poiFeatureService;
        public readonly IDapperRepository<Poi> _abstractDapperRepository;
        public readonly IPoiPropertiesService _propertiesService;
        public readonly IMapper _mapper;



        public PoiController(IPoiService rootService, IPoiFeatureService poiFeatureService, IPoiPropertiesService propertiesService, IMapper mapper, IDapperRepository<Poi> abstractDapperRepository)

        {
            _poiService = rootService;
            _poiFeatureService = poiFeatureService;
            _abstractDapperRepository = abstractDapperRepository;

            _propertiesService = propertiesService;
            _mapper = mapper;


        }

      
        [HttpPost("SavePoiToDatabase")]
        public async Task  Add()
        {
            StreamReader reader = new StreamReader("data/Poi.geojson");
            string contents = reader.ReadToEnd();
            reader.Close();

            PoiFeatureViewModel? deserializedProduct = JsonConvert.DeserializeObject<PoiFeatureViewModel>(contents);
            var deserializedProductNew = _mapper.Map<PoiFeatureListViewModel>(deserializedProduct);
            var poiModel =await  _poiFeatureService.Add(deserializedProductNew);

            if (deserializedProduct!=null &&  deserializedProduct.features != null)
            {
                foreach (var item in deserializedProduct.features)
                {
                    item.PoiFeatureId = poiModel.Id;
                    var model = await _poiService.Add(item);
                    string geometry = JsonConvert.SerializeObject(item.geometryModel);

                    string querry = "update \"Poi\" set \"geometry\" = ST_GeomFromGeoJSON('" + geometry + "')   where \"Id\"='" + model.Id + "'";
                    _abstractDapperRepository.Execute(querry);


                }
            }

        }

    }
}