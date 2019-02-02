(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["src-app-modules-add-update-appointment-add-update-appointment-module"],{

/***/ "./src/app/modules/add-update-appointment/add-update-appointment-routing.module.ts":
/*!*****************************************************************************************!*\
  !*** ./src/app/modules/add-update-appointment/add-update-appointment-routing.module.ts ***!
  \*****************************************************************************************/
/*! exports provided: AddUpdateAppointmentRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AddUpdateAppointmentRoutingModule", function() { return AddUpdateAppointmentRoutingModule; });
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _components_update_appointment_wrapper_update_appointment_wrapper_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./components/update-appointment-wrapper/update-appointment-wrapper.component */ "./src/app/modules/add-update-appointment/components/update-appointment-wrapper/update-appointment-wrapper.component.ts");
/* harmony import */ var _components_add_appointment_wrapper_add_appointment_wrapper_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./components/add-appointment-wrapper/add-appointment-wrapper.component */ "./src/app/modules/add-update-appointment/components/add-appointment-wrapper/add-appointment-wrapper.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};




var routes = [
    {
        path: 'add',
        component: _components_add_appointment_wrapper_add_appointment_wrapper_component__WEBPACK_IMPORTED_MODULE_3__["AddAppointmentWrapperComponent"]
    }, {
        path: 'update',
        component: _components_update_appointment_wrapper_update_appointment_wrapper_component__WEBPACK_IMPORTED_MODULE_2__["UpdateAppointmentWrapperComponent"]
    }
];
var AddUpdateAppointmentRoutingModule = /** @class */ (function () {
    function AddUpdateAppointmentRoutingModule() {
    }
    AddUpdateAppointmentRoutingModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_0__["RouterModule"].forChild(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_0__["RouterModule"]]
        })
    ], AddUpdateAppointmentRoutingModule);
    return AddUpdateAppointmentRoutingModule;
}());



/***/ }),

/***/ "./src/app/modules/add-update-appointment/add-update-appointment.module.ts":
/*!*********************************************************************************!*\
  !*** ./src/app/modules/add-update-appointment/add-update-appointment.module.ts ***!
  \*********************************************************************************/
/*! exports provided: AddUpdateAppointmentModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AddUpdateAppointmentModule", function() { return AddUpdateAppointmentModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var _components_add_appointment_wrapper_add_appointment_wrapper_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./components/add-appointment-wrapper/add-appointment-wrapper.component */ "./src/app/modules/add-update-appointment/components/add-appointment-wrapper/add-appointment-wrapper.component.ts");
/* harmony import */ var _components_type_input_type_input_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./components/type-input/type-input.component */ "./src/app/modules/add-update-appointment/components/type-input/type-input.component.ts");
/* harmony import */ var _components_update_appointment_wrapper_update_appointment_wrapper_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./components/update-appointment-wrapper/update-appointment-wrapper.component */ "./src/app/modules/add-update-appointment/components/update-appointment-wrapper/update-appointment-wrapper.component.ts");
/* harmony import */ var _components_misc_input_misc_input_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./components/misc-input/misc-input.component */ "./src/app/modules/add-update-appointment/components/misc-input/misc-input.component.ts");
/* harmony import */ var _components_participant_input_participant_input_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./components/participant-input/participant-input.component */ "./src/app/modules/add-update-appointment/components/participant-input/participant-input.component.ts");
/* harmony import */ var _components_date_input_date_input_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./components/date-input/date-input.component */ "./src/app/modules/add-update-appointment/components/date-input/date-input.component.ts");
/* harmony import */ var _components_visibility_input_visibility_input_component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./components/visibility-input/visibility-input.component */ "./src/app/modules/add-update-appointment/components/visibility-input/visibility-input.component.ts");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ng-uikit-pro-standard */ "./node_modules/ng-uikit-pro-standard/esm5/ng-uikit-pro-standard.es5.js");
/* harmony import */ var _add_update_appointment_routing_module__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! ./add-update-appointment-routing.module */ "./src/app/modules/add-update-appointment/add-update-appointment-routing.module.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};












var AddUpdateAppointmentModule = /** @class */ (function () {
    function AddUpdateAppointmentModule() {
    }
    AddUpdateAppointmentModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            declarations: [
                _components_add_appointment_wrapper_add_appointment_wrapper_component__WEBPACK_IMPORTED_MODULE_2__["AddAppointmentWrapperComponent"],
                _components_type_input_type_input_component__WEBPACK_IMPORTED_MODULE_3__["TypeInputComponent"],
                _components_update_appointment_wrapper_update_appointment_wrapper_component__WEBPACK_IMPORTED_MODULE_4__["UpdateAppointmentWrapperComponent"],
                _components_misc_input_misc_input_component__WEBPACK_IMPORTED_MODULE_5__["MiscInputComponent"],
                _components_participant_input_participant_input_component__WEBPACK_IMPORTED_MODULE_6__["ParticipantInputComponent"],
                _components_date_input_date_input_component__WEBPACK_IMPORTED_MODULE_7__["DateInputComponent"],
                _components_visibility_input_visibility_input_component__WEBPACK_IMPORTED_MODULE_8__["VisibilityInputComponent"]
            ],
            imports: [
                _angular_common__WEBPACK_IMPORTED_MODULE_1__["CommonModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_9__["FormsModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_9__["ReactiveFormsModule"],
                _add_update_appointment_routing_module__WEBPACK_IMPORTED_MODULE_11__["AddUpdateAppointmentRoutingModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_10__["WavesModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_10__["ButtonsModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_10__["CollapseModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_10__["CheckboxModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_10__["DatepickerModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_10__["SelectModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_10__["TimePickerModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_10__["InputsModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_10__["InputUtilitiesModule"]
            ],
            exports: [
                _components_add_appointment_wrapper_add_appointment_wrapper_component__WEBPACK_IMPORTED_MODULE_2__["AddAppointmentWrapperComponent"],
                _components_type_input_type_input_component__WEBPACK_IMPORTED_MODULE_3__["TypeInputComponent"],
                _components_update_appointment_wrapper_update_appointment_wrapper_component__WEBPACK_IMPORTED_MODULE_4__["UpdateAppointmentWrapperComponent"],
                _components_misc_input_misc_input_component__WEBPACK_IMPORTED_MODULE_5__["MiscInputComponent"],
                _components_participant_input_participant_input_component__WEBPACK_IMPORTED_MODULE_6__["ParticipantInputComponent"],
                _components_date_input_date_input_component__WEBPACK_IMPORTED_MODULE_7__["DateInputComponent"],
                _components_visibility_input_visibility_input_component__WEBPACK_IMPORTED_MODULE_8__["VisibilityInputComponent"]
            ],
            schemas: [_angular_core__WEBPACK_IMPORTED_MODULE_0__["NO_ERRORS_SCHEMA"]],
            providers: [ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_10__["MDBSpinningPreloader"]]
        })
    ], AddUpdateAppointmentModule);
    return AddUpdateAppointmentModule;
}());



/***/ }),

/***/ "./src/app/modules/add-update-appointment/components/add-appointment-wrapper/add-appointment-wrapper.component.html":
/*!**************************************************************************************************************************!*\
  !*** ./src/app/modules/add-update-appointment/components/add-appointment-wrapper/add-appointment-wrapper.component.html ***!
  \**************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n            <!-- Vertical Steppers -->\r\n            <form [formGroup]=\"addForm\" (ngSubmit)=\"stepForward()\" >\r\n            <div class=\"row mt-1\">\r\n              <div class=\"col-md-12\">\r\n      \r\n                <!-- Stepers Wrapper -->\r\n                <ul class=\"stepper stepper-vertical\">\r\n                  \r\n      \r\n                  <!-- First Step -->\r\n                  <li [class.completed]=\"this.activeView > 0\" [class.active]=\"this.activeView === 0\" >\r\n                    <a>\r\n                      <span [class.completed-color]=\"this.activeView > 0\" class=\"circle\">1</span>\r\n                      <span class=\"label\">Typ</span>\r\n                    </a>\r\n                    <div *ngIf=\"this.views[0] === true\" class=\"step-content w-100\">\r\n                      <app-type-input [typeGroup]=\"addForm\" (typeEmitter)=\"getType($event)\"></app-type-input>\r\n                    </div>\r\n                  </li>\r\n      \r\n                  <!-- Second Step -->\r\n                  <li [class.completed]=\"this.activeView > 1\" [class.active]=\"this.activeView === 1\">\r\n      \r\n                    <!--Section Title -->\r\n                    <a>\r\n                      <span [class.completed-color]=\"this.activeView > 1\" class=\"circle\">2</span>\r\n                      <span class=\"label\">Titel</span>\r\n                    </a>\r\n      \r\n                    <!-- Section Description -->\r\n                    <div *ngIf=\"this.views[1] === true\" class=\"step-content w-100\">\r\n                          <app-misc-input [miscGroup]=\"addForm\"></app-misc-input>\r\n                      \r\n                    </div>\r\n                  </li>\r\n      \r\n                  <!-- Third Step -->\r\n                  <li [class.completed]=\"this.activeView > 2\" [class.active]=\"this.activeView === 2\">\r\n                    <a>\r\n                      <span [class.completed-color]=\"this.activeView > 2\" class=\"circle\">3</span>\r\n                      <span class=\"label\">Mitglieder</span>\r\n                    </a>\r\n                    <div *ngIf=\"this.views[2] === true\" class=\"step-content w-100\">\r\n                          <app-participant-input [allUsers]=\"this.allUsers\" [allOrganisations]=\"this.allOrganisations\" [participantGroup]=\"addForm\" [isShift]=\"this.isShift\"></app-participant-input>\r\n                    </div> \r\n                  </li>\r\n      \r\n                  <!-- Fourth Step -->\r\n                  <li [class.completed]=\"this.activeView > 3\" [class.active]=\"this.activeView === 3\">\r\n                    <a>\r\n                      <span [class.completed-color]=\"this.activeView > 3\" class=\"circle\">4</span>\r\n                      <span class=\"label\">Datum</span>\r\n                    </a>\r\n                    <div *ngIf=\"this.views[3] === true\" class=\"step-content w-100\">\r\n                        <app-date-input [isShift]=\"this.isShift\" [dateGroup]=\"addForm\"></app-date-input>\r\n                    </div>\r\n                  </li>\r\n                  <li [class.completed]=\"this.activeView > 4\" [class.active]=\"this.activeView === 4\">\r\n                      <a>\r\n                        <span [class.completed-color]=\"this.activeView > 4\" class=\"circle\">5</span>\r\n                        <span class=\"label\">Sichtbarkeit</span>\r\n                      </a>\r\n                      <div *ngIf=\"this.views[4] === true\" class=\"step-content w-100\">\r\n                              <app-visibility-input [visibilityGroup]=\"addForm\"></app-visibility-input>\r\n                      </div>\r\n                    </li>\r\n                  \r\n                </ul>\r\n                <!-- /.Stepers Wrapper -->\r\n      \r\n              </div>\r\n            </div>\r\n      \r\n            <!-- Steppers Navigation -->\r\n            <div class=\"row mt-1\">\r\n              <div class=\"col-md-12 text-right\">\r\n                <button class=\"btn btn-flat btn-md\" type=\"button\" (click)=\"stepBack()\">Zurück</button>\r\n                <button class=\"btn btn-color btn-md\" type=\"submit\">Vorwärts</button>\r\n              </div>\r\n            </div>\r\n          </form>\r\n            <!-- /.Vertical Steppers -->\r\n\r\n"

/***/ }),

