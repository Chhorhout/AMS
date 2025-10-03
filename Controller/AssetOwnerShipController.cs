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
    public class AssetOwnerShipController : ControllerBase
    {
        private readonly ApplicationDbcontext _context;
        private readonly IMapper _mapper;
        private const int PageSize = 4;

        public AssetOwnerShipController(ApplicationDbcontext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssetOwnerShipResponseDto>>> GetAllAssetOwnerShips(
            int? page,
            string? searchTerm,
            string? searchBy = "name"
        )
        {
            int pageNumber = page ?? 1;
            var query = _context.AssetOwnerShips.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                switch (searchBy.ToLower())
                {
                    case "name":
                        query = query.Where(ao => ao.Name.ToLower().Contains(searchTerm));
                        break;
                    default:
                        query = query.Where(ao => ao.Name.ToLower().Contains(searchTerm));
                        break;
                }
            }

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

            var assetOwnerShips = await query
                .Skip((pageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            Response.Headers.Append("X-Total-Count", totalItems.ToString());
            Response.Headers.Append("X-Total-Pages", totalPages.ToString());
            Response.Headers.Append("X-Current-Page", pageNumber.ToString());
            Response.Headers.Append("X-Page-Size", PageSize.ToString());

            return Ok(_mapper.Map<IEnumerable<AssetOwnerShipResponseDto>>(assetOwnerShips));
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssetOwnerShip(Guid id)
        {
            var assetOwnerShip = await _context.AssetOwnerShips.Include(a => a.Asset).FirstOrDefaultAsync(a => a.Id == id);
            if (assetOwnerShip == null || assetOwnerShip.Asset == null)
            {
                return NotFound();
            }
            var assetOwnerShipDto = _mapper.Map<AssetOwnerShipResponseDto>(assetOwnerShip);
            return Ok(assetOwnerShipDto);
        }
 

        [HttpPost]
        public async Task<IActionResult> CreateAssetOwnerShip(AssetOwnerShipCreateDto dto)
        {
            var asset = await _context.Assets.FindAsync(dto.AssetId);
            if (asset == null)
            {
                return NotFound();
            }
            var assetOwnerShip = _mapper.Map<AssetOwnerShip>(dto);
            assetOwnerShip.Asset = asset;
            _context.AssetOwnerShips.Add(assetOwnerShip);
            await _context.SaveChangesAsync();
            var assetOwnerShipDto = _mapper.Map<AssetOwnerShipResponseDto>(assetOwnerShip);
            return CreatedAtAction(nameof(GetAssetOwnerShip), new { id = assetOwnerShip.Id }, assetOwnerShipDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssetOwnerShip(Guid id, AssetOwnerShipCreateDto dto)
        {
            var assetOwnerShip = await _context.AssetOwnerShips.FindAsync(id);
            if (assetOwnerShip == null)
            {
                return NotFound();
            }
            var asset = await _context.Assets.FindAsync(dto.AssetId);
            if (asset == null)
            {
                return NotFound();
            }
            assetOwnerShip.Asset = asset;
            _mapper.Map(dto, assetOwnerShip);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssetOwnerShip(Guid id)
        {
            var assetOwnerShip = await _context.AssetOwnerShips.FindAsync(id);
            if (assetOwnerShip == null)
            {
                return NotFound();
            }
            _context.AssetOwnerShips.Remove(assetOwnerShip);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}