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
    dbAcct : {acctId : number , acctName : string};
    items : {prodId : number ,product : Product,  quantiy : number , price : number , total : number}[];



}