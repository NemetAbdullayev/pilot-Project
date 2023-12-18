using AutoMapper;
using BusinessLayer.Abstract.BuildingAbstractServices;
using BusinessLayer.Abstract.PoiAbstractServices;
using Dapper;
using DataAccessLayer.Abstract.DapperInterface;
using EntityLayer.Concrete.Building;
using EntityLayer.Concrete.Point;
using EntityLayer.ViewModels.BuildingsViewModels;
using EntityLayer.ViewModels.PoiViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using NetTopologySuite.Geometries;
using NetTopologySuite.Index.HPRtree;
using Newtonsoft.Json;
using Npgsql;
using Npgsql.Internal;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace PilotProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        public readonly IDapperRepository<Building> _abstractDapperRepository;
        public readonly IDapperRepository<Poi> _poiAbstractDapperRepository;
        public readonly IBuildingService _buildingService;
        public readonly IBuildingFeatureService _buildingFeatureService;
        public readonly IMapper _mapper;

        public BuildingController(IBuildingFeatureService buildingFeatureService, IBuildingService buildingService, IPoiPropertiesService propertiesService, IMapper mapper, IDapperRepository<Building> abstractDapperRepository, IDapperRepository<Poi> poiAbstractDapperRepository)

        {
            _abstractDapperRepository = abstractDapperRepository;
            _poiAbstractDapperRepository = poiAbstractDapperRepository;
            _buildingFeatureService = buildingFeatureService;
            _buildingService = buildingService;

            _mapper = mapper;


        }
        [HttpPost("SaveBuildingsToDatabase")]
        public async Task Add()
        {
            StreamReader readerBuilding1 = new StreamReader("data/bina1.geojson");
            string buildings1 = readerBuilding1.ReadToEnd();
            readerBuilding1.Close();
            StreamReader readerBuilding2 = new StreamReader("data/bina2.geojson");
            string buildings2 = readerBuilding2.ReadToEnd();
            readerBuilding2.Close();

            BuildingFeatureViewModel? deserializedBuilding1 = JsonConvert.DeserializeObject<BuildingFeatureViewModel>(buildings1);
            BuildingFeatureViewModel? deserializedBuilding2 = JsonConvert.DeserializeObject<BuildingFeatureViewModel>(buildings2);

            List<BuildingViewModel> sameBuildings = new List<BuildingViewModel>();
        
           
            foreach (var item in deserializedBuilding1.features)
            {
                foreach (var item1 in deserializedBuilding2.features)
                {

                    bool equal =
              item.geometryModel.coordinates.Rank == item1.geometryModel.coordinates.Rank &&
              Enumerable.Range(0, item.geometryModel.coordinates.Rank).All(dimension => item.geometryModel.coordinates.GetLength(dimension) == item1.geometryModel.coordinates.GetLength(dimension)) &&
              item.geometryModel.coordinates.Cast<float>().SequenceEqual(item1.geometryModel.coordinates.Cast<float>()); ;
                    if (equal)
                    {
                        sameBuildings.Add(item1);
                    }
                }
            }
            deserializedBuilding1.features.AddRange(deserializedBuilding2.features);

            foreach (var item in sameBuildings)
            {
                deserializedBuilding1.features.Remove(item);
            }
            var deserializedProductNew = _mapper.Map<BuildingFeatureListViewModel>(deserializedBuilding1);

            var buildingModel =await  _buildingFeatureService.Add(deserializedProductNew);

            if (deserializedBuilding1.features != null)
            {
                foreach (var item in deserializedBuilding1.features)
                {
                    item.BuildingFeatureId = buildingModel.Id;
                    var model =await  _buildingService.Add(item);
                    string geometry = JsonConvert.SerializeObject(item.geometryModel);

                    string querry = "update \"Buildings\" set \"geometry\" = ST_GeomFromGeoJSON('" + geometry + "') ,\"BuildingFeatureId\"='" + buildingModel.Id + "'  where \"Id\"='" + model.Id + "'";
                    _abstractDapperRepository.Execute(querry);

                }
            }
        }

        [HttpDelete("{id}")]
        public  IActionResult Delete(int id)
        {
            string querry = "delete from  \"Buildings\"   where \"Id\"='" + id + "'";

            _abstractDapperRepository.Execute(querry);


            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            string querry = "SELECT  \"Id\", ST_AsGeoJSON(\"geometry\") ::geometry as \"geometry\" FROM \"Buildings\" where \"Id\"='" + id + "' \r\n";

            var result = _abstractDapperRepository.GetItem(querry);
           BuildingShowViewModel building = _mapper.Map<BuildingShowViewModel>(result);

            var opt = new JsonSerializerOptions
            {
                Converters =
               {
                   new  NetTopologySuite.IO.Converters.GeoJsonConverterFactory()
               }
            };
            string jsonString = System.Text.Json.JsonSerializer.Serialize(building, opt);
            return Ok(jsonString);
        }
        [HttpGet]
        public IActionResult Get()
        {

            string querry = "SELECT  \"Id\", ST_AsGeoJSON(\"geometry\") ::geometry  as \"geometry\" FROM \"Buildings\" \r\n";

            var result = _abstractDapperRepository.GetAllItems(querry);


            List<BuildingShowViewModel> buildings = _mapper.Map<List<BuildingShowViewModel>>(result);
            var opt = new JsonSerializerOptions
            {
                Converters =
               {
                   new  NetTopologySuite.IO.Converters.GeoJsonConverterFactory()
               }
            };
            string jsonString = System.Text.Json.JsonSerializer.Serialize(buildings, opt);




            return Ok(jsonString);
        }
        [HttpPost]
        public void Save([FromBody] BuildingSaveViewModel buildingViewModel)
        {
            string geometry = JsonConvert.SerializeObject(buildingViewModel.geometry);
            string querry = "insert into \"Buildings\" (geometry) values ( ST_GeomFromGeoJSON('" + geometry + "' ))";
            _abstractDapperRepository.Execute(querry);
        }
        [HttpPut("{id}")]
        public void Update([FromBody] BuildingSaveViewModel buildingViewModel,int id)
        {
            string geometry = JsonConvert.SerializeObject(buildingViewModel.geometry);
            string querry = "update  \"Buildings\" set  \"geometry\"  =ST_GeomFromGeoJSON('" + geometry + "' ) where \"Id\"='"+id+"' ";
            _abstractDapperRepository.Execute(querry);
        }

        [HttpGet("getPoi/{id}")]
        public IActionResult GetPoi(int id)
        {

            string querry = "select *  from \"Poi\" p where ST_Intersects\r\n    (p.\"geometry\",(select b.\"geometry\" from \"Buildings\" b where b.\"Id\"='"+id+"'))";

            var result = _poiAbstractDapperRepository.GetAllItems(querry);
            List<PoiShowViewModel> poies = _mapper.Map<List<PoiShowViewModel>>(result);
            var opt = new JsonSerializerOptions
            {
                Converters =
               {
                   new  NetTopologySuite.IO.Converters.GeoJsonConverterFactory()
               }
            };
            string jsonString = System.Text.Json.JsonSerializer.Serialize(poies, opt);
            return Ok(jsonString);
        }
    }
}
