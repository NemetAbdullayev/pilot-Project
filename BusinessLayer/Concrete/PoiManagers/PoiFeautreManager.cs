using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Abstract.PoiAbstractServices;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete.Point;
using EntityLayer.ViewModels;
using EntityLayer.ViewModels.PoiViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete.PoiManagers
{
    public class PoiFeatureManager : IPoiFeatureService
    {
        private readonly IGenericRepository<PoiFeature> _featureRepository;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _databaseContext;
        public PoiFeatureManager(IGenericRepository<PoiFeature> examRepository, IMapper mapper, DatabaseContext databaseContext)
        {
            _featureRepository = examRepository;
            _mapper = mapper;
            _databaseContext = databaseContext;
        }
        public async Task<PoiFeatureListViewModel> Add(PoiFeatureListViewModel featureListViewModel)
        {
            PoiFeature feature = await _featureRepository.Add(_mapper.Map<PoiFeature>(featureListViewModel));

            return _mapper.Map<PoiFeatureListViewModel>(feature);

        }



        public async Task Delete(int examId)
        {
            PoiFeature feature = await _featureRepository.Get(examId);

            await _databaseContext.SaveChangesAsync();

        }

        public async Task<PoiFeatureListViewModel> Get(int id)
        {
            PoiFeature feature = await _featureRepository.Get(id);
            return _mapper.Map<PoiFeatureListViewModel>(feature);
        }

        public async Task<List<PoiFeatureListViewModel>> Get()
        {
            List<PoiFeature> features = await _featureRepository.Get();
            return _mapper.Map<List<PoiFeatureListViewModel>>(features);

        }

        public async Task<PoiFeatureListViewModel> Update(PoiFeatureListViewModel featureListViewModel)
        {
            PoiFeature feature = await _featureRepository.Update(_mapper.Map<PoiFeature>(featureListViewModel));
            return _mapper.Map<PoiFeatureListViewModel>(feature);
        }
    }
}