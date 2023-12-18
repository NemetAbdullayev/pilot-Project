using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Abstract.BuildingAbstractServices;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Concrete.EntityFramework.BuildingRepositories;
using EntityLayer.Concrete.Building;
using EntityLayer.Concrete.Road;
using EntityLayer.ViewModels;
using EntityLayer.ViewModels.BuildingsViewModels;
using EntityLayer.ViewModels.RoadsViewModel;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete.BuildingManagers
{
    public class BuildingManager : IBuildingService
    {
        private readonly IGenericRepository<Building> _buildingRepository;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _databaseContext;
        public BuildingManager(IGenericRepository<Building> buildingRepository, IMapper mapper, DatabaseContext databaseContext)
        {
            _buildingRepository = buildingRepository;
            _mapper = mapper;
            _databaseContext = databaseContext;
        }

        public async Task<BuildingViewModel> Add(BuildingViewModel buildingViewModel)
        {
            Building road = await _buildingRepository.Add(_mapper.Map<Building>(buildingViewModel));


            return _mapper.Map<BuildingViewModel>(road);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BuildingViewModel> Get(int id)
        {
            Building building = await _buildingRepository.Get(id);
            return _mapper.Map<BuildingViewModel>(building);
        }

        public async Task<List<BuildingViewModel>> Get()
        {
          
            List<Building> buildings = await _buildingRepository.Get();
              return _mapper.Map<List<BuildingViewModel>>(buildings); ;

        }

        public async Task<BuildingViewModel> Update(BuildingViewModel buildingViewModel)
        {
            Building building = await _buildingRepository.Update(_mapper.Map<Building>(buildingViewModel));
            return _mapper.Map<BuildingViewModel>(building);
        }


    }
}

