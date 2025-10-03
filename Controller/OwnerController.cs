using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using AMS.Api.Data;
using AMS.Api.Models;
using AMS.Api.Dtos;
using Microsoft.EntityFrameworkCore;

namespace AMS.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly ApplicationDbcontext _context;
        private readonly IMapper _mapper;
        private const int PageSize = 10;

        public OwnerController(ApplicationDbcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OwnerResponseDto>>> GetOwners(
            int? page,
            string? searchTerm,
            string? searchBy = "name"
        )
        {
            var owners = await _context.Owners.ToListAsync();
            var ownersDto = _mapper.Map<List<OwnerResponseDto>>(owners);
            return Ok(ownersDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOwnerById(Guid id)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<OwnerResponseDto>(owner));
        }
        [HttpPost]
        public async Task<IActionResult> CreateOwner(OwnerCreateDto ownerDto)
        {
            var owner = _mapper.Map<Owner>(ownerDto);
            await _context.Owners.AddAsync(owner);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOwnerById), new { id = owner.Id }, ownerDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwner(Guid id, OwnerCreateDto ownerDto)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            _mapper.Map(ownerDto, owner);
            await _context.SaveChangesAsync();
            return Ok(ownerDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(Guid id)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            _context.Owners.Remove(owner);
            await _context.SaveChangesAsync();
            return Ok(Success());
        }
        [HttpGet("success")]
        public IActionResult Success()
        {
            return Ok(new { message = "Owner deleted successfully" , status = "success" });
        }
    }
}