/***/ "./src/app/modules/add-update-appointment/components/add-appointment-wrapper/add-appointment-wrapper.component.scss":
/*!**************************************************************************************************************************!*\
  !*** ./src/app/modules/add-update-appointment/components/add-appointment-wrapper/add-appointment-wrapper.component.scss ***!
  \**************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "ul.stepper li.completed a .circle {\n  background-color: #00C851 !important; }\n\nul.stepper li.active a .circle {\n  background-color: #e9241d !important; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9hZGQtdXBkYXRlLWFwcG9pbnRtZW50L2NvbXBvbmVudHMvYWRkLWFwcG9pbnRtZW50LXdyYXBwZXIvQzpcXFVzZXJzXFxjaHJpc1xcU291cmNlIENvZGVcXEdpdEh1YlxcYmZrLXBvcnRhbFxcYmZrLXBvcnRhbC1jbGllbnQvc3JjXFxhcHBcXG1vZHVsZXNcXGFkZC11cGRhdGUtYXBwb2ludG1lbnRcXGNvbXBvbmVudHNcXGFkZC1hcHBvaW50bWVudC13cmFwcGVyXFxhZGQtYXBwb2ludG1lbnQtd3JhcHBlci5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFDQTtFQUNJLHFDQUE2QyxFQUNoRDs7QUFDRDtFQUNJLHFDQUEyQyxFQUM5QyIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvYWRkLXVwZGF0ZS1hcHBvaW50bWVudC9jb21wb25lbnRzL2FkZC1hcHBvaW50bWVudC13cmFwcGVyL2FkZC1hcHBvaW50bWVudC13cmFwcGVyLmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsiQGltcG9ydCBcInNyYy92YXJpYWJsZXMuc2Nzc1wiO1xyXG51bC5zdGVwcGVyIGxpLmNvbXBsZXRlZCBhIC5jaXJjbGUge1xyXG4gICAgYmFja2dyb3VuZC1jb2xvcjogJGNvbXBsZXRlZF9jb2xvciAhaW1wb3J0YW50O1xyXG59XHJcbnVsLnN0ZXBwZXIgbGkuYWN0aXZlIGEgLmNpcmNsZSB7XHJcbiAgICBiYWNrZ3JvdW5kLWNvbG9yOiAkcHJpbWFyeV9jb2xvciAhaW1wb3J0YW50O1xyXG59XHJcbiJdfQ== */"

/***/ }),

/***/ "./src/app/modules/add-update-appointment/components/add-appointment-wrapper/add-appointment-wrapper.component.ts":
/*!************************************************************************************************************************!*\
  !*** ./src/app/modules/add-update-appointment/components/add-appointment-wrapper/add-appointment-wrapper.component.ts ***!
  \************************************************************************************************************************/
/*! exports provided: AddAppointmentWrapperComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AddAppointmentWrapperComponent", function() { return AddAppointmentWrapperComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ng-uikit-pro-standard */ "./node_modules/ng-uikit-pro-standard/esm5/ng-uikit-pro-standard.es5.js");
/* harmony import */ var moment__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! moment */ "./node_modules/moment/moment.js");
/* harmony import */ var moment__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(moment__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var src_app_core_services_appointment_service_appointment_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! src/app/core/services/appointment-service/appointment.service */ "./src/app/core/services/appointment-service/appointment.service.ts");
/* harmony import */ var src_app_core_services_session_user_service_session_user_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! src/app/core/services/session-user-service/session-user.service */ "./src/app/core/services/session-user-service/session-user.service.ts");
/* harmony import */ var src_app_shared_validation_customValidations__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! src/app/shared/validation/customValidations */ "./src/app/shared/validation/customValidations.ts");
/* harmony import */ var src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! src/app/shared/enums/static-strings */ "./src/app/shared/enums/static-strings.ts");
/* harmony import */ var src_app_shared_models_appointment__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! src/app/shared/models/appointment */ "./src/app/shared/models/appointment.ts");
/* harmony import */ var src_app_core_services_organisation_service_organisation_service__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! src/app/core/services/organisation-service/organisation.service */ "./src/app/core/services/organisation-service/organisation.service.ts");
/* harmony import */ var src_app_core_services_user_service_user_service__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! src/app/core/services/user-service/user.service */ "./src/app/core/services/user-service/user.service.ts");
/* harmony import */ var src_app_core_services_roles_service_roles_service__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! src/app/core/services/roles-service/roles.service */ "./src/app/core/services/roles-service/roles.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};













var AddAppointmentWrapperComponent = /** @class */ (function () {
    function AddAppointmentWrapperComponent(fb, toast, appointmentService, sessionUser, route, organisationService, userService, roleService) {
        this.fb = fb;
        this.toast = toast;
        this.appointmentService = appointmentService;
        this.sessionUser = sessionUser;
        this.route = route;
        this.organisationService = organisationService;
        this.userService = userService;
        this.roleService = roleService;
        this.allUsers = [];
        this.allOrganisations = [];
        this.activeView = 0;
        this.isShift = false;
        this.views = [
            true,
            false,
            false,
            false,
            false
        ];
        this.addForm = fb.group({
            'type': ['', [_angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required]],
            'title': ['', [_angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required, _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].maxLength(30)]],
            'description': ['', [_angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].maxLength(300)]],
            'participants': ['', [_angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required]],
            'areParticipantsOrgs': new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('', { validators: _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required, updateOn: 'change' }),
            'maxParticipants': [
                ' ',
                [_angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].max(60)]
            ],
            'deadLineString': [''],
            'endDateString': [
                '', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required
            ],
            'startDateString': [
                '', _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required
            ],
            'startTimeString': [
                '',
                [_angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required]
            ],
            'endTimeString': [
                '',
                [_angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].required]
            ],
            'isVisible': new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('', { updateOn: 'change' }),
            'participantsVisible': new _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormControl"]('', { updateOn: 'change' })
        }, {
            updateOn: 'submit', validators: _angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].compose([src_app_shared_validation_customValidations__WEBPACK_IMPORTED_MODULE_7__["participantsRequired"], src_app_shared_validation_customValidations__WEBPACK_IMPORTED_MODULE_7__["participantsVal"], src_app_shared_validation_customValidations__WEBPACK_IMPORTED_MODULE_7__["dateValidation"]])
        });
    }
    AddAppointmentWrapperComponent.prototype.ngOnInit = function () {
        var _this = this;
        if (this.roleService.isUserBfk) {
            this.addForm.setValidators(_angular_forms__WEBPACK_IMPORTED_MODULE_1__["Validators"].compose([src_app_shared_validation_customValidations__WEBPACK_IMPORTED_MODULE_7__["participantsRequired"], src_app_shared_validation_customValidations__WEBPACK_IMPORTED_MODULE_7__["participantsVal"], src_app_shared_validation_customValidations__WEBPACK_IMPORTED_MODULE_7__["dateValidation"], src_app_shared_validation_customValidations__WEBPACK_IMPORTED_MODULE_7__["appointmentTimeValidation"]]));
        }
        this.fetchOrgs();
        this.fetchUsers();
        this._routeSubscription = this.route.queryParams.subscribe(function (queryparams) {
            if (!!queryparams) {
                _this.addForm.patchValue({ startDateString: queryparams['date'] });
            }
        });
        this.addForm.patchValue({ isVisible: false, participantsVisible: false });
    };
    AddAppointmentWrapperComponent.prototype.fetchOrgs = function () {
        var _this = this;
        this._allOrgsSubscription = this.organisationService._allOrganisations.subscribe(function (orgs) {
            _this.allOrganisations = [];
            _this.allOrganisations = orgs;
        });
    };
    AddAppointmentWrapperComponent.prototype.fetchUsers = function () {
        var _this = this;
        this._allUsersSubscription = this.userService._allUsers.subscribe(function (users) {
            _this.allUsers = [];
            _this.allUsers = users;
        });
    };
    AddAppointmentWrapperComponent.prototype.getType = function (event) {
        if (event === src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_8__["AppointmentTypes"][src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_8__["AppointmentTypes"].Dienst] ||
            event === src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_8__["AppointmentTypes"][src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_8__["AppointmentTypes"].MarktplatzDienst] ||
            event === src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_8__["AppointmentTypes"][src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_8__["AppointmentTypes"].FreierDienst]) {
            this.isShift = true;
            this.addForm.patchValue({ areParticipantsOrgs: false, participants: [] });
        }
        else {
            this.isShift = false;
        }
    };
    AddAppointmentWrapperComponent.prototype.areParticipantsOrgsChangeEvent = function () {
        var _this = this;
        this._areParticipantsOrgsSubscription = this.addForm.get('areParticipantsOrgs').valueChanges.subscribe(function (data) {
            _this.addForm.patchValue({ participants: [] });
        });
    };
    AddAppointmentWrapperComponent.prototype.stepBack = function () {
        this.views[this.activeView] = false;
        this.activeView -= 1;
        this.views[this.activeView] = true;
    };
    AddAppointmentWrapperComponent.prototype.nextView = function () {
        this.views[this.activeView] = false;
        this.activeView += 1;
        this.views[this.activeView] = true;
    };
    AddAppointmentWrapperComponent.prototype.stepForward = function () {
        var _this = this;
        this.activeView = this.views.findIndex(function (val) { return val === true; });
        console.log(this.addForm);
        switch (this.activeView) {
            case 0:
                if (this.addForm.get('type').valid) {
                    this.addForm.get('description').reset();
                    this.nextView();
                }
                break;
            case 1:
                console.log(this.addForm);
                if (this.addForm.get('title').valid && this.addForm.get('description').valid) {
                    this.nextView();
                    this.areParticipantsOrgsChangeEvent();
                }
                break;
            case 2:
                console.log(this.addForm);
                if (this.addForm.get('participants').valid
                    && this.addForm.get('maxParticipants').valid
                    && this.addForm.get('areParticipantsOrgs').valid) {
                    this.nextView();
                }
                break;
            case 3:
                if (this.addForm.hasError('onlyNightShiftsDuringWeek')) {
                    this.toast.error('Zwischen Mo-Fr nur Nachtschichten zwischen 18-6 Uhr');
                }
                if (this.addForm.get('startTimeString').hasError('required') ||
                    this.addForm.get('endTimeString').hasError('required')) {
                    this
                        .toast
                        .error('StartZeit und EndZeit sind verpflichtend');
                }
                if (this.addForm.get('endDateString').valid
                    && this.addForm.get('startDateString').valid
                    && this.addForm.get('startTimeString').valid
                    && this.addForm.get('endTimeString').valid) {
                    this.nextView();
                }
                break;
            case 4:
                var copyParticipants_1 = [];
                if (this.addForm.get('areParticipantsOrgs').value === 1) {
                    this.addForm.get('participants').value.forEach(function (id) {
                        copyParticipants_1.push(_this.allOrganisations.find(function (org) { return org.id === id; }));
                    });
                    this.addForm.patchValue({ areParticipantsOrgs: true });
                }
                else {
                    this.addForm.get('participants').value.forEach(function (id) {
                        copyParticipants_1.push(_this.allUsers.find(function (user) { return user.id === id; }));
                    });
                    this.addForm.patchValue({ areParticipantsOrgs: false });
                }
                this.addForm.patchValue({ 'participants': copyParticipants_1 });
                var owner = this.sessionUser.getUser();
                var deadline = moment__WEBPACK_IMPORTED_MODULE_3__(this.addForm.get('deadLineString').value, 'DD.MM.YYYY').toDate();
                if (this.isShift) {
                    owner = this.addForm.get('participants').value[0];
                    this.addForm.patchValue({ participants: [] });
                    deadline = null;
                }
                // tslint:disable-next-line:max-line-length
                var startDate = moment__WEBPACK_IMPORTED_MODULE_3__(this.addForm.get('startDateString').value + ' ' + this.addForm.get('startTimeString').value, 'DD.MM.YYYY HH:mm').toDate();
                // tslint:disable-next-line:max-line-length
                var endDate = moment__WEBPACK_IMPORTED_MODULE_3__(this.addForm.get('endDateString').value + ' ' + this.addForm.get('endTimeString').value, 'DD.MM.YYYY HH:mm').toDate();
                var appointmentToAdd = new src_app_shared_models_appointment__WEBPACK_IMPORTED_MODULE_9__["Appointment"](99999, this.addForm.get('title').value, this.addForm.get('description').value, startDate, endDate, this.addForm.get('participants').value, this.addForm.get('maxParticipants').value, deadline, this.addForm.get('participantsVisible').value, owner, this.addForm.get('type').value, this.addForm.get('isVisible').value, this.addForm.get('areParticipantsOrgs').value);
                this.appointmentService._appointmentToAdd.next(appointmentToAdd);
                break;
            default:
                break;
        }
    };
    AddAppointmentWrapperComponent.prototype.ngOnDestroy = function () {
        this._routeSubscription.unsubscribe();
        this._allOrgsSubscription.unsubscribe();
        this._allUsersSubscription.unsubscribe();
        if (this._areParticipantsOrgsSubscription != null) {
            this._areParticipantsOrgsSubscription.unsubscribe();
        }
    };
    AddAppointmentWrapperComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-add-appointment-wrapper',
            template: __webpack_require__(/*! ./add-appointment-wrapper.component.html */ "./src/app/modules/add-update-appointment/components/add-appointment-wrapper/add-appointment-wrapper.component.html"),
            styles: [__webpack_require__(/*! ./add-appointment-wrapper.component.scss */ "./src/app/modules/add-update-appointment/components/add-appointment-wrapper/add-appointment-wrapper.component.scss")]
        }),
        __metadata("design:paramtypes", [_angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormBuilder"],
            ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_2__["ToastService"],
            src_app_core_services_appointment_service_appointment_service__WEBPACK_IMPORTED_MODULE_5__["AppointmentService"],
            src_app_core_services_session_user_service_session_user_service__WEBPACK_IMPORTED_MODULE_6__["SessionUserService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_4__["ActivatedRoute"],
            src_app_core_services_organisation_service_organisation_service__WEBPACK_IMPORTED_MODULE_10__["OrganisationService"],
            src_app_core_services_user_service_user_service__WEBPACK_IMPORTED_MODULE_11__["UserService"],
            src_app_core_services_roles_service_roles_service__WEBPACK_IMPORTED_MODULE_12__["RolesService"]])
    ], AddAppointmentWrapperComponent);
    return AddAppointmentWrapperComponent;
}());



