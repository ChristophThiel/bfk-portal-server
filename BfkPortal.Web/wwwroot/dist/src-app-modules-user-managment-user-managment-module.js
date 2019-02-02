(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["src-app-modules-user-managment-user-managment-module"],{

/***/ "./src/app/modules/user-managment/components/add-update-user-wrapper/add-update-user-wrapper.component.html":
/*!******************************************************************************************************************!*\
  !*** ./src/app/modules/user-managment/components/add-update-user-wrapper/add-update-user-wrapper.component.html ***!
  \******************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div>\r\n    <app-user-misc-input [isUpdate]=\"this.isUpdate\" [miscForm]=\"this.miscForm\"></app-user-misc-input>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/modules/user-managment/components/add-update-user-wrapper/add-update-user-wrapper.component.scss":
/*!******************************************************************************************************************!*\
  !*** ./src/app/modules/user-managment/components/add-update-user-wrapper/add-update-user-wrapper.component.scss ***!
  \******************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvdXNlci1tYW5hZ21lbnQvY29tcG9uZW50cy9hZGQtdXBkYXRlLXVzZXItd3JhcHBlci9hZGQtdXBkYXRlLXVzZXItd3JhcHBlci5jb21wb25lbnQuc2NzcyJ9 */"

/***/ }),

/***/ "./src/app/modules/user-managment/components/add-update-user-wrapper/add-update-user-wrapper.component.ts":
/*!****************************************************************************************************************!*\
  !*** ./src/app/modules/user-managment/components/add-update-user-wrapper/add-update-user-wrapper.component.ts ***!
  \****************************************************************************************************************/
/*! exports provided: AddUpdateUserWrapperComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AddUpdateUserWrapperComponent", function() { return AddUpdateUserWrapperComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var src_app_shared_validation_customValidations__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/shared/validation/customValidations */ "./src/app/shared/validation/customValidations.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var src_app_core_services_user_service_user_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! src/app/core/services/user-service/user.service */ "./src/app/core/services/user-service/user.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





var AddUpdateUserWrapperComponent = /** @class */ (function () {
    function AddUpdateUserWrapperComponent(fb, route, userService) {
        this.fb = fb;
        this.route = route;
        this.userService = userService;
        console.log(location);
        this.miscForm = fb.group({
            firstName: ['', [_angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required]],
            lastName: ['', [_angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required]],
            telephone: ['', [_angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required, src_app_shared_validation_customValidations__WEBPACK_IMPORTED_MODULE_2__["telephoneValidation"]]],
            email: ['', [_angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required, _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].email]],
            roles: [[], [_angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required]],
            organisations: [[], [_angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required]]
        }, { updateOn: 'submit' });
    }
    AddUpdateUserWrapperComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.route.params.subscribe(function (params) {
            if (!!params['id']) {
                _this.isUpdate = true;
                var id_1 = +params['id'];
                _this.userService._allUsers.subscribe(function (users) {
                    var userToUpdate = users.find(function (user) { return user.id === id_1; });
                    _this.initVals(userToUpdate);
                });
            }
            else {
                _this.isUpdate = false;
            }
        });
    };
    AddUpdateUserWrapperComponent.prototype.initVals = function (userToUpdate) {
        var _this = this;
        userToUpdate.entitlements.forEach(function (entitlement) {
            console.log(entitlement);
            var copyRoles = _this.miscForm.get('roles').value;
            copyRoles.push(entitlement);
            _this.miscForm.patchValue({ roles: copyRoles });
        });
        userToUpdate.memberships.forEach(function (entitlement) {
            var copyOrgs = _this.miscForm.get('organisations').value;
            copyOrgs.push(entitlement.id);
            _this.miscForm.patchValue({ organisations: copyOrgs });
        });
        this.miscForm.patchValue({
            firstName: userToUpdate.firstname,
            lastName: userToUpdate.lastname,
            email: userToUpdate.email,
            telephone: userToUpdate.telephone
        });
    };
    AddUpdateUserWrapperComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-add-update-user-wrapper',
            template: __webpack_require__(/*! ./add-update-user-wrapper.component.html */ "./src/app/modules/user-managment/components/add-update-user-wrapper/add-update-user-wrapper.component.html"),
            styles: [__webpack_require__(/*! ./add-update-user-wrapper.component.scss */ "./src/app/modules/user-managment/components/add-update-user-wrapper/add-update-user-wrapper.component.scss")]
        }),
        __metadata("design:paramtypes", [_angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormBuilder"],
            _angular_router__WEBPACK_IMPORTED_MODULE_3__["ActivatedRoute"],
            src_app_core_services_user_service_user_service__WEBPACK_IMPORTED_MODULE_4__["UserService"]])
    ], AddUpdateUserWrapperComponent);
    return AddUpdateUserWrapperComponent;
}());



