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

namespace ALSaray.Controllers
{
    [Route("api/purchase")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {

        private readonly IMapper mapper;
        private readonly MyDBContext context;

        public PurchaseController(IMapper mapper,MyDBContext context  )
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet()]
        public async Task<IActionResult> GetPurchase()
        {
           
            var purchase = await context.purchases.Include(p=>p.purchaseItems).ToListAsync();

            if (purchase == null)
                return NotFound();

         

            return Ok(mapper.Map<List<Purchase>,List<PurchaseResource>>(purchase));

        }




        [HttpPost]
      public async Task<IActionResult> CreatePurchase ([FromBody] SavePurchaseResource savePurchase)
          
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

            var purchase = mapper.Map<SavePurchaseResource,Purchase>(savePurchase);

            purchase.LastUpdatedDate = DateTime.Now;
            
            context.purchases.Add(purchase);

            //foreach (var item in purchaseResource.purchaseItems)
            //{
            //    context.purchaseItems.Add(item);

            //}


            await context.SaveChangesAsync();

            var result =   mapper.Map<Purchase, PurchaseResource>(purchase);
            
            
                    
            return Ok(result);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePurchase(int id, [FromBody] SavePurchaseResource savePurchase)
        {


            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            var purchase = await context.purchases.FindAsync(id);

            if (purchase == null)
                return NotFound();


            mapper.Map<SavePurchaseResource, Purchase>(savePurchase,purchase);

            purchase.LastUpdatedDate = DateTime.Now;

           
            await context.SaveChangesAsync();

            //var result =   mapper.Map<Purchase, PurchaseResource>(purchase);



            return Ok(purchase);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase(int id)

        {

            var purchase = await context.purchases.FindAsync(id);

            if (purchase == null)
                return NotFound();
            
            context.Remove(purchase);
            await context.SaveChangesAsync();

            return Ok(id);



        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPurchase(int id)
        {
            var purchase = await context.purchases
             .Include(a => a.dbAcct)
            .Include(p=>p.purchaseItems)
            .SingleOrDefaultAsync(p=>p.purchId ==id);

            if (purchase == null)
                return NotFound();

            var purchaseresource = mapper.Map<Purchase, PurchaseResource>(purchase);

            return Ok(purchaseresource);

        }


        //private readonly MyDBContext _context;

        //public PurchaseController(MyDBContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/Purchase
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Purchase>>> Getpurchases()
        //{
        //    return await _context.purchases.ToListAsync();
        //}

        //// GET: api/Purchase/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Purchase>> GetPurchase(int id)
        //{
        //    var purchase = await _context.purchases.FindAsync(id);

        //    if (purchase == null)
        //    {
        //        return NotFound();
        //    }

        //    return purchase;
        //}

        //// PUT: api/Purchase/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPurchase(int id, Purchase purchase)
        //{
        //    if (id != purchase.purchId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(purchase).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PurchaseExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Purchase
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Purchase>> PostPurchase(Purchase purchase)
        //{
        //    _context.purchases.Add(purchase);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPurchase", new { id = purchase.purchId }, purchase);
        //}

        //// DELETE: api/Purchase/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Purchase>> DeletePurchase(int id)
        //{
        //    var purchase = await _context.purchases.FindAsync(id);
        //    if (purchase == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.purchases.Remove(purchase);
        //    await _context.SaveChangesAsync();

        //    return purchase;
        //}

        //private bool PurchaseExists(int id)
        //{
        //    return _context.purchases.Any(e => e.purchId == id);
        //}
    }
}
