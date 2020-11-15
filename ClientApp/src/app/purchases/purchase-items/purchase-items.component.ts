import { MydbaccutService } from './../../shared/mydbaccut.service';
import { Mydbaccut } from '../../models/mydbaccut.model';
import { PurchaseService } from './../../shared/purchase.service';
import { NgForm } from '@angular/forms';
import { ProductService } from './../../shared/product.service';
import { PurchaseItem } from './../../models/purchase-item.model';
import { Component, OnInit,Inject } from '@angular/core';
import {MAT_DIALOG_DATA,MatDialogRef} from "@angular/material"
import { Product } from './../../models/product.model';



@Component({
  selector: 'app-purchase-items',
  templateUrl: './purchase-items.component.html',
  styles: []
})
export class PurchaseItemsComponent implements OnInit {
  formData:PurchaseItem
  productList:Product[];
  isValid:boolean = true;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data,
    public dialogRef:MatDialogRef<PurchaseItemsComponent>,
    private productService:ProductService,
    private purchaseService:PurchaseService
   ) { }
  
  ngOnInit() {

    this.productService.getProductList().then(res=>this.productList = res as Product[] );
   

    if (this.data.OrderItemIndex==null)
    this.formData={
     
      purchItemId:null,
      purchId:this.data.purchId,
      prodId:0,
      itemName:'',
      price:0,
      quantity:0,
      total:0,
    }
    else
      this.formData = Object.assign({},this.purchaseService.purchaseItems[this.data.OrderItemIndex]) ;
   

  }
  updateIemnName(ctrl){
    if (ctrl.selectedIndex==0){
        this.formData.itemName= '';
    }
    else{
      this.formData.itemName = this.productList[ctrl.selectedIndex-1].prodName;

    }

  }

  updateTotal(){
    this.formData.total =parseFloat((this.formData.quantity * this.formData.price).toFixed(2));
   
  }

 save(form){
    if (this.validateForm(form.value)){
      if (this.data.OrderItemIndex==null)
      this.purchaseService.purchaseItems.push(form.value);
      else
      this.purchaseService.purchaseItems[this.data.OrderItemIndex] = form.value
      this.dialogRef.close();
     }
    
   
  }

  validateForm(formData:PurchaseItem){
      this.isValid=true;
      if(formData.prodId==0)
      this.isValid=false;
      else if (formData.quantity==0)
      this.isValid = false;
      return this.isValid;
 }

 close()
 {

  this.dialogRef.close()

 }
 


}