/***/ }),

/***/ "./src/app/modules/user-managment/components/user-management-list/user-management-list.component.html":
/*!************************************************************************************************************!*\
  !*** ./src/app/modules/user-managment/components/user-management-list/user-management-list.component.html ***!
  \************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"list-group\">\r\n    <div *ngFor=\"let user of allUsers\" class=\"row list-group-item justify-content-center\">\r\n        <div class=\"col-md-6 col-sm-12\">\r\n          <div class=\"row\">\r\n              <h5 class=\"col-md-\"><b>{{user.lastname}}</b>\r\n                {{user.firstname}}</h5>\r\n                <p class=\"col text-muted\">{{user.telephone}}</p>\r\n          </div>\r\n          <div class=\"row\">\r\n          <p class=\"text-muted\">{{user.email}}</p>\r\n              \r\n          </div>\r\n          <div class=\"row\">\r\n            <div *ngFor=\"let entitlement of user.entitlements\" >\r\n                <div class=\"chip\">{{entitlement}}</div>\r\n            </div>\r\n          </div>\r\n          <div class=\"row\">\r\n              <div *ngFor=\"let membership of user.memberships\" >\r\n                  <div class=\"chip\">{{membership.name}}</div>\r\n              </div>\r\n            </div>\r\n            \r\n        </div>\r\n        <div class=\"col-md-6 col-sm-12\">\r\n          <button (click)=\"changeView(user)\" class=\"btn btn-color waves-light\" mdbWavesEffect> <i class=\"fa fa-edit\"></i>\r\n            Ändern</button>\r\n            <button (click)=\"deleteUser(user)\" class=\"btn btn-color waves-light\" mdbWavesEffect> <i class=\"fa fa-trash\"></i>\r\n              Löschen</button>\r\n        </div>\r\n      </div>\r\n</div>\r\n\r\n"

/***/ }),

/***/ "./src/app/modules/user-managment/components/user-management-list/user-management-list.component.scss":
/*!************************************************************************************************************!*\
  !*** ./src/app/modules/user-managment/components/user-management-list/user-management-list.component.scss ***!
  \************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".list-group-item {\n  display: flex; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy91c2VyLW1hbmFnbWVudC9jb21wb25lbnRzL3VzZXItbWFuYWdlbWVudC1saXN0L0M6XFxVc2Vyc1xcY2hyaXNcXFNvdXJjZSBDb2RlXFxHaXRIdWJcXGJmay1wb3J0YWxcXGJmay1wb3J0YWwtY2xpZW50L3NyY1xcYXBwXFxtb2R1bGVzXFx1c2VyLW1hbmFnbWVudFxcY29tcG9uZW50c1xcdXNlci1tYW5hZ2VtZW50LWxpc3RcXHVzZXItbWFuYWdlbWVudC1saXN0LmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0ksY0FBYSxFQUNoQiIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvdXNlci1tYW5hZ21lbnQvY29tcG9uZW50cy91c2VyLW1hbmFnZW1lbnQtbGlzdC91c2VyLW1hbmFnZW1lbnQtbGlzdC5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIi5saXN0LWdyb3VwLWl0ZW17XHJcbiAgICBkaXNwbGF5OiBmbGV4O1xyXG59Il19 */"

