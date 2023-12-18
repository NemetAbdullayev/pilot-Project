using AutoMapper;
using BusinessLayer.Abstract.RoadAbstractServices;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete.Road;
using EntityLayer.ViewModels.RoadsViewModel;
using EntityLayer.ViewModels.RoadsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete.RoadManagers
{
    public class RoadFeatureManager : IRoadFeautreService
    {
        private readonly IGenericRepository<RoadFeature> _roadRootRepository;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _databaseContext;
        public RoadFeatureManager(IGenericRepository<RoadFeature> roadRootRepository, IMapper mapper, DatabaseContext databaseContext)
        {
            _roadRootRepository = roadRootRepository;
            _mapper = mapper;
            _databaseContext = databaseContext;
        }
        public async Task<RoadFeatureListViewModel> Add(RoadFeatureListViewModel roadRootViewModel)
        {

            RoadFeature roadRoot = await _roadRootRepository.Add(_mapper.Map<RoadFeature>(roadRootViewModel));


            return _mapper.Map<RoadFeatureListViewModel>(roadRoot);

        }
      


        public async Task Delete(int id)
        {
            RoadFeature roadRoot = await _roadRootRepository.Get(id);

            await _databaseContext.SaveChangesAsync();

        }

        public async Task<RoadFeatureViewModel> Get(int id)
        {
            RoadFeature roadRoot = await _roadRootRepository.Get(id);
            return _mapper.Map<RoadFeatureViewModel>(roadRoot);
        }

        public async Task<List<RoadFeatureViewModel>> Get()
        {
            List<RoadFeature> roots = await _roadRootRepository.Get();
            return _mapper.Map<List<RoadFeatureViewModel>>(roots);

        }

        public async Task<RoadFeatureViewModel> Update(RoadFeatureViewModel rootViewModel)
        {
            RoadFeature roadRoot = await _roadRootRepository.Update(_mapper.Map<RoadFeature>(rootViewModel));
            return _mapper.Map<RoadFeatureViewModel>(roadRoot);
        }

       
    }
}