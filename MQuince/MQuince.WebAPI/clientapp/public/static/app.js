const homepage = { template: '<homepage></homepage>' }
const createAppointment = { template: '<homepage1></homepage1>'}
const test = { template:"<create-appointment></create-appointment>"}

const router = new VueRouter({
	routes: [
        { path: '/', component: homepage },
		{ path: '/createappointment', component: createAppointment },
		{ path: '/app', component: test }
		
	]
});


var app = new Vue({
	router,
	el: '#app'
});
