"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.GoodsFormComponent = void 0;
var core_1 = require("@angular/core");
var GoodsFormComponent = /** @class */ (function () {
    function GoodsFormComponent(categoryService) {
        this.categoryService = categoryService;
        this.products = [];
        this.goods = {};
    }
    GoodsFormComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.categoryService.getCategory().subscribe(function (categories) {
            _this.categories = categories;
            console.log("Testing1", _this.categories);
        });
    };
    GoodsFormComponent.prototype.onCategoryChang = function () {
        var _this = this;
        console.log("Testing2", this.goods.category);
        var selectedCategory = this.categories.find(function (c) { return c.catId == _this.goods.category; });
        this.products = selectedCategory.products;
        console.log("Testing3", this.products);
    };
    GoodsFormComponent = __decorate([
        core_1.Component({
            selector: 'goods-form',
            templateUrl: './goods-form.component.html',
            styleUrls: ['./goods-form.component.css']
        })
    ], GoodsFormComponent);
    return GoodsFormComponent;
}());
exports.GoodsFormComponent = GoodsFormComponent;