/***/ }),

/***/ "./src/app/modules/add-update-appointment/components/date-input/date-input.component.html":
/*!************************************************************************************************!*\
  !*** ./src/app/modules/add-update-appointment/components/date-input/date-input.component.html ***!
  \************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div [formGroup]=\"dateGroup\" style=\"width: 95%\">\r\n    <div *ngIf=\"!this.isShift\" class=\"row\">\r\n        <span class=\"m-auto required-color\">*</span>\r\n      <div class=\"col md-form \">\r\n        <mdb-date-picker mdbValidate name=\"mydate \" [placeholder]=\" 'Deadline zum Eintragen'\" [options]=\"myDatePickerOptions\r\n                            \" formControlName=\"deadLineString\" ></mdb-date-picker>\r\n        <mdb-error *ngIf=\"deadLineString.invalid && (deadLineString.dirty || deadLineString.touched)\">\r\n          <span *ngIf=\"deadLineString.errors.deadLineTooBig\">Die Deadline ist zu Groß</span>\r\n          <span *ngIf=\"deadLineString.errors.deadlineNotValid\" >Deadline ist verpflichtend</span>\r\n        </mdb-error>\r\n      </div>\r\n    </div>\r\n    <div class=\"row \">\r\n        <span class=\"m-auto required-color\">*</span>\r\n      <div class=\"col md-form\">\r\n        <mdb-date-picker mdbValidate id=\"fromDate\" #fromDate (dateChanged)=\"fromDateInputFieldChanged($event)\" name=\"fromDate \" [options]=\"myDatePickerOptions\"\r\n        formControlName=\"startDateString\" [placeholder]=\"'(Datum) Von'\" required>\r\n    </mdb-date-picker>\r\n    <mdb-error *ngIf=\"startDateString.invalid && (startDateString.dirty || startDateString.touched)\">\r\n        <span *ngIf=\"startDateString.errors.required\" >Dieses Feld muss ausgefüllt werden</span>\r\n        <span *ngIf=\"startDateString.errors.noValidDate\">Kein richtiges Datum</span>\r\n        <span *ngIf=\"startDateString.errors.noHistoryAppointments\" >Keine Termine in der Vergangenheit</span>\r\n        <span *ngIf=\"startDateString.errors.tooBig\" >Zu große Start Zeit</span>\r\n      </mdb-error>\r\n      </div>\r\n      <span class=\"m-auto required-color\">*</span>\r\n      <div class=\"col md-form\">\r\n        <mdb-date-picker mdbValidate id=\"toDate\" #toDate name=\"toDate \" [placeholder]=\" '(Datum) Bis' \" [options]=\"myDatePickerOptions\r\n      \" formControlName=\"endDateString\" required></mdb-date-picker>\r\n      <mdb-error *ngIf=\"endDateString.invalid && (endDateString.dirty || endDateString.touched)\">\r\n          <span *ngIf=\"endDateString.errors.required\" >Dieses Feld muss ausgefüllt werden</span>\r\n          <span *ngIf=\"endDateString.errors.noValidDate\">Kein richtiges Datum</span>\r\n        </mdb-error>\r\n      </div>\r\n    </div>\r\n    <div class=\"row \">\r\n        <span class=\"m-auto required-color\">*</span>\r\n      <div class=\"col md-form\">\r\n        <mdb-time-picker #fromTime  [buttonLabel]=\" 'Fertig' \" [twelvehour]=\"false \" [darktheme]=\"false \" [placeholder]=\"\r\n      '(Zeit) Von' \" [label]=\" '24 Stunden' \" formControlName=\"startTimeString\" required></mdb-time-picker>\r\n      </div>\r\n      <span class=\"m-auto required-color\">*</span>\r\n      <div class=\"col md-form\">\r\n        <mdb-time-picker [buttonLabel]=\" 'Fertig' \" [twelvehour]=\"false \" [darktheme]=\"false \" [placeholder]=\"\r\n      '(Zeit) Bis' \" [label]=\" '24 Stunden' \" formControlName=\"endTimeString\" required></mdb-time-picker>\r\n      </div>\r\n    </div>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/modules/add-update-appointment/components/date-input/date-input.component.scss":
/*!************************************************************************************************!*\
  !*** ./src/app/modules/add-update-appointment/components/date-input/date-input.component.scss ***!
  \************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvYWRkLXVwZGF0ZS1hcHBvaW50bWVudC9jb21wb25lbnRzL2RhdGUtaW5wdXQvZGF0ZS1pbnB1dC5jb21wb25lbnQuc2NzcyJ9 */"

/***/ }),

/***/ "./src/app/modules/add-update-appointment/components/date-input/date-input.component.ts":
/*!**********************************************************************************************!*\
  !*** ./src/app/modules/add-update-appointment/components/date-input/date-input.component.ts ***!
  \**********************************************************************************************/
