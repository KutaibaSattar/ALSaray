using System.Security.Cryptography;
using ALSaray.Controllers.Resource;
using ALSaray.Models;
using AutoMapper;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ALSaray.Core.Models;

namespace ALSaray.Mapping
{
    public class MappingProfile : Profile
    {

       

        public MappingProfile()
        {
            //from Domain to API Resource
            
            CreateMap<Category, CategoryResource>();
            
            CreateMap<Products, ProductResource>();
            
            
            //CreateMap<MyDbAcct, MyDBAcctsResources>();
            //CreateMap<MyDBAcctsResources, MyDbAcct>();


           CreateMap<MyDbAcct, MyDBAcctsResources>();
           CreateMap<MyDBAcctsResources, MyDbAcct>()
           .ForMember(a=>a.acctId, opt=>opt.Ignore());
            
            
            
            CreateMap<string, HierarchyId>().ConvertUsing(s => HierarchyId.Parse(s));
          

            CreateMap<Purchase, SavePurchaseResource>();
            CreateMap<SavePurchaseResource, Purchase>()
               .ForMember(p=>p.purchId,opt=>opt.Ignore()) ; //ignor mapping this field
           
            CreateMap<Purchase, PurchaseResource>()
           .ForMember(pr=>pr.purchaseItems,opt=>opt.MapFrom(p=>p.purchaseItems));
            //.ForMember(dest => dest.dbAcct,opt => opt.MapFrom(src => src.dbAcct));
            //.ForMember(pr=>pr.purchaseItems,opt=>opt.MapFrom(p=>p.purchaseItems.Select(pr=> pr.Products)));
           
                 //.ForPath(dest => dest.purchase,opt => opt.MapFrom(src => src.dbAcct.Purchases))
            //.ForMember(pr=>pr.product,op=>opt.MapFrom(p=>p.purchaseItems))
            
             //.ForMember(pr=>pr.Products,opt=>opt.MapFrom(p=> new ProductResource {prodName = "Hello" }))
             //.ForMember(dest => dest.Products.prodName,opt => opt.UseValue<string>("Hello"));
           
            //.ForMember(pr=>pr.product,opt=>opt.MapFrom(p=>p.purchaseItems.Select(pr=> new ProductResource{prodId = pr.prodId})));
                //.AfterMap((p,pr)=> Mapper.Map(p.purchaseItems,pr.Products));
            
            CreateMap<Purchase, PurchaseResource>();
            CreateMap<PurchaseResource, Purchase>();
            
           
            CreateMap<PurchaseItems, PurchaseItemsResource>();
            CreateMap<PurchaseItemsResource, PurchaseItems>();

            //from API Resource(source) to Domain
            //CreateMap<PurchaseResource, Purchase>()
            //    .ForMember(p=>p.purchaseItems,opt=>opt.MapFrom(pr=>pr.purchaseItems.Select(id=>new PurchaseItems {purchId = id})));

           CreateMap<PurchaseQuereyResource,PurchaseQuery>();
            CreateMap<PurchaseQuery,PurchaseQuereyResource>(); 
            
            
            
            //CreateMap<PurchaseItemsResource, PurchaseItems>();


        }

    }
}
