using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Abstract.BuildingAbstractServices;
using DataAccessLayer.Abstract;
using DataAccessLayer.Abstract.BuildingInterfaces;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Concrete.EntityFramework.BuildingRepositories;
using EntityLayer.Concrete.Building;
using EntityLayer.ViewModels;
using EntityLayer.ViewModels.BuildingsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete.BuildingManagers
{
    public class BuildingFeatureManager : IBuildingFeatureService
    {
        private readonly IGenericRepository<BuildingFeature> _buildingFeatureRepository;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _databaseContext;
        public BuildingFeatureManager(IGenericRepository<BuildingFeature> buildingFeatureRepository, IMapper mapper, DatabaseContext databaseContext)
        {
            _buildingFeatureRepository = buildingFeatureRepository;
            _mapper = mapper;
            _databaseContext = databaseContext;
        }
        public async Task<BuildingFeatureListViewModel> Add(BuildingFeatureListViewModel buildingFeatureViewModel)
        {
            BuildingFeature road = await _buildingFeatureRepository.Add(_mapper.Map<BuildingFeature>(buildingFeatureViewModel));


            return _mapper.Map<BuildingFeatureListViewModel>(road);

        }



        public async Task Delete(int id)
        {
            BuildingFeature buildingFeature = await _buildingFeatureRepository.Get(id);

            await _databaseContext.SaveChangesAsync();

        }

        public async Task<BuildingFeatureViewModel> Get(int id)
        {
            BuildingFeature buildingFeature = await _buildingFeatureRepository.Get(id);
            return _mapper.Map<BuildingFeatureViewModel>(buildingFeature);
        }

        public async Task<List<BuildingFeatureViewModel>> Get()
        {
            List<BuildingFeature> buildingFeatures = await _buildingFeatureRepository.Get();
            return _mapper.Map<List<BuildingFeatureViewModel>>(buildingFeatures);

        }

        public async Task<BuildingFeatureViewModel> Update(BuildingFeatureViewModel buildingFeatureViewModel)
        {
            BuildingFeature buildingFeature = await _buildingFeatureRepository.Update(_mapper.Map<BuildingFeature>(buildingFeatureViewModel));
            return _mapper.Map<BuildingFeatureViewModel>(buildingFeature);
        }
    }
}