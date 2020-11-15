"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.DbacctsnewComponent = void 0;
var core_1 = require("@angular/core");
var DbacctsnewComponent = /** @class */ (function () {
    function DbacctsnewComponent(route, //read parameter
    router, // if invalid id the navigate to a adifferent page
    mydbaccountService, 
    //private toastr: ToastrManager,
    toastr) {
        this.route = route;
        this.router = router;
        this.mydbaccountService = mydbaccountService;
        this.toastr = toastr;
        this.dbaccounts = {
            acctId: 0,
            acctKey: '',
            acctName: '',
            nodePath: ''
        };
    }
    DbacctsnewComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.route.params.subscribe(function (p) {
            if (p['id'].search('/') == -1) {
                _this.dbaccounts.acctId = p['id'];
                _this.mydbaccountService.getAcc(_this.dbaccounts.acctId).subscribe(function (a) { _this.dbaccounts = a; });
            }
            else
                _this.dbaccounts.nodePath = p['id']; //Checking
        });
    };
    DbacctsnewComponent.prototype["delete"] = function () {
        var _this = this;
        if (confirm("Are you sure ?")) {
            this.mydbaccountService["delete"](this.dbaccounts.acctId).subscribe(function () { return _this.router.navigate(['/dbaccts']); });
        }
    };
    DbacctsnewComponent.prototype.submit = function () {
        /*  this.toastr.success('Hello world!', 'Toastr fun!',{
           timeOut: 10000,
         positionClass: 'toast-top-right',
         }); */
        var _this = this;
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
        if (this.dbaccounts.acctId == 0) {
            var result$ = this.mydbaccountService.Create(this.dbaccounts);
            //
        }
        else {
            var result$ = this.mydbaccountService.Update(this.dbaccounts.acctId, this.dbaccounts);
        }
        result$.subscribe(function () {
            _this.toastr.success("Data was sucessfully saved.");
            _this.router.navigate(['/dbaccts']);
        });
    };
    DbacctsnewComponent = __decorate([
        core_1.Component({
            selector: 'app-dbacctsnew',
            templateUrl: './dbacctsnew.component.html',
            styleUrls: ['./dbacctsnew.component.css']
        })
    ], DbacctsnewComponent);
    return DbacctsnewComponent;
}());
exports.DbacctsnewComponent = DbacctsnewComponent;
