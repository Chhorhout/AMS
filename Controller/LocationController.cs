using Microsoft.AspNetCore.Mvc;
using AMS.Api.Data;
using AMS.Api.Models;
using AMS.Api.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AMS.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ApplicationDbcontext _context;
        private readonly IMapper _mapper;

        public LocationController(ApplicationDbcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLocations()
        {
            var locations = await _context.Locations.ToListAsync();
            var locationsDto = _mapper.Map<List<LocationResponseDto>>(locations);
            return Ok(locationsDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById(Guid id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            var locationDto = _mapper.Map<LocationResponseDto>(location);
            return Ok(locationDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateLocation(LocationCreateDto locationDto)
        {
            var location = _mapper.Map<Location>(locationDto);
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();
            var createdLocationDto = _mapper.Map<LocationResponseDto>(location);
            return CreatedAtAction(nameof(GetLocationById), new { id = location.LocationId }, createdLocationDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocation(Guid id, LocationCreateDto locationDto)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            _mapper.Map(locationDto, location);
            await _context.SaveChangesAsync();
            return Ok(locationDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(Guid id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();
            return Ok(location);
        }
    }
}