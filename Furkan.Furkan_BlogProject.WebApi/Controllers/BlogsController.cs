using AutoMapper;
using Furkan.Furkan_BlogProject.Business.Interfaces;
using Furkan.Furkan_BlogProject.DTO.DTOs.BlogDTOs;
using Furkan.Furkan_BlogProject.DTO.DTOs.CategoryBlogDTO;
using Furkan.Furkan_BlogProject.Entities.Concreate;
using Furkan.Furkan_BlogProject.WebApi.CustomFilters;
using Furkan.Furkan_BlogProject.WebApi.Enums;
using Furkan.Furkan_BlogProject.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CategoryBlogDTO = Furkan.Furkan_BlogProject.DTO.DTOs.CategoryBlogDTO.CategoryBlogDTO;

namespace Furkan.Furkan_BlogProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : UploadFileController
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;

        public BlogsController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<BlogListDTO>>(await _blogService.GetAllSortedByReleaseTimeAsync()));
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<Blog>))]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<BlogListDTO>(await _blogService.FindByIdAsync(id)));
        }

        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> Create([FromForm]BlogAddModel blogAddModel)
        {
            var uploadModel = await UploadFileAsync(blogAddModel.Image, "image/jpeg");

            if(uploadModel.UploadState == UploadState.Succes)
            {
                blogAddModel.ImagePath = uploadModel.newName;
                await _blogService.AddAsync(_mapper.Map<BlogAddModel, Blog>(blogAddModel));
                return Created("", blogAddModel);
            }

            else if (uploadModel.UploadState == UploadState.NotExits)
            {
                await _blogService.AddAsync(_mapper.Map<BlogAddModel, Blog>(blogAddModel));
                return Created("", blogAddModel);
            }

            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }           
           
        }

        [HttpPut("{id}")]
        [Authorize]
        [ValidModel]
        [ServiceFilter(typeof(ValidId<Blog>))]
        public async Task<IActionResult> Update(int id,[FromForm]BlogUpdateModel blogUpdateModel)
        {
            if (id != blogUpdateModel.Id)
                return BadRequest("geçersiz id");

            var uploadModel = await UploadFileAsync(blogUpdateModel.Image, "image/jpeg");

            if (uploadModel.UploadState == UploadState.Succes)
            {
                var updatedBlog = await _blogService.FindByIdAsync(blogUpdateModel.Id);
                updatedBlog.Title = blogUpdateModel.Title;
                updatedBlog.ShortDescription = blogUpdateModel.ShortDescription;
                updatedBlog.Content = blogUpdateModel.Content;
                updatedBlog.ImagePath = uploadModel.newName;

                await _blogService.UpdateAsync(updatedBlog);
                return NoContent();
            }

            else if (uploadModel.UploadState == UploadState.NotExits)
            {
                var updatedBlog = await _blogService.FindByIdAsync(blogUpdateModel.Id);
                updatedBlog.Title = blogUpdateModel.Title;
                updatedBlog.ShortDescription = blogUpdateModel.ShortDescription;
                updatedBlog.Content = blogUpdateModel.Content;

                await _blogService.UpdateAsync(updatedBlog);
                return NoContent();
            }

            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        [ServiceFilter(typeof(ValidId<Blog>))]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogService.RemoveAsync(new Blog { Id = id });
            return NoContent();
        }


        [HttpPost("[action]")]
        [Authorize]
        [ValidModel]
        public async Task<IActionResult> AddToCategoryAsync(CategoryBlogDTO categoryBlogDTO)
        {
            await _blogService.AddToCategoryAsync(categoryBlogDTO);
            return Created("", categoryBlogDTO);
        }

        [HttpDelete("[action]")]
        [Authorize]
        public async Task<IActionResult> RemoveFromCategoryAsync(CategoryBlogDTO categoryBlogDTO)
        {
            await _blogService.RemoveFromCategoryAsync(categoryBlogDTO);
            return NoContent();
        }

        [HttpGet("[action]/{id}")]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> GetAllByCategoryId(int id)
        {        
            return Ok(await _blogService.GetAllWithCategoryIdAsync(id));
        }



    }
}
