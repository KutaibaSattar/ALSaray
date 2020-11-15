import { Injectable } from '@angular/core';
import { Purchase } from './../models/purchase.model';
import { PurchaseItem } from './../models/purchase-item.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PurchaseService {

  formData: Purchase
  purchaseItems: PurchaseItem[];


  constructor(private http: HttpClient) { }

  saveOrUpdatePurchase() {

    console.log("Hello");
    var body = {

      ...this.formData,
      purchaseItems : this.purchaseItems


    };

    console.log(body);
    return this.http.post('/api/purchase/',body);
    


  }

  delete(id){

    console.log(id)
    return this.http.delete('/api/purchase/' + id)

  }

  getPurchases(){
    return this.http.get('api/purchase')

  }

}