/***/ }),

/***/ "./src/app/modules/user-managment/components/user-management-list/user-management-list.component.ts":
/*!**********************************************************************************************************!*\
  !*** ./src/app/modules/user-managment/components/user-management-list/user-management-list.component.ts ***!
  \**********************************************************************************************************/
/*! exports provided: UserManagementListComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "UserManagementListComponent", function() { return UserManagementListComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var src_app_core_services_user_service_user_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/core/services/user-service/user.service */ "./src/app/core/services/user-service/user.service.ts");
/* harmony import */ var src_app_core_services_navbar_buttons_service_navbar_buttons_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/core/services/navbar-buttons-service/navbar-buttons.service */ "./src/app/core/services/navbar-buttons-service/navbar-buttons.service.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var UserManagementListComponent = /** @class */ (function () {
    function UserManagementListComponent(changeDetector, userService, navbarButtons, router) {
        this.changeDetector = changeDetector;
        this.userService = userService;
        this.navbarButtons = navbarButtons;
        this.router = router;
        this.allUsers = [];
    }
    UserManagementListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.navbarButtons.changeToListUserManagementView();
        this
            .userService
            ._allUsers
            .subscribe(function (users) {
            _this.allUsers = [];
            _this.allUsers = users;
        });
    };
    UserManagementListComponent.prototype.changeView = function (user) {
        this.router.navigate(['home/user-management/update/' + user.id]);
    };
    UserManagementListComponent.prototype.deleteUser = function (user) {
        this
            .userService
            ._userToDelete
            .next(user);
    };
    UserManagementListComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-user-management-list',
            template: __webpack_require__(/*! ./user-management-list.component.html */ "./src/app/modules/user-managment/components/user-management-list/user-management-list.component.html"),
            styles: [__webpack_require__(/*! ./user-management-list.component.scss */ "./src/app/modules/user-managment/components/user-management-list/user-management-list.component.scss")]
        }),
        __metadata("design:paramtypes", [_angular_core__WEBPACK_IMPORTED_MODULE_0__["ChangeDetectorRef"],
            src_app_core_services_user_service_user_service__WEBPACK_IMPORTED_MODULE_1__["UserService"],
            src_app_core_services_navbar_buttons_service_navbar_buttons_service__WEBPACK_IMPORTED_MODULE_2__["NavbarButtonsService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_3__["Router"]])
    ], UserManagementListComponent);
    return UserManagementListComponent;
}());



/***/ }),

