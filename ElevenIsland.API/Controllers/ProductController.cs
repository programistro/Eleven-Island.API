﻿using ElevenIsland.API.Data;
using ElevenIsland.Core;
using ElevenIsland.Core.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElevenIsland.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    
    private readonly AppDbContext _context;

    public ProductController(ILogger<ProductController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var findProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

        if (findProduct == null)
        {
            return NotFound();
        }

        return Ok(findProduct);
    }

    [HttpPost("add-product")]
    public async Task<IActionResult> AddProduct([FromBody] ProductDto dto)
    {
        if (dto == null)
        {
            return BadRequest();
        }

        Product product = new()
        {
            Id = dto.Id,
            Attributes = dto.Attributes,
            idProduct = Guid.NewGuid(),
            Images = dto.Images,
            Price = dto.Price,
            FullDescription = dto.FullDescription,
            OldPrice = dto.OldPrice,
            ShortDescription = dto.ShortDescription,
        };
        
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return Ok(product);
    }

    [HttpGet("get-category-product/{categoryId}")]
    public async Task<IActionResult> GetByCategory(int categoryId)
    {
        var products = await _context.Products.Where(x => x.CategoryId == categoryId).ToListAsync();
        
        return Ok(products);
    }

    [HttpGet("get-category-product/{limit}/{page}")]
    public async Task<IActionResult> GetByCategory(int limit, int page)
    {
        var products = await _context.Products
            .OrderBy(p => p.Id)
            .Skip((page - 1) * limit)
            .Take(limit)
            .ToListAsync();
        var result = new
        {
            Products = products,
            PageSize = limit,
            PageNumber = page
        };  

        return Ok(result);
    }

    [HttpGet("get-all-products")]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _context.Products.ToListAsync();
        
        return Ok(products);
    }
}