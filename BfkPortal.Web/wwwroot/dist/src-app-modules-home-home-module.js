(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["src-app-modules-home-home-module"],{

/***/ "./src/app/modules/home/components/overview-list/overview-list.component.html":
/*!************************************************************************************!*\
  !*** ./src/app/modules/home/components/overview-list/overview-list.component.html ***!
  \************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div (click)=\"goToAppointmentList()\" class=\"\">\r\n  <div class=\" z-depth-3 mb-1  list-group-item list-color\">\r\n    <div>\r\n      <div style=\"height:100%; width: 100%\" class=\"row  justify-content-between\">\r\n        <h5 class=\"col-md-6 col-sm-12 txtOverflow\">\r\n          <b>{{appointment.title }}\r\n          </b>\r\n\r\n        </h5>\r\n        <p class=\" mb-0 col-md-6 col-sm-12 txtOverflow\">{{appointment.from.getHours()\r\n          }}:{{appointment.from.getMinutes()\r\n          <10? '0' : '' }}{{appointment.from.getMinutes() }} - {{appointment.to.getHours()}}\r\n            :{{appointment.to.getMinutes() <10? '0' : '' }}{{appointment.to.getMinutes() }} \r\n            <span *ngIf=\"appointment.moreDays && checkWidth() > 1125\">\r\n                (bis\r\n                {{appointment.to.getDate() }}.{{appointment.to.getMonth()+1 }}.{{appointment.to.getFullYear() }})\r\n            </span>\r\n        </p>\r\n        <p class=\"col-12\" *ngIf=\"appointment.moreDays && checkWidth() < 1125\">\r\n            (bis\r\n            {{appointment.to.getDate() }}.{{appointment.to.getMonth()+1 }}.{{appointment.to.getFullYear() }})\r\n        </p>\r\n      </div>\r\n\r\n\r\n    </div>\r\n    <div [ngStyle]=\"{'background-color': checkColor(appointment)}\" class=\"col-12 color-height\">\r\n    </div>\r\n  </div>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/modules/home/components/overview-list/overview-list.component.scss":
/*!************************************************************************************!*\
  !*** ./src/app/modules/home/components/overview-list/overview-list.component.scss ***!
  \************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".txtOverflow {\n  word-break: break-all; }\n\n.color-height {\n  height: 1vh; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9ob21lL2NvbXBvbmVudHMvb3ZlcnZpZXctbGlzdC9DOlxcVXNlcnNcXGNocmlzXFxTb3VyY2UgQ29kZVxcR2l0SHViXFxiZmstcG9ydGFsXFxiZmstcG9ydGFsLWNsaWVudC9zcmNcXGFwcFxcbW9kdWxlc1xcaG9tZVxcY29tcG9uZW50c1xcb3ZlcnZpZXctbGlzdFxcb3ZlcnZpZXctbGlzdC5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtFQUNJLHNCQUFxQixFQUN0Qjs7QUFFRDtFQUNFLFlBQVcsRUFDWiIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvaG9tZS9jb21wb25lbnRzL292ZXJ2aWV3LWxpc3Qvb3ZlcnZpZXctbGlzdC5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIi50eHRPdmVyZmxvdyB7XHJcbiAgICB3b3JkLWJyZWFrOiBicmVhay1hbGw7XHJcbiAgfVxyXG4gIFxyXG4gIC5jb2xvci1oZWlnaHQge1xyXG4gICAgaGVpZ2h0OiAxdmg7XHJcbiAgfVxyXG4iXX0= */"

/***/ }),

/***/ "./src/app/modules/home/components/overview-list/overview-list.component.ts":
/*!**********************************************************************************!*\
  !*** ./src/app/modules/home/components/overview-list/overview-list.component.ts ***!
  \**********************************************************************************/
/*! exports provided: OverviewListComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "OverviewListComponent", function() { return OverviewListComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var src_app_shared_models_appointment__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/shared/models/appointment */ "./src/app/shared/models/appointment.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var OverviewListComponent = /** @class */ (function () {
    function OverviewListComponent(router) {
        this.router = router;
        this.checkColor = src_app_shared_models_appointment__WEBPACK_IMPORTED_MODULE_2__["Appointment"].checkColor;
    }
    OverviewListComponent.prototype.goToAppointmentList = function () {
        this.router.navigate(['/home/appointments/list'], { fragment: this.appointment.id.toString() });
    };
    OverviewListComponent.prototype.ngOnInit = function () {
        this.navigationExtras = {
            fragment: this.appointment.id.toString()
        };
    };
    OverviewListComponent.prototype.checkWidth = function () {
        return window.innerWidth;
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", src_app_shared_models_appointment__WEBPACK_IMPORTED_MODULE_2__["Appointment"])
    ], OverviewListComponent.prototype, "appointment", void 0);
    OverviewListComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-overview-list',
            template: __webpack_require__(/*! ./overview-list.component.html */ "./src/app/modules/home/components/overview-list/overview-list.component.html"),
            styles: [__webpack_require__(/*! ./overview-list.component.scss */ "./src/app/modules/home/components/overview-list/overview-list.component.scss")]
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"]])
    ], OverviewListComponent);
    return OverviewListComponent;
}());



