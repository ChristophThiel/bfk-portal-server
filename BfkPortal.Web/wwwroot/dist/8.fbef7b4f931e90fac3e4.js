(window.webpackJsonp=window.webpackJsonp||[]).push([[8],{DZ53:function(l,n,u){"use strict";u.r(n);var e=u("CcnG"),t=function(){return function(){}}(),i=u("pMnS"),o=u("i0AA"),c=u("Ip0R"),a=u("KzlR"),r=u("t/Na"),s=u("LvDl"),p=function(){return function(){}}(),b=u("q3Kh"),d=u("+Zhm"),f=u("ds6q"),g=u("wd/R"),h="http://www.bfk-portal.at/api/file/",m=function(){function l(l){this.httpClient=l,this._progress=new f.Subject,this._allFiles=new d.ReplaySubject}return l.prototype.getFiles=function(){var l=this;return this.httpClient.get(h+"all").pipe(Object(b.map)(function(n){console.log(n);var u=[];n.forEach(function(n){var e=n.fileName.split(".")[1],t=new p;t.created=g(n.created).format("HH:mm DD.MM.YYYY"),t.fileName=n.fileName,t.group=l.checkFileGroup(e),t.id=n.id,t.lastModified=g(n.lastModified).format("HH:mm DD.MM.YYYY"),t.ownerId=n.ownerId,t.path=n.path,u.push(t)}),l._allFiles.next(u)})).toPromise()},l.prototype.downloadFile=function(l){var n=new r.h({"Content-Type":"application/json",Accept:"application/json"});return this.httpClient.get(h+"download/"+l,{headers:n,responseType:"blob"}).pipe(Object(b.map)(function(l){return l}))},l.prototype.deleteFile=function(l){return this.httpClient.get(h+"delete/"+l)},l.prototype.upload=function(l,n){var u=this,e=new FormData;e.append("file",l,l.name);var t=new r.h({enctype:"multipart/form-data"});this.httpClient.request(new r.i("POST",h+"upload",e,{reportProgress:!0,headers:t})).subscribe(function(l){if(console.log(l),l.type===r.f.UploadProgress){var e=Math.round(100*l.loaded/l.total);u._progress.next(e)}else l instanceof r.j&&(u._progress.next(0),u._progress.complete(),u.getFiles(),n.hide())})},l.prototype.groupFiles=function(l){var n=this,u=[],e=s.groupBy(l,function(l){var u=l.fileName.split(".")[1];return n.checkFileGroup(u)});for(var t in console.log(e),e)e.hasOwnProperty(t)&&u.push(e[t]);return u},l.prototype.checkFileGroup=function(l){return"docx"===l||"doc"===l?"Word Dateien":"jpeg"===l||"jpg"===l||"png"===l?"Bild Dateien":"xlsx"===l||"csv"===l||"xlsm"===l?"Excel Dateien":"pptx"===l||"ppt"===l?"Powerpoint Dateien":"pdf"===l?"Pdf Dateien":"7z"===l||"zip"===l||"rar"===l?"Zip Dateien":"txt"===l||"rtf"===l?"Text Dateien":"wav"===l||"mp3"===l?"Audio Dateien":"mpg"===l||"avi"===l||"mp4"===l?"Video Dateien":"Andere Dateien"},l.ngInjectableDef=e.S({factory:function(){return new l(e.W(r.c))},token:l,providedIn:"root"}),l}(),v=function(){function l(l){this.fileService=l,this.getModalRef=new e.m,this.progress=0}return l.prototype.ngOnInit=function(){var l=this;this.fileService._progress.subscribe(function(n){console.log(l.progress),l.progress=n},function(l){console.log(l)})},l.prototype.ngAfterViewInit=function(){console.log(this.addModal),this.getModalRef.emit(this.addModal)},l.prototype.uploadFile=function(){this.fileService.upload(this.file.nativeFile,this.addModal)},l.prototype.showFileName=function(){return null==this.file?"":this.file.name},l.prototype.onUploadOutput=function(l){console.log(l),"addedToQueue"===l.type&&(this.file=l.file)},l}(),y=e.ob({encapsulation:0,styles:[[".progress[_ngcontent-%COMP%], .progress-bar[_ngcontent-%COMP%]{height:20px!important}"]],data:{}});function w(l){return e.Kb(0,[e.Gb(402653184,1,{addModal:0}),(l()(),e.qb(1,16777216,null,null,31,"div",[["aria-hidden","true"],["aria-labelledby","myBasicModalLabel"],["class","modal fade"],["mdbModal",""],["role","dialog"],["tabindex","-1"]],null,[[null,"keydown"],[null,"click"],[null,"keydown.esc"]],function(l,n,u){var t=!0;return"keydown"===n&&(t=!1!==e.Ab(l,2).onKeyDown(u)&&t),"click"===n&&(t=!1!==e.Ab(l,2).onClick(u)&&t),"keydown.esc"===n&&(t=!1!==e.Ab(l,2).onEsc()&&t),t},null,null)),e.pb(2,4341760,[[1,4],["addModal",4]],0,o.Kb,[e.k,e.O,e.D,o.Sc],null,null),(l()(),e.qb(3,0,null,null,29,"div",[["class","modal-dialog"],["role","document"]],null,null,null,null,null)),(l()(),e.qb(4,0,null,null,28,"div",[["class","modal-content"]],null,null,null,null,null)),(l()(),e.qb(5,0,null,null,5,"div",[["class","modal-header"]],null,null,null,null,null)),(l()(),e.qb(6,0,null,null,2,"button",[["aria-label","Close"],["class","close pull-right"],["type","button"]],null,[[null,"click"]],function(l,n,u){var t=!0;return"click"===n&&(t=!1!==e.Ab(l,2).hide()&&t),t},null,null)),(l()(),e.qb(7,0,null,null,1,"span",[["aria-hidden","true"]],null,null,null,null,null)),(l()(),e.Ib(-1,null,["\xd7"])),(l()(),e.qb(9,0,null,null,1,"h4",[["class","modal-title w-100"],["id","myModalLabel"]],null,null,null,null,null)),(l()(),e.Ib(-1,null,["Dokument hinzuf\xfcgen"])),(l()(),e.qb(11,0,null,null,12,"div",[["class","modal-body"]],null,null,null,null,null)),(l()(),e.qb(12,0,null,null,8,"div",[["class","file-field md-form"]],null,null,null,null,null)),(l()(),e.qb(13,0,null,null,5,"div",[["class","btn-color"],["floating","true"],["mdbBtn",""],["mdbWavesEffect",""],["size","md"]],null,[[null,"click"]],function(l,n,u){var t=!0;return"click"===n&&(t=!1!==e.Ab(l,14).click(u)&&t),t},null,null)),e.pb(14,16384,null,0,o.Nc,[e.k],null,null),e.pb(15,81920,null,0,o.jb,[e.k,e.D],{size:[0,"size"],floating:[1,"floating"]},null),(l()(),e.qb(16,0,null,null,0,"i",[["aria-hidden","true"],["class","fas fa-cloud-upload-alt"]],null,null,null,null,null)),(l()(),e.qb(17,0,null,null,1,"input",[["mdbFileSelect",""],["type","file"]],null,[[null,"uploadOutput"]],function(l,n,u){var e=!0;return"uploadOutput"===n&&(e=!1!==l.component.onUploadOutput(u)&&e),e},null,null)),e.pb(18,212992,null,0,o.Y,[e.B,e.k],null,{uploadOutput:"uploadOutput"}),(l()(),e.qb(19,0,null,null,1,"div",[["class","file-path-wrapper mt-3"]],null,null,null,null,null)),(l()(),e.qb(20,0,null,null,0,"input",[["class","file-path"],["placeholder","Dokument"],["type","text"]],[[8,"value",0]],null,null,null,null)),(l()(),e.qb(21,0,null,null,2,"mdb-progress",[["aria-valuemax","100"],["aria-valuemin","0"],["max","100"],["min","0"],["type","success"]],[[1,"aria-valuenow",0]],null,null,a.M,a.q)),e.pb(22,49152,null,0,o.dc,[o.ec],{max:[0,"max"],type:[1,"type"],value:[2,"value"]},null),(l()(),e.Ib(23,0,["","%"])),(l()(),e.qb(24,0,null,null,8,"div",[["class","modal-footer"]],null,null,null,null,null)),(l()(),e.qb(25,0,null,null,3,"button",[["class","btn btn-flat waves-light "],["mdbBtn",""],["mdbWavesEffect",""]],null,[[null,"click"]],function(l,n,u){var t=!0;return"click"===n&&(t=!1!==e.Ab(l,26).click(u)&&t),"click"===n&&(t=!1!==e.Ab(l,2).hide()&&t),t},null,null)),e.pb(26,16384,null,0,o.Nc,[e.k],null,null),e.pb(27,81920,null,0,o.jb,[e.k,e.D],null,null),(l()(),e.Ib(-1,null,["Schliessen"])),(l()(),e.qb(29,0,null,null,3,"button",[["class","btn btn-color waves-light "],["mdbBtn",""],["mdbWavesEffect",""]],null,[[null,"click"]],function(l,n,u){var t=!0,i=l.component;return"click"===n&&(t=!1!==e.Ab(l,30).click(u)&&t),"click"===n&&(t=!1!==i.uploadFile()&&t),t},null,null)),e.pb(30,16384,null,0,o.Nc,[e.k],null,null),e.pb(31,81920,null,0,o.jb,[e.k,e.D],null,null),(l()(),e.Ib(-1,null,["Upload"]))],function(l,n){var u=n.component;l(n,15,0,"md","true"),l(n,18,0),l(n,22,0,"100","success",u.progress),l(n,27,0),l(n,31,0)},function(l,n){var u=n.component;l(n,20,0,u.showFileName()),l(n,21,0,e.sb(1,"",u.progress,"")),l(n,23,0,u.progress)})}var k=u("K52H"),q=function(){function l(l,n){this.fileService=l,this.navbarButtons=n,this.progress=0,this.groupedFiles=[]}return l.prototype.ngOnInit=function(){var l=this;this.fetchFiles(),this.navbarButtons.changeToDocuments(),this._allFilesSubscription=this.fileService._allFiles.subscribe(function(n){console.log(n),l.groupedFiles=l.fileService.groupFiles(n),console.log(l.groupedFiles)})},l.prototype.fetchFiles=function(){this.fileService.getFiles()},l.prototype.downloadFile=function(l){this._downloadFileSubscription=this.fileService.downloadFile(l.id).subscribe(function(n){console.log(n);var u=new File([n],l.fileName,{lastModified:+l.lastModified}),e=document.createElement("a");e.href=window.URL.createObjectURL(u),e.download=l.fileName,e.click()})},l.prototype.deleteFile=function(l){var n=this;console.log(l),this._deleteFileSubscription=this.fileService.deleteFile(l).subscribe(function(l){n.fetchFiles()})},l.prototype.getModalRef=function(l){console.log(l),this.addModal=l},l.prototype.ngOnDestroy=function(){this._allFilesSubscription.unsubscribe(),null!=this._deleteFileSubscription&&this._deleteFileSubscription.unsubscribe(),null!=this._downloadFileSubscription&&this._downloadFileSubscription.unsubscribe()},l}(),x=e.ob({encapsulation:0,styles:[[".dropdown-toggle[_ngcontent-%COMP%]:after{content:none!important}.fa-circle[_ngcontent-%COMP%]{display:none}span[_ngcontent-%COMP%]:hover   .fa-circle[_ngcontent-%COMP%]{display:inline-block}mdb-popover-container[_ngcontent-%COMP%]{width:100%}.btn-floating[_ngcontent-%COMP%]{overflow:unset}"]],data:{}});function F(l){return e.Kb(0,[(l()(),e.qb(0,0,null,null,0,"i",[["class","far fa-file-image"]],null,null,null,null,null))],null,null)}function O(l){return e.Kb(0,[(l()(),e.qb(0,0,null,null,0,"i",[["class","far fa-file-word"]],null,null,null,null,null))],null,null)}function D(l){return e.Kb(0,[(l()(),e.qb(0,0,null,null,0,"i",[["class","far fa-file-excel green-text"]],null,null,null,null,null))],null,null)}function M(l){return e.Kb(0,[(l()(),e.qb(0,0,null,null,0,"i",[["class","far fa-file-powerpoint"]],null,null,null,null,null))],null,null)}function I(l){return e.Kb(0,[(l()(),e.qb(0,0,null,null,0,"i",[["class","far fa-file-pdf"]],null,null,null,null,null))],null,null)}function S(l){return e.Kb(0,[(l()(),e.qb(0,0,null,null,0,"i",[["class","far fa-file-archive"]],null,null,null,null,null))],null,null)}function A(l){return e.Kb(0,[(l()(),e.qb(0,0,null,null,0,"i",[["class","far fa-file-alt"]],null,null,null,null,null))],null,null)}function _(l){return e.Kb(0,[(l()(),e.qb(0,0,null,null,0,"i",[["class","far fa-file-audio"]],null,null,null,null,null))],null,null)}function C(l){return e.Kb(0,[(l()(),e.qb(0,0,null,null,0,"i",[["class","far fa-file-video"]],null,null,null,null,null))],null,null)}function K(l){return e.Kb(0,[(l()(),e.qb(0,0,null,null,0,"i",[["class","far fa-file"]],null,null,null,null,null))],null,null)}function L(l){return e.Kb(0,[(l()(),e.qb(0,0,null,null,19,"div",[],null,null,null,null,null)),(l()(),e.qb(1,0,null,null,18,"li",[["class","list-group-item d-flex justify-content-between"]],null,null,null,null,null)),(l()(),e.qb(2,0,null,null,1,"div",[["class","d-flex my-auto"]],null,null,null,null,null)),(l()(),e.Ib(3,null,["",""])),(l()(),e.qb(4,0,null,null,1,"div",[["class","d-flex my-auto"]],null,null,null,null,null)),(l()(),e.Ib(5,null,["",""])),(l()(),e.qb(6,16777216,null,null,13,"div",[["class","btn-group  float-right"],["dropdown",""]],[[2,"dropup",null],[2,"open",null],[2,"show",null]],null,null,null,null)),e.Fb(512,null,o.l,o.l,[]),e.pb(8,212992,null,0,o.k,[e.k,e.D,e.O,o.Sc,o.i,o.l],null,null),(l()(),e.qb(9,0,null,null,5,"a",[["class","dropdown-toggle d-flex waves-light"],["dropdownToggle",""],["mdbWavesEffect",""],["type","button"]],[[1,"aria-haspopup",0],[1,"disabled",0],[1,"aria-expanded",0]],[[null,"click"],["document","click"],[null,"keyup.esc"]],function(l,n,u){var t=!0;return"click"===n&&(t=!1!==e.Ab(l,10).click(u)&&t),"click"===n&&(t=!1!==e.Ab(l,11).onClick()&&t),"document:click"===n&&(t=!1!==e.Ab(l,11).onDocumentClick(u)&&t),"keyup.esc"===n&&(t=!1!==e.Ab(l,11).onEsc()&&t),t},null,null)),e.pb(10,16384,null,0,o.Nc,[e.k],null,null),e.pb(11,147456,null,0,o.m,[o.l,e.k],null,null),(l()(),e.qb(12,0,null,null,2,"span",[["class","fa-stack fa-lg"]],null,null,null,null,null)),(l()(),e.qb(13,0,null,null,0,"i",[["class","fa fa-circle fa-stack-2x"],["style","color: lightgrey;"]],null,null,null,null,null)),(l()(),e.qb(14,0,null,null,0,"i",[["class","fa fa-ellipsis-v fa-stack-1x"]],null,null,null,null,null)),(l()(),e.qb(15,0,null,null,4,"div",[["class","dropdown-menu dropdown-menu-right dropdown-primary"],["role","menu"]],null,null,null,null,null)),(l()(),e.qb(16,0,null,null,1,"div",[["class","dropdown-item"]],null,[[null,"click"]],function(l,n,u){var e=!0;return"click"===n&&(e=!1!==l.component.downloadFile(l.context.$implicit)&&e),e},null,null)),(l()(),e.Ib(-1,null,[" Download "])),(l()(),e.qb(18,0,null,null,1,"div",[["class","dropdown-item"]],null,null,null,null,null)),(l()(),e.Ib(-1,null,[" L\xf6schen "]))],function(l,n){l(n,8,0)},function(l,n){l(n,3,0,n.context.$implicit.fileName),l(n,5,0,n.context.$implicit.lastModified),l(n,6,0,e.Ab(n,8).dropup,e.Ab(n,8).isOpen,e.Ab(n,8).isOpen),l(n,9,0,e.Ab(n,11).ariaHaspopup,e.Ab(n,11).isDisabled,e.Ab(n,11).isOpen)})}function j(l){return e.Kb(0,[(l()(),e.qb(0,0,null,null,26,"div",[],null,null,null,null,null)),(l()(),e.qb(1,0,null,null,21,"h3",[["class","h3-responsive font-weight-bold"]],null,null,null,null,null)),(l()(),e.hb(16777216,null,null,1,null,F)),e.pb(3,16384,null,0,c.l,[e.O,e.L],{ngIf:[0,"ngIf"]},null),(l()(),e.hb(16777216,null,null,1,null,O)),e.pb(5,16384,null,0,c.l,[e.O,e.L],{ngIf:[0,"ngIf"]},null),(l()(),e.hb(16777216,null,null,1,null,D)),e.pb(7,16384,null,0,c.l,[e.O,e.L],{ngIf:[0,"ngIf"]},null),(l()(),e.hb(16777216,null,null,1,null,M)),e.pb(9,16384,null,0,c.l,[e.O,e.L],{ngIf:[0,"ngIf"]},null),(l()(),e.hb(16777216,null,null,1,null,I)),e.pb(11,16384,null,0,c.l,[e.O,e.L],{ngIf:[0,"ngIf"]},null),(l()(),e.hb(16777216,null,null,1,null,S)),e.pb(13,16384,null,0,c.l,[e.O,e.L],{ngIf:[0,"ngIf"]},null),(l()(),e.hb(16777216,null,null,1,null,A)),e.pb(15,16384,null,0,c.l,[e.O,e.L],{ngIf:[0,"ngIf"]},null),(l()(),e.hb(16777216,null,null,1,null,_)),e.pb(17,16384,null,0,c.l,[e.O,e.L],{ngIf:[0,"ngIf"]},null),(l()(),e.hb(16777216,null,null,1,null,C)),e.pb(19,16384,null,0,c.l,[e.O,e.L],{ngIf:[0,"ngIf"]},null),(l()(),e.hb(16777216,null,null,1,null,K)),e.pb(21,16384,null,0,c.l,[e.O,e.L],{ngIf:[0,"ngIf"]},null),(l()(),e.Ib(22,null,[" "," "])),(l()(),e.qb(23,0,null,null,0,"hr",[["class","hr-dark"]],null,null,null,null,null)),(l()(),e.qb(24,0,null,null,2,"ul",[["class","list-group mb-3"]],null,null,null,null,null)),(l()(),e.hb(16777216,null,null,1,null,L)),e.pb(26,278528,null,0,c.k,[e.O,e.L,e.s],{ngForOf:[0,"ngForOf"]},null)],function(l,n){l(n,3,0,"Bild Dateien"===n.context.$implicit[0].group),l(n,5,0,"Word Dateien"===n.context.$implicit[0].group),l(n,7,0,"Excel Dateien"===n.context.$implicit[0].group),l(n,9,0,"Powerpoint Dateien"===n.context.$implicit[0].group),l(n,11,0,"Pdf Dateien"===n.context.$implicit[0].group),l(n,13,0,"Zip Dateien"===n.context.$implicit[0].group),l(n,15,0,"Text Dateien"===n.context.$implicit[0].group),l(n,17,0,"Audio Dateien"===n.context.$implicit[0].group),l(n,19,0,"Video Dateien"===n.context.$implicit[0].group),l(n,21,0,"Andere Dateien"===n.context.$implicit[0].group),l(n,26,0,n.context.$implicit)},function(l,n){l(n,22,0,n.context.$implicit[0].group)})}function N(l){return e.Kb(0,[(l()(),e.qb(0,0,null,null,2,"div",[],null,null,null,null,null)),(l()(),e.hb(16777216,null,null,1,null,j)),e.pb(2,278528,null,0,c.k,[e.O,e.L,e.s],{ngForOf:[0,"ngForOf"]},null),(l()(),e.qb(3,0,null,null,3,"div",[["class","fixed-action-btn"],["style","bottom: 45px; right: 24px;"]],null,null,null,null,null)),(l()(),e.qb(4,0,null,null,2,"a",[["class","btn-floating btn-large btn-color waves-light"],["mdbWavesEffect",""]],null,[[null,"click"]],function(l,n,u){var t=!0,i=l.component;return"click"===n&&(t=!1!==e.Ab(l,5).click(u)&&t),"click"===n&&(t=!1!==i.addModal.show()&&t),t},null,null)),e.pb(5,16384,null,0,o.Nc,[e.k],null,null),(l()(),e.qb(6,0,null,null,0,"i",[["class","fas fa-plus"]],null,null,null,null,null)),(l()(),e.qb(7,0,null,null,1,"app-add-modal",[],null,[[null,"getModalRef"]],function(l,n,u){var e=!0;return"getModalRef"===n&&(e=!1!==l.component.getModalRef(u)&&e),e},w,y)),e.pb(8,4308992,null,0,v,[m],null,{getModalRef:"getModalRef"})],function(l,n){l(n,2,0,n.component.groupedFiles),l(n,8,0)},null)}function P(l){return e.Kb(0,[(l()(),e.qb(0,0,null,null,1,"app-document-list",[],null,null,null,N,x)),e.pb(1,245760,null,0,q,[m,k.a],null,null)],function(l,n){l(n,1,0)},null)}var $=e.mb("app-document-list",q,P,{},{},[]),R=u("ZYCi"),E=function(){return function(){}}();u.d(n,"DocumentModuleNgFactory",function(){return Y});var Y=e.nb(t,[],function(l){return e.xb([e.yb(512,e.j,e.bb,[[8,[i.a,$,a.b,a.c,a.a,a.d]],[3,e.j],e.x]),e.yb(4608,c.n,c.m,[e.u,[2,c.z]]),e.yb(4608,o.Tc,o.Tc,[]),e.yb(4608,o.Sc,o.Sc,[e.j,e.z,e.q,o.Tc,e.g]),e.yb(4608,o.Z,o.Z,[e.E,o.Sc]),e.yb(4608,o.ec,o.ec,[]),e.yb(4608,o.cb,o.cb,[c.d]),e.yb(1073742336,c.c,c.c,[]),e.yb(1073742336,R.p,R.p,[[2,R.v],[2,R.n]]),e.yb(1073742336,E,E,[]),e.yb(1073742336,o.J,o.J,[]),e.yb(1073742336,o.Oc,o.Oc,[]),e.yb(1073742336,o.n,o.n,[]),e.yb(1073742336,o.C,o.C,[]),e.yb(1073742336,o.Lb,o.Lb,[]),e.yb(1073742336,o.N,o.N,[]),e.yb(1073742336,o.H,o.H,[]),e.yb(1073742336,o.Yb,o.Yb,[]),e.yb(1073742336,o.fc,o.fc,[]),e.yb(1073742336,t,t,[]),e.yb(1024,R.l,function(){return[[{path:"",component:q}]]},[])])})}}]);