/*! exports provided: DateInputComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DateInputComponent", function() { return DateInputComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ng-uikit-pro-standard */ "./node_modules/ng-uikit-pro-standard/esm5/ng-uikit-pro-standard.es5.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var DateInputComponent = /** @class */ (function () {
    function DateInputComponent(changeDetector) {
        this.changeDetector = changeDetector;
        this.myDatePickerOptions = {
            closeAfterSelect: true,
            // Strings and translations
            dayLabels: {
                su: 'Son',
                mo: 'Mon',
                tu: 'Die',
                we: 'Mit',
                th: 'Don',
                fr: 'Fre',
                sa: 'Sam'
            },
            dayLabelsFull: {
                su: 'Sonntag',
                mo: 'Montag',
                tu: 'Dienstag',
                we: 'Mittwoch',
                th: 'Donnerstag',
                fr: 'Freitag',
                sa: 'Samstag'
            },
            monthLabels: {
                1: 'Jan',
                2: 'Feb',
                3: 'Mär',
                4: 'Apr',
                5: 'Mai',
                6: 'Jun',
                7: 'Jul',
                8: 'Aug',
                9: 'Sep',
                10: 'Okt',
                11: 'Nov',
                12: 'Dez'
            },
            monthLabelsFull: {
                1: 'Januar',
                2: 'Februar',
                3: 'März',
                4: 'April',
                5: 'Mai',
                6: 'Juni',
                7: 'Juli',
                8: 'August',
                9: 'September',
                10: 'Oktober',
                11: 'November',
                12: 'Dezember'
            },
            // Buttons
            todayBtnTxt: 'Heute',
            clearBtnTxt: 'Löschen',
            closeBtnTxt: 'Schliessen',
            // Format
            dateFormat: 'dd.mm.yyyy',
            // First day of the week
            firstDayOfWeek: 'mo',
            // Disable dates
            disableWeekends: false,
            // Enable dates (when disabled) Year limits
            minYear: 1000,
            maxYear: 9999,
            // Show Today button
            showTodayBtn: true,
            // Show Clear date button
            showClearDateBtn: true,
        };
    }
    DateInputComponent.prototype.ngOnInit = function () {
    };
    DateInputComponent.prototype.ngAfterViewInit = function () {
        console.log(this.toDate);
    };
    Object.defineProperty(DateInputComponent.prototype, "deadLineString", {
        get: function () { return this.dateGroup.get('deadLineString'); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DateInputComponent.prototype, "endDateString", {
        get: function () { return this.dateGroup.get('endDateString'); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DateInputComponent.prototype, "startDateString", {
        get: function () { return this.dateGroup.get('startDateString'); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DateInputComponent.prototype, "startTimeString", {
        get: function () { return this.dateGroup.get('startTimeString'); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DateInputComponent.prototype, "endTimeString", {
        get: function () { return this.dateGroup.get('endTimeString'); },
        enumerable: true,
        configurable: true
    });
    DateInputComponent.prototype.fromDateInputFieldChanged = function (e) {
        console.log(e);
        this.changeDetector.detectChanges();
        console.log(this.toDate);
        this.toDate.openBtnClicked();
        console.log(this.dateGroup);
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", Boolean)
    ], DateInputComponent.prototype, "isShift", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroup"])
    ], DateInputComponent.prototype, "dateGroup", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ViewChild"])('toDate'),
        __metadata("design:type", ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_2__["MDBDatePickerComponent"])
    ], DateInputComponent.prototype, "toDate", void 0);
    DateInputComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-date-input',
            template: __webpack_require__(/*! ./date-input.component.html */ "./src/app/modules/add-update-appointment/components/date-input/date-input.component.html"),
            styles: [__webpack_require__(/*! ./date-input.component.scss */ "./src/app/modules/add-update-appointment/components/date-input/date-input.component.scss")]
        }),
        __metadata("design:paramtypes", [_angular_core__WEBPACK_IMPORTED_MODULE_0__["ChangeDetectorRef"]])
    ], DateInputComponent);
    return DateInputComponent;
}());



/***/ }),

/***/ "./src/app/modules/add-update-appointment/components/misc-input/misc-input.component.html":
/*!************************************************************************************************!*\
  !*** ./src/app/modules/add-update-appointment/components/misc-input/misc-input.component.html ***!
  \************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div [formGroup]=\"miscGroup\" style=\"width: 90%\">\r\n    <div class=\"row\" >\r\n        <span class=\"m-auto required-color\">*</span>\r\n        <div class=\"md-form col\">\r\n            <input mdbInput mdbValidate type=\"text\" id=\"form2\" class=\"form-control\" formControlName=\"title\">\r\n            <label for=\"form2\">Überschrift</label>\r\n            <mdb-error *ngIf=\"title.invalid && (title.dirty || title.touched)\">\r\n              <span *ngIf=\"title.errors.required\">Titel wird benötigt</span>\r\n              <span *ngIf=\"title.errors.maxlength\">Zuviele Zeichen</span>\r\n            </mdb-error>\r\n          </div>\r\n      \r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"md-form col\">\r\n            <textarea mdbInput mdbValidate type=\"text \" id=\"form7 \" class=\"md-textarea form-control \" mdbCharCounter\r\n              length=\"300 \" rows=\"3\" formControlName=\"description\" ></textarea>\r\n            <label for=\"form7 \">Beschreibung</label>\r\n            <mdb-error *ngIf=\"description.invalid && (description.dirty || description.touched)\">\r\n                <span *ngIf=\"description.errors.maxlength\">Zuviele Zeichen</span>\r\n            </mdb-error>\r\n            <mdb-success *ngIf=\"description.valid && (description.dirty || description.touched)\">\r\n            </mdb-success>\r\n          </div>\r\n    </div>\r\n</div>\r\n\r\n"

/***/ }),

/***/ "./src/app/modules/add-update-appointment/components/misc-input/misc-input.component.scss":
/*!************************************************************************************************!*\
  !*** ./src/app/modules/add-update-appointment/components/misc-input/misc-input.component.scss ***!
  \************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".md-form .prefix {\n  font-size: 1.5rem;\n  margin-top: 1rem; }\n\n.md-form label.active {\n  color: #e9241d !important; }\n\n.form-control:focus {\n  border-bottom: 1px solid #d7ccc8 !important;\n  box-shadow: 0 1px 0 0 #d7ccc8 !important; }\n\n.md-form input[type=\"text\"]:focus {\n  border-bottom: 1px solid #d7ccc8 !important;\n  box-shadow: 0 1px 0 0 #d7ccc8 !important; }\n\n.md-form label {\n  padding-left: 14px; }\n\ntextarea:focus ~ .chars {\n  margin-right: 5% !important; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9hZGQtdXBkYXRlLWFwcG9pbnRtZW50L2NvbXBvbmVudHMvbWlzYy1pbnB1dC9DOlxcVXNlcnNcXGNocmlzXFxTb3VyY2UgQ29kZVxcR2l0SHViXFxiZmstcG9ydGFsXFxiZmstcG9ydGFsLWNsaWVudC9zcmNcXGFwcFxcbW9kdWxlc1xcYWRkLXVwZGF0ZS1hcHBvaW50bWVudFxcY29tcG9uZW50c1xcbWlzYy1pbnB1dFxcbWlzYy1pbnB1dC5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFDQTtFQUNJLGtCQUFpQjtFQUNqQixpQkFBZ0IsRUFDbkI7O0FBQ0Q7RUFDSSwwQkFBZ0MsRUFDbkM7O0FBQ0Q7RUFDSSw0Q0FBdUQ7RUFDdkQseUNBQW9ELEVBQ3ZEOztBQUNEO0VBQ0ksNENBQXVEO0VBQ3ZELHlDQUFvRCxFQUN2RDs7QUFDRDtFQUNJLG1CQUFrQixFQUNyQjs7QUFDRDtFQUNJLDRCQUEyQixFQUM5QiIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvYWRkLXVwZGF0ZS1hcHBvaW50bWVudC9jb21wb25lbnRzL21pc2MtaW5wdXQvbWlzYy1pbnB1dC5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIkBpbXBvcnQgXCJzcmMvdmFyaWFibGVzLnNjc3NcIjtcclxuLm1kLWZvcm0gLnByZWZpeCB7XHJcbiAgICBmb250LXNpemU6IDEuNXJlbTtcclxuICAgIG1hcmdpbi10b3A6IDFyZW07XHJcbn1cclxuLm1kLWZvcm0gbGFiZWwuYWN0aXZlIHtcclxuICAgIGNvbG9yOiAkcHJpbWFyeV9jb2xvciAhaW1wb3J0YW50O1xyXG59XHJcbi5mb3JtLWNvbnRyb2w6Zm9jdXMge1xyXG4gICAgYm9yZGVyLWJvdHRvbTogMXB4IHNvbGlkICRmb3JtX2NvbnRyb2xfZm9jdXMgIWltcG9ydGFudDtcclxuICAgIGJveC1zaGFkb3c6IDAgMXB4IDAgMCAkZm9ybV9jb250cm9sX2ZvY3VzICFpbXBvcnRhbnQ7XHJcbn1cclxuLm1kLWZvcm0gaW5wdXRbdHlwZT1cInRleHRcIl06Zm9jdXMge1xyXG4gICAgYm9yZGVyLWJvdHRvbTogMXB4IHNvbGlkICRmb3JtX2NvbnRyb2xfZm9jdXMgIWltcG9ydGFudDtcclxuICAgIGJveC1zaGFkb3c6IDAgMXB4IDAgMCAkZm9ybV9jb250cm9sX2ZvY3VzICFpbXBvcnRhbnQ7XHJcbn1cclxuLm1kLWZvcm0gbGFiZWwge1xyXG4gICAgcGFkZGluZy1sZWZ0OiAxNHB4O1xyXG59XHJcbnRleHRhcmVhOmZvY3VzIH4gLmNoYXJze1xyXG4gICAgbWFyZ2luLXJpZ2h0OiA1JSAhaW1wb3J0YW50O1xyXG59XHJcbiJdfQ== */"

/***/ }),

/***/ "./src/app/modules/add-update-appointment/components/misc-input/misc-input.component.ts":
/*!**********************************************************************************************!*\
  !*** ./src/app/modules/add-update-appointment/components/misc-input/misc-input.component.ts ***!
  \**********************************************************************************************/
/*! exports provided: MiscInputComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "MiscInputComponent", function() { return MiscInputComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var MiscInputComponent = /** @class */ (function () {
    function MiscInputComponent() {
    }
    MiscInputComponent.prototype.ngOnInit = function () {
    };
    MiscInputComponent.prototype.ngOnChanges = function (changes) {
        if (!!changes['miscGroup']) {
            this.miscGroup = changes['miscGroup'].currentValue;
        }
    };
    Object.defineProperty(MiscInputComponent.prototype, "title", {
        get: function () { return this.miscGroup.get('title'); },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(MiscInputComponent.prototype, "description", {
        get: function () { return this.miscGroup.get('description'); },
        enumerable: true,
        configurable: true
    });
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroup"])
    ], MiscInputComponent.prototype, "miscGroup", void 0);
    MiscInputComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-misc-input',
            template: __webpack_require__(/*! ./misc-input.component.html */ "./src/app/modules/add-update-appointment/components/misc-input/misc-input.component.html"),
            styles: [__webpack_require__(/*! ./misc-input.component.scss */ "./src/app/modules/add-update-appointment/components/misc-input/misc-input.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], MiscInputComponent);
    return MiscInputComponent;
}());



/***/ }),

