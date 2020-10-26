import { Product } from './../shared/product.model';
import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'goods-form',
  templateUrl: './goods-form.component.html',
  styleUrls: ['./goods-form.component.css']
})
export class GoodsFormComponent implements OnInit {

  categories: any[];
  products: any =[];
  goods :any ={};
  
  constructor(private categoryService: CategoryService) { }

  ngOnInit() {

    this .categoryService.getCategory().subscribe(categories => {
      this.categories = categories as [];
     
      console.log("Testing1", this.categories) 




    });

  }
  onCategoryChang(){
      console.log("Testing2",this.goods.category)
     var selectedCategory =   this.categories.find(c=>c.catId == this.goods.category)
     this.products =  selectedCategory.products
      console.log("Testing3",this.products)
  }

}