/***/ "./src/app/modules/user-managment/components/user-misc-input/user-misc-input.component.html":
/*!**************************************************************************************************!*\
  !*** ./src/app/modules/user-managment/components/user-misc-input/user-misc-input.component.html ***!
  \**************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n<form [formGroup]=\"miscForm\" (ngSubmit)=\"next()\" >\r\n  <div class=\"row\">\r\n    <div class=\"col-6\">\r\n      <div class=\"md-form\">\r\n        <input mdbInput mdbValidate formControlName=\"firstName\" type=\"text\" class=\"form-control\">\r\n        <label class=\"label-color\">Vorname</label>\r\n        <mdb-error *ngIf=\"firstName.invalid && (firstName.dirty || firstName.touched)\">\r\n            <span *ngIf=\"firstName.errors.required\">Vorname wird benötigt</span>\r\n          </mdb-error>\r\n      </div>\r\n    </div>\r\n    <div class=\"col-6\">\r\n      <div class=\"md-form\">\r\n        <input mdbInput mdbValidate formControlName=\"lastName\" type=\"text\" class=\"form-control\">\r\n        <label class=\"label-color\">Nachname</label>\r\n        <mdb-error *ngIf=\"lastName.invalid && (lastName.dirty || lastName.touched)\">\r\n            <span *ngIf=\"lastName.errors.required\">Nachname wird benötigt</span>\r\n          </mdb-error>\r\n      </div>\r\n  \r\n    </div>\r\n  </div>\r\n  <div class=\"row\">\r\n    <div class=\"col\">\r\n      <div class=\"md-form\">\r\n        <input mdbInput mdbValidate formControlName=\"email\" type=\"email\" class=\"form-control\">\r\n        <label class=\"label-color\">E-mail</label>\r\n        <mdb-error *ngIf=\"email.invalid && (email.dirty || email.touched)\">\r\n            <span *ngIf=\"email.errors.required\">E-mail wird benötigt</span>\r\n            <span *ngIf=\"email.errors.email\">E-mail nicht richtig</span>\r\n          </mdb-error>\r\n      </div>\r\n  \r\n    </div>\r\n  \r\n  </div>\r\n  <div class=\"row\">\r\n    <div class=\"col\">\r\n      <div class=\"md-form\">\r\n        <input mdbInput mdbValidate formControlName=\"telephone\" type=\"tel\" class=\"form-control\">\r\n        <label class=\"label-color\">Telefonnummer</label>\r\n        <mdb-error *ngIf=\"telephone.invalid && (telephone.dirty || telephone.touched)\">\r\n            <span *ngIf=\"telephone.errors.required\">Telefonnummer wird benötigt</span>\r\n            <span *ngIf=\"telephone.errors.phoneNumberNotValid\">Telefonnummer nicht richtig</span>\r\n          </mdb-error>\r\n      </div>\r\n  \r\n    </div>\r\n  \r\n  </div>\r\n  \r\n  \r\n  \r\n  <div class=\"row mt-4\">\r\n    <div class=\"col md-form\">\r\n      <mdb-select #roleSelect mdbValidate [highlightFirst]=\"false\" formControlName=\"roles\" [options]=\"allRolesMultiSelect\"\r\n        [multiple]=\"true\" class=\"colorful-select dropdown-primary\"></mdb-select>\r\n      <label class=\"label-color\">Rollen auswählen</label>\r\n      <mdb-error *ngIf=\"roles.invalid && (roles.dirty || roles.touched)\">\r\n          <span *ngIf=\"roles.errors.required\">Rollen wird benötigt</span>\r\n        </mdb-error>\r\n    </div>\r\n  </div>\r\n  <div class=\"row mt-4\">\r\n    <div class=\"col md-form\">\r\n      <mdb-select mdbValidate #organisationSelect [highlightFirst]=\"false\" formControlName=\"organisations\"\r\n        [options]=\"allOrganisationsMultiSelect\" [multiple]=\"true\" class=\"colorful-select dropdown-primary\"></mdb-select>\r\n      <label class=\"label-color\">Organisation auswählen</label>\r\n      <mdb-error *ngIf=\"organisations.invalid && (organisations.dirty || organisations.touched)\">\r\n          <span *ngIf=\"organisations.errors.required\">Organisationen werden benötigt</span>\r\n        </mdb-error>\r\n    </div>\r\n  </div>\r\n  <div><p class=\" mt-5 text-muted text-center\">Seite 1 von 2</p></div>\r\n  <div class=\"mt-5 d-flex justify-content-end\">\r\n    <button type=\"submit\" class=\"btn btn-color waves-light\" mdbWavesEffect>Nächste</button>\r\n  </div>\r\n</form>"

/***/ }),

/***/ "./src/app/modules/user-managment/components/user-misc-input/user-misc-input.component.scss":
/*!**************************************************************************************************!*\
  !*** ./src/app/modules/user-managment/components/user-misc-input/user-misc-input.component.scss ***!
  \**************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvdXNlci1tYW5hZ21lbnQvY29tcG9uZW50cy91c2VyLW1pc2MtaW5wdXQvdXNlci1taXNjLWlucHV0LmNvbXBvbmVudC5zY3NzIn0= */"

/***/ }),

/***/ "./src/app/modules/user-managment/components/user-misc-input/user-misc-input.component.ts":
/*!************************************************************************************************!*\
  !*** ./src/app/modules/user-managment/components/user-misc-input/user-misc-input.component.ts ***!
  \************************************************************************************************/
