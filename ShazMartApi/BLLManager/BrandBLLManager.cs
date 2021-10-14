using AutoMapper;
using BLLManager.Interface;
using Microsoft.EntityFrameworkCore;
using SazMart.DAL.Database;
using SazMart.DAL.ModelClass.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLLManager
{
    public class BrandBLLManager : IBrandBLLManager
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BrandBLLManager(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Brand> AddBrandAsync(Brand brand)
        {
            await _context.Brand.AddAsync(brand);
            return brand;
        }

        public async Task<IEnumerable<Brand>> GetAll()
        {
            return await _context.Brand.ToListAsync();
        }

        public async Task<bool> IsExits(string brandName)
        {
            return await _context.Brand.AnyAsync(p => p.BrandName == brandName);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
