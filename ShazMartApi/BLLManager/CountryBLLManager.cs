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
    public class CountryBLLManager : ICountryBLLManager
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CountryBLLManager(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Country> AddCountryAsync(Country country)
        {
            await _context.Country.AddAsync(country);
            return country;
        }

        public async Task<IEnumerable< CountryDTO>> GetAllCountryAsync()
        {
            return await _context.Country
                .ProjectTo<CountryDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool> IsExists(string countryName)
        {
            return await _context.Country.AnyAsync(p => p.CountryName == countryName);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
