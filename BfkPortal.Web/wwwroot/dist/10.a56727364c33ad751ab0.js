(window.webpackJsonp=window.webpackJsonp||[]).push([[10],{qNYQ:function(n,l,t){"use strict";t.r(l);var u=t("CcnG"),e=function(){return function(){}}(),i=t("pMnS"),o=t("Ip0R"),s=t("cx5N"),r=t("wd/R"),c=function(){function n(n){this.router=n,this.checkColor=s.a.checkColor}return n.prototype.goToAppointmentList=function(){this.router.navigate(["/home/appointments/list"],{fragment:this.appointment.id.toString(),queryParams:{date:r(this.appointment.from).format("DD.MM.YYYY")}})},n.prototype.ngOnInit=function(){this.navigationExtras={fragment:this.appointment.id.toString()}},n.prototype.ngOnChanges=function(n){console.log(n),n.appointment&&(this.appointment=n.appointment.currentValue)},n.prototype.checkWidth=function(){return window.innerWidth},n}(),p=t("ZYCi"),a=u.ob({encapsulation:0,styles:[[".txtOverflow[_ngcontent-%COMP%]{word-break:break-all}.color-height[_ngcontent-%COMP%]{height:1vh}"]],data:{}});function b(n){return u.Kb(0,[(n()(),u.qb(0,0,null,null,2,"span",[],null,null,null,null,null)),(n()(),u.Ib(1,null,[" (bis ",") "])),u.Eb(2,4)],null,function(n,l){var t=l.component,e=u.Jb(l,1,0,n(l,2,0,u.Ab(l.parent,0),t.appointment.to,"dd.MM.yyyy","","de-AT"));n(l,1,0,e)})}function m(n){return u.Kb(0,[u.Cb(0,o.e,[u.u]),(n()(),u.qb(1,0,null,null,15,"div",[["class",""]],null,[[null,"click"]],function(n,l,t){var u=!0;return"click"===l&&(u=!1!==n.component.goToAppointmentList()&&u),u},null,null)),(n()(),u.qb(2,0,null,null,14,"div",[["class"," z-depth-3 mb-1  list-group-item list-color"]],null,null,null,null,null)),(n()(),u.qb(3,0,null,null,10,"div",[],null,null,null,null,null)),(n()(),u.qb(4,0,null,null,9,"div",[["class","row  justify-content-between"],["style","height:100%; width: 100%"]],null,null,null,null,null)),(n()(),u.qb(5,0,null,null,2,"h5",[["class","col-md-6 col-sm-12 txtOverflow"]],null,null,null,null,null)),(n()(),u.qb(6,0,null,null,1,"b",[],null,null,null,null,null)),(n()(),u.Ib(7,null,[""," "])),(n()(),u.qb(8,0,null,null,5,"p",[["class"," mb-0 col-md-6 col-sm-12 txtOverflow"]],null,null,null,null,null)),(n()(),u.Ib(9,null,[""," - "," "])),u.Eb(10,4),u.Eb(11,4),(n()(),u.hb(16777216,null,null,1,null,b)),u.pb(13,16384,null,0,o.l,[u.O,u.L],{ngIf:[0,"ngIf"]},null),(n()(),u.qb(14,0,null,null,2,"div",[["class","col-12 color-height"]],null,null,null,null,null)),u.pb(15,278528,null,0,o.o,[u.t,u.k,u.D],{ngStyle:[0,"ngStyle"]},null),u.Db(16,{"background-color":0})],function(n,l){var t=l.component;n(l,13,0,t.appointment.moreDays);var u=n(l,16,0,t.checkColor(t.appointment));n(l,15,0,u)},function(n,l){var t=l.component;n(l,7,0,t.appointment.title);var e=u.Jb(l,9,0,n(l,10,0,u.Ab(l,0),t.appointment.from,"HH:mm","","de-AT")),i=u.Jb(l,9,1,n(l,11,0,u.Ab(l,0),t.appointment.to,"HH:mm","","de-AT"));n(l,9,0,e,i)})}var f=t("KzlR"),h=t("i0AA"),g=t("4uNl"),d=t("6BtO"),y=t("LvDl"),v=t("3Owf"),A=t("h8TB"),q=t("K52H"),w=t("UkzC"),O=t("NlNA"),k=function(){function n(n,l,t,u){this.appointmentService=n,this.sessionUser=l,this.navbarButtons=t,this.router=u,this.myAppointments=[],this.myShifts=[],this.myAppointmentsCounter=0,this.myShiftsCounter=0}return n.prototype.ngOnInit=function(){var n=this;console.log(this.navbarButtons),this.navbarButtons.changeToOverviewView(),this._allAppointmentsSubscription=this.appointmentService._allAppointments.subscribe(function(l){n.getLastAppointments(l),setTimeout(function(){return n.appointmentService._homeIsLoading.next(!1)},1e3)})},n.prototype.checkWidth=function(){return window.innerWidth},n.prototype.getLastAppointments=function(n){var l=this;this.myAppointments=[],this.myShifts=[],n.sort(function(n,l){return n.from.getTime()-l.from.getTime()}),n.forEach(function(n){(l.sessionUser.getUser().entitlements.includes(w.b[w.b.AdminBwst])||l.sessionUser.getUser().entitlements.includes(w.b[w.b.UserBwst]))&&n.type!==w.a[w.a.FreierDienst]&&n.type!==w.a[w.a.Vollversammlung]&&n.owner.email===l.sessionUser.getUser().email&&l.myShiftsCounter<=5&&n.from.getTime()>(new Date).getTime()&&(l.myShifts.push(n),l.myShiftsCounter++),(l.sessionUser.getUser().entitlements.includes(w.b[w.b.AdminBfk])||l.sessionUser.getUser().entitlements.includes(w.b[w.b.UserBfk]))&&n.type===w.a[w.a.Vollversammlung]&&(O.a.checkparticipations(n.participations[0])?n.participations.includes(l.sessionUser.getUser().email)&&l.myAppointmentsCounter<=5&&n.from.getTime()>(new Date).getTime()&&(l.myAppointments.push(n),l.myAppointmentsCounter++):l.checkForParticipationInOrg(n)&&l.myAppointmentsCounter<=5&&n.from.getTime()>(new Date).getTime()&&(l.myAppointments.push(n),l.myAppointmentsCounter++))})},n.prototype.checkForParticipationInOrg=function(n){for(var l=0,t=n.participations;l<t.length;l++)for(var u=t[l],e=0,i=this.sessionUser.getUser().memberships;e<i.length;e++)if(y.isEqual(u,i[e]))return!0;return!1},n.prototype.ngOnDestroy=function(){this._allAppointmentsSubscription.unsubscribe()},n}(),C=u.ob({encapsulation:0,styles:[[".set-flex[_ngcontent-%COMP%]{flex:1}"]],data:{}});function I(n){return u.Kb(0,[(n()(),u.qb(0,0,null,null,2,"div",[],null,null,null,null,null)),(n()(),u.qb(1,0,null,null,1,"app-overview-list",[],null,null,null,m,a)),u.pb(2,638976,null,0,c,[p.n],{appointment:[0,"appointment"]},null)],function(n,l){n(l,2,0,l.context.$implicit)},null)}function x(n){return u.Kb(0,[(n()(),u.qb(0,0,null,null,4,"div",[["class"," set-flex list-group "]],null,null,null,null,null)),(n()(),u.qb(1,0,null,null,1,"h4",[["class"," align-self-center"]],null,null,null,null,null)),(n()(),u.Ib(-1,null,["N\xe4chste Dienste"])),(n()(),u.hb(16777216,null,null,1,null,I)),u.pb(4,278528,null,0,o.k,[u.O,u.L,u.s],{ngForOf:[0,"ngForOf"]},null)],function(n,l){n(l,4,0,l.component.myShifts)},null)}function T(n){return u.Kb(0,[(n()(),u.qb(0,0,null,null,2,"div",[],null,null,null,null,null)),(n()(),u.qb(1,0,null,null,1,"app-overview-list",[],null,null,null,m,a)),u.pb(2,638976,null,0,c,[p.n],{appointment:[0,"appointment"]},null)],function(n,l){n(l,2,0,l.context.$implicit)},null)}function S(n){return u.Kb(0,[(n()(),u.qb(0,0,null,null,4,"div",[["class"," set-flex list-group "]],null,null,null,null,null)),(n()(),u.qb(1,0,null,null,1,"h4",[["class","align-self-center"]],null,null,null,null,null)),(n()(),u.Ib(-1,null,["N\xe4chste Termine"])),(n()(),u.hb(16777216,null,null,1,null,T)),u.pb(4,278528,null,0,o.k,[u.O,u.L,u.s],{ngForOf:[0,"ngForOf"]},null)],function(n,l){n(l,4,0,l.component.myAppointments)},null)}function L(n){return u.Kb(0,[(n()(),u.qb(0,0,null,null,4,"div",[["class","d-flex flex-row justify-content-between"]],null,null,null,null,null)),(n()(),u.hb(16777216,null,null,1,null,x)),u.pb(2,16384,null,0,o.l,[u.O,u.L],{ngIf:[0,"ngIf"]},null),(n()(),u.hb(16777216,null,null,1,null,S)),u.pb(4,16384,null,0,o.l,[u.O,u.L],{ngIf:[0,"ngIf"]},null)],function(n,l){var t=l.component;n(l,2,0,0!=t.myShifts.length),n(l,4,0,0!=t.myAppointments.length)},null)}function D(n){return u.Kb(0,[(n()(),u.qb(0,0,null,null,2,"div",[],null,null,null,null,null)),(n()(),u.hb(16777216,null,null,1,null,L)),u.pb(2,16384,null,0,o.l,[u.O,u.L],{ngIf:[0,"ngIf"],ngIfElse:[1,"ngIfElse"]},null)],function(n,l){n(l,2,0,l.component.checkWidth()>=550,u.Ab(l.parent.parent,3))},null)}function K(n){return u.Kb(0,[(n()(),u.qb(0,0,null,null,2,"div",[],null,null,null,null,null)),(n()(),u.hb(16777216,null,null,1,null,D)),u.pb(2,16384,null,0,o.l,[u.O,u.L],{ngIf:[0,"ngIf"],ngIfElse:[1,"ngIfElse"]},null)],function(n,l){var t=l.component;n(l,2,0,0!=t.myShifts.length||0!=t.myAppointments.length,u.Ab(l.parent,4))},null)}function N(n){return u.Kb(0,[(n()(),u.qb(0,0,null,null,2,"div",[],null,null,null,null,null)),(n()(),u.qb(1,0,null,null,1,"app-overview-list",[],null,null,null,m,a)),u.pb(2,638976,null,0,c,[p.n],{appointment:[0,"appointment"]},null)],function(n,l){n(l,2,0,l.context.$implicit)},null)}function U(n){return u.Kb(0,[(n()(),u.qb(0,0,null,null,2,"div",[],null,null,null,null,null)),(n()(),u.qb(1,0,null,null,1,"app-overview-list",[],null,null,null,m,a)),u.pb(2,638976,null,0,c,[p.n],{appointment:[0,"appointment"]},null)],function(n,l){n(l,2,0,l.context.$implicit)},null)}function B(n){return u.Kb(0,[(n()(),u.qb(0,0,null,null,12,"mdb-tabset",[["id","userMngmtTabs"]],[[2,"tab-container",null]],null,null,f.T,f.x)),u.Fb(512,null,h.Nc,h.Nc,[u.k]),u.pb(2,4440064,[["OverviewTabs",4]],0,h.Bc,[u.B,h.Cc,h.Nc,u.h,u.D],{buttonClass:[0,"buttonClass"],contentClass:[1,"contentClass"]},null),(n()(),u.qb(3,0,null,0,4,"mdb-tab",[["heading","N\xe4chste Dienste"]],[[2,"tab-pane",null],[2,"fade",null]],null,null,null,null)),u.pb(4,212992,null,0,h.yc,[u.B,h.Bc,u.k,u.D],{heading:[0,"heading"]},null),(n()(),u.qb(5,0,null,null,2,"div",[["class"," set-flex list-group "]],null,null,null,null,null)),(n()(),u.hb(16777216,null,null,1,null,N)),u.pb(7,278528,null,0,o.k,[u.O,u.L,u.s],{ngForOf:[0,"ngForOf"]},null),(n()(),u.qb(8,0,null,0,4,"mdb-tab",[["heading","N\xe4chste Termine"]],[[2,"tab-pane",null],[2,"fade",null]],null,null,null,null)),u.pb(9,212992,null,0,h.yc,[u.B,h.Bc,u.k,u.D],{heading:[0,"heading"]},null),(n()(),u.qb(10,0,null,null,2,"div",[["class"," set-flex list-group "]],null,null,null,null,null)),(n()(),u.hb(16777216,null,null,1,null,U)),u.pb(12,278528,null,0,o.k,[u.O,u.L,u.s],{ngForOf:[0,"ngForOf"]},null)],function(n,l){var t=l.component;n(l,2,0,"md-tabs tabs-2 pills-secondary white",""),n(l,4,0,"N\xe4chste Dienste"),n(l,7,0,t.myShifts),n(l,9,0,"N\xe4chste Termine"),n(l,12,0,t.myAppointments)},function(n,l){n(l,0,0,u.Ab(l,2).clazz),n(l,3,0,u.Ab(l,4).addClass,u.Ab(l,4).test),n(l,8,0,u.Ab(l,9).addClass,u.Ab(l,9).test)})}function F(n){return u.Kb(0,[(n()(),u.qb(0,0,null,null,1,"h1",[["class","d-flex justify-content-center h1-responsive"]],null,null,null,null,null)),(n()(),u.Ib(-1,null,["Keine Dienste oder Termine"])),(n()(),u.qb(2,0,null,null,2,"div",[["class","d-flex justify-content-center"]],null,null,null,null,null)),(n()(),u.qb(3,0,null,null,1,"button",[["class","btn btn-color btn-rounded"]],null,[[null,"click"]],function(n,l,t){var u=!0;return"click"===l&&(u=!1!==n.component.router.navigate(["home/marketplace"])&&u),u},null,null)),(n()(),u.Ib(-1,null,["Zum Marktplatz"]))],null,null)}function E(n){return u.Kb(0,[(n()(),u.qb(0,0,null,null,1,"app-loading-screen",[],null,null,null,g.b,g.a)),u.pb(1,114688,null,0,d.a,[],null,null)],function(n,l){n(l,1,0)},null)}function M(n){return u.Kb(0,[(n()(),u.hb(16777216,null,null,2,null,K)),u.pb(1,16384,null,0,o.l,[u.O,u.L],{ngIf:[0,"ngIf"],ngIfElse:[1,"ngIfElse"]},null),u.Cb(131072,o.b,[u.h]),(n()(),u.hb(0,[["small_Devices",2]],null,0,null,B)),(n()(),u.hb(0,[["noAppointments",2]],null,0,null,F)),(n()(),u.hb(0,[["isLoading",2]],null,0,null,E))],function(n,l){var t=l.component;n(l,1,0,!u.Jb(l,1,0,u.Ab(l,2).transform(t.appointmentService._homeIsLoading)),u.Ab(l,5))},null)}function _(n){return u.Kb(0,[(n()(),u.qb(0,0,null,null,1,"app-overview",[],null,null,null,M,C)),u.pb(1,245760,null,0,k,[v.a,A.a,q.a,p.n],null,null)],function(n,l){n(l,1,0)},null)}var z=u.mb("app-overview",k,_,{},{},[]),P=t("xkgV"),j=function(){return function(){}}(),H=t("PCNd");t.d(l,"HomeModuleNgFactory",function(){return J});var J=u.nb(e,[],function(n){return u.xb([u.yb(512,u.j,u.bb,[[8,[i.a,z,f.b,f.c]],[3,u.j],u.x]),u.yb(4608,o.n,o.m,[u.u,[2,o.z]]),u.yb(4608,P.d,P.d,[]),u.yb(4608,h.cb,h.cb,[o.d]),u.yb(4608,h.Cc,h.Cc,[]),u.yb(1073742336,o.c,o.c,[]),u.yb(1073742336,p.p,p.p,[[2,p.v],[2,p.n]]),u.yb(1073742336,j,j,[]),u.yb(1073742336,h.n,h.n,[]),u.yb(1073742336,h.Oc,h.Oc,[]),u.yb(1073742336,h.C,h.C,[]),u.yb(1073742336,h.N,h.N,[]),u.yb(1073742336,h.Lb,h.Lb,[]),u.yb(1073742336,P.a,P.a,[]),u.yb(1073742336,H.a,H.a,[]),u.yb(1073742336,h.Ac,h.Ac,[]),u.yb(1073742336,e,e,[]),u.yb(1024,p.l,function(){return[[{path:"",component:k}]]},[])])})}}]);