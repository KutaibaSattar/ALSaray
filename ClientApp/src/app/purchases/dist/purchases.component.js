"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.PurchasesComponent = void 0;
var core_1 = require("@angular/core");
var PurchasesComponent = /** @class */ (function () {
    function PurchasesComponent(purchaseService) {
        this.purchaseService = purchaseService;
    }
    PurchasesComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.purchaseService.getPurchases().subscribe(function (purchases) { return _this.purchases = purchases; });
        //this.purchaseService.getPurchases().subscribe((purchase :Purchases []) => this.purchases = purchase )
    };
    PurchasesComponent = __decorate([
        core_1.Component({
            selector: 'app-purchases',
            templateUrl: './purchases.component.html',
            styleUrls: ['./purchases.component.css']
        })
    ], PurchasesComponent);
    return PurchasesComponent;
}());
exports.PurchasesComponent = PurchasesComponent;
