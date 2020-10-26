using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALSaray.Controllers.Resource;
using ALSaray.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ALSaray.Controllers
{
    public class CategoryController : Controller
    {
        private readonly MyDBContext context;
        private readonly IMapper mapper;

        public CategoryController(MyDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet("/api/category")]
        public async Task<IEnumerable<CategoryResource>> GetCategories()
        {
            var categories = await context.categories.Include(m => m.Products).ToListAsync();



            return mapper.Map<List<Category>, List<CategoryResource>>(categories);


        }
    }
}
