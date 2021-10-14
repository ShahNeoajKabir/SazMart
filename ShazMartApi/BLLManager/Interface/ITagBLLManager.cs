using SazMart.DAL.ModelClass.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLManager.Interface
{
    public interface ITagBLLManager
    {
        Task<Tag> AddTagAsync(Tag tag);
        Task<bool> SaveAllAsync();
    }
}