/***/ }),

/***/ "./src/app/modules/home/components/overview/overview.component.html":
/*!**************************************************************************!*\
  !*** ./src/app/modules/home/components/overview/overview.component.html ***!
  \**************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div *ngIf=\"this.myShifts.length != 0 || this.myAppointments.length != 0; else: noAppointments\" >\r\n  <div\r\n  class=\"d-flex flex-row justify-content-between\"\r\n  *ngIf=\"checkWidth() >= 500; else: small_Devices\"\r\n>\r\n  <div class=\" set-flex list-group \" *ngIf=\"this.myShifts.length != 0\">\r\n    <h4 class=\" align-self-center\">Nächste Dienste</h4>\r\n    <div *ngFor=\"let appointment of myShifts\">\r\n      <app-overview-list [appointment]=\"appointment\"></app-overview-list>\r\n    </div>\r\n  </div>\r\n    <div class=\" set-flex list-group \" *ngIf=\"this.myAppointments.length != 0\">\r\n      <h4 class=\"align-self-center\">Nächste Termine</h4>\r\n      <div *ngFor=\"let appointment of myAppointments\">\r\n        <app-overview-list [appointment]=\"appointment\"></app-overview-list>\r\n      </div>\r\n    </div>\r\n  </div>\r\n</div>\r\n\r\n\r\n\r\n<ng-template #small_Devices>\r\n    <mdb-tabset id=\"userMngmtTabs\" #OverviewTabs [buttonClass]=\"'md-tabs tabs-2 pills-secondary white'\"\r\n    [contentClass]=\"''\">\r\n    <!--Panel 1-->\r\n    <mdb-tab heading=\"Nächste Dienste\">\r\n\r\n        <div\r\n        class=\" set-flex list-group \"\r\n        *ngIf=\"this.myAppointments.length != 0\"\r\n      >\r\n        <div *ngFor=\"let appointment of myShifts\">\r\n          <app-overview-list [appointment]=\"appointment\"></app-overview-list>\r\n        </div>\r\n      </div>\r\n\r\n\r\n\r\n\r\n    </mdb-tab>\r\n    <!--Panel 2-->\r\n    <mdb-tab heading=\"Nächste Termine\">\r\n        <div\r\n        class=\" set-flex list-group \"\r\n        *ngIf=\"this.myAppointments.length != 0\"\r\n      >\r\n        <div *ngFor=\"let appointment of myAppointments\">\r\n          <app-overview-list [appointment]=\"appointment\"></app-overview-list>\r\n        </div>\r\n      </div>\r\n\r\n    </mdb-tab>\r\n  </mdb-tabset>\r\n</ng-template>\r\n<ng-template #noAppointments>\r\n      <h1 class=\"d-flex justify-content-center h1-responsive\">Keine Dienste oder Termine</h1>\r\n      <div class=\"d-flex justify-content-center\">\r\n          <button (click)=\"this.router.navigate(['home/marketplace'])\" class=\"btn btn-color\">Zum Marktplatz<i class=\"fa fa-paper-plane-o ml-1\"></i></button>\r\n      </div>\r\n      \r\n  \r\n</ng-template>\r\n\r\n"

/***/ }),

/***/ "./src/app/modules/home/components/overview/overview.component.scss":
/*!**************************************************************************!*\
  !*** ./src/app/modules/home/components/overview/overview.component.scss ***!
  \**************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".set-flex {\n  flex: 1; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9ob21lL2NvbXBvbmVudHMvb3ZlcnZpZXcvQzpcXFVzZXJzXFxjaHJpc1xcU291cmNlIENvZGVcXEdpdEh1YlxcYmZrLXBvcnRhbFxcYmZrLXBvcnRhbC1jbGllbnQvc3JjXFxhcHBcXG1vZHVsZXNcXGhvbWVcXGNvbXBvbmVudHNcXG92ZXJ2aWV3XFxvdmVydmlldy5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFDQTtFQUNFLFFBQU8sRUFDUiIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvaG9tZS9jb21wb25lbnRzL292ZXJ2aWV3L292ZXJ2aWV3LmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsiQGltcG9ydCBcInNyYy92YXJpYWJsZXMuc2Nzc1wiO1xyXG4uc2V0LWZsZXh7XHJcbiAgZmxleDogMTtcclxufVxyXG4iXX0= */"

