using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entities;
using BLL.StoreService;
using BLL.DTO;
using BasicCRUD.InputForms.Store;

namespace BasicCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoresController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Store>>> GetStores()
        {
            return Ok(await _storeService.GetStores());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Store>> GetStore(string id)
        {
            var store = await _storeService.GetStore(id);
            if (store == null)
            {
                return NotFound();
            }

            return Ok(store);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStore(string id, StoreForm2 storeForm)
        {
            if (!_storeService.StoreExists(id))
            {
                return BadRequest();
            }

            var storeDto = new StoreDTO
            {
                StorName = storeForm.StorName,
                StorAddress = storeForm.StorAddress,
                City = storeForm.City,
                State = storeForm.State,
                Zip = storeForm.Zip
            };

            if (await _storeService.UpdateStore(id, storeDto))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<StoreDTO>> PostStore([FromBody] StoreForm storeForm)
        {
            if (storeForm == null)
            {
                return BadRequest("Store's data is null");
            }

            if (_storeService.StoreExists(storeForm.StorId))
            {
                return Conflict("Store with the same ID already exists");
            }

            var store = new StoreDTO
            {
                StorId = storeForm.StorId,
                StorName = storeForm.StorName,
                StorAddress = storeForm.StorAddress,
                City = storeForm.City,
                State = storeForm.State,
                Zip = storeForm.Zip
            };

            if (await _storeService.CreateStore(store))
            {
                return CreatedAtAction(nameof(GetStore), new { id = store.StorId }, storeForm);
            }

            return BadRequest("An error occurred while creating the store.");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(string id)
        {
            if (await _storeService.DeleteStore(id))
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