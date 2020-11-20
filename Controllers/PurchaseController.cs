using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ALSaray.Models;
using ALSaray.Controllers.Resource;
using AutoMapper;
using ALSaray.Core;
using ALSaray.Core.Models;

namespace ALSaray.Controllers
{
    [Route("api/purchase")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {

        private readonly IMapper mapper;
        
        private readonly IALSarayRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public PurchaseController(IMapper mapper,  IALSarayRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPurchases([FromQuery] PurchaseQuereyResource filterResource)
        {

            
            var filter = mapper.Map<PurchaseQuereyResource, PurchaseQuery> (filterResource);
            
            var purchase = await repository.GetPurchases(filter) ;

            if (purchase == null)
                return NotFound();


            return Ok(mapper.Map<IEnumerable<Purchase>, IEnumerable<PurchaseResource>>(purchase));

        }
       /*   [HttpGet()]
        public async Task<IActionResult> GetPurchases(Filter filterResource)
        {

            
            //var filter = mapper.Map<FilterResource, Filter> (filterResource);
            
            var purchase = await repository.GetPurchases() ;

            if (purchase == null)
                return NotFound();


            return Ok(mapper.Map<IEnumerable<Purchase>, IEnumerable<PurchaseResource>>(purchase));

        }
 */



        [HttpPost]
        public async Task<IActionResult> CreatePurchase([FromBody] SavePurchaseResource savePurchase)

        {


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            

            /*
            var model = await context.myDbAccts.FindAsync(purchaseResource.accId);

            if (model == null)
            {
                ModelState.AddModelError("Account Id", "Invalid Account Id");
                return BadRequest(ModelState);

            }
            */

            /*
            Buisness role validation;
            
            if(true)
            {
                ModelState.AddModelError("....", "ErrorMessage");
                return BadRequest(ModelState);

            }
            */

            var purchase = mapper.Map<SavePurchaseResource, Purchase>(savePurchase);

            purchase.LastUpdatedDate = DateTime.Now;

            repository.Add(purchase);




            //foreach (var item in purchaseResource.purchaseItems)
            //{
            //    context.purchaseItems.Add(item);

            //}


            await unitOfWork.CompleteAsync();

            purchase = await repository.GetPurchase(purchase.purchId);

            var result = mapper.Map<Purchase, PurchaseResource>(purchase);



            return Ok(result);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePurchase(int id, SavePurchaseResource savePurchase)
        {


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var purchase = await repository.GetPurchase(id);


            if (purchase == null)
                return NotFound();


            mapper.Map<Purchase, PurchaseResource>(purchase);

            purchase.LastUpdatedDate = DateTime.Now;


            await unitOfWork.CompleteAsync();

            var result = mapper.Map<Purchase, PurchaseResource>(purchase);



            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase(int id)

        {

            var purchase = await repository.GetPurchase(id, includeRelated: false);

            if (purchase == null)
                return NotFound();

            repository.Remove(purchase);

            await unitOfWork.CompleteAsync();

            return Ok(id);



        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPurchase(int id)
        {
            var purchase = await repository.GetPurchase(id);

            if (purchase == null)
                return NotFound();

            var purchaseresource = mapper.Map<Purchase, PurchaseResource>(purchase);

            return Ok(purchaseresource);


        }



    }
}
