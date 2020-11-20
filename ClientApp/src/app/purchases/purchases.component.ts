import { MydbaccutService } from './../shared/mydbaccut.service';
import { Component, OnInit } from '@angular/core';
import { Purchases } from '../models/Purchases.model';
import { PurchaseService } from '../shared/purchase.service';
import { Mydbaccut } from '../models/mydbaccut.model';

@Component({
  selector: 'app-purchases',
  templateUrl: './purchases.component.html',
  styleUrls: ['./purchases.component.css']
})
export class PurchasesComponent implements OnInit {
  
  constructor(private purchaseService : PurchaseService, private dbacctService : MydbaccutService) {  }
  
  purchases : Purchases [];
  account : Mydbaccut[];
  filter : any={};
  //allPurchases : Purchases[];
  

  ngOnInit() {

    this.dbacctService.getMyacctList().then(res => this.account = res as Mydbaccut[]);
    
   /*  this.purchaseService.getPurchases()
    .subscribe(purchases  => this.purchases = this.allPurchases = purchases as any); */
    //this.purchaseService.getPurchases().subscribe((purchase :Purchases []) => this.purchases = purchase )
   
    this.populatePurchases();

  }

  private populatePurchases(){
    this.purchaseService.getPurchases(this.filter)
    .subscribe(purchases  => this.purchases = purchases as any);



  }
  
  
  onFilterChange(){

  this.populatePurchases();
  
    /*  var purchases = this.allPurchases

    if (this.filter.acctId)

      purchases = purchases.filter(p=> p.dbAcct.acctId == this.filter.acctId);

    this.purchases = purchases;  // if no filter
 */

  }

  resetFilter(){
    this.filter ={};
    this.onFilterChange();

  }

}
