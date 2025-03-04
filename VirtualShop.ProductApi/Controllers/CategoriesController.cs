﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualShop.ProductApi.DTOs;
using VirtualShop.ProductApi.Services;

namespace VirtualShop.ProductApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
    {
        var categoriesDTO = await _categoryService.GetCategories();
        if (categoriesDTO == null || !categoriesDTO.Any())
        {
            return NotFound("Categories not found");
        }
        return Ok(categoriesDTO);
    }

    [HttpGet("products")]
    public async Task<ActionResult<CategoryDTO>> GetCategoriesProducts()
    {
        var categoriesDTO = await _categoryService.GetCategoriesProducts();
        if (categoriesDTO is null)
        {
            return NotFound("Categories not found");
        }
        return Ok(categoriesDTO);
    }

    [HttpGet("{id:int}", Name = "GetCategory")]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get(int id)
    {
        var categoryDTO = await _categoryService.GetCategoryById(id);
        if (categoryDTO is null)
        {
            return NotFound("Categy not found");
        }
        return Ok(categoryDTO);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDTO)
    {
        if (categoryDTO is null)
            return BadRequest("Invalid data");

        await _categoryService.AddCategory(categoryDTO);

        return new CreatedAtRouteResult("GetCategory", new { id = categoryDTO.CategoryId },
            categoryDTO);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDTO)
    {
        if (id != categoryDTO.CategoryId ||
            categoryDTO is null)
            return BadRequest();

        await _categoryService.UpdateCategory(categoryDTO);

        return Ok(categoryDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var categoryDTO = await _categoryService.GetCategoryById(id);
        if (categoryDTO is null)
            return NotFound("Category not found");

        await _categoryService.RemoveCategory(id);

        return Ok(categoryDTO);
    }
}
