using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLLManager.Interface;
using Microsoft.EntityFrameworkCore;
using SazMart.DAL.Database;
using SazMart.DAL.ModelClass.DTO;
using SazMart.DAL.ModelClass.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLLManager
{
    public class CityBLLManager : ICityBLLManager
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CityBLLManager(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<City> AddCityAsync(City city)
        {
            await _context.City.AddAsync(city);
            return city;
        }

        public async Task<IEnumerable<CityDTO>> GetAll()
        {
            return await _context.City
                .ProjectTo<CityDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool> IsExists(string cityName)
        {
            return await _context.City.AnyAsync(p => p.CityName == cityName);

        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
