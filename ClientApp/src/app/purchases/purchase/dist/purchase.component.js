"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.PurchaseComponent = void 0;
var purchase_items_component_1 = require("./../purchase-items/purchase-items.component");
var core_1 = require("@angular/core");
var dialog_1 = require("@angular/material/dialog");
var PurchaseComponent = /** @class */ (function () {
    function PurchaseComponent(service, dialog, mydbacctservice, toastr) {
        this.service = service;
        this.dialog = dialog;
        this.mydbacctservice = mydbacctservice;
        this.toastr = toastr;
        this.isValid = true;
    }
    PurchaseComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.mydbacctservice.getMyacctList().then(function (res) { return _this.myaccut = res; });
        this.resetForm();
    };
    PurchaseComponent.prototype.resetForm = function (form) {
        if (form = null)
            form.resetForm();
        this.service.formData = {
            purchId: null,
            purchNo: Math.floor(1000000 + Math.random() * 900000).toString(),
            accId: null,
            pMethod: '',
            gtotal: 0
        };
        this.service.purchaseItems = [];
    };
    PurchaseComponent.prototype.AddOrEditPurchseItem = function (OrderItemIndex, OrderID) {
        var _this = this;
        var dialogConfig = new dialog_1.MatDialogConfig;
        dialogConfig.autoFocus = true;
        dialogConfig.width = "50%";
        dialogConfig.data = { OrderItemIndex: OrderItemIndex, OrderID: OrderID };
        this.dialog.open(purchase_items_component_1.PurchaseItemsComponent, dialogConfig).afterClosed().subscribe(function (res) { _this.updateGrandTotal(); });
    };
    PurchaseComponent.prototype.OnDeletePurchseItem = function (purchItemId, i) {
        this.service.purchaseItems.splice(i, 1);
        this.updateGrandTotal();
    };
    PurchaseComponent.prototype.updateGrandTotal = function () {
        this.service.formData.gtotal = this.service.purchaseItems.reduce(function (prev, curr) {
            return prev + curr.total;
        }, 0);
        this.service.formData.gtotal = parseFloat((this.service.formData.gtotal).toFixed(2));
    };
    PurchaseComponent.prototype.validateForm = function () {
        this.isValid = true;
        if (this.service.formData.accId == 0)
            this.isValid = false;
        else if (this.service.purchaseItems.length == 0)
            this.isValid = false;
        return this.isValid;
    };
    PurchaseComponent.prototype.OnSubmit = function (form) {
        var _this = this;
        if (this.validateForm()) {
            this.service.saveOrUpdatePurchase().subscribe(function (res) {
                _this.resetForm();
                _this.toastr.success("Submitted Successfuly", "Bab ALSaray");
            });
        }
    };
    PurchaseComponent = __decorate([
        core_1.Component({
            selector: 'app-purchase',
            templateUrl: './purchase.component.html',
            styles: []
        })
    ], PurchaseComponent);
    return PurchaseComponent;
}());
exports.PurchaseComponent = PurchaseComponent;