/*! exports provided: UserMiscInputComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "UserMiscInputComponent", function() { return UserMiscInputComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var src_app_core_services_organisation_service_organisation_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/core/services/organisation-service/organisation.service */ "./src/app/core/services/organisation-service/organisation.service.ts");
/* harmony import */ var src_app_core_services_user_service_user_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/core/services/user-service/user.service */ "./src/app/core/services/user-service/user.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var UserMiscInputComponent = /** @class */ (function () {
    function UserMiscInputComponent(userService, organisationService) {
        this.userService = userService;
        this.organisationService = organisationService;
        this.allRoles = [];
        this.allOrganisations = [];
        this.allRolesMultiSelect = [];
        this.allOrganisationsMultiSelect = [];
    }
    UserMiscInputComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.fetchRoles();
        this.fetchOrganisations();
        if (this.isUpdate) {
            this.miscForm.get('roles').valueChanges.subscribe(function (data) {
                if (data != null) {
                    _this.fetchRoles();
                }
            });
        }
        else {
            this.fetchRoles();
            this.fetchOrganisations();
        }
    };
    Object.defineProperty(UserMiscInputComponent.prototype, "firstName", {
        get: function () { return this.miscForm.get('firstName'); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(UserMiscInputComponent.prototype, "lastName", {
        get: function () { return this.miscForm.get('lastName'); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(UserMiscInputComponent.prototype, "email", {
        get: function () { return this.miscForm.get('email'); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(UserMiscInputComponent.prototype, "telephone", {
        get: function () { return this.miscForm.get('telephone'); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(UserMiscInputComponent.prototype, "roles", {
        get: function () { return this.miscForm.get('roles'); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(UserMiscInputComponent.prototype, "organisations", {
        get: function () { return this.miscForm.get('organisations'); },
        enumerable: true,
        configurable: true
    });
    UserMiscInputComponent.prototype.fetchRoles = function () {
        var _this = this;
        this._allRolesSubscription = this
            .userService
            .getRoles()
            .subscribe(function (roles) {
            _this.allRoles = [];
            _this.allRoles = roles;
            _this.pushRolesIntoMultiSelect();
        });
    };
    UserMiscInputComponent.prototype.fetchOrganisations = function () {
        var _this = this;
        this._allOrgsSubscription = this
            .organisationService
            ._allOrganisations
            .subscribe(function (organisations) {
            console.log(organisations);
            _this.allOrganisations = [];
            _this.allOrganisations = organisations;
            _this.pushOrganisationsIntoMultiSelect();
        });
    };
    UserMiscInputComponent.prototype.next = function () {
        console.log(this.miscForm);
    };
    UserMiscInputComponent.prototype.pushRolesIntoMultiSelect = function () {
        var _this = this;
        this.allRolesMultiSelect = [];
        this.allRoles.forEach(function (element) {
            console.log(element);
            _this.allRolesMultiSelect.push({ value: element, label: element });
        });
    };
    UserMiscInputComponent.prototype.pushOrganisationsIntoMultiSelect = function () {
        var _this = this;
        this.allOrganisationsMultiSelect = [];
        this.allOrganisations.forEach(function (organisation) {
            _this.allOrganisationsMultiSelect.push({ value: organisation.id, label: organisation.name });
        });
    };
    UserMiscInputComponent.prototype.ngOnDestroy = function () {
        this._allOrgsSubscription.unsubscribe();
        this._allRolesSubscription.unsubscribe();
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroup"])
    ], UserMiscInputComponent.prototype, "miscForm", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", Boolean)
    ], UserMiscInputComponent.prototype, "isUpdate", void 0);
    UserMiscInputComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-user-misc-input',
            template: __webpack_require__(/*! ./user-misc-input.component.html */ "./src/app/modules/user-managment/components/user-misc-input/user-misc-input.component.html"),
            styles: [__webpack_require__(/*! ./user-misc-input.component.scss */ "./src/app/modules/user-managment/components/user-misc-input/user-misc-input.component.scss")]
        }),
        __metadata("design:paramtypes", [src_app_core_services_user_service_user_service__WEBPACK_IMPORTED_MODULE_3__["UserService"],
            src_app_core_services_organisation_service_organisation_service__WEBPACK_IMPORTED_MODULE_2__["OrganisationService"]])
    ], UserMiscInputComponent);
    return UserMiscInputComponent;
}());



/***/ }),

/***/ "./src/app/modules/user-managment/components/user-preferences-input/user-preferences-input.component.html":
/*!****************************************************************************************************************!*\
  !*** ./src/app/modules/user-managment/components/user-preferences-input/user-preferences-input.component.html ***!
  \****************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<p>\r\n  user-preferences-input works!\r\n</p>\r\n"

/***/ }),

/***/ "./src/app/modules/user-managment/components/user-preferences-input/user-preferences-input.component.scss":
/*!****************************************************************************************************************!*\
  !*** ./src/app/modules/user-managment/components/user-preferences-input/user-preferences-input.component.scss ***!
  \****************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvdXNlci1tYW5hZ21lbnQvY29tcG9uZW50cy91c2VyLXByZWZlcmVuY2VzLWlucHV0L3VzZXItcHJlZmVyZW5jZXMtaW5wdXQuY29tcG9uZW50LnNjc3MifQ== */"

/***/ }),

/***/ "./src/app/modules/user-managment/components/user-preferences-input/user-preferences-input.component.ts":
/*!**************************************************************************************************************!*\
  !*** ./src/app/modules/user-managment/components/user-preferences-input/user-preferences-input.component.ts ***!
  \**************************************************************************************************************/
/*! exports provided: UserPreferencesInputComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "UserPreferencesInputComponent", function() { return UserPreferencesInputComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var UserPreferencesInputComponent = /** @class */ (function () {
    function UserPreferencesInputComponent() {
    }
    UserPreferencesInputComponent.prototype.ngOnInit = function () {
    };
    UserPreferencesInputComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-user-preferences-input',
            template: __webpack_require__(/*! ./user-preferences-input.component.html */ "./src/app/modules/user-managment/components/user-preferences-input/user-preferences-input.component.html"),
            styles: [__webpack_require__(/*! ./user-preferences-input.component.scss */ "./src/app/modules/user-managment/components/user-preferences-input/user-preferences-input.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], UserPreferencesInputComponent);
    return UserPreferencesInputComponent;
}());



/***/ }),

/***/ "./src/app/modules/user-managment/user-management-routing.module.ts":
/*!**************************************************************************!*\
  !*** ./src/app/modules/user-managment/user-management-routing.module.ts ***!
  \**************************************************************************/
/*! exports provided: UserManagementRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "UserManagementRoutingModule", function() { return UserManagementRoutingModule; });
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _components_add_update_user_wrapper_add_update_user_wrapper_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./components/add-update-user-wrapper/add-update-user-wrapper.component */ "./src/app/modules/user-managment/components/add-update-user-wrapper/add-update-user-wrapper.component.ts");
/* harmony import */ var _components_user_management_list_user_management_list_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./components/user-management-list/user-management-list.component */ "./src/app/modules/user-managment/components/user-management-list/user-management-list.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};




