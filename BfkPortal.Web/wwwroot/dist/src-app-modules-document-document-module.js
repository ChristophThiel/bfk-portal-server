(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["src-app-modules-document-document-module"],{

/***/ "./src/app/core/services/file-service/file.service.ts":
/*!************************************************************!*\
  !*** ./src/app/core/services/file-service/file.service.ts ***!
  \************************************************************/
/*! exports provided: FileService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "FileService", function() { return FileService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! lodash */ "./node_modules/lodash/lodash.js");
/* harmony import */ var lodash__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(lodash__WEBPACK_IMPORTED_MODULE_2__);
/* harmony import */ var _shared_models_document__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./../../../shared/models/document */ "./src/app/shared/models/document.ts");
/* harmony import */ var rxjs_internal_operators_map__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! rxjs/internal/operators/map */ "./node_modules/rxjs/internal/operators/map.js");
/* harmony import */ var rxjs_internal_operators_map__WEBPACK_IMPORTED_MODULE_4___default = /*#__PURE__*/__webpack_require__.n(rxjs_internal_operators_map__WEBPACK_IMPORTED_MODULE_4__);
/* harmony import */ var rxjs_internal_ReplaySubject__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! rxjs/internal/ReplaySubject */ "./node_modules/rxjs/internal/ReplaySubject.js");
/* harmony import */ var rxjs_internal_ReplaySubject__WEBPACK_IMPORTED_MODULE_5___default = /*#__PURE__*/__webpack_require__.n(rxjs_internal_ReplaySubject__WEBPACK_IMPORTED_MODULE_5__);
/* harmony import */ var rxjs_internal_Subject__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! rxjs/internal/Subject */ "./node_modules/rxjs/internal/Subject.js");
/* harmony import */ var rxjs_internal_Subject__WEBPACK_IMPORTED_MODULE_6___default = /*#__PURE__*/__webpack_require__.n(rxjs_internal_Subject__WEBPACK_IMPORTED_MODULE_6__);
/* harmony import */ var moment__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! moment */ "./node_modules/moment/moment.js");
/* harmony import */ var moment__WEBPACK_IMPORTED_MODULE_7___default = /*#__PURE__*/__webpack_require__.n(moment__WEBPACK_IMPORTED_MODULE_7__);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};








