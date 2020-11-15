"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
exports.__esModule = true;
exports.PurchaseItemsComponent = void 0;
var core_1 = require("@angular/core");
var material_1 = require("@angular/material");
var PurchaseItemsComponent = /** @class */ (function () {
    function PurchaseItemsComponent(data, dialogRef, productService, purchaseService) {
        this.data = data;
        this.dialogRef = dialogRef;
        this.productService = productService;
        this.purchaseService = purchaseService;
        this.isValid = true;
    }
    PurchaseItemsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.productService.getProductList().then(function (res) { return _this.productList = res; });
        if (this.data.OrderItemIndex == null)
            this.formData = {
                purchItemId: null,
                purchId: this.data.purchId,
                prodId: 0,
                itemName: '',
                price: 0,
                quantity: 0,
                total: 0
            };
        else
            this.formData = Object.assign({}, this.purchaseService.purchaseItems[this.data.OrderItemIndex]);
    };
    PurchaseItemsComponent.prototype.updateIemnName = function (ctrl) {
        if (ctrl.selectedIndex == 0) {
            this.formData.itemName = '';
        }
        else {
            this.formData.itemName = this.productList[ctrl.selectedIndex - 1].prodName;
        }
    };
    PurchaseItemsComponent.prototype.updateTotal = function () {
        this.formData.total = parseFloat((this.formData.quantity * this.formData.price).toFixed(2));
    };
    PurchaseItemsComponent.prototype.save = function (form) {
        if (this.validateForm(form.value)) {
            if (this.data.OrderItemIndex == null)
                this.purchaseService.purchaseItems.push(form.value);
            else
                this.purchaseService.purchaseItems[this.data.OrderItemIndex] = form.value;
            this.dialogRef.close();
        }
    };
    PurchaseItemsComponent.prototype.validateForm = function (formData) {
        this.isValid = true;
        if (formData.prodId == 0)
            this.isValid = false;
        else if (formData.quantity == 0)
            this.isValid = false;
        return this.isValid;
    };
    PurchaseItemsComponent.prototype.close = function () {
        this.dialogRef.close();
    };
    PurchaseItemsComponent = __decorate([
        core_1.Component({
            selector: 'app-purchase-items',
            templateUrl: './purchase-items.component.html',
            styles: []
        }),
        __param(0, core_1.Inject(material_1.MAT_DIALOG_DATA))
    ], PurchaseItemsComponent);
    return PurchaseItemsComponent;
}());
exports.PurchaseItemsComponent = PurchaseItemsComponent;
