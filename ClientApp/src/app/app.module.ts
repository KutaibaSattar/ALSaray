import { GoodsFormComponent } from './goods-form/goods-form.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Component, ErrorHandler } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import {MatDialogModule} from '@angular/material/dialog';
import {CategoryService} from './shared/category.service';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { PurchasesComponent } from './purchases/purchases.component';
import { PurchaseComponent } from './purchases/purchase/purchase.component';
import { PurchaseItemsComponent } from './purchases/purchase-items/purchase-items.component';
import { PurchaseService } from './shared/purchase.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DbacctsComponent } from './dbaccts/dbaccts.component';
import { DbacctsnewComponent } from './dbacctsnew/dbacctsnew.component';
import { AppErrorHandler } from './app.error-handler';
//import  {ToastrModule} from 'ng6-toastr-notifications';
import {ToastrModule} from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    PurchasesComponent,
    PurchaseComponent,
    GoodsFormComponent,
    PurchaseItemsComponent,
    DbacctsComponent,
    DbacctsnewComponent,
     ],

  entryComponents:[PurchaseItemsComponent],
 
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    //ToastrModule.forRoot(),
    ToastrModule.forRoot({
      timeOut:3000,
      preventDuplicates: true,
      closeButton : true,
      positionClass: 'toast-top-center'
      
    }),
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatDialogModule,
    RouterModule.forRoot([
      { path: '', component: DbacctsComponent },
      { path: 'accounts/new', component: DbacctsnewComponent },
      { path: 'accounts/new/:id', component: DbacctsnewComponent },
      { path: '', component: HomeComponent, pathMatch: 'full' },

      { path: 'goods', component: GoodsFormComponent },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'dbaccts', component: DbacctsComponent},
      //----------------------------------------------------------------
      {path : 'purchases',component:PurchasesComponent},
      {path : 'purchase',children :[
      {path:'',component:PurchaseComponent},
      {path:'edit/:id',component:PurchaseComponent }
     ]
  
       } 
    ]),
    BrowserAnimationsModule
  ],

  
  providers: [
    {provide:ErrorHandler, useClass:AppErrorHandler},
    CategoryService,
    PurchaseService,

    
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