var routes = [
    {
        path: 'list',
        component: _components_user_management_list_user_management_list_component__WEBPACK_IMPORTED_MODULE_3__["UserManagementListComponent"]
    },
    {
        path: 'add',
        component: _components_add_update_user_wrapper_add_update_user_wrapper_component__WEBPACK_IMPORTED_MODULE_2__["AddUpdateUserWrapperComponent"]
    },
    {
        path: 'update/:id',
        component: _components_add_update_user_wrapper_add_update_user_wrapper_component__WEBPACK_IMPORTED_MODULE_2__["AddUpdateUserWrapperComponent"]
    }
];
var UserManagementRoutingModule = /** @class */ (function () {
    function UserManagementRoutingModule() {
    }
    UserManagementRoutingModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_0__["RouterModule"].forChild(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_0__["RouterModule"]]
        })
    ], UserManagementRoutingModule);
    return UserManagementRoutingModule;
}());



/***/ }),

/***/ "./src/app/modules/user-managment/user-managment.module.ts":
/*!*****************************************************************!*\
  !*** ./src/app/modules/user-managment/user-managment.module.ts ***!
  \*****************************************************************/
/*! exports provided: UserManagementModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "UserManagementModule", function() { return UserManagementModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ng-uikit-pro-standard */ "./node_modules/ng-uikit-pro-standard/esm5/ng-uikit-pro-standard.es5.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _user_management_routing_module__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./user-management-routing.module */ "./src/app/modules/user-managment/user-management-routing.module.ts");
/* harmony import */ var _components_add_update_user_wrapper_add_update_user_wrapper_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./components/add-update-user-wrapper/add-update-user-wrapper.component */ "./src/app/modules/user-managment/components/add-update-user-wrapper/add-update-user-wrapper.component.ts");
/* harmony import */ var _components_user_management_list_user_management_list_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./components/user-management-list/user-management-list.component */ "./src/app/modules/user-managment/components/user-management-list/user-management-list.component.ts");
/* harmony import */ var _components_user_misc_input_user_misc_input_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./components/user-misc-input/user-misc-input.component */ "./src/app/modules/user-managment/components/user-misc-input/user-misc-input.component.ts");
/* harmony import */ var _components_user_preferences_input_user_preferences_input_component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./components/user-preferences-input/user-preferences-input.component */ "./src/app/modules/user-managment/components/user-preferences-input/user-preferences-input.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};