/***/ "./src/app/modules/add-update-appointment/components/participant-input/participant-input.component.html":
/*!**************************************************************************************************************!*\
  !*** ./src/app/modules/add-update-appointment/components/participant-input/participant-input.component.html ***!
  \**************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div [formGroup]=\"participantGroup\" style=\"width: 90%\">\r\n    <div *ngIf=\"!isShift\" class=\"row mt-3\">\r\n        <span class=\"m-auto required-color\">*</span>\r\n        <div class=\"col\">\r\n          <mdb-select mdbValidate [highlightFirst]=\"false\" formControlName=\"areParticipantsOrgs\"  #optionSelect (selected)=\"selectedOption($event)\" [options]=\"participantOptions\"></mdb-select>\r\n          <label class=\"label-color\">Art der Teilnehmer auswählen </label>\r\n          <mdb-error *ngIf=\"areParticipantsOrgs.invalid && (areParticipantsOrgs.dirty || areParticipantsOrgs.touched)\" >\r\n              <span *ngIf=\"areParticipantsOrgs.errors.required\">Die Art der Teilnehmer muss ausgewählt werden</span>\r\n          </mdb-error>\r\n        </div>\r\n      </div>\r\n      <div *ngIf=\"showUser\" class=\"row mt-5\">\r\n      <div class=\" col\">\r\n        <mdb-select mdbValidate [highlightFirst]=\"false\" id=\"userSelect\" #userSelect formControlName=\"participants\" [options]=\"allUsersMultiSelect\"\r\n          [multiple]=\"this.isShift ? false : true\" class=\"colorful-select  dropdown-primary\"></mdb-select>\r\n        <label for=\"userSelect\" class=\"label-color\">Teilnehmer auswählen</label>\r\n        <mdb-error *ngIf=\"participants.invalid && (participants.dirty || participants.touched)\" >\r\n            <span *ngIf=\"participants.errors.required\">Es müssen Teilnehmer ausgewählt werden</span>\r\n            <span *ngIf=\"participantsGroup.errors.participantsRequired\">Es müssen Teilnehmer ausgewählt werden</span>\r\n        </mdb-error>\r\n      </div>\r\n      \r\n      \r\n      </div>\r\n      <div *ngIf=\"showOrganisation\" class=\"row  mt-5\">\r\n      <div class=\" col\">\r\n        <mdb-select mdbValidate [highlightFirst]=\"false\" id=\"organsiationSelect\" formControlName=\"participants\" #organisationSelect [options]=\"allOrganisationsMultiSelect\"\r\n          [multiple]=\"true\" class=\"colorful-select  dropdown-primary\"></mdb-select>\r\n        <label for=\"organisationSelect\" class=\"label-color\">Teilnehmer auswählen</label>\r\n        <mdb-error *ngIf=\"participants.invalid && (participants.dirty || participants.touched)\" >\r\n            <span *ngIf=\"participants.errors.required\">Es müssen Organisationen ausgewählt werden</span> \r\n        </mdb-error>\r\n      </div>\r\n    </div>\r\n      <div *ngIf=\"!this.isShift\" class=\"row mt-1\">\r\n        <span class=\"m-auto required-color\">*</span>  \r\n        <div class=\"md-form col\">\r\n            <input mdbValidate mdbInput style=\"margin-bottom: 0px\" type=\"number\" formControlName=\"maxParticipants\" class=\"form-control \" id=\"numberInputEx \">\r\n            <label for=\"numberInputEx \">Maximale Teilnehmer</label>\r\n            <mdb-error *ngIf=\"maxParticipants.invalid && (maxParticipants.dirty || maxParticipants.touched)\" >\r\n              <span *ngIf=\"maxParticipants.errors.max\">Zuviele Teilnehmer</span>\r\n              <span *ngIf=\"participantGroup.errors.tooMuchParticipants\"> Anzahl der möglichen Teilnehmer erhöhen</span>\r\n            </mdb-error>\r\n          </div>\r\n\r\n\r\n</div>\r\n\r\n\r\n\r\n"

/***/ }),

/***/ "./src/app/modules/add-update-appointment/components/participant-input/participant-input.component.scss":
/*!**************************************************************************************************************!*\
  !*** ./src/app/modules/add-update-appointment/components/participant-input/participant-input.component.scss ***!
  \**************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".md-form .prefix {\n  font-size: 1.5rem;\n  margin-top: 1rem; }\n\n.md-form label.active {\n  color: #e9241d !important; }\n\n.form-control:focus {\n  border-bottom: 1px solid #d7ccc8 !important;\n  box-shadow: 0 1px 0 0 #d7ccc8 !important; }\n\n.md-form input[type=\"text\"]:focus {\n  border-bottom: 1px solid #d7ccc8 !important;\n  box-shadow: 0 1px 0 0 #d7ccc8 !important; }\n\n.md-form label {\n  padding-left: 14px; }\n\n.dropdown .dropdown-menu .dropdown-item:hover,\n.dropdown .dropdown-menu .dropdown-item:active {\n  background-color: white !important;\n  color: #e9241d !important; }\n\nmdb-select + label {\n  position: absolute !important;\n  font-size: 0.8rem !important;\n  left: 15px !important; }\n\n.menu-color {\n  color: #e9241d !important; }\n\n.dropdown-menu {\n  background-color: #e9241d !important;\n  color: white !important; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9hZGQtdXBkYXRlLWFwcG9pbnRtZW50L2NvbXBvbmVudHMvcGFydGljaXBhbnQtaW5wdXQvQzpcXFVzZXJzXFxjaHJpc1xcU291cmNlIENvZGVcXEdpdEh1YlxcYmZrLXBvcnRhbFxcYmZrLXBvcnRhbC1jbGllbnQvc3JjXFxhcHBcXG1vZHVsZXNcXGFkZC11cGRhdGUtYXBwb2ludG1lbnRcXGNvbXBvbmVudHNcXHBhcnRpY2lwYW50LWlucHV0XFxwYXJ0aWNpcGFudC1pbnB1dC5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFDQTtFQUNJLGtCQUFpQjtFQUNqQixpQkFBZ0IsRUFDbkI7O0FBQ0Q7RUFDSSwwQkFBZ0MsRUFDbkM7O0FBQ0Q7RUFDSSw0Q0FBdUQ7RUFDdkQseUNBQW9ELEVBQ3ZEOztBQUNEO0VBQ0ksNENBQXVEO0VBQ3ZELHlDQUFvRCxFQUN2RDs7QUFDRDtFQUNJLG1CQUFrQixFQUNyQjs7QUFDRDs7RUFFRSxtQ0FBZ0Q7RUFDaEQsMEJBQWdDLEVBQ2pDOztBQUNEO0VBQ0ksOEJBQTZCO0VBQzdCLDZCQUE0QjtFQUM1QixzQkFBcUIsRUFDeEI7O0FBQ0Q7RUFDSSwwQkFBZ0MsRUFDakM7O0FBQ0g7RUFDSSxxQ0FBMkM7RUFDM0Msd0JBQXFDLEVBQ3hDIiwiZmlsZSI6InNyYy9hcHAvbW9kdWxlcy9hZGQtdXBkYXRlLWFwcG9pbnRtZW50L2NvbXBvbmVudHMvcGFydGljaXBhbnQtaW5wdXQvcGFydGljaXBhbnQtaW5wdXQuY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyJAaW1wb3J0IFwic3JjL3ZhcmlhYmxlcy5zY3NzXCI7XHJcbi5tZC1mb3JtIC5wcmVmaXgge1xyXG4gICAgZm9udC1zaXplOiAxLjVyZW07XHJcbiAgICBtYXJnaW4tdG9wOiAxcmVtO1xyXG59XHJcbi5tZC1mb3JtIGxhYmVsLmFjdGl2ZSB7XHJcbiAgICBjb2xvcjogJHByaW1hcnlfY29sb3IgIWltcG9ydGFudDtcclxufVxyXG4uZm9ybS1jb250cm9sOmZvY3VzIHtcclxuICAgIGJvcmRlci1ib3R0b206IDFweCBzb2xpZCAkZm9ybV9jb250cm9sX2ZvY3VzICFpbXBvcnRhbnQ7XHJcbiAgICBib3gtc2hhZG93OiAwIDFweCAwIDAgJGZvcm1fY29udHJvbF9mb2N1cyAhaW1wb3J0YW50O1xyXG59XHJcbi5tZC1mb3JtIGlucHV0W3R5cGU9XCJ0ZXh0XCJdOmZvY3VzIHtcclxuICAgIGJvcmRlci1ib3R0b206IDFweCBzb2xpZCAkZm9ybV9jb250cm9sX2ZvY3VzICFpbXBvcnRhbnQ7XHJcbiAgICBib3gtc2hhZG93OiAwIDFweCAwIDAgJGZvcm1fY29udHJvbF9mb2N1cyAhaW1wb3J0YW50O1xyXG59XHJcbi5tZC1mb3JtIGxhYmVsIHtcclxuICAgIHBhZGRpbmctbGVmdDogMTRweDtcclxufVxyXG4uZHJvcGRvd24gLmRyb3Bkb3duLW1lbnUgLmRyb3Bkb3duLWl0ZW06aG92ZXIsXHJcbi5kcm9wZG93biAuZHJvcGRvd24tbWVudSAuZHJvcGRvd24taXRlbTphY3RpdmUge1xyXG4gIGJhY2tncm91bmQtY29sb3I6ICRhY2NlbnRfY29sb3Jfd2hpdGUgIWltcG9ydGFudDtcclxuICBjb2xvcjogJHByaW1hcnlfY29sb3IgIWltcG9ydGFudDtcclxufVxyXG5tZGItc2VsZWN0ICsgbGFiZWwge1xyXG4gICAgcG9zaXRpb246IGFic29sdXRlICFpbXBvcnRhbnQ7XHJcbiAgICBmb250LXNpemU6IDAuOHJlbSAhaW1wb3J0YW50O1xyXG4gICAgbGVmdDogMTVweCAhaW1wb3J0YW50O1xyXG59XHJcbi5tZW51LWNvbG9yIHtcclxuICAgIGNvbG9yOiAkcHJpbWFyeV9jb2xvciAhaW1wb3J0YW50O1xyXG4gIH1cclxuLmRyb3Bkb3duLW1lbnUge1xyXG4gICAgYmFja2dyb3VuZC1jb2xvcjogJHByaW1hcnlfY29sb3IgIWltcG9ydGFudDtcclxuICAgIGNvbG9yOiAkYWNjZW50X2NvbG9yX3doaXRlICFpbXBvcnRhbnQ7XHJcbn1cclxuIl19 */"

