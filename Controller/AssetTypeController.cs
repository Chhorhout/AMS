using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AMS.Api.Dtos;
using AMS.Api.Models;
using AMS.Api.Data;
using Microsoft.EntityFrameworkCore;
namespace AMS.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetTypeController : ControllerBase
    {
        private readonly ApplicationDbcontext _context;
        private readonly IMapper _mapper;

        public AssetTypeController(ApplicationDbcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAssetTypes()
        {
            var assetTypes = await _context.AssetTypes.ToListAsync();
            var assetTypesDto = _mapper.Map<List<AssetTypeResponseDto>>(assetTypes);
            return Ok(assetTypesDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAssetType(AssetTypeCreateDto assetTypeDto)
        {
            var assetType = _mapper.Map<AssetType>(assetTypeDto);
            await _context.AssetTypes.AddAsync(assetType);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAssetTypeById), new { id = assetType.Id }, assetTypeDto);
        }  
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssetTypeById(Guid id)
        {
            var assetType = await _context.AssetTypes.FindAsync(id);
            if (assetType == null)
            {
                return NotFound();
            }
            var assetTypeResponseDto = _mapper.Map<AssetTypeResponseDto>(assetType);
            return Ok(assetTypeResponseDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssetType(Guid id, AssetTypeCreateDto assetTypeDto)
        {
            var assetType = await _context.AssetTypes.FindAsync(id);
            if (assetType == null)
            {
                return NotFound();
            }
            _mapper.Map(assetTypeDto, assetType);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssetType(Guid id)
        {
            var assetType = await _context.AssetTypes.FindAsync(id);
            if (assetType == null)
            {
                return NotFound();
            }
            _context.AssetTypes.Remove(assetType);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}