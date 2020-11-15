import { ProductService } from './../shared/product.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Mydbaccut } from '../models/mydbaccut.model';
import { MydbaccutService } from '../shared/mydbaccut.service';
//import { ToastrManager } from 'ng6-toastr-notifications';
import { ToastrService } from 'ngx-toastr';
import { timer } from 'rxjs';
import { isNumber } from 'util';
import { stringify } from 'querystring';


@Component({
  selector: 'app-dbacctsnew',
  templateUrl: './dbacctsnew.component.html',
  styleUrls: ['./dbacctsnew.component.css']
})
export class DbacctsnewComponent implements OnInit {

  dbaccounts : Mydbaccut ={
    acctId :0,
    acctKey : '',
    acctName:'',
    nodePath:''
  }
 
  constructor(
   private route: ActivatedRoute, //read parameter
   private router: Router, // if invalid id the navigate to a adifferent page
   private mydbaccountService:MydbaccutService,
   //private toastr: ToastrManager,
   private toastr: ToastrService )  { 
   

  }


  ngOnInit() {
    this.route.params.subscribe(p => { 
     
       if (p['id'].search('/') == -1){
        this.dbaccounts.acctId = p['id'] 
        this.mydbaccountService.getAcc(this.dbaccounts.acctId).subscribe(a=>{ this.dbaccounts = a as any})
         
       }
        
        else
        this.dbaccounts.nodePath = p['id'] //Checking
    
    
    })

  }
  delete(){
   
   
     if (confirm("Are you sure ?")){
       this.mydbaccountService.delete(this.dbaccounts.acctId).subscribe(()=> this.router.navigate(['/dbaccts']))
 
     }
 
   }
  submit() {
    
   /*  this.toastr.success('Hello world!', 'Toastr fun!',{
      timeOut: 10000,
    positionClass: 'toast-top-right',
    }); */
   
   /*  this.mydbaccountService.Create(this.dbaccounts).subscribe(
      x => console.log(x), 
      err=> {this.toastr.errorToastr('This is error toast.', 'Oops!',{
        toastTimeout:3000,
        showCloseButton:true,
        position:'top-center'
      }
      
       
      )}) */

     /*   this.mydbaccountService.Create(this.dbaccounts).subscribe(
      x => console.log(x), 
      err=> {this.toastr.error('This is error toast.', 'Oops!'
      
       
      )}) */
     
      //this.toastr.error('This is error toast.', 'Oops!')
     
     if (this.dbaccounts.acctId == 0){
      
      var result$ = this.mydbaccountService.Create(this.dbaccounts)
      
      
      //
    }
     else
     {
      
      var result$ = this.mydbaccountService.Update(this.dbaccounts.acctId,this.dbaccounts)

     }
    
     result$.subscribe(()=> {this.toastr.success("Data was sucessfully saved.");
      
      this.router.navigate(['/dbaccts'])
     })

    
  }

  
}
