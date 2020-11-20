import { Injectable } from '@angular/core';
import { Purchase } from './../models/purchase.model';
import { PurchaseItem } from './../models/purchase-item.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PurchaseService {
  private readonly purchaseEndpoint = 'api/purchase';
  formData: Purchase
  purchaseItems: PurchaseItem[];
 

  constructor(private http: HttpClient) { }

  saveOrUpdatePurchase() {

        var body = {

      ...this.formData,
      purchaseItems : this.purchaseItems


    };

    console.log(body);
    return this.http.post(this.purchaseEndpoint,body);
    


  }

  delete(id){

    console.log(id)
    return this.http.delete(this.purchaseEndpoint + id)

  }
  toQueryString(obj){
    var parts = [];
    for( var property in obj){
      var value = obj[property];

      if (value !=null && value !=undefined )
        parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value))


    }
     return parts.join('&'); 

  }


  getPurchases(filter){
    
   

    return this.http.get(this.purchaseEndpoint + '?' + this.toQueryString(filter))

  }

}
