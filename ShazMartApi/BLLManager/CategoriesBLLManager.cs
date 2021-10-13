using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLLManager.Interface;
using Microsoft.EntityFrameworkCore;
using SazMart.DAL.Database;
using SazMart.DAL.ModelClass.DTO;
using SazMart.DAL.ModelClass.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLManager
{
    public class CategoriesBLLManager : ICategoriesBLLManager
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CategoriesBLLManager(DatabaseContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Categories> AddCategoriesAsync(Categories categories)
        {
            await _context.Categories.AddAsync(categories);
            return categories;
        }

        public async Task<SubCategories> AddSubCategoriesByAsync(SubCategories subCategories)
        {
            await _context.SubCategories.AddAsync(subCategories);
            return subCategories;
        }

        public async Task<IEnumerable<CategoriesDTO>> GetCategories()
        {
            return await _context.Categories
                .ProjectTo<CategoriesDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<CategoriesDTO> GetCategoriesByName(string categoriesname)
        {
            return await _context.Categories.Where(p => p.Name.ToLower() == categoriesname.ToLower())
                .ProjectTo<CategoriesDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> IsExits(string categoriesName)
        {
            return await _context.Categories.AnyAsync(p => p.Name == categoriesName);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
