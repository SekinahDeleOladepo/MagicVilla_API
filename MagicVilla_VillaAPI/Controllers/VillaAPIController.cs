using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Model;
using MagicVilla_VillaAPI.Model.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController: ControllerBase
    {
        private readonly ApplicationDBContext _db;

        public VillaAPIController(ApplicationDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<CreateVillaDTO>> GetVillas()
        {
            return Ok(_db.Villas);  
        }
        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CreateVillaDTO>> GetVillaAsync(int id)
        {
            if(id == 0) 
            {
                return BadRequest();
            } 
        
            var villa = await _db.Villas.FirstOrDefaultAsync(u=>u.Id==id);
            if (villa == null) 
            {
                return NotFound();
            }
            return Ok(villa);   

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CreateVillaDTO>> CreateVillaAsync([FromBody]CreateVillaDTO villaDto)
        {
            if (await _db.Villas.FirstOrDefaultAsync(u => u.Name.ToLower() == villaDto.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Villa name already exists");
                return BadRequest(ModelState);
            }
            if (villaDto == null) 
            { 
                return BadRequest(villaDto);
            }
            Villa model = new Villa()
            {
                Name = villaDto.Name,
                DateCreated = DateTime.Now,
                Details = villaDto.Details,
                Sqft = villaDto.Sqft,
                Rate = villaDto.Rate,
                ImageUrl = villaDto.ImageUrl,
                Amenity = villaDto.Amenity,
                Occupancy = villaDto.Occupancy,

            };
            await _db.Villas.AddAsync(model);
           await _db.SaveChangesAsync();
            return CreatedAtRoute("GetVilla",new {id =model.Id }, model);
        }
        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id) 
        { 
            if(id == 0) 
            {
                return BadRequest();
            }
           var  villa=await _db.Villas.FirstOrDefaultAsync(u => u.Id == id);
            if(villa == null)
            {
                return NotFound();
            }
            _db.Villas.Remove(villa);
           
            return NoContent();
        }
        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateVillaAsync(int id, [FromBody] VillaUpdateDTO villaDto)
        {
            if (villaDto == null || id != villaDto.Id)
            {
                return BadRequest();
            }
            var villa = await _db.Villas.FirstOrDefaultAsync(u => u.Id == id);
            Villa model = new Villa()
            {
                Id = villaDto.Id,
                Name = villaDto.Name,
                DateCreated = DateTime.Now,
                Details = villaDto.Details,
                Sqft = villaDto.Sqft,
                Rate = villaDto.Rate,
                ImageUrl = villaDto.ImageUrl,
                Amenity = villaDto.Amenity,
                Occupancy = villaDto.Occupancy,

            };
            _db.Villas.Update(model);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        [HttpPatch("{id:int}", Name = "UpdatePatchVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialVillaAsync(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var villa = await _db.Villas.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            if(villa == null)
            {
                return BadRequest();
            }
            VillaUpdateDTO villaDto = new VillaUpdateDTO()
            {
                Id = villa.Id,
                Name = villa.Name,
                Details = villa.Details,
                Sqft = villa.Sqft,
                Rate = villa.Rate,
                ImageUrl = villa.ImageUrl,
                Amenity = villa.Amenity,
                Occupancy = villa.Occupancy,

            };
            await _db.SaveChangesAsync();
            patchDTO.ApplyTo(villaDto, ModelState);
            Villa model = new Villa()
            {
                Id = villaDto.Id,
                Name = villaDto.Name,
                DateCreated = DateTime.Now,
                Details = villaDto.Details,
                Sqft = villaDto.Sqft,
                Rate = villaDto.Rate,
                ImageUrl = villaDto.ImageUrl,
                Amenity = villaDto.Amenity,
                Occupancy = villaDto.Occupancy,

            };
            _db.Villas.Update(model);
            await _db.SaveChangesAsync();
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);    
            }
            return NoContent();
        }


    }
}
