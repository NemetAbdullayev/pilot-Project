using AutoMapper;
using BusinessLayer.Abstract.RoadAbstractServices;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Concrete.EntityFramework.RoadRepositories;
using EntityLayer.Concrete.Road;
using EntityLayer.ViewModels.RoadsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete.RoadManagers
{
    public class RoadPropertiesManager : IRoadPropertiesService
    {
        private readonly IGenericRepository<RoadProperties> _roadPropertiesRepository; 
        private readonly IMapper _mapper;
        private readonly DatabaseContext _databaseContext;
        public RoadPropertiesManager(IGenericRepository<RoadProperties> roadPropertiesRepository, IMapper mapper, DatabaseContext databaseContext)
        {
            _roadPropertiesRepository = roadPropertiesRepository;
            _mapper = mapper;
            _databaseContext = databaseContext;
        }
        public async Task<RoadProperties> Add(RoadProperties roadPropertiesModel)
        {

            RoadProperties roadProperties = await _roadPropertiesRepository.Add((roadPropertiesModel));


            return _mapper.Map<RoadProperties>(roadProperties);

        }



        public async Task Delete(int id)
        {
            RoadProperties roadProperties = await _roadPropertiesRepository.Get(id);

            await _databaseContext.SaveChangesAsync();

        }

        public async Task<RoadProperties> Get(int id)
        {
            RoadProperties roadProperties = await _roadPropertiesRepository.Get(id);
            return roadProperties;
        }

        public async Task<List<RoadProperties>> Get()
        {
            List<RoadProperties> roadProperties = await _roadPropertiesRepository.Get();
            return roadProperties;

        }

        public async Task<RoadProperties> Update(RoadProperties roadPropertiesModel)
        {
            RoadProperties roadProperties = await _roadPropertiesRepository.Update(roadPropertiesModel);
            return roadProperties;
        }
    }
}