
//import { ToastrModule, ToastrService } from 'ngx-toastr';
//import { ToastrManager, ToastrModule } from 'ng6-toastr-notifications';

//import { ErrorHandler,Inject,NgZone } from "@angular/core";

/* 
export class AppErrorHandler implements ErrorHandler{
 
  constructor ( @Inject(ToastrModule) private toastr: ToastrManager ){}
  handleError (error:any): void{
    this.toastr.errorToastr('This is error toast.', 'Outside!',{
      toastTimeout:3000,
      showCloseButton:true,
      position:'top-center'
    })
    // Immediately remove current toasts without using animation


// Remove current toasts using animation

    console.log ("ERROR")
  
  };

  
} */

/* export class AppErrorHandler implements ErrorHandler{
 
  constructor ( @Inject(ToastrModule) private toastr:ToastrService ){}
  handleError (error:any): void{
    this.toastr.error('This is error toast.', 'Outside!')
    // Immediately remove current toasts without using animation


// Remove current toasts using animation

    console.log ("ERROR")
  
  };

  
} */
import { ErrorHandler, Inject, Injector, NgZone, isDevMode } from "@angular/core";
import { ToastrService } from "ngx-toastr";

export class AppErrorHandler implements ErrorHandler {
  constructor(@Inject(NgZone) private ngZone: NgZone, @Inject(Injector) private injector: Injector) { }

  private get toastr(): ToastrService {
      return this.injector.get(ToastrService);
  }

  public handleError(error: any): void {
      this.ngZone.run(() => {
          let errorTitle = 'Error';
          let errMsg = 'An unexpected error ocurred';
          this.toastr.error(errMsg,errorTitle);
                
      });

     
  }
}
