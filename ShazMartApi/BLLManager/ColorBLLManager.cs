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
    public class ColorBLLManager : IColorBLLManager
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public ColorBLLManager(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ColorDTO> AddColor(ColorDTO colorDTO)
        {
            var color = _mapper.Map<Colors>(colorDTO);
            await _context.Colors.AddAsync(color);

            return colorDTO;
        }

        public async Task<IEnumerable<ColorDTO>> GetAll()
        {
            return await _context.Colors
                .ProjectTo<ColorDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
