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
using System.Data.Common;
using System.Runtime.InteropServices.ComTypes;
using AutoMapper.XpressionMapper.Extensions;

namespace ALSaray.Controllers
{

    [Route("api/mydbaccts")]
    [ApiController]
    public class MyDbAcctsController : Controller
    {

         private readonly MyDBContext context;
         private readonly IMapper mapper;


        public  MyDbAcctsController(MyDBContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        
        public async Task<IEnumerable<MyDBAcctsResources>> GetMyDBAccts()
        {
            var mydbaccts = await context.myDbAccts.ToListAsync();

           
           return  mapper.Map<List<MyDbAcct>, List<MyDBAcctsResources>>(mydbaccts);
           
        }

        [HttpPost]
        public async Task<IActionResult> CreateDbAccounts(MyDBAcctsResources acctsResource )

        {

             throw new Exception(); 

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //acctsResource.nodePath = HierarchyId.Parse(acctsResource.path);

            HierarchyId  parentItem = HierarchyId.Parse(acctsResource.nodePath);

            //var parent = context.myDbAccts.FirstOrDefault(e => e.nodePath == HierarchyId.Parse(acctsResource.nodePath).GetAncestor(1));

            var lastItemInCurrentLevel = context.myDbAccts.Where(x => x.nodePath.GetAncestor(1) == parentItem)
            .OrderByDescending(x => x.nodePath)
            .FirstOrDefault();

            var child1Node = lastItemInCurrentLevel != null ? lastItemInCurrentLevel.nodePath : null;

            var newNode = parentItem.GetDescendant(child1Node, null);

            acctsResource.nodePath = newNode.ToString();
            
            var acct = mapper.Map<MyDBAcctsResources,MyDbAcct>(acctsResource);

            

            context.myDbAccts.Add(acct);

            //foreach (var item in purchaseResource.purchaseItems)
            //{
            //    context.purchaseItems.Add(item);

            //}


            await context.SaveChangesAsync();

            

            var result =   mapper.Map<MyDbAcct, MyDBAcctsResources>(acct);



            return Ok(result);

        }
       

      [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDbAccount(int id, MyDBAcctsResources mydbcctsresources)
        {


            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            var dbaccount = await context.myDbAccts.FindAsync(id);

            if (dbaccount == null)
                return NotFound();


            mapper.Map<MyDBAcctsResources, MyDbAcct>(mydbcctsresources, dbaccount);

                       
            await context.SaveChangesAsync();

            var result =   mapper.Map<MyDbAcct, MyDBAcctsResources>(dbaccount);



            return Ok(result);

        }

       






    }
}
