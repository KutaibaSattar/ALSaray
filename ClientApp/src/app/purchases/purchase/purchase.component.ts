import {  ToastrService } from 'ngx-toastr';
import { MydbaccutService } from './../../shared/mydbaccut.service';
import { Mydbaccut } from '../../models/mydbaccut.model';
import { PurchaseItemsComponent } from './../purchase-items/purchase-items.component';
import { Component, OnInit } from '@angular/core';
import { PurchaseService } from '../../shared/purchase.service';
import { NgForm, Validators } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';

@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styles: []

})
export class PurchaseComponent implements OnInit {

  myaccut: Mydbaccut[];
  isValid: boolean = true;

  constructor(public service: PurchaseService,
    private dialog: MatDialog,
    private mydbacctservice: MydbaccutService,
    private toastr :ToastrService

  ) { }

  ngOnInit() {
    this.mydbacctservice.getMyacctList().then(res => this.myaccut = res as Mydbaccut[]);
    this.resetForm();
  }

  resetForm(form?: NgForm) {

    if (form = null)

      form.resetForm();

    this.service.formData = {
      purchId: null,
      purchNo: Math.floor(1000000 + Math.random() * 900000).toString(),
      accId: null,
      pMethod: '',
      gtotal: 0

    };

    this.service.purchaseItems = [];


  }
  AddOrEditPurchseItem(OrderItemIndex, OrderID) {

    const dialogConfig = new MatDialogConfig;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "50%";
    dialogConfig.data = { OrderItemIndex, OrderID };

    this.dialog.open(PurchaseItemsComponent, dialogConfig).afterClosed().subscribe(res => { this.updateGrandTotal() });

  }

  OnDeletePurchseItem(purchItemId: number, i: number) {
    this.service.purchaseItems.splice(i, 1);
    this.updateGrandTotal();

  }

  updateGrandTotal() {
    this.service.formData.gtotal = this.service.purchaseItems.reduce((prev, curr) => {
      return prev + curr.total
    }, 0);
    this.service.formData.gtotal = parseFloat((this.service.formData.gtotal).toFixed(2));

  }

  validateForm() {
    this.isValid = true;
    if (this.service.formData.accId == 0)
      this.isValid = false;
    else if (this.service.purchaseItems.length == 0)
      this.isValid = false;

    return this.isValid;
  }
  
  OnSubmit(form: NgForm) {

    if (this.validateForm())
    {

        this.service.saveOrUpdatePurchase().subscribe(res => {
        this.resetForm();
        this.toastr.success("Submitted Successfuly","Bab ALSaray");  

        })

    }

  }

    
}

   
   
 


