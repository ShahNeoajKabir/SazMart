using BLLManager.Interface;
using SazMart.DAL.Database;
using SazMart.DAL.ModelClass.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLManager
{
    public class TagBLLManager : ITagBLLManager
    {
        private readonly DatabaseContext _context;

        public TagBLLManager(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Tag> AddTagAsync(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
            return tag;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
