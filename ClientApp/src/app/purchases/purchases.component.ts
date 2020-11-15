import { Component, OnInit } from '@angular/core';
import { Purchases } from '../models/Purchases.model';
import { PurchaseService } from '../shared/purchase.service';

@Component({
  selector: 'app-purchases',
  templateUrl: './purchases.component.html',
  styleUrls: ['./purchases.component.css']
})
export class PurchasesComponent implements OnInit {
  
  constructor(private purchaseService : PurchaseService) {  }
  
  purchases : Purchases [];
  

  ngOnInit() {

    this.purchaseService.getPurchases().subscribe(purchases  => this.purchases = purchases as any);
    //this.purchaseService.getPurchases().subscribe((purchase :Purchases []) => this.purchases = purchase )

  }

}
