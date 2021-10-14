using BLLManager.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SazMart.DAL.ModelClass.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SazMart.Service.Controllers
{
    [Route("api/Tag")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagBLLManager _tagBLL;

        public TagController(ITagBLLManager tagBLL)
        {
            _tagBLL = tagBLL;
        }

        [HttpPost("AddTag")]
        public async Task<ActionResult<Tag>>AddTag(Tag tag)
        {
            await _tagBLL.AddTagAsync(tag);

            if (await _tagBLL.SaveAllAsync()) return NoContent();

            return tag;
        }
    }
}
