(window.webpackJsonp=window.webpackJsonp||[]).push([[9],{qNYQ:function(n,l,t){"use strict";t.r(l);var u=t("CcnG"),e=function(){return function(){}}(),i=t("pMnS"),o=t("Ip0R"),r=t("cx5N"),s=t("wd/R"),c=function(){function n(n){this.router=n,this.checkColor=r.a.checkColor}return n.prototype.goToAppointmentList=function(){this.router.navigate(["/home/appointments/list"],{fragment:this.appointment.id.toString(),queryParams:{date:s(this.appointment.from).format("DD.MM.YYYY")}})},n.prototype.ngOnInit=function(){this.navigationExtras={fragment:this.appointment.id.toString()}},n.prototype.checkWidth=function(){return window.innerWidth},n}(),a=t("ZYCi"),p=u.pb({encapsulation:0,styles:[[".txtOverflow[_ngcontent-%COMP%]{word-break:break-all}.color-height[_ngcontent-%COMP%]{height:1vh}"]],data:{}});function b(n){return u.Lb(0,[(n()(),u.rb(0,0,null,null,1,"span",[],null,null,null,null,null)),(n()(),u.Jb(1,null,[" (bis ",".",".",") "]))],null,function(n,l){var t=l.component;n(l,1,0,t.appointment.to.getDate(),t.appointment.to.getMonth()+1,t.appointment.to.getFullYear())})}function m(n){return u.Lb(0,[(n()(),u.rb(0,0,null,null,1,"p",[["class","col-12"]],null,null,null,null,null)),(n()(),u.Jb(1,null,[" (bis ",".",".",") "]))],null,function(n,l){var t=l.component;n(l,1,0,t.appointment.to.getDate(),t.appointment.to.getMonth()+1,t.appointment.to.getFullYear())})}function f(n){return u.Lb(0,[(n()(),u.rb(0,0,null,null,15,"div",[["class",""]],null,[[null,"click"]],function(n,l,t){var u=!0;return"click"===l&&(u=!1!==n.component.goToAppointmentList()&&u),u},null,null)),(n()(),u.rb(1,0,null,null,14,"div",[["class"," z-depth-3 mb-1  list-group-item list-color"]],null,null,null,null,null)),(n()(),u.rb(2,0,null,null,10,"div",[],null,null,null,null,null)),(n()(),u.rb(3,0,null,null,9,"div",[["class","row  justify-content-between"],["style","height:100%; width: 100%"]],null,null,null,null,null)),(n()(),u.rb(4,0,null,null,2,"h5",[["class","col-md-6 col-sm-12 txtOverflow"]],null,null,null,null,null)),(n()(),u.rb(5,0,null,null,1,"b",[],null,null,null,null,null)),(n()(),u.Jb(6,null,[""," "])),(n()(),u.rb(7,0,null,null,3,"p",[["class"," mb-0 col-md-6 col-sm-12 txtOverflow"]],null,null,null,null,null)),(n()(),u.Jb(8,null,["",":",""," - "," :",""," "])),(n()(),u.ib(16777216,null,null,1,null,b)),u.qb(10,16384,null,0,o.k,[u.P,u.M],{ngIf:[0,"ngIf"]},null),(n()(),u.ib(16777216,null,null,1,null,m)),u.qb(12,16384,null,0,o.k,[u.P,u.M],{ngIf:[0,"ngIf"]},null),(n()(),u.rb(13,0,null,null,2,"div",[["class","col-12 color-height"]],null,null,null,null,null)),u.qb(14,278528,null,0,o.n,[u.t,u.k,u.E],{ngStyle:[0,"ngStyle"]},null),u.Eb(15,{"background-color":0})],function(n,l){var t=l.component;n(l,10,0,t.appointment.moreDays&&t.checkWidth()>1125),n(l,12,0,t.appointment.moreDays&&t.checkWidth()<1125);var u=n(l,15,0,t.checkColor(t.appointment));n(l,14,0,u)},function(n,l){var t=l.component;n(l,6,0,t.appointment.title),n(l,8,0,t.appointment.from.getHours(),t.appointment.from.getMinutes()<10?"0":"",t.appointment.from.getMinutes(),t.appointment.to.getHours(),t.appointment.to.getMinutes()<10?"0":"",t.appointment.to.getMinutes())})}var g=t("KzlR"),h=t("/7Gs"),d=t("LvDl"),v=t("3Owf"),y=t("h8TB"),k=t("K52H"),w=t("UkzC"),M=t("NlNA"),I=function(){function n(n,l,t,u){this.appointmentService=n,this.sessionUser=l,this.navbarButtons=t,this.router=u,this.myAppointments=[],this.myShifts=[],this.myAppointmentsCounter=0,this.myShiftsCounter=0}return n.prototype.ngOnInit=function(){var n=this;this.navbarButtons.changeToOverviewView(),this.appointmentService._allAppointments.subscribe(function(l){n.getLastAppointments(l)})},n.prototype.checkWidth=function(){return window.innerWidth},n.prototype.getLastAppointments=function(n){var l=this;this.myAppointments=[],this.myShifts=[],n.sort(function(n,l){return n.from.getTime()-l.from.getTime()}),n.forEach(function(n){(l.sessionUser.getUser().entitlements.includes(w.b[w.b.AdminBwst])||l.sessionUser.getUser().entitlements.includes(w.b[w.b.UserBwst]))&&(n.type===w.a[w.a.Dienst]||n.type===w.a[w.a.MarktplatzDienst])&&n.owner.email===l.sessionUser.getUser().email&&l.myShiftsCounter<=5&&n.from.getTime()>(new Date).getTime()&&(l.myShifts.push(n),l.myShiftsCounter++),(l.sessionUser.getUser().entitlements.includes(w.b[w.b.AdminBfk])||l.sessionUser.getUser().entitlements.includes(w.b[w.b.UserBfk]))&&n.type!==w.a[w.a.Dienst]&&n.type!==w.a[w.a.MarktplatzDienst]&&n.type!==w.a[w.a.FreierDienst]&&(M.a.checkparticipations(n.participations[0])?n.participations.includes(l.sessionUser.getUser().email)&&l.myAppointmentsCounter<=5&&n.from.getTime()>(new Date).getTime()&&(l.myAppointments.push(n),l.myAppointmentsCounter++):l.checkForParticipationInOrg(n)&&l.myAppointmentsCounter<=5&&n.from.getTime()>(new Date).getTime()&&(l.myAppointments.push(n),l.myAppointmentsCounter++))})},n.prototype.checkForParticipationInOrg=function(n){for(var l=0,t=n.participations;l<t.length;l++)for(var u=t[l],e=0,i=this.sessionUser.getUser().memberships;e<i.length;e++)if(d.isEqual(u,i[e]))return!0},n}(),q=u.pb({encapsulation:0,styles:[[".set-flex[_ngcontent-%COMP%]{flex:1}"]],data:{}});function A(n){return u.Lb(0,[(n()(),u.rb(0,0,null,null,2,"div",[],null,null,null,null,null)),(n()(),u.rb(1,0,null,null,1,"app-overview-list",[],null,null,null,f,p)),u.qb(2,114688,null,0,c,[a.n],{appointment:[0,"appointment"]},null)],function(n,l){n(l,2,0,l.context.$implicit)},null)}function B(n){return u.Lb(0,[(n()(),u.rb(0,0,null,null,4,"div",[["class"," set-flex list-group "]],null,null,null,null,null)),(n()(),u.rb(1,0,null,null,1,"h4",[["class"," align-self-center"]],null,null,null,null,null)),(n()(),u.Jb(-1,null,["N\xe4chste Dienste"])),(n()(),u.ib(16777216,null,null,1,null,A)),u.qb(4,278528,null,0,o.j,[u.P,u.M,u.s],{ngForOf:[0,"ngForOf"]},null)],function(n,l){n(l,4,0,l.component.myShifts)},null)}function C(n){return u.Lb(0,[(n()(),u.rb(0,0,null,null,2,"div",[],null,null,null,null,null)),(n()(),u.rb(1,0,null,null,1,"app-overview-list",[],null,null,null,f,p)),u.qb(2,114688,null,0,c,[a.n],{appointment:[0,"appointment"]},null)],function(n,l){n(l,2,0,l.context.$implicit)},null)}function D(n){return u.Lb(0,[(n()(),u.rb(0,0,null,null,4,"div",[["class"," set-flex list-group "]],null,null,null,null,null)),(n()(),u.rb(1,0,null,null,1,"h4",[["class","align-self-center"]],null,null,null,null,null)),(n()(),u.Jb(-1,null,["N\xe4chste Termine"])),(n()(),u.ib(16777216,null,null,1,null,C)),u.qb(4,278528,null,0,o.j,[u.P,u.M,u.s],{ngForOf:[0,"ngForOf"]},null)],function(n,l){n(l,4,0,l.component.myAppointments)},null)}function L(n){return u.Lb(0,[(n()(),u.rb(0,0,null,null,4,"div",[["class","d-flex flex-row justify-content-between"]],null,null,null,null,null)),(n()(),u.ib(16777216,null,null,1,null,B)),u.qb(2,16384,null,0,o.k,[u.P,u.M],{ngIf:[0,"ngIf"]},null),(n()(),u.ib(16777216,null,null,1,null,D)),u.qb(4,16384,null,0,o.k,[u.P,u.M],{ngIf:[0,"ngIf"]},null)],function(n,l){var t=l.component;n(l,2,0,0!=t.myShifts.length),n(l,4,0,0!=t.myAppointments.length)},null)}function z(n){return u.Lb(0,[(n()(),u.rb(0,0,null,null,2,"div",[],null,null,null,null,null)),(n()(),u.ib(16777216,null,null,1,null,L)),u.qb(2,16384,null,0,o.k,[u.P,u.M],{ngIf:[0,"ngIf"],ngIfElse:[1,"ngIfElse"]},null)],function(n,l){n(l,2,0,l.component.checkWidth()>=500,u.Bb(l.parent,2))},null)}function O(n){return u.Lb(0,[(n()(),u.rb(0,0,null,null,2,"div",[],null,null,null,null,null)),(n()(),u.rb(1,0,null,null,1,"app-overview-list",[],null,null,null,f,p)),u.qb(2,114688,null,0,c,[a.n],{appointment:[0,"appointment"]},null)],function(n,l){n(l,2,0,l.context.$implicit)},null)}function x(n){return u.Lb(0,[(n()(),u.rb(0,0,null,null,2,"div",[["class"," set-flex list-group "]],null,null,null,null,null)),(n()(),u.ib(16777216,null,null,1,null,O)),u.qb(2,278528,null,0,o.j,[u.P,u.M,u.s],{ngForOf:[0,"ngForOf"]},null)],function(n,l){n(l,2,0,l.component.myShifts)},null)}function S(n){return u.Lb(0,[(n()(),u.rb(0,0,null,null,2,"div",[],null,null,null,null,null)),(n()(),u.rb(1,0,null,null,1,"app-overview-list",[],null,null,null,f,p)),u.qb(2,114688,null,0,c,[a.n],{appointment:[0,"appointment"]},null)],function(n,l){n(l,2,0,l.context.$implicit)},null)}function P(n){return u.Lb(0,[(n()(),u.rb(0,0,null,null,2,"div",[["class"," set-flex list-group "]],null,null,null,null,null)),(n()(),u.ib(16777216,null,null,1,null,S)),u.qb(2,278528,null,0,o.j,[u.P,u.M,u.s],{ngForOf:[0,"ngForOf"]},null)],function(n,l){n(l,2,0,l.component.myAppointments)},null)}function T(n){return u.Lb(0,[(n()(),u.rb(0,0,null,null,10,"mdb-tabset",[["id","userMngmtTabs"]],[[2,"tab-container",null]],null,null,g.W,g.z)),u.Gb(512,null,h.Rc,h.Rc,[u.k]),u.qb(2,4440064,[["OverviewTabs",4]],0,h.Ec,[u.B,h.Fc,h.Rc],{buttonClass:[0,"buttonClass"],contentClass:[1,"contentClass"]},null),(n()(),u.rb(3,0,null,0,3,"mdb-tab",[["heading","N\xe4chste Dienste"]],[[2,"active",null],[2,"tab-pane",null],[2,"fade",null]],null,null,null,null)),u.qb(4,212992,null,0,h.Bc,[u.B,h.Ec,u.k],{heading:[0,"heading"]},null),(n()(),u.ib(16777216,null,null,1,null,x)),u.qb(6,16384,null,0,o.k,[u.P,u.M],{ngIf:[0,"ngIf"]},null),(n()(),u.rb(7,0,null,0,3,"mdb-tab",[["heading","N\xe4chste Termine"]],[[2,"active",null],[2,"tab-pane",null],[2,"fade",null]],null,null,null,null)),u.qb(8,212992,null,0,h.Bc,[u.B,h.Ec,u.k],{heading:[0,"heading"]},null),(n()(),u.ib(16777216,null,null,1,null,P)),u.qb(10,16384,null,0,o.k,[u.P,u.M],{ngIf:[0,"ngIf"]},null)],function(n,l){var t=l.component;n(l,2,0,"md-tabs tabs-2 pills-secondary white",""),n(l,4,0,"N\xe4chste Dienste"),n(l,6,0,0!=t.myAppointments.length),n(l,8,0,"N\xe4chste Termine"),n(l,10,0,0!=t.myAppointments.length)},function(n,l){n(l,0,0,u.Bb(l,2).clazz),n(l,3,0,u.Bb(l,4).active,u.Bb(l,4).addClass,u.Bb(l,4).test),n(l,7,0,u.Bb(l,8).active,u.Bb(l,8).addClass,u.Bb(l,8).test)})}function U(n){return u.Lb(0,[(n()(),u.rb(0,0,null,null,1,"h1",[["class","d-flex justify-content-center h1-responsive"]],null,null,null,null,null)),(n()(),u.Jb(-1,null,["Keine Dienste oder Termine"])),(n()(),u.rb(2,0,null,null,2,"div",[["class","d-flex justify-content-center"]],null,null,null,null,null)),(n()(),u.rb(3,0,null,null,1,"button",[["class","btn btn-color btn-rounded"]],null,[[null,"click"]],function(n,l,t){var u=!0;return"click"===l&&(u=!1!==n.component.router.navigate(["home/marketplace"])&&u),u},null,null)),(n()(),u.Jb(-1,null,["Zum Marktplatz"]))],null,null)}function F(n){return u.Lb(0,[(n()(),u.ib(16777216,null,null,1,null,z)),u.qb(1,16384,null,0,o.k,[u.P,u.M],{ngIf:[0,"ngIf"],ngIfElse:[1,"ngIfElse"]},null),(n()(),u.ib(0,[["small_Devices",2]],null,0,null,T)),(n()(),u.ib(0,[["noAppointments",2]],null,0,null,U))],function(n,l){var t=l.component;n(l,1,0,0!=t.myShifts.length||0!=t.myAppointments.length,u.Bb(l,3))},null)}function E(n){return u.Lb(0,[(n()(),u.rb(0,0,null,null,1,"app-overview",[],null,null,null,F,q)),u.qb(1,114688,null,0,I,[v.a,y.a,k.a,a.n],null,null)],function(n,l){n(l,1,0)},null)}var N=u.nb("app-overview",I,E,{},{},[]),j=function(){return function(){}}();t.d(l,"HomeModuleNgFactory",function(){return J});var J=u.ob(e,[],function(n){return u.yb([u.zb(512,u.j,u.cb,[[8,[i.a,N]],[3,u.j],u.x]),u.zb(4608,o.m,o.l,[u.u,[2,o.y]]),u.zb(4608,h.bb,h.bb,[o.c]),u.zb(1073742336,o.b,o.b,[]),u.zb(1073742336,a.p,a.p,[[2,a.v],[2,a.n]]),u.zb(1073742336,j,j,[]),u.zb(1073742336,h.m,h.m,[]),u.zb(1073742336,h.Sc,h.Sc,[]),u.zb(1073742336,h.B,h.B,[]),u.zb(1073742336,h.Dc,h.Dc,[]),u.zb(1073742336,e,e,[]),u.zb(1024,a.l,function(){return[[{path:"",component:I}]]},[])])})}}]);