/***/ }),

/***/ "./src/app/modules/add-update-appointment/components/participant-input/participant-input.component.ts":
/*!************************************************************************************************************!*\
  !*** ./src/app/modules/add-update-appointment/components/participant-input/participant-input.component.ts ***!
  \************************************************************************************************************/
/*! exports provided: ParticipantInputComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParticipantInputComponent", function() { return ParticipantInputComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! lodash */ "./node_modules/lodash/lodash.js");
/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(lodash__WEBPACK_IMPORTED_MODULE_2__);
/* harmony import */ var ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ng-uikit-pro-standard */ "./node_modules/ng-uikit-pro-standard/esm5/ng-uikit-pro-standard.es5.js");
/* harmony import */ var src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! src/app/shared/enums/static-strings */ "./src/app/shared/enums/static-strings.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





var ParticipantInputComponent = /** @class */ (function () {
    function ParticipantInputComponent(changeDetector) {
        this.changeDetector = changeDetector;
        this.participantsAreOrgs = new _angular_core__WEBPACK_IMPORTED_MODULE_0__["EventEmitter"]();
        this.showOrganisation = false;
        this.showUser = false;
        this.allUsersMultiSelect = [];
        this.allOrganisationsMultiSelect = [];
        this.participantOptions = [
            {
                value: 1,
                label: 'Organisationen'
            }, {
                value: 2,
                label: 'Mitglieder'
            }
        ];
    }
    ParticipantInputComponent.prototype.ngOnInit = function () {
        if (this.isShift) {
            this.participantGroup.patchValue({ maxParticipants: 1 });
            this.showUser = true;
            console.log(this.allUsers);
            this.pushUsersToMultiSelect();
        }
    };
    ParticipantInputComponent.prototype.ngAfterViewInit = function () {
    };
    ParticipantInputComponent.prototype.ngOnChanges = function (changes) {
        if (!!changes['allUsers']) {
            this.allUsers = changes['allUsers'].currentValue;
            if (this.showUser) {
                this.pushUsersToMultiSelect();
            }
        }
        if (!!changes['allOrganisations']) {
            console.log(this.participantGroup.value);
            console.log(this.participantGroup.get('participants').value);
            this.allOrganisations = changes['allOrganisations'].currentValue;
            if (this.showOrganisation) {
                this.pushOrganisationToMultiSelect();
            }
        }
        if (!!changes['participantGroup']) {
            this.participantGroup = changes['participantGroup'].currentValue;
            console.log(this.participantGroup.value);
            if (this.participantGroup.get('areParticipantsOrgs').value === 1) {
                this.selectedOption(this.participantOptions[0]);
            }
            else if (this.participantGroup.get('areParticipantsOrgs').value === 2) {
                this.selectedOption(this.participantOptions[1]);
            }
        }
    };
    Object.defineProperty(ParticipantInputComponent.prototype, "maxParticipants", {
        get: function () {
            return this.participantGroup.get('maxParticipants');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ParticipantInputComponent.prototype, "participants", {
        get: function () {
            return this.participantGroup.get('participants');
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ParticipantInputComponent.prototype, "areParticipantsOrgs", {
        get: function () { return this.participantGroup.get('areParticipantsOrgs'); },
        enumerable: true,
        configurable: true
    });
    ParticipantInputComponent.prototype.selectedOption = function (e) {
        if (e.label === 'Organisationen') {
            this.pushOrganisationToMultiSelect();
            this.showOrganisation = true;
            this.showUser = false;
        }
        else if (e.label === 'Mitglieder') {
            this.pushUsersToMultiSelect();
            this.showOrganisation = false;
            this.showUser = true;
        }
    };
    ParticipantInputComponent.prototype.pushOrganisationToMultiSelect = function () {
        var _this = this;
        this.allOrganisationsMultiSelect = [];
        this
            .allOrganisations
            .forEach(function (organisation) {
            _this
                .allOrganisationsMultiSelect
                .push({ value: organisation.id, label: organisation.name });
        });
    };
    ParticipantInputComponent.prototype.pushUsersToMultiSelect = function () {
        var _this = this;
        this.allUsersMultiSelect = [];
        this
            .allUsers
            .forEach(function (user) {
            if (_this.isShift) {
                if (lodash__WEBPACK_IMPORTED_MODULE_2__["includes"](user.entitlements, src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_4__["Roles"][src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_4__["Roles"].UserBwst]) || lodash__WEBPACK_IMPORTED_MODULE_2__["includes"](user.entitlements, src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_4__["Roles"][src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_4__["Roles"].AdminBwst])) {
                    _this
                        .allUsersMultiSelect
                        .push({
                        value: user.id,
                        label: user.firstname + ' ' + user.lastname,
                    });
                }
            }
            else {
                _this
                    .allUsersMultiSelect
                    .push({
                    value: user.id,
                    label: user.firstname + ' ' + user.lastname
                });
            }
        });
        console.log(this.allUsersMultiSelect);
        this.showUser = true;
    };
    ParticipantInputComponent.prototype.ngOnDestroy = function () {
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", Boolean)
    ], ParticipantInputComponent.prototype, "isShift", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroup"])
    ], ParticipantInputComponent.prototype, "participantGroup", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Output"])(),
        __metadata("design:type", Object)
    ], ParticipantInputComponent.prototype, "participantsAreOrgs", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", Array)
    ], ParticipantInputComponent.prototype, "allUsers", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", Array)
    ], ParticipantInputComponent.prototype, "allOrganisations", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ViewChild"])('optionSelect'),
        __metadata("design:type", ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_3__["SelectComponent"])
    ], ParticipantInputComponent.prototype, "optionSelect", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ViewChild"])('userSelect'),
        __metadata("design:type", ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_3__["SelectComponent"])
    ], ParticipantInputComponent.prototype, "userSelect", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ViewChild"])('organisationSelect'),
        __metadata("design:type", ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_3__["SelectComponent"])
    ], ParticipantInputComponent.prototype, "organisationSelect", void 0);
    ParticipantInputComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-participant-input',
            template: __webpack_require__(/*! ./participant-input.component.html */ "./src/app/modules/add-update-appointment/components/participant-input/participant-input.component.html"),
            styles: [__webpack_require__(/*! ./participant-input.component.scss */ "./src/app/modules/add-update-appointment/components/participant-input/participant-input.component.scss")]
        }),
        __metadata("design:paramtypes", [_angular_core__WEBPACK_IMPORTED_MODULE_0__["ChangeDetectorRef"]])
    ], ParticipantInputComponent);
    return ParticipantInputComponent;
}());



/***/ }),

/***/ "./src/app/modules/add-update-appointment/components/type-input/type-input.component.html":
/*!************************************************************************************************!*\
  !*** ./src/app/modules/add-update-appointment/components/type-input/type-input.component.html ***!
  \************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div style=\"width: 90%\" [formGroup]=\"typeGroup\">\r\n    <div class=\"col mt-3\" *ngIf=\"this.allTypes.length >= 1\">\r\n      <mdb-select mdbValidate [highlightFirst]=\"false\" id=\"typeSelect\" #typeSelect (selected)=\"getType($event)\" [options]=\"allTypes\" [multiple]=\"false\" class=\"colorful-select dropdown-primary\" formControlName=\"type\"></mdb-select>\r\n      <label for=\"typeSelect\" class=\"label-color\">Typ auswählen</label>\r\n      <mdb-error *ngIf=\"type.invalid && (type.dirty || type.touched)\">\r\n          <span *ngIf=\"type.errors.required\">Titel wird benötigt</span>\r\n      </mdb-error>\r\n    </div>\r\n  </div>\r\n"

/***/ }),

/***/ "./src/app/modules/add-update-appointment/components/type-input/type-input.component.scss":
/*!************************************************************************************************!*\
  !*** ./src/app/modules/add-update-appointment/components/type-input/type-input.component.scss ***!
  \************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "mdb-select + label {\n  position: absolute !important;\n  font-size: 0.8rem !important;\n  left: 15px !important; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9hZGQtdXBkYXRlLWFwcG9pbnRtZW50L2NvbXBvbmVudHMvdHlwZS1pbnB1dC9DOlxcVXNlcnNcXGNocmlzXFxTb3VyY2UgQ29kZVxcR2l0SHViXFxiZmstcG9ydGFsXFxiZmstcG9ydGFsLWNsaWVudC9zcmNcXGFwcFxcbW9kdWxlc1xcYWRkLXVwZGF0ZS1hcHBvaW50bWVudFxcY29tcG9uZW50c1xcdHlwZS1pbnB1dFxcdHlwZS1pbnB1dC5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFDQTtFQUNJLDhCQUE2QjtFQUM3Qiw2QkFBNEI7RUFDNUIsc0JBQXFCLEVBQ3hCIiwiZmlsZSI6InNyYy9hcHAvbW9kdWxlcy9hZGQtdXBkYXRlLWFwcG9pbnRtZW50L2NvbXBvbmVudHMvdHlwZS1pbnB1dC90eXBlLWlucHV0LmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsiQGltcG9ydCBcInNyYy92YXJpYWJsZXMuc2Nzc1wiO1xyXG5tZGItc2VsZWN0ICsgbGFiZWwge1xyXG4gICAgcG9zaXRpb246IGFic29sdXRlICFpbXBvcnRhbnQ7XHJcbiAgICBmb250LXNpemU6IDAuOHJlbSAhaW1wb3J0YW50O1xyXG4gICAgbGVmdDogMTVweCAhaW1wb3J0YW50O1xyXG59XHJcbiJdfQ== */"

/***/ }),

/***/ "./src/app/modules/add-update-appointment/components/type-input/type-input.component.ts":
/*!**********************************************************************************************!*\
  !*** ./src/app/modules/add-update-appointment/components/type-input/type-input.component.ts ***!
  \**********************************************************************************************/
