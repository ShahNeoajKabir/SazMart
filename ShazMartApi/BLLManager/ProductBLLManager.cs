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
    public class ProductBLLManager : IProductBLLManager
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public ProductBLLManager(DatabaseContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            product.Status = (int)SazMart.Common.Enum.Enum.Status.Active;
            await _context.Product.AddAsync(product);
            return product;

        }

        public async Task<IEnumerable<ProductDTO>> GetAllProduct()
        {
            return await _context.Product
                .ProjectTo<ProductDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
