import { ProductService } from './../shared/product.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Mydbaccut } from '../shared/mydbaccut.model';
import { MydbaccutService } from '../shared/mydbaccut.service';
//import { ToastrManager } from 'ng6-toastr-notifications';
import { ToastrService } from 'ngx-toastr';
import { timer } from 'rxjs';


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
   private toastr: ToastrService
   
  )
  
  { 
    route.params.subscribe(p => { this.dbaccounts.nodePath = p['id']})

  }

  ngOnInit() {
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
      this.mydbaccountService.Create(this.dbaccounts).subscribe(
        x => console.log(x))
  }
}
