using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Abstract.PoiAbstractServices;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;

using EntityLayer.Concrete.Point;
using EntityLayer.ViewModels.PoiViewModels;

namespace BusinessLayer.Concrete.PoiManagers
{//public class Geometry
    //{
    //    [System.ComponentModel.DataAnnotations.Key]
    //    public int Id { get; set; }
    //    public string ?type { get; set; }
    //    public List<double>? coordinates { get; set; }
    //}
    public class PoiManager : IPoiService
    {
        private readonly IGenericRepository<Poi> _poiRepository;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _databaseContext;
        public PoiManager(IGenericRepository<Poi> poiRepository, IMapper mapper, DatabaseContext databaseContext)
        {
            _poiRepository = poiRepository;
            _mapper = mapper;
            _databaseContext = databaseContext;
        }
        public async Task<PoiViewModel> Add(PoiViewModel poiViewModel)
        {

            Poi poi = await _poiRepository.Add(_mapper.Map<Poi>(poiViewModel));

            await _databaseContext.SaveChangesAsync();
            return _mapper.Map<PoiViewModel>(poi);

        }


        public async Task Delete(int id)
        {
            Poi exam = await _poiRepository.Get(id);

            await _databaseContext.SaveChangesAsync();

        }

        public async Task<PoiViewModel> Get(int id)
        {
            Poi root = await _poiRepository.Get(id);
            return _mapper.Map<PoiViewModel>(root);
        }

        public async Task<List<PoiViewModel>> Get()
        {
            List<Poi> roots = await _poiRepository.Get();
            return _mapper.Map<List<PoiViewModel>>(roots);

        }

        public async Task<PoiViewModel> Update(PoiViewModel poiViewModel)
        {
            Poi root = await _poiRepository.Update(_mapper.Map<Poi>(poiViewModel));
            return _mapper.Map<PoiViewModel>(root);
        }

      
    }
}
