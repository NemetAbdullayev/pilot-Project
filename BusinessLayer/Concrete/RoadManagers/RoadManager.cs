using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Abstract.RoadAbstractServices;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Concrete.EntityFramework.RoadRepositories;
using EntityLayer.Concrete.Road;
using EntityLayer.ViewModels;
using EntityLayer.ViewModels.RoadsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete.RoadManagers
{
    public class RoadManager : IRoadService
    {
        private readonly IGenericRepository<Road> _roadRepository;
        private readonly IMapper _mapper;
        private readonly DatabaseContext _databaseContext;
        public RoadManager(IGenericRepository<Road> roadRepository, IMapper mapper, DatabaseContext databaseContext)
        {
            _roadRepository = roadRepository;
            _mapper = mapper;
            _databaseContext = databaseContext;
        }
        public async Task<RoadViewModel> Add(RoadViewModel roadViewModel)
        {

            Road road = await _roadRepository.Add(_mapper.Map<Road>(roadViewModel));


            return _mapper.Map<RoadViewModel>(road);

        }
    }
}