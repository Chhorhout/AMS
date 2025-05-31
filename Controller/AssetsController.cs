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
    public class AssetsController : ControllerBase
    {
        private readonly ApplicationDbcontext _context;
        private readonly IMapper _mapper;

        public AssetsController(ApplicationDbcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAssetResponse()
        {
            var assets = await _context.Assets.ToListAsync();
            var assetDtos = _mapper.Map<List<AssetResponseDto>>(assets);
            return Ok(assetDtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssetById(Guid id)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }
            var assetDto = _mapper.Map<AssetResponseDto>(asset);
            return Ok(assetDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsset(AssetsCreateDto assetDto)
        {
            var asset = _mapper.Map<Assets>(assetDto);
            await _context.Assets.AddAsync(asset);
            await _context.SaveChangesAsync();
            var createdAssetDto = _mapper.Map<AssetResponseDto>(asset);
            return CreatedAtAction(nameof(GetAssetById), new { id = asset.AssetId }, createdAssetDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsset(Guid id, AssetsCreateDto assetDto)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }
            _mapper.Map(assetDto, asset);
            await _context.SaveChangesAsync();
            return Ok(assetDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsset(Guid id)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }
            _context.Assets.Remove(asset);
            await _context.SaveChangesAsync();
            return Ok(asset);
        }
    }
}

