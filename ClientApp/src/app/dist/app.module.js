"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.AppModule = void 0;
var goods_form_component_1 = require("./goods-form/goods-form.component");
var platform_browser_1 = require("@angular/platform-browser");
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var http_1 = require("@angular/common/http");
var router_1 = require("@angular/router");
var dialog_1 = require("@angular/material/dialog");
var category_service_1 = require("./shared/category.service");
var app_component_1 = require("./app.component");
var nav_menu_component_1 = require("./nav-menu/nav-menu.component");
var home_component_1 = require("./home/home.component");
var counter_component_1 = require("./counter/counter.component");
var fetch_data_component_1 = require("./fetch-data/fetch-data.component");
var purchases_component_1 = require("./purchases/purchases.component");
var purchase_component_1 = require("./purchases/purchase/purchase.component");
var purchase_items_component_1 = require("./purchases/purchase-items/purchase-items.component");
var purchase_service_1 = require("./shared/purchase.service");
var animations_1 = require("@angular/platform-browser/animations");
var dbaccts_component_1 = require("./dbaccts/dbaccts.component");
var dbacctsnew_component_1 = require("./dbacctsnew/dbacctsnew.component");
var app_error_handler_1 = require("./app.error-handler");
//import  {ToastrModule} from 'ng6-toastr-notifications';
var ngx_toastr_1 = require("ngx-toastr");
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        core_1.NgModule({
            declarations: [
                app_component_1.AppComponent,
                nav_menu_component_1.NavMenuComponent,
                home_component_1.HomeComponent,
                counter_component_1.CounterComponent,
                fetch_data_component_1.FetchDataComponent,
                purchases_component_1.PurchasesComponent,
                purchase_component_1.PurchaseComponent,
                goods_form_component_1.GoodsFormComponent,
                purchase_items_component_1.PurchaseItemsComponent,
                dbaccts_component_1.DbacctsComponent,
                dbacctsnew_component_1.DbacctsnewComponent,
            ],
            entryComponents: [purchase_items_component_1.PurchaseItemsComponent],
            imports: [
                platform_browser_1.BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
                http_1.HttpClientModule,
                forms_1.FormsModule,
                //ToastrModule.forRoot(),
                ngx_toastr_1.ToastrModule.forRoot({
                    timeOut: 3000,
                    preventDuplicates: true,
                    closeButton: true,
                    positionClass: 'toast-top-center'
                }),
                forms_1.ReactiveFormsModule,
                animations_1.BrowserAnimationsModule,
                dialog_1.MatDialogModule,
                router_1.RouterModule.forRoot([
                    { path: '', component: dbaccts_component_1.DbacctsComponent },
                    { path: 'accounts/new', component: dbacctsnew_component_1.DbacctsnewComponent },
                    { path: 'accounts/new/:id', component: dbacctsnew_component_1.DbacctsnewComponent },
                    { path: '', component: home_component_1.HomeComponent, pathMatch: 'full' },
                    { path: 'goods', component: goods_form_component_1.GoodsFormComponent },
                    { path: 'counter', component: counter_component_1.CounterComponent },
                    { path: 'fetch-data', component: fetch_data_component_1.FetchDataComponent },
                    { path: 'dbaccts', component: dbaccts_component_1.DbacctsComponent },
                    //----------------------------------------------------------------
                    { path: 'purchases', component: purchases_component_1.PurchasesComponent },
                    { path: 'purchase', children: [
                            { path: '', component: purchase_component_1.PurchaseComponent },
                            { path: 'edit/:id', component: purchase_component_1.PurchaseComponent }
                        ]
                    }
                ]),
                animations_1.BrowserAnimationsModule
            ],
            providers: [
                { provide: core_1.ErrorHandler, useClass: app_error_handler_1.AppErrorHandler },
                category_service_1.CategoryService,
                purchase_service_1.PurchaseService,
            ],
            bootstrap: [app_component_1.AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;
