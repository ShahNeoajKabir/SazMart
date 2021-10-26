using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLLManager.Interface;
using Microsoft.EntityFrameworkCore;
using SazMart.DAL.Database;
using SazMart.DAL.ModelClass.DTO;
using SazMart.DAL.ModelClass.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLLManager.BusinessLogic
{
    public class CategoryBLLManager : ICategoryBLLManager
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CategoryBLLManager(DatabaseContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> Upsert(CategoryViewModel viewModel)
        {
            Categories categories;
            categories = await _context.Categories.FirstOrDefaultAsync(p => p.Id == viewModel.Id);
            viewModel.Name = viewModel.Name.Trim();
            if (categories == null)
            {
                categories = new Categories();
                categories.CreatedBy = "bappy";
                categories.CreatedDateTime = DateTime.UtcNow;
                await _context.Categories.AddAsync(categories);
            }
            else
            {
                categories.LastModifiedBy = "Bappy";
                categories.LastModifiedDateTime = DateTime.UtcNow;
            }

            if(_context.Categories.Any(p=>p.Name.ToLower()==viewModel.Name.ToLower() 
            && p.Id !=viewModel.Id
            ))
                throw new DuplicateWaitObjectException("Name", viewModel.Name);
            categories = _mapper.Map((CategoryViewModel)viewModel, categories);
            if (categories.Id == Guid.Empty)
            {
                categories.Id = Guid.NewGuid();
            }

            await _context.SaveChangesAsync();
            return categories.Id;
        }
        public async Task<bool> DeleteCategory(Guid Id)
        {
            Categories categories;
            categories = await _context.Categories.FirstOrDefaultAsync(p => p.Id == Id);
            if (categories != null)
            {
                _context.Categories.Remove(categories);
            }
            else
            {
                return false;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public List<CategoryViewModel> GetAll()
        {
            List<CategoryViewModel> categories =  _context.Categories
                .ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider)
                .ToList();
            return categories;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllActiveCategory()
        {
            IEnumerable<CategoryViewModel> categories =await _context.Categories
                .ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider)
                .Where(p => p.Status == (int)SazMart.Common.Enum.Enum.Status.Active).ToListAsync();
            return categories;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllDeactiveCategory()
        {
            IEnumerable<CategoryViewModel> categories = (IEnumerable<CategoryViewModel>)await _context.Categories
                .Where(p => p.Status == (int)SazMart.Common.Enum.Enum.Status.Inactive).ToListAsync();
            return categories;
        }

        public Task<CategoryViewModel> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        
    }
}