/***/ }),

/***/ "./src/app/modules/home/components/overview/overview.component.ts":
/*!************************************************************************!*\
  !*** ./src/app/modules/home/components/overview/overview.component.ts ***!
  \************************************************************************/
/*! exports provided: OverviewComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "OverviewComponent", function() { return OverviewComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! lodash */ "./node_modules/lodash/lodash.js");
/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(lodash__WEBPACK_IMPORTED_MODULE_1__);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var src_app_core_services_appointment_service_appointment_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/core/services/appointment-service/appointment.service */ "./src/app/core/services/appointment-service/appointment.service.ts");
/* harmony import */ var src_app_core_services_session_user_service_session_user_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! src/app/core/services/session-user-service/session-user.service */ "./src/app/core/services/session-user-service/session-user.service.ts");
/* harmony import */ var src_app_core_services_navbar_buttons_service_navbar_buttons_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! src/app/core/services/navbar-buttons-service/navbar-buttons.service */ "./src/app/core/services/navbar-buttons-service/navbar-buttons.service.ts");
/* harmony import */ var src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! src/app/shared/enums/static-strings */ "./src/app/shared/enums/static-strings.ts");
/* harmony import */ var src_app_shared_models_user__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! src/app/shared/models/user */ "./src/app/shared/models/user.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};








var OverviewComponent = /** @class */ (function () {
    function OverviewComponent(appointmentService, sessionUser, navbarButtons, router) {
        this.appointmentService = appointmentService;
        this.sessionUser = sessionUser;
        this.navbarButtons = navbarButtons;
        this.router = router;
        this.myAppointments = [];
        this.myShifts = [];
        this.myAppointmentsCounter = 0;
        this.myShiftsCounter = 0;
    }
    OverviewComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.navbarButtons.changeToOverviewView();
        this
            .appointmentService
            ._allAppointments
            .subscribe(function (appointments) {
            _this.getLastAppointments(appointments);
        });
    };
    OverviewComponent.prototype.checkWidth = function () {
        return window.innerWidth;
    };
    OverviewComponent.prototype.getLastAppointments = function (appointments) {
        var _this = this;
        this.myAppointments = [];
        this.myShifts = [];
        appointments.sort(function (a, b) { return a.from.getTime() - b.from.getTime(); });
        appointments.forEach(function (appointment) {
            if (_this.sessionUser.getUser().entitlements.includes(src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__["Roles"][src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__["Roles"].AdminBwst])
                || _this.sessionUser.getUser().entitlements.includes(src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__["Roles"][src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__["Roles"].UserBwst])) {
                if ((appointment.type === src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__["AppointmentTypes"][src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__["AppointmentTypes"].Dienst]
                    || appointment.type === src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__["AppointmentTypes"][src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__["AppointmentTypes"].MarktplatzDienst])
                    && appointment.owner.email === _this.sessionUser.getUser().email
                    && _this.myShiftsCounter <= 5
                    && appointment.from.getTime() > new Date().getTime()) {
                    _this
                        .myShifts
                        .push(appointment);
                    _this.myShiftsCounter++;
                }
            }
            if (_this.sessionUser.getUser().entitlements.includes(src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__["Roles"][src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__["Roles"].AdminBfk])
                || _this.sessionUser.getUser().entitlements.includes(src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__["Roles"][src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__["Roles"].UserBfk])) {
                if (appointment.type !== src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__["AppointmentTypes"][src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__["AppointmentTypes"].Dienst]
                    && appointment.type !== src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__["AppointmentTypes"][src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__["AppointmentTypes"].MarktplatzDienst]
                    && appointment.type !== src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__["AppointmentTypes"][src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__["AppointmentTypes"].FreierDienst]) {
                    if (src_app_shared_models_user__WEBPACK_IMPORTED_MODULE_7__["User"].checkparticipations(appointment.participations[0])) {
                        if (appointment.participations.includes(_this.sessionUser.getUser().email)
                            && _this.myAppointmentsCounter <= 5
                            && appointment.from.getTime() > new Date().getTime()) {
                            _this
                                .myAppointments
                                .push(appointment);
                            _this.myAppointmentsCounter++;
                        }
                    }
                    else {
                        if (_this.checkForParticipationInOrg(appointment)
                            && _this.myAppointmentsCounter <= 5
                            && appointment.from.getTime() > new Date().getTime()) {
                            _this
                                .myAppointments
                                .push(appointment);
                            _this.myAppointmentsCounter++;
                        }
                    }
                }
            }
        });
    };
    OverviewComponent.prototype.checkForParticipationInOrg = function (appointment) {
        for (var _i = 0, _a = appointment.participations; _i < _a.length; _i++) {
            var participant = _a[_i];
            for (var _b = 0, _c = this.sessionUser.getUser().memberships; _b < _c.length; _b++) {
                var membership = _c[_b];
                if (lodash__WEBPACK_IMPORTED_MODULE_1__["isEqual"](participant, membership)) {
                    return true;
                }
            }
        }
    };
    OverviewComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({ selector: 'app-overview', template: __webpack_require__(/*! ./overview.component.html */ "./src/app/modules/home/components/overview/overview.component.html"), styles: [__webpack_require__(/*! ./overview.component.scss */ "./src/app/modules/home/components/overview/overview.component.scss")] }),
        __metadata("design:paramtypes", [src_app_core_services_appointment_service_appointment_service__WEBPACK_IMPORTED_MODULE_3__["AppointmentService"],
            src_app_core_services_session_user_service_session_user_service__WEBPACK_IMPORTED_MODULE_4__["SessionUserService"],
            src_app_core_services_navbar_buttons_service_navbar_buttons_service__WEBPACK_IMPORTED_MODULE_5__["NavbarButtonsService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_2__["Router"]])
    ], OverviewComponent);
    return OverviewComponent;
}());



