using AutoMapper;
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
    public class PoiPropertiesManager : IPoiPropertiesService
    {
        private readonly IGenericRepository<PoiProperties> _propertiesRepository;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _databaseContext;
        public PoiPropertiesManager(IGenericRepository<PoiProperties> examRepository, IMapper mapper, DatabaseContext databaseContext)
        {
            _propertiesRepository = examRepository;
            _mapper = mapper;
            _databaseContext = databaseContext;
        }
        public async Task<PoiProperties> Add(PoiProperties propertiesViewModel)
        {
            PoiProperties exam = await _propertiesRepository.Add(_mapper.Map<PoiProperties>(propertiesViewModel));

            return _mapper.Map<PoiProperties>(exam);

        }



        public async Task Delete(int id)
        {
            PoiProperties properties = await _propertiesRepository.Get(id);

            await _databaseContext.SaveChangesAsync();

        }

        public async Task<PoiProperties> Get(int id)
        {
            PoiProperties properties = await _propertiesRepository.Get(id);
            return _mapper.Map<PoiProperties>(properties);
        }

        public async Task<List<PoiProperties>> Get()
        {
            List<PoiProperties> properties = await _propertiesRepository.Get();
            return _mapper.Map<List<PoiProperties>>(properties);

        }

        public async Task<PoiProperties> Update(PoiProperties propertiesViewModel)
        {
            PoiProperties exam = await _propertiesRepository.Update(_mapper.Map<PoiProperties>(propertiesViewModel));
            return _mapper.Map<PoiProperties>(exam);
        }
    }
}