var SERVER_URL = 'https://bfk-portal.herokuapp.com/api/file/';
var FileService = /** @class */ (function () {
    function FileService(httpClient) {
        this.httpClient = httpClient;
        this._progress = new rxjs_internal_Subject__WEBPACK_IMPORTED_MODULE_6__["Subject"]();
        this._allFiles = new rxjs_internal_ReplaySubject__WEBPACK_IMPORTED_MODULE_5__["ReplaySubject"]();
    }
    FileService.prototype.getFiles = function () {
        var _this = this;
        return this.httpClient.get(SERVER_URL + 'all').pipe(Object(rxjs_internal_operators_map__WEBPACK_IMPORTED_MODULE_4__["map"])(function (files) {
            console.log(files);
            var copyFiles = [];
            files.forEach(function (file) {
                var fileEnd = file.fileName.split('.')[1];
                var newFile = new _shared_models_document__WEBPACK_IMPORTED_MODULE_3__["Document"]();
                newFile.created = moment__WEBPACK_IMPORTED_MODULE_7__(file.created).format('HH:mm DD.MM.YYYY');
                newFile.fileName = file.fileName;
                newFile.group = _this.checkFileGroup(fileEnd);
                newFile.id = file.id;
                newFile.lastModified = moment__WEBPACK_IMPORTED_MODULE_7__(file.created).format('HH:mm DD.MM.YYYY');
                newFile.ownerId = file.ownerId;
                newFile.path = file.path;
                copyFiles.push(newFile);
            });
            _this._allFiles.next(copyFiles);
        })).toPromise();
    };
    FileService.prototype.downloadFile = function (id) {
        return this.httpClient.get(SERVER_URL + 'download/' + id).pipe(Object(rxjs_internal_operators_map__WEBPACK_IMPORTED_MODULE_4__["map"])(function (response) { return console.log(response); }));
    };
    FileService.prototype.deleteFile = function (id) {
        return this.httpClient.get(SERVER_URL + 'delete/' + id);
    };
    FileService.prototype.upload = function (file, progressModal) {
        var _this = this;
        var formData = new FormData();
        formData.append('uploadFile', file, file.name);
        var headers = new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpHeaders"]({ 'enctype': 'multipart/form-data' });
        this
            .httpClient
            .request(new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpRequest"]('POST', SERVER_URL + 'upload', formData, { reportProgress: true, headers: headers }))
            .subscribe(function (event) {
            console.log(event);
            if (event.type === _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpEventType"].UploadProgress) {
                var percentDone = Math.round(100 * event.loaded / event.total);
                _this
                    ._progress
                    .next(percentDone);
            }
            else if (event instanceof _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpResponse"]) {
                _this
                    ._progress
                    .next(0);
                _this
                    ._progress
                    .complete();
                _this.getFiles();
                progressModal.hide();
            }
        });
    };
    FileService.prototype.groupFiles = function (files) {
        var _this = this;
        var partedDocs = [];
        var groupedDocs = lodash__WEBPACK_IMPORTED_MODULE_2__["groupBy"](files, function (file) {
            var fileEnd = file.fileName.split('.')[1];
            var group = _this.checkFileGroup(fileEnd);
            return group;
        });
        console.log(groupedDocs);
        for (var key in groupedDocs) {
            if (groupedDocs.hasOwnProperty(key)) {
                var value = groupedDocs[key];
                partedDocs.push(value);
            }
        }
        return partedDocs;
    };
    FileService.prototype.checkFileGroup = function (fileEnd) {
        // tslint:disable-next-line:curly
        if (fileEnd === 'docx' || fileEnd === 'doc')
            return 'Word Dateien';
        // tslint:disable-next-line:curly
        if (fileEnd === 'jpeg' || fileEnd === 'jpg' || fileEnd === 'png')
            return 'Bild Dateien';
        // tslint:disable-next-line:curly
        if (fileEnd === 'xlsx' || fileEnd === 'csv' || fileEnd === 'xlsm')
            return 'Excel Dateien';
        // tslint:disable-next-line:curly
        if (fileEnd === 'pptx' || fileEnd === 'ppt')
            return 'Powerpoint Dateien';
        // tslint:disable-next-line:curly
        if (fileEnd === 'pdf')
            return 'Pdf Dateien';
        // tslint:disable-next-line:curly
        if (fileEnd === '7z' || fileEnd === 'zip' || fileEnd === 'rar')
            return 'Zip Dateien';
        // tslint:disable-next-line:curly
        if (fileEnd === 'txt' || fileEnd === 'rtf')
            return 'Text Dateien';
        // tslint:disable-next-line:curly
        if (fileEnd === 'wav' || fileEnd === 'mp3')
            return 'Audio Dateien';
        // tslint:disable-next-line:curly
        if (fileEnd === 'mpg' || fileEnd === 'avi' || fileEnd === 'mp4')
            return 'Video Dateien';
        return 'Andere Dateien';
    };
    FileService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({ providedIn: 'root' }),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]])
    ], FileService);
    return FileService;
}());



/***/ }),

