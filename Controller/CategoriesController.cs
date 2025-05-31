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
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbcontext _context;
        private readonly IMapper _mapper;

        public CategoriesController(ApplicationDbcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            if(categories == null)
            {
                return NotFound();
            }
            var categoriesDto = _mapper.Map<List<CategoriesResponseDto>>(categories);
            return Ok(categoriesDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoriesById(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if(category == null)
            {   
                return NotFound();
            }
            var categoryDto = _mapper.Map<CategoriesResponseDto>(category);
            return Ok(categoryDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoriesCreateDto categoryDto)
        {
            var category = _mapper.Map<Categories>(categoryDto);
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            var createdCategoryDto = _mapper.Map<CategoriesResponseDto>(category);
            return CreatedAtAction(nameof(GetCategoriesById), new { id = category.CategoryId }, createdCategoryDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, CategoriesCreateDto categoryDto)
        {
            var category = await _context.Categories.FindAsync(id);
            if(category == null)
            {
                return NotFound();
            }
            _mapper.Map(categoryDto, category);
            await _context.SaveChangesAsync();
            return Ok(categoryDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if(category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return Ok(category);
        }
        

    }
}