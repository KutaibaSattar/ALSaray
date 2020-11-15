"use strict";
var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.PurchaseService = void 0;
var core_1 = require("@angular/core");
var PurchaseService = /** @class */ (function () {
    function PurchaseService(http) {
        this.http = http;
    }
    PurchaseService.prototype.saveOrUpdatePurchase = function () {
        console.log("Hello");
        var body = __assign(__assign({}, this.formData), { purchaseItems: this.purchaseItems });
        console.log(body);
        return this.http.post('/api/purchase/', body);
    };
    PurchaseService.prototype["delete"] = function (id) {
        console.log(id);
        return this.http["delete"]('/api/purchase/' + id);
    };
    PurchaseService.prototype.getPurchases = function () {
        return this.http.get('api/purchase');
    };
    PurchaseService = __decorate([
        core_1.Injectable({
            providedIn: 'root'
        })
    ], PurchaseService);
    return PurchaseService;
}());
exports.PurchaseService = PurchaseService;
