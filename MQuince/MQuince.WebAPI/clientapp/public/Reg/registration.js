const Register1 = { template: '<register1></register1>' }
const Register2 = { template: '<register2></register2>' }
const Register3 = { template: '<register3></register3>' }
const Register4 = { template: '<register4></register4>' }

const router = new VueRouter({
	routes: [
		{ path: '/', component: Register1, props: true },
		{ path: '/reg2', component: Register2 },
		{ path: '/reg3', component: Register3 },
		{ path: '/reg4', component: Register4 }
	],
	scrollBehavior(to, from, savedPosition) {
		return { x: 0, y: 0 };
	}
});

var app = new Vue({
	router,
	el: '#registartion'
});