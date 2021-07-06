using FreeCourse.Shared.ControllerBases;
using FreeCourseServices.Catalog.Dtos;
using FreeCourseServices.Catalog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourseServices.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    internal class CategoryController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();

            return CreateActionResultInstance(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            return CreateActionResultInstance(category);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto  )
        {
           var response =  await _categoryService.CreateAsync(categoryDto);

            return CreateActionResultInstance(response);
        }
    }
}
