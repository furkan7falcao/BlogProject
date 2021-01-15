using AutoMapper;
using Furkan.Furkan_BlogProject.Business.Interfaces;
using Furkan.Furkan_BlogProject.DTO.DTOs.CategoryDTOs;
using Furkan.Furkan_BlogProject.Entities.Concreate;
using Furkan.Furkan_BlogProject.WebApi.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furkan.Furkan_BlogProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoriesController : UploadFileController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<CategoryListDTO>>(await _categoryService.GetAllAsync()));
        }


        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<CategoryListDTO>(await _categoryService.FindByIdAsync(id)));
        }


        [HttpPost]
        [Authorize]
        [ValidModel]
        public async Task<IActionResult> Create(DTO.DTOs.CategoryDTOs.CategoryAddDTO categoryAddDTO)
        {
            await _categoryService.AddAsync(_mapper.Map<Category>(categoryAddDTO));
            return Created("", categoryAddDTO);
        }


        [HttpPut("{id}")]
        [Authorize]
        [ValidModel]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> Update(int id ,CategoryUpdateDTO categoryUpdateDTO)
        {
            if (id != categoryUpdateDTO.Id)
                return BadRequest("id eşleşmiyor");

            await _categoryService.UpdateAsync(_mapper.Map<Category>(categoryUpdateDTO));
            return NoContent();
        }


        [HttpDelete("{id}")]
        [Authorize]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.RemoveAsync(new Category{ Id = id});
            return NoContent();
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetWithBlogsCount()
        {
            var categoriesWithBlogs = await _categoryService.GetAllWithCategoryBlogs();

            List<CategoryWithBlogsCountDTO> categoriesWithBlogsList = new List<CategoryWithBlogsCountDTO>();

            foreach (var categoryWithBlogs in categoriesWithBlogs)
            {
                var categoriesWithBlogsItem = new CategoryWithBlogsCountDTO();

                categoriesWithBlogsItem.BlogsCount = categoryWithBlogs.CategoryBlogs.Count;
                categoriesWithBlogsItem.CategoryId = categoryWithBlogs.Id;
                categoriesWithBlogsItem.CategoryName = categoryWithBlogs.Name;


                categoriesWithBlogsList.Add(categoriesWithBlogsItem);
            }

            return Ok(categoriesWithBlogsList);
        }


    }
}
