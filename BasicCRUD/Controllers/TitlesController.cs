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
using BasicCRUD.InputForms.Title;
using BLL.DTO;

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
        public async Task<IActionResult> PutTitle(string id, TitleForm titleForm)
        {
            if (!_titleService.TitleExists(id))
            {
                return NotFound();
            }

            var pubDate = new DateTime(titleForm.PubYear, titleForm.PubMonth, titleForm.PubDay);

            var titleDto = new TitleDTO
            {
                TitleId = titleForm.TitleId,
                Title1 = titleForm.Title1,
                Type = titleForm.Type,
                PubId = titleForm.PubId,
                Price = titleForm.Price,
                Advance = titleForm.Advance,
                Royalty = titleForm.Royalty,
                YtdSales = titleForm.YtdSales,
                Notes = titleForm.Notes,
                Pubdate = pubDate
            };

            if (await _titleService.UpdateTitle(id, titleDto))
            {
                return NoContent();
            }

            return BadRequest("An error occurred");
        }

        [HttpPost]
        public async Task<ActionResult<TitleDTO>> PostTitle([FromBody] TitleForm titleForm)
        {
            if (titleForm == null)
            {
                return BadRequest("Title's data is null");
            }

            if (_titleService.TitleExists(titleForm.TitleId))
            {
                return Conflict("Title with the same ID already exists");
            }

            var pubDate = new DateTime(titleForm.PubYear, titleForm.PubMonth, titleForm.PubDay);

            var titleDto = new TitleDTO
            {
                TitleId = titleForm.TitleId,
                Title1 = titleForm.Title1,
                Type = titleForm.Type,
                PubId = titleForm.PubId,
                Price = titleForm.Price,
                Advance = titleForm.Advance,
                Royalty = titleForm.Royalty,
                YtdSales = titleForm.YtdSales,
                Notes = titleForm.Notes,
                Pubdate = pubDate
            };

            if (await _titleService.CreateTitle(titleDto))
            {
                return CreatedAtAction(nameof(GetTitle), new { id = titleDto.TitleId }, titleDto);
            }

            return BadRequest("An error occurred");
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