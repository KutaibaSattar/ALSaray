using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ALSaray.Models;
using AutoMapper;
using ALSaray.Controllers.Resource;

namespace ALSaray.Controllers
{
     public class ProductController : Controller
    {
        private readonly MyDBContext context;
        private readonly IMapper mapper;


        public ProductController(MyDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet("/api/products")]
        public async Task<IEnumerable<ProductResource>> GetProducts()
        {
            var products = await context.products.ToListAsync();



            return mapper.Map<List<Products>, List<ProductResource>>(products);


        }
    }
}