/*! exports provided: TypeInputComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TypeInputComponent", function() { return TypeInputComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var src_app_core_services_appointment_service_appointment_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/core/services/appointment-service/appointment.service */ "./src/app/core/services/appointment-service/appointment.service.ts");
/* harmony import */ var ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ng-uikit-pro-standard */ "./node_modules/ng-uikit-pro-standard/esm5/ng-uikit-pro-standard.es5.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var TypeInputComponent = /** @class */ (function () {
    function TypeInputComponent(appointmentService, changeDetector) {
        this.appointmentService = appointmentService;
        this.changeDetector = changeDetector;
        this.allTypes = [];
        this.typeEmitter = new _angular_core__WEBPACK_IMPORTED_MODULE_0__["EventEmitter"]();
    }
    TypeInputComponent.prototype.ngOnInit = function () {
        this.fetchTypes();
    };
    TypeInputComponent.prototype.ngOnChanges = function (changes) {
        this.typeGroup = changes['typeGroup'].currentValue;
    };
    Object.defineProperty(TypeInputComponent.prototype, "type", {
        get: function () { return this.typeGroup.get('type'); },
        enumerable: true,
        configurable: true
    });
    TypeInputComponent.prototype.fetchTypes = function () {
        var _this = this;
        this._allTypesSubscription = this
            .appointmentService
            .getTypes()
            .subscribe(function (data) {
            _this.allTypes = [],
                data.forEach(function (element) {
                    _this
                        .allTypes
                        .push({ value: element, label: element });
                });
        });
    };
    TypeInputComponent.prototype.getType = function (e) {
        this.typeEmitter.emit(e.label);
    };
    TypeInputComponent.prototype.ngOnDestroy = function () {
        this._allTypesSubscription.unsubscribe();
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Output"])(),
        __metadata("design:type", Object)
    ], TypeInputComponent.prototype, "typeEmitter", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroup"])
    ], TypeInputComponent.prototype, "typeGroup", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ViewChild"])('typeSelect'),
        __metadata("design:type", ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_3__["SelectComponent"])
    ], TypeInputComponent.prototype, "typeSelect", void 0);
    TypeInputComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-type-input',
            template: __webpack_require__(/*! ./type-input.component.html */ "./src/app/modules/add-update-appointment/components/type-input/type-input.component.html"),
            styles: [__webpack_require__(/*! ./type-input.component.scss */ "./src/app/modules/add-update-appointment/components/type-input/type-input.component.scss")]
        }),
        __metadata("design:paramtypes", [src_app_core_services_appointment_service_appointment_service__WEBPACK_IMPORTED_MODULE_2__["AppointmentService"],
            _angular_core__WEBPACK_IMPORTED_MODULE_0__["ChangeDetectorRef"]])
    ], TypeInputComponent);
    return TypeInputComponent;
}());



/***/ }),

/***/ "./src/app/modules/add-update-appointment/components/update-appointment-wrapper/update-appointment-wrapper.component.html":
/*!********************************************************************************************************************************!*\
  !*** ./src/app/modules/add-update-appointment/components/update-appointment-wrapper/update-appointment-wrapper.component.html ***!
  \********************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n <div class=\"col mt-2 text-center\">\r\n  <h3 class=\"h3 h3-responsive\">{{this.type}}</h3>\r\n</div>\r\n<form [formGroup]=\"updateForm\" (ngSubmit)=\"onSubmit()\" >\r\n    <app-misc-input [miscGroup]=\"updateForm\"></app-misc-input>\r\n    <app-participant-input *ngIf=\"this.updateForm.get('participants').value !== ''\"  [allUsers]=\"this.allUsers\" [allOrganisations]=\"this.allOrganisations\" [participantGroup]=\"updateForm\" [isShift]=\"this.isShift\"></app-participant-input>\r\n    <app-date-input [isShift]=\"this.isShift\" [dateGroup]=\"updateForm\"></app-date-input>\r\n    <app-visibility-input [visibilityGroup]=\"updateForm\"></app-visibility-input>\r\n    <button type=\"submit\" class=\"col btn btn-color waves-light\" mdbWavesEffect> <i class=\"fa fa-plus\"></i>Ändern</button>\r\n</form>"

/***/ }),

/***/ "./src/app/modules/add-update-appointment/components/update-appointment-wrapper/update-appointment-wrapper.component.scss":
/*!********************************************************************************************************************************!*\
  !*** ./src/app/modules/add-update-appointment/components/update-appointment-wrapper/update-appointment-wrapper.component.scss ***!
  \********************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvYWRkLXVwZGF0ZS1hcHBvaW50bWVudC9jb21wb25lbnRzL3VwZGF0ZS1hcHBvaW50bWVudC13cmFwcGVyL3VwZGF0ZS1hcHBvaW50bWVudC13cmFwcGVyLmNvbXBvbmVudC5zY3NzIn0= */"

/***/ }),

/***/ "./src/app/modules/add-update-appointment/components/update-appointment-wrapper/update-appointment-wrapper.component.ts":
/*!******************************************************************************************************************************!*\
  !*** ./src/app/modules/add-update-appointment/components/update-appointment-wrapper/update-appointment-wrapper.component.ts ***!
  \******************************************************************************************************************************/
/*! exports provided: UpdateAppointmentWrapperComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "UpdateAppointmentWrapperComponent", function() { return UpdateAppointmentWrapperComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ng-uikit-pro-standard */ "./node_modules/ng-uikit-pro-standard/esm5/ng-uikit-pro-standard.es5.js");
/* harmony import */ var moment__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! moment */ "./node_modules/moment/moment.js");
/* harmony import */ var moment__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(moment__WEBPACK_IMPORTED_MODULE_2__);
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var src_app_shared_models_appointment__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! src/app/shared/models/appointment */ "./src/app/shared/models/appointment.ts");
/* harmony import */ var src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! src/app/shared/enums/static-strings */ "./src/app/shared/enums/static-strings.ts");
/* harmony import */ var src_app_core_services_session_user_service_session_user_service__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! src/app/core/services/session-user-service/session-user.service */ "./src/app/core/services/session-user-service/session-user.service.ts");
/* harmony import */ var src_app_core_services_appointment_service_appointment_service__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! src/app/core/services/appointment-service/appointment.service */ "./src/app/core/services/appointment-service/appointment.service.ts");
/* harmony import */ var src_app_shared_validation_customValidations__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! src/app/shared/validation/customValidations */ "./src/app/shared/validation/customValidations.ts");
/* harmony import */ var src_app_core_services_user_service_user_service__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! src/app/core/services/user-service/user.service */ "./src/app/core/services/user-service/user.service.ts");
/* harmony import */ var src_app_core_services_organisation_service_organisation_service__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! src/app/core/services/organisation-service/organisation.service */ "./src/app/core/services/organisation-service/organisation.service.ts");
/* harmony import */ var src_app_core_services_roles_service_roles_service__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! src/app/core/services/roles-service/roles.service */ "./src/app/core/services/roles-service/roles.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};













