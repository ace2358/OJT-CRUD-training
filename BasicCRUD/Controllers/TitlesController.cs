using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entities;
using BLL.TitleService;

namespace BasicCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitlesController : ControllerBase
    {
        private readonly ITitleService _titleService;

        public TitlesController(ITitleService titleService)
        {
            _titleService = titleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Title>>> GetTitles()
        {
            return Ok(await _titleService.GetTitles());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Title>> GetTitle(string id)
        {
            var title = await _titleService.GetTitle(id);
            if (title == null)
            {
                return NotFound();
            }

            return Ok(title);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitle(string id, Title title)
        {
            if (id != title.TitleId)
            {
                return BadRequest();
            }

            if (await _titleService.UpdateTitle(id, title))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Title>> PostTitle(Title title)
        {
            if (await _titleService.CreateTitle(title))
            {
                return CreatedAtAction("GetTitle", new { id = title.TitleId }, title);
            }
            else if (_titleService.TitleExists(title.TitleId))
            {
                return Conflict();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTitle(string id)
        {
            if (await _titleService.DeleteTitle(id))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}