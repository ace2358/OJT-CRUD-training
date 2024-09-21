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
        public async Task<IActionResult> PutStore(string id, Store store)
        {
            if (id != store.StorId)
            {
                return BadRequest();
            }

            if (await _storeService.UpdateStore(id, store))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Store>> PostStore(Store store)
        {
            if (await _storeService.CreateStore(store))
            {
                return CreatedAtAction("GetStore", new { id = store.StorId }, store);
            }
            else if (_storeService.StoreExists(store.StorId))
            {
                return Conflict();
            }

            return BadRequest();
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