/***/ }),

/***/ "./src/app/modules/home/home-routing.module.ts":
/*!*****************************************************!*\
  !*** ./src/app/modules/home/home-routing.module.ts ***!
  \*****************************************************/
/*! exports provided: HomeRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HomeRoutingModule", function() { return HomeRoutingModule; });
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _components_overview_overview_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./components/overview/overview.component */ "./src/app/modules/home/components/overview/overview.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var routes = [
    {
        path: '',
        component: _components_overview_overview_component__WEBPACK_IMPORTED_MODULE_2__["OverviewComponent"]
    }
];
var HomeRoutingModule = /** @class */ (function () {
    function HomeRoutingModule() {
    }
    HomeRoutingModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_0__["RouterModule"].forChild(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_0__["RouterModule"]]
        })
    ], HomeRoutingModule);
    return HomeRoutingModule;
}());



/***/ }),

/***/ "./src/app/modules/home/home.module.ts":
/*!*********************************************!*\
  !*** ./src/app/modules/home/home.module.ts ***!
  \*********************************************/
/*! exports provided: HomeModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "HomeModule", function() { return HomeModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var _components_overview_overview_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./components/overview/overview.component */ "./src/app/modules/home/components/overview/overview.component.ts");
/* harmony import */ var _components_overview_list_overview_list_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./components/overview-list/overview-list.component */ "./src/app/modules/home/components/overview-list/overview-list.component.ts");
/* harmony import */ var ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ng-uikit-pro-standard */ "./node_modules/ng-uikit-pro-standard/esm5/ng-uikit-pro-standard.es5.js");
/* harmony import */ var _home_routing_module__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./home-routing.module */ "./src/app/modules/home/home-routing.module.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};






var HomeModule = /** @class */ (function () {
    function HomeModule() {
    }
    HomeModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            declarations: [
                _components_overview_overview_component__WEBPACK_IMPORTED_MODULE_2__["OverviewComponent"],
                _components_overview_list_overview_list_component__WEBPACK_IMPORTED_MODULE_3__["OverviewListComponent"]
            ],
            imports: [
                _angular_common__WEBPACK_IMPORTED_MODULE_1__["CommonModule"],
                _home_routing_module__WEBPACK_IMPORTED_MODULE_5__["HomeRoutingModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_4__["ButtonsModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_4__["WavesModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_4__["CollapseModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_4__["TabsModule"]
            ],
            exports: [
                _components_overview_overview_component__WEBPACK_IMPORTED_MODULE_2__["OverviewComponent"],
                _components_overview_list_overview_list_component__WEBPACK_IMPORTED_MODULE_3__["OverviewListComponent"]
            ],
            schemas: [_angular_core__WEBPACK_IMPORTED_MODULE_0__["NO_ERRORS_SCHEMA"]],
            providers: [ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_4__["MDBSpinningPreloader"]]
        })
    ], HomeModule);
    return HomeModule;
}());



/***/ })

}]);
//# sourceMappingURL=src-app-modules-home-home-module.js.map