var UserManagementModule = /** @class */ (function () {
    function UserManagementModule() {
    }
    UserManagementModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            declarations: [
                _components_user_management_list_user_management_list_component__WEBPACK_IMPORTED_MODULE_6__["UserManagementListComponent"],
                _components_add_update_user_wrapper_add_update_user_wrapper_component__WEBPACK_IMPORTED_MODULE_5__["AddUpdateUserWrapperComponent"],
                _components_user_misc_input_user_misc_input_component__WEBPACK_IMPORTED_MODULE_7__["UserMiscInputComponent"],
                _components_user_preferences_input_user_preferences_input_component__WEBPACK_IMPORTED_MODULE_8__["UserPreferencesInputComponent"]
            ],
            imports: [
                _angular_common__WEBPACK_IMPORTED_MODULE_1__["CommonModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormsModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_3__["ReactiveFormsModule"],
                _user_management_routing_module__WEBPACK_IMPORTED_MODULE_4__["UserManagementRoutingModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_2__["MaterialChipsModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_2__["InputsModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_2__["InputUtilitiesModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_2__["WavesModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_2__["ButtonsModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_2__["SelectModule"]
            ],
            exports: [
                _components_user_management_list_user_management_list_component__WEBPACK_IMPORTED_MODULE_6__["UserManagementListComponent"],
                _components_add_update_user_wrapper_add_update_user_wrapper_component__WEBPACK_IMPORTED_MODULE_5__["AddUpdateUserWrapperComponent"],
                _components_user_misc_input_user_misc_input_component__WEBPACK_IMPORTED_MODULE_7__["UserMiscInputComponent"],
                _components_user_preferences_input_user_preferences_input_component__WEBPACK_IMPORTED_MODULE_8__["UserPreferencesInputComponent"]
            ],
            schemas: [_angular_core__WEBPACK_IMPORTED_MODULE_0__["NO_ERRORS_SCHEMA"]],
            providers: [ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_2__["MDBSpinningPreloader"]]
        })
    ], UserManagementModule);
    return UserManagementModule;
}());



/***/ })

}]);
//# sourceMappingURL=src-app-modules-user-managment-user-managment-module.js.map