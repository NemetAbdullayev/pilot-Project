using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Abstract.BuildingAbstractServices;
using BusinessLayer.Abstract.RoadAbstractServices;
using DataAccessLayer.Abstract.DapperInterface;
using DataAccessLayer.Abstract.RoadInterfaces;
using EntityLayer.Concrete.Building;
using EntityLayer.Concrete.Road;
using EntityLayer.ViewModels.BuildingsViewModels;
using EntityLayer.ViewModels.RoadsViewModel;
using EntityLayer.ViewModels.RoadsViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Npgsql;
using System.Linq;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PilotProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoadController : ControllerBase
    {
        public readonly IRoadService _roadService;
        public readonly IRoadFeautreService _roadRootService;
        public readonly IDapperRepository<Road> _abstractDapperRepository;
        public readonly IMapper _mapper;



        public RoadController(IRoadService roadService, IRoadFeautreService roadRootService, IMapper mapper, IDapperRepository<Road> abstractDapperRepository)

        {
            _abstractDapperRepository = abstractDapperRepository;
            _roadService = roadService;
            _roadRootService = roadRootService;


            _mapper = mapper;


        }

        [HttpPost("SaveRoadsToDatabase")]
        public async Task Add()
        {
            StreamReader reader = new StreamReader("data/yollar.geojson");
            string roads = reader.ReadToEnd();
            reader.Close();

            RoadFeatureViewModel? deserializedRoad = JsonConvert.DeserializeObject<RoadFeatureViewModel>(roads);
            var deserializedRoadNew = _mapper.Map<RoadFeatureListViewModel>(deserializedRoad);

            var roadModel = await _roadRootService.Add(deserializedRoadNew);
            if (deserializedRoad != null && deserializedRoad.features != null)
            {
                foreach (var item in deserializedRoad.features)
                {
                    item.RoadFeatureId = roadModel.Id;
                    var model = await _roadService.Add(item);
                    string geometry = JsonConvert.SerializeObject(item.geometryModel);
                    string querrySelect = "select * from \"Roads\" where \"geometry\" = ST_GeomFromGeoJSON('" + geometry + "') ";
                    var a = _abstractDapperRepository.GetAllItems(querrySelect);
                    string querryUpdate = "update \"Roads\" set \"geometry\" = ST_GeomFromGeoJSON('" + geometry + "')   where \"Id\"='" + model.Id + "'";

                        _abstractDapperRepository.Execute(querryUpdate);
                }
                string querryDelete = "delete from \"Roads\" c where c.\"Id\" in(\tselect distinct(a.\"Id\") aid from \"Roads\" a, \"Roads\" b where ST_Intersects\r\n    (a.\"geometry\",b.\"geometry\") AND a.\"Id\"<b.\"Id\")";
                _abstractDapperRepository.Execute(querryDelete);
            }


        }

    }
}
