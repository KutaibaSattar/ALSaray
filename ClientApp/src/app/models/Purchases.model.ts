import { NumberValueAccessor } from "@angular/forms";

export interface Product{

   prodId : number;
   prodName : string; 


}


export interface Purchases{

    purchId : number;
    purchNo : string;
    pMethod : string;
    gtotal : number;
    myDBAcctsResource : {ID : number , Name : string};
    items : {prodId : number ,product : Product,  quantiy : number , price : number , total : number}[];



}