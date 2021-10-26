using AutoMapper;
using BLLManager.Interface;
using Microsoft.EntityFrameworkCore;
using SazMart.DAL.Database;
using SazMart.DAL.ModelClass.DTO;
using SazMart.DAL.ModelClass.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLManager.BusinessLogic
{
    public class BrandBLLManager : IBrandBLLManager
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BrandBLLManager(DatabaseContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<Guid> Upsert(BrandViewModel model)
        {
            Brand brand = new Brand();
            brand = await _context.Brands.FirstOrDefaultAsync(p => p.Id == model.Id);

            if (brand == null)
            {
                brand = new Brand();
                brand.CreatedBy = "Bappy";
                brand.CreatedDateTime = DateTime.Now;
                await _context.Brands.AddAsync(brand);
            }
            brand = _mapper.Map((BrandViewModel)model, brand);
            await _context.SaveChangesAsync();
            return brand.Id;
        }
        public async Task<bool> SaveChangeAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }



        public async Task<bool>IsExits(string brandName)
        {
            return await _context.Brands.AnyAsync(p => p.Name == brandName);
         
        }

        
    }
}