// tslint:disable-next-line:max-line-length
var UpdateAppointmentWrapperComponent = /** @class */ (function () {
    function UpdateAppointmentWrapperComponent(toast, fb, sessionUser, route, appointmentService, userService, organisationService, roleService) {
        this.toast = toast;
        this.fb = fb;
        this.sessionUser = sessionUser;
        this.route = route;
        this.appointmentService = appointmentService;
        this.userService = userService;
        this.organisationService = organisationService;
        this.roleService = roleService;
        this.allUsers = [];
        this.allOrganisations = [];
        this.activeView = 0;
        this.titleError = ' ';
        this.isShift = false;
        this.descriptionError = ' ';
        this.appTypes = src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__["AppointmentTypes"];
        this.updateForm = fb.group({
            'type': ['', [_angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].required]],
            'title': ['', [_angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].required, _angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].maxLength(30)]],
            'description': ['', [_angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].maxLength(300)]],
            'participants': ['', [_angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].required]],
            'areParticipantsOrgs': new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormControl"]('', { validators: _angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].required, updateOn: 'change' }),
            'maxParticipants': [
                ' ',
                [_angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].max(60)]
            ],
            'deadLineString': [''],
            'endDateString': [
                '', _angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].required
            ],
            'startDateString': [
                '', _angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].required
            ],
            'startTimeString': [
                '',
                [_angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].required]
            ],
            'endTimeString': [
                '',
                [_angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].required]
            ],
            'isVisible': new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormControl"]('', { updateOn: 'change' }),
            'participantsVisible': new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormControl"]('', { updateOn: 'change' })
        }, {
            updateOn: 'submit', validators: _angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].compose([src_app_shared_validation_customValidations__WEBPACK_IMPORTED_MODULE_9__["participantsRequired"], src_app_shared_validation_customValidations__WEBPACK_IMPORTED_MODULE_9__["participantsVal"], src_app_shared_validation_customValidations__WEBPACK_IMPORTED_MODULE_9__["dateValidation"]])
        });
    }
    UpdateAppointmentWrapperComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.fetchOrgs();
        this.fetchUsers();
        if (this.roleService.isUserBfk) {
            this.updateForm.setValidators(_angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].compose([src_app_shared_validation_customValidations__WEBPACK_IMPORTED_MODULE_9__["participantsRequired"], src_app_shared_validation_customValidations__WEBPACK_IMPORTED_MODULE_9__["participantsVal"], src_app_shared_validation_customValidations__WEBPACK_IMPORTED_MODULE_9__["dateValidation"], src_app_shared_validation_customValidations__WEBPACK_IMPORTED_MODULE_9__["appointmentTimeValidation"]]));
        }
        this._routeSubscription = this.route.queryParams.subscribe(function (queryparams) {
            if (!!queryparams) {
                var appointmentToUpdateId_1 = JSON.parse(queryparams.AppointmentToUpdate);
                console.log(appointmentToUpdateId_1);
                _this._allAppointemntSubscription = _this.appointmentService._allAppointments.subscribe(function (appointments) {
                    if (appointments.length > 0) {
                        console.log(appointments);
                        _this.appointmentToUpdate = appointments.find(function (appointment) { return appointmentToUpdateId_1 === appointment.id; });
                        console.log(_this.appointmentToUpdate);
                        _this.checkVals();
                    }
                });
            }
        });
    };
    UpdateAppointmentWrapperComponent.prototype.checkVals = function () {
        this.id = this.appointmentToUpdate.id;
        this.type = this.appointmentToUpdate.type;
        console.log(this.updateForm);
        if (this.type === src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__["AppointmentTypes"][src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__["AppointmentTypes"].Dienst] ||
            this.type === src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__["AppointmentTypes"][src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__["AppointmentTypes"].MarktplatzDienst] ||
            this.type === src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__["AppointmentTypes"][src_app_shared_enums_static_strings__WEBPACK_IMPORTED_MODULE_6__["AppointmentTypes"].FreierDienst]) {
            this.updateForm.patchValue({ participants: [this.appointmentToUpdate.owner.id] });
            this.isShift = true;
        }
        else {
            this.isShift = false;
            var selectedParticipants_1 = [];
            this.appointmentToUpdate.participations.forEach(function (participant) {
                selectedParticipants_1.push(participant.id);
            });
            this.updateForm.patchValue({ participants: selectedParticipants_1 });
        }
        this.updateForm.patchValue({ type: this.appointmentToUpdate.type });
        if (this.appointmentToUpdate.areParticipantsOrganisations) {
            this.updateForm.patchValue({ areParticipantsOrgs: 1 });
        }
        else {
            this.updateForm.patchValue({ areParticipantsOrgs: 2 });
        }
        this.areParticipantsOrgsChangeEvent();
        this.updateForm.patchValue({ isVisible: this.appointmentToUpdate.isVisible,
            participantsVisible: this.appointmentToUpdate.showParticipants });
        if (this.appointmentToUpdate.deadline != null) {
            this
                .updateForm
                .patchValue({
                deadLineString: moment__WEBPACK_IMPORTED_MODULE_2__(this.appointmentToUpdate.deadline)
                    .format('DD.MM.YYYY')
                    .toString()
            });
        }
        this.updateForm.patchValue({ startDateString: moment__WEBPACK_IMPORTED_MODULE_2__(this.appointmentToUpdate.from)
                .format('DD.MM.YYYY')
                .toString(),
            endDateString: moment__WEBPACK_IMPORTED_MODULE_2__(this.appointmentToUpdate.to)
                .format('DD.MM.YYYY')
                .toString(),
            startTimeString: moment__WEBPACK_IMPORTED_MODULE_2__(this.appointmentToUpdate.from)
                .format('HH:mm')
                .toString(),
            endTimeString: moment__WEBPACK_IMPORTED_MODULE_2__(this.appointmentToUpdate.to)
                .format('HH:mm')
                .toString() });
        this.updateForm.patchValue({ maxParticipants: this.appointmentToUpdate.maxParticipants });
        this
            .updateForm
            .patchValue({ title: this.appointmentToUpdate.title,
            description: this.appointmentToUpdate.description });
    };
    UpdateAppointmentWrapperComponent.prototype.areParticipantsOrgsChangeEvent = function () {
        var _this = this;
        this._areParticipantsOrgsSubscription = this.updateForm.get('areParticipantsOrgs').valueChanges.subscribe(function (data) {
            _this.updateForm.patchValue({ participants: [] });
        });
    };
    UpdateAppointmentWrapperComponent.prototype.fetchOrgs = function () {
        var _this = this;
        this._allOrgsSubscription = this.organisationService._allOrganisations.subscribe(function (orgs) {
            _this.allOrganisations = [];
            _this.allOrganisations = orgs;
        });
    };
    UpdateAppointmentWrapperComponent.prototype.fetchUsers = function () {
        var _this = this;
        this._allUsersSubscription = this.userService._allUsers.subscribe(function (users) {
            _this.allUsers = [];
            _this.allUsers = users;
        });
    };
    UpdateAppointmentWrapperComponent.prototype.onSubmit = function () {
        var _this = this;
        if (this.updateForm.hasError('onlyNightShiftsDuringWeek')) {
            this.toast.error('Zwischen Mo-Fr nur Nachtschichten zwischen 18-6 Uhr');
        }
        if (this.updateForm.get('startTimeString').hasError('required') ||
            this.updateForm.get('endTimeString').hasError('required')) {
            this
                .toast
                .error('StartZeit und EndZeit sind verpflichtend');
        }
        if (this.updateForm.valid) {
            var copyParticipants_1 = [];
            if (this.updateForm.get('areParticipantsOrgs').value === 1) {
                this.updateForm.get('participants').value.forEach(function (id) {
                    copyParticipants_1.push(_this.allOrganisations.find(function (org) { return org.id === id; }));
                });
                this.updateForm.patchValue({ areParticipantsOrgs: true });
            }
            else {
                this.updateForm.get('participants').value.forEach(function (id) {
                    copyParticipants_1.push(_this.allUsers.find(function (user) { return user.id === id; }));
                });
                this.updateForm.patchValue({ areParticipantsOrgs: false });
            }
            this.updateForm.patchValue({ participants: copyParticipants_1 });
            var owner = this.sessionUser.getUser();
            var deadline = moment__WEBPACK_IMPORTED_MODULE_2__(this.updateForm.get('deadLineString').value, 'DD.MM.YYYY').toDate();
            if (this.isShift) {
                owner = this.updateForm.get('participants').value[0];
                this.updateForm.patchValue({ participants: [] });
                deadline = null;
            }
            // tslint:disable-next-line:max-line-length
            var startDate = moment__WEBPACK_IMPORTED_MODULE_2__(this.updateForm.get('startDateString').value + ' ' + this.updateForm.get('startTimeString').value, 'DD.MM.YYYY HH:mm').toDate();
            // tslint:disable-next-line:max-line-length
            var endDate = moment__WEBPACK_IMPORTED_MODULE_2__(this.updateForm.get('endDateString').value + ' ' + this.updateForm.get('endTimeString').value, 'DD.MM.YYYY HH:mm').toDate();
            var appointmentToUpdate = new src_app_shared_models_appointment__WEBPACK_IMPORTED_MODULE_5__["Appointment"](this.id, this.updateForm.get('title').value, this.updateForm.get('description').value, startDate, endDate, this.updateForm.get('participants').value, this.updateForm.get('maxParticipants').value, deadline, this.updateForm.get('participantsVisible').value, owner, this.type, this.updateForm.get('isVisible').value, this.updateForm.get('areParticipantsOrgs').value);
            this.appointmentService.appointmentToUpdate.next(appointmentToUpdate);
        }
    };
    UpdateAppointmentWrapperComponent.prototype.ngOnDestroy = function () {
        this._routeSubscription.unsubscribe();
        this._allOrgsSubscription.unsubscribe();
        this._allUsersSubscription.unsubscribe();
        this._areParticipantsOrgsSubscription.unsubscribe();
    };
    UpdateAppointmentWrapperComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({ selector: 'app-update-appointment-wrapper', template: __webpack_require__(/*! ./update-appointment-wrapper.component.html */ "./src/app/modules/add-update-appointment/components/update-appointment-wrapper/update-appointment-wrapper.component.html"), styles: [__webpack_require__(/*! ./update-appointment-wrapper.component.scss */ "./src/app/modules/add-update-appointment/components/update-appointment-wrapper/update-appointment-wrapper.component.scss")] }),
        __metadata("design:paramtypes", [ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_1__["ToastService"],
            _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormBuilder"],
            src_app_core_services_session_user_service_session_user_service__WEBPACK_IMPORTED_MODULE_7__["SessionUserService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_4__["ActivatedRoute"],
            src_app_core_services_appointment_service_appointment_service__WEBPACK_IMPORTED_MODULE_8__["AppointmentService"],
            src_app_core_services_user_service_user_service__WEBPACK_IMPORTED_MODULE_10__["UserService"],
            src_app_core_services_organisation_service_organisation_service__WEBPACK_IMPORTED_MODULE_11__["OrganisationService"],
            src_app_core_services_roles_service_roles_service__WEBPACK_IMPORTED_MODULE_12__["RolesService"]])
    ], UpdateAppointmentWrapperComponent);
    return UpdateAppointmentWrapperComponent;
}());



/***/ }),

/***/ "./src/app/modules/add-update-appointment/components/visibility-input/visibility-input.component.html":
/*!************************************************************************************************************!*\
  !*** ./src/app/modules/add-update-appointment/components/visibility-input/visibility-input.component.html ***!
  \************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div [formGroup]=\"visibilityGroup\">\r\n    <mdb-checkbox [inline]=\"true\" class=\"checkbox-teal\" #isVisible formControlName=\"isVisible\">Sichtbar für andere</mdb-checkbox>\r\n    <mdb-checkbox [inline]=\"true\" *ngIf=\"checkVisibleState()\" class=\"checkbox-teal\" #showParticipants formControlName=\"participantsVisible\">Sichtbar nur für Admins</mdb-checkbox>\r\n\r\n  </div>\r\n"

/***/ }),

/***/ "./src/app/modules/add-update-appointment/components/visibility-input/visibility-input.component.scss":
/*!************************************************************************************************************!*\
  !*** ./src/app/modules/add-update-appointment/components/visibility-input/visibility-input.component.scss ***!
  \************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL21vZHVsZXMvYWRkLXVwZGF0ZS1hcHBvaW50bWVudC9jb21wb25lbnRzL3Zpc2liaWxpdHktaW5wdXQvdmlzaWJpbGl0eS1pbnB1dC5jb21wb25lbnQuc2NzcyJ9 */"

/***/ }),

/***/ "./src/app/modules/add-update-appointment/components/visibility-input/visibility-input.component.ts":
/*!**********************************************************************************************************!*\
  !*** ./src/app/modules/add-update-appointment/components/visibility-input/visibility-input.component.ts ***!
  \**********************************************************************************************************/
/*! exports provided: VisibilityInputComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "VisibilityInputComponent", function() { return VisibilityInputComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ng-uikit-pro-standard */ "./node_modules/ng-uikit-pro-standard/esm5/ng-uikit-pro-standard.es5.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var VisibilityInputComponent = /** @class */ (function () {
    function VisibilityInputComponent() {
    }
    VisibilityInputComponent.prototype.ngOnInit = function () {
    };
    VisibilityInputComponent.prototype.checkVisibleState = function () {
        if (!this.visibilityGroup.get('isVisible').value && this.visibilityGroup.get('participantsVisible').value) {
            this.visibilityGroup.patchValue({ participantsVisible: false });
        }
        return this.visibilityGroup.get('isVisible').value;
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Input"])(),
        __metadata("design:type", _angular_forms__WEBPACK_IMPORTED_MODULE_1__["FormGroup"])
    ], VisibilityInputComponent.prototype, "visibilityGroup", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ViewChild"])('isVisible'),
        __metadata("design:type", ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_2__["CheckboxComponent"])
    ], VisibilityInputComponent.prototype, "isVisible", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ViewChild"])('showParticipants'),
        __metadata("design:type", ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_2__["CheckboxComponent"])
    ], VisibilityInputComponent.prototype, "showParticipants", void 0);
    VisibilityInputComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-visibility-input',
            template: __webpack_require__(/*! ./visibility-input.component.html */ "./src/app/modules/add-update-appointment/components/visibility-input/visibility-input.component.html"),
            styles: [__webpack_require__(/*! ./visibility-input.component.scss */ "./src/app/modules/add-update-appointment/components/visibility-input/visibility-input.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], VisibilityInputComponent);
    return VisibilityInputComponent;
}());



/***/ })

}]);
//# sourceMappingURL=src-app-modules-add-update-appointment-add-update-appointment-module.js.map