/***/ "./src/app/modules/document/components/document-list/document-list.component.html":
/*!****************************************************************************************!*\
  !*** ./src/app/modules/document/components/document-list/document-list.component.html ***!
  \****************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"w-100 d-inline-block justify-content-center d-flex\">\r\n    <button mdbBtn type=\"button\" placement=\"bottom\" [mdbPopover]=\"popTemplate\" size=\"sm\" class=\"btn btn-color float-left waves-light\" mdbWavesEffect> \r\n      <i class=\"fa fa-plus\"></i>\r\n     </button>\r\n</div> \r\n<div>\r\n  <div *ngFor=\"let fileGroup of groupedFiles\" >\r\n    <h3 class=\"h3-responsive font-weight-bold\">\r\n        <i *ngIf=\"fileGroup[0].group === 'Bild Dateien'\"  class=\"fa fa-file-picture-o\"></i>\r\n        <i *ngIf=\"fileGroup[0].group === 'Word Dateien'\"  class=\"fa fa-file-word-o\"></i>\r\n        <i *ngIf=\"fileGroup[0].group === 'Excel Dateien'\"  class=\"fa fa-file-excel-o\"></i>\r\n        <i *ngIf=\"fileGroup[0].group === 'Powerpoint Dateien'\"   class=\"fa fa-file-powerpoint-o\"></i>\r\n        <i *ngIf=\"fileGroup[0].group === 'Pdf Dateien'\"   class=\"fa fa-file-pdf-o\"></i>\r\n        <i *ngIf=\"fileGroup[0].group === 'Zip Dateien'\"   class=\"fa fa-file-zip-o\"></i>\r\n        <i *ngIf=\"fileGroup[0].group === 'Text Dateien'\"   class=\"fa fa-file-text-o\"></i>\r\n        <i *ngIf=\"fileGroup[0].group === 'Audio Dateien'\"   class=\"fa fa-file-audio-o\"></i>\r\n        <i *ngIf=\"fileGroup[0].group === 'Video Dateien'\"   class=\"fa fa-file-video-o\"></i>\r\n        <i *ngIf=\"fileGroup[0].group === 'Andere Dateien'\"   class=\"fa fa-file\"></i>\r\n      {{fileGroup[0].group}}\r\n    </h3>\r\n    <hr class=\"hr-dark\">\r\n  <ul class=\"list-group mb-3\">\r\n    <div *ngFor=\"let file of fileGroup\" >\r\n      <li class=\"list-group-item d-flex justify-content-between\">\r\n        <div class=\"d-flex my-auto\">{{file.fileName}}</div>\r\n        <div class=\"d-flex my-auto\">{{file.lastModified}}</div>\r\n        <div class=\"btn-group  float-right\" dropdown>\r\n            <a dropdownToggle type=\"button\" class=\"dropdown-toggle d-flex waves-light\" mdbWavesEffect>\r\n                <span class=\"fa-stack fa-lg\"><i class=\"fa fa-circle fa-stack-2x\" style=\"color: lightgrey;\">\r\n                  </i><i class=\"fa fa-ellipsis-v fa-stack-1x\"></i></span>\r\n            </a>\r\n            \r\n            <div class=\"dropdown-menu dropdown-menu-right dropdown-primary\" role=\"menu\">\r\n              <div (click)=\"this.downloadFile(file.id)\" class=\"dropdown-item\">\r\n                Download\r\n              </div>\r\n              <div class=\"dropdown-item\">\r\n                  Löschen\r\n                </div>\r\n            </div>\r\n        </div>\r\n      </li>\r\n    </div>\r\n  </ul>\r\n</div>\r\n</div>\r\n<app-progress-modal (getModalRef)=\"getModalRef($event)\"></app-progress-modal>\r\n<ng-template #popTemplate>\r\n    <div class=\"file-field md-form\">\r\n        <div mdbBtn floating=\"true\" size=\"md\"  class=\"btn-color\" mdbWavesEffect>\r\n          <i class=\"fa fa-cloud-upload\" aria-hidden=\"true\"></i>\r\n          <input type=\"file\" mdbFileSelect (uploadOutput)=\"onUploadOutput($event)\">\r\n        </div>\r\n      <div class=\"file-path-wrapper mt-3\">\r\n        <input class=\"file-path\" type=\"text\" placeholder=\"Dokument\" [value]=\"showFileName()\">\r\n      </div>\r\n    </div>\r\n    <button mdbBtn size=\"sm\" class=\"btn btn-color waves-light \" (click)=\"uploadFile()\" mdbWavesEffect>Starte den Upload</button>\r\n  </ng-template>\r\n"

/***/ }),

/***/ "./src/app/modules/document/components/document-list/document-list.component.scss":
/*!****************************************************************************************!*\
  !*** ./src/app/modules/document/components/document-list/document-list.component.scss ***!
  \****************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".dropdown-toggle:after {\n  content: none !important; }\n\n.fa-circle {\n  display: none; }\n\nspan:hover .fa-circle {\n  display: inline-block; }\n\nmdb-popover-container {\n  width: 100%; }\n\n.btn-floating {\n  overflow: unset; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9kb2N1bWVudC9jb21wb25lbnRzL2RvY3VtZW50LWxpc3QvQzpcXFVzZXJzXFxjaHJpc1xcU291cmNlIENvZGVcXEdpdEh1YlxcYmZrLXBvcnRhbFxcYmZrLXBvcnRhbC1jbGllbnQvc3JjXFxhcHBcXG1vZHVsZXNcXGRvY3VtZW50XFxjb21wb25lbnRzXFxkb2N1bWVudC1saXN0XFxkb2N1bWVudC1saXN0LmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0kseUJBQXdCLEVBQzNCOztBQUNEO0VBQ0ksY0FBYSxFQUNoQjs7QUFDRDtFQUVRLHNCQUFxQixFQUN4Qjs7QUFHTDtFQUNJLFlBQVcsRUFDZDs7QUFDRDtFQUNJLGdCQUFlLEVBQ2xCIiwiZmlsZSI6InNyYy9hcHAvbW9kdWxlcy9kb2N1bWVudC9jb21wb25lbnRzL2RvY3VtZW50LWxpc3QvZG9jdW1lbnQtbGlzdC5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbIi5kcm9wZG93bi10b2dnbGU6YWZ0ZXJ7XHJcbiAgICBjb250ZW50OiBub25lICFpbXBvcnRhbnQ7XHJcbn1cclxuLmZhLWNpcmNsZXtcclxuICAgIGRpc3BsYXk6IG5vbmU7XHJcbn1cclxuc3Bhbjpob3ZlcntcclxuICAgIC5mYS1jaXJjbGUge1xyXG4gICAgICAgIGRpc3BsYXk6IGlubGluZS1ibG9jaztcclxuICAgIH1cclxuICAgIFxyXG59XHJcbm1kYi1wb3BvdmVyLWNvbnRhaW5lcntcclxuICAgIHdpZHRoOiAxMDAlO1xyXG59XHJcbi5idG4tZmxvYXRpbmcge1xyXG4gICAgb3ZlcmZsb3c6IHVuc2V0O1xyXG59XHJcbiJdfQ== */"

/***/ }),

/***/ "./src/app/modules/document/components/document-list/document-list.component.ts":
/*!**************************************************************************************!*\
  !*** ./src/app/modules/document/components/document-list/document-list.component.ts ***!
  \**************************************************************************************/
/*! exports provided: DocumentListComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DocumentListComponent", function() { return DocumentListComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var src_app_core_services_file_service_file_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! src/app/core/services/file-service/file.service */ "./src/app/core/services/file-service/file.service.ts");
/* harmony import */ var src_app_core_services_navbar_buttons_service_navbar_buttons_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/core/services/navbar-buttons-service/navbar-buttons.service */ "./src/app/core/services/navbar-buttons-service/navbar-buttons.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var DocumentListComponent = /** @class */ (function () {
    function DocumentListComponent(fileService, navbarButtons) {
        this.fileService = fileService;
        this.navbarButtons = navbarButtons;
        this.progress = 0;
        this.groupedFiles = [];
    }
    DocumentListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.fetchFiles();
        this.navbarButtons.changeToDocuments();
        this._allFilesSubscription = this.fileService._allFiles.subscribe(function (files) {
            console.log(files);
            _this.groupedFiles = _this.fileService.groupFiles(files);
            console.log(_this.groupedFiles);
        });
    };
    DocumentListComponent.prototype.fetchFiles = function () {
        this.fileService.getFiles();
    };
    DocumentListComponent.prototype.uploadFile = function () {
        this.progressModal.show();
        this
            .fileService
            .upload(this.file.nativeFile, this.progressModal);
    };
    DocumentListComponent.prototype.downloadFile = function (id) {
        console.log(id);
        this.fileService.downloadFile(id).subscribe();
    };
    DocumentListComponent.prototype.deleteFile = function (id) {
        var _this = this;
        console.log(id);
        this._deleteFileSubscription = this.fileService.deleteFile(id).subscribe(function (data) {
            _this.fetchFiles();
        });
    };
    DocumentListComponent.prototype.getModalRef = function (event) {
        console.log(event);
        this.progressModal = event;
    };
    DocumentListComponent.prototype.onUploadOutput = function (output) {
        console.log(output);
        if (output.type === 'addedToQueue') {
            this.file = output.file;
        } // add file to array when added
    };
    DocumentListComponent.prototype.showFileName = function () {
        if (this.file == null) {
            return '';
        }
        else {
            return this.file.name;
        }
    };
    DocumentListComponent.prototype.ngOnDestroy = function () {
        this._allFilesSubscription.unsubscribe();
        if (this._deleteFileSubscription != null) {
            this._deleteFileSubscription.unsubscribe();
        }
    };
    DocumentListComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({ selector: 'app-document-list', template: __webpack_require__(/*! ./document-list.component.html */ "./src/app/modules/document/components/document-list/document-list.component.html"), styles: [__webpack_require__(/*! ./document-list.component.scss */ "./src/app/modules/document/components/document-list/document-list.component.scss")] }),
        __metadata("design:paramtypes", [src_app_core_services_file_service_file_service__WEBPACK_IMPORTED_MODULE_1__["FileService"], src_app_core_services_navbar_buttons_service_navbar_buttons_service__WEBPACK_IMPORTED_MODULE_2__["NavbarButtonsService"]])
    ], DocumentListComponent);
    return DocumentListComponent;
}());



/***/ }),

/***/ "./src/app/modules/document/components/progress-modal/progress-modal.component.html":
/*!******************************************************************************************!*\
  !*** ./src/app/modules/document/components/progress-modal/progress-modal.component.html ***!
  \******************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div mdbModal #progressModal=\"mdbModal\" class=\"modal fade right\" tabindex=\"-1\" role=\"dialog\" aria-labelledby=\"myBasicModalLabel\"\r\n  aria-hidden=\"true\">\r\n  <div class=\"modal-dialog modal-side modal-sm modal-bottom-right \" role=\"document\">\r\n    <div class=\"modal-content\">\r\n      <div class=\"modal-header\">\r\n        <button type=\"button\" class=\"close pull-right\" aria-label=\"Close\" (click)=\"progressModal.hide()\">\r\n          <span aria-hidden=\"true\">×</span>\r\n        </button>\r\n      </div>\r\n      <div class=\"modal-body\">\r\n        <mdb-progress [value]=\"this.progress\" min=\"0\" max=\"100\" type=\"success\" aria-valuenow=\"'this.progress'\" aria-valuemin=\"0\" aria-valuemax=\"100\">{{this.progress}}%</mdb-progress>\r\n      </div>\r\n    </div>\r\n  </div>\r\n</div>\r\n"

/***/ }),

/***/ "./src/app/modules/document/components/progress-modal/progress-modal.component.scss":
/*!******************************************************************************************!*\
  !*** ./src/app/modules/document/components/progress-modal/progress-modal.component.scss ***!
  \******************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".modal .modal-side {\n  min-width: 300px; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbW9kdWxlcy9kb2N1bWVudC9jb21wb25lbnRzL3Byb2dyZXNzLW1vZGFsL0M6XFxVc2Vyc1xcY2hyaXNcXFNvdXJjZSBDb2RlXFxHaXRIdWJcXGJmay1wb3J0YWxcXGJmay1wb3J0YWwtY2xpZW50L3NyY1xcYXBwXFxtb2R1bGVzXFxkb2N1bWVudFxcY29tcG9uZW50c1xccHJvZ3Jlc3MtbW9kYWxcXHByb2dyZXNzLW1vZGFsLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0ksaUJBQWdCLEVBQ25CIiwiZmlsZSI6InNyYy9hcHAvbW9kdWxlcy9kb2N1bWVudC9jb21wb25lbnRzL3Byb2dyZXNzLW1vZGFsL3Byb2dyZXNzLW1vZGFsLmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsiLm1vZGFsIC5tb2RhbC1zaWRlIHtcclxuICAgIG1pbi13aWR0aDogMzAwcHg7XHJcbn0iXX0= */"

/***/ }),

/***/ "./src/app/modules/document/components/progress-modal/progress-modal.component.ts":
/*!****************************************************************************************!*\
  !*** ./src/app/modules/document/components/progress-modal/progress-modal.component.ts ***!
  \****************************************************************************************/
/*! exports provided: ProgressModalComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ProgressModalComponent", function() { return ProgressModalComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ng-uikit-pro-standard */ "./node_modules/ng-uikit-pro-standard/esm5/ng-uikit-pro-standard.es5.js");
/* harmony import */ var src_app_core_services_file_service_file_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! src/app/core/services/file-service/file.service */ "./src/app/core/services/file-service/file.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var ProgressModalComponent = /** @class */ (function () {
    function ProgressModalComponent(fileService) {
        this.fileService = fileService;
        this.getModalRef = new _angular_core__WEBPACK_IMPORTED_MODULE_0__["EventEmitter"]();
        this.progress = 0;
    }
    ProgressModalComponent.prototype.ngOnInit = function () {
        var _this = this;
        this
            .fileService
            ._progress
            .subscribe(function (value) {
            console.log(_this.progress);
            _this.progress = value;
        }, function (err) {
            console.log(err);
        });
    };
    ProgressModalComponent.prototype.ngAfterViewInit = function () {
        console.log(this.progressModal);
        this.getModalRef.emit(this.progressModal);
    };
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Output"])(),
        __metadata("design:type", Object)
    ], ProgressModalComponent.prototype, "getModalRef", void 0);
    __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["ViewChild"])('progressModal'),
        __metadata("design:type", ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_1__["ModalDirective"])
    ], ProgressModalComponent.prototype, "progressModal", void 0);
    ProgressModalComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-progress-modal',
            template: __webpack_require__(/*! ./progress-modal.component.html */ "./src/app/modules/document/components/progress-modal/progress-modal.component.html"),
            styles: [__webpack_require__(/*! ./progress-modal.component.scss */ "./src/app/modules/document/components/progress-modal/progress-modal.component.scss")]
        }),
        __metadata("design:paramtypes", [src_app_core_services_file_service_file_service__WEBPACK_IMPORTED_MODULE_2__["FileService"]])
    ], ProgressModalComponent);
    return ProgressModalComponent;
}());



/***/ }),

/***/ "./src/app/modules/document/document-routing.module.ts":
/*!*************************************************************!*\
  !*** ./src/app/modules/document/document-routing.module.ts ***!
  \*************************************************************/
/*! exports provided: DocumentRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DocumentRoutingModule", function() { return DocumentRoutingModule; });
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _components_document_list_document_list_component__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./components/document-list/document-list.component */ "./src/app/modules/document/components/document-list/document-list.component.ts");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var routes = [
    {
        path: '',
        component: _components_document_list_document_list_component__WEBPACK_IMPORTED_MODULE_1__["DocumentListComponent"]
    }
];
var DocumentRoutingModule = /** @class */ (function () {
    function DocumentRoutingModule() {
    }
    DocumentRoutingModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_0__["RouterModule"].forChild(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_0__["RouterModule"]]
        })
    ], DocumentRoutingModule);
    return DocumentRoutingModule;
}());



/***/ }),

/***/ "./src/app/modules/document/document.module.ts":
/*!*****************************************************!*\
  !*** ./src/app/modules/document/document.module.ts ***!
  \*****************************************************/
/*! exports provided: DocumentModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DocumentModule", function() { return DocumentModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ng-uikit-pro-standard */ "./node_modules/ng-uikit-pro-standard/esm5/ng-uikit-pro-standard.es5.js");
/* harmony import */ var _components_document_list_document_list_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./components/document-list/document-list.component */ "./src/app/modules/document/components/document-list/document-list.component.ts");
/* harmony import */ var _document_routing_module__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./document-routing.module */ "./src/app/modules/document/document-routing.module.ts");
/* harmony import */ var _components_progress_modal_progress_modal_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./components/progress-modal/progress-modal.component */ "./src/app/modules/document/components/progress-modal/progress-modal.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};






var DocumentModule = /** @class */ (function () {
    function DocumentModule() {
    }
    DocumentModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            declarations: [
                _components_document_list_document_list_component__WEBPACK_IMPORTED_MODULE_3__["DocumentListComponent"],
                _components_progress_modal_progress_modal_component__WEBPACK_IMPORTED_MODULE_5__["ProgressModalComponent"]
            ],
            imports: [
                _angular_common__WEBPACK_IMPORTED_MODULE_1__["CommonModule"],
                _document_routing_module__WEBPACK_IMPORTED_MODULE_4__["DocumentRoutingModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_2__["FileInputModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_2__["WavesModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_2__["ButtonsModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_2__["CollapseModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_2__["ModalModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_2__["InputsModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_2__["DropdownModule"],
                ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_2__["PopoverModule"]
            ],
            exports: [
                _components_document_list_document_list_component__WEBPACK_IMPORTED_MODULE_3__["DocumentListComponent"]
            ],
            schemas: [_angular_core__WEBPACK_IMPORTED_MODULE_0__["NO_ERRORS_SCHEMA"]],
            providers: [ng_uikit_pro_standard__WEBPACK_IMPORTED_MODULE_2__["MDBSpinningPreloader"]]
        })
    ], DocumentModule);
    return DocumentModule;
}());



/***/ }),

/***/ "./src/app/shared/models/document.ts":
/*!*******************************************!*\
  !*** ./src/app/shared/models/document.ts ***!
  \*******************************************/
/*! exports provided: Document */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Document", function() { return Document; });
var Document = /** @class */ (function () {
    function Document() {
    }
    return Document;
}());



/***/ })

}]);
//# sourceMappingURL=src-app-modules-document-document-module.js.map