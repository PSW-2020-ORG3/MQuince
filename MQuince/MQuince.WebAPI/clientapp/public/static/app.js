const homepage = { template: '<homepage></homepage>' }
const createAppointment = { template: '<homepage1></homepage1>'}
const test = { template:"<create-appointment></create-appointment>"}
const loginUser = { template: '<loginUser></loginUser>'}

const router = new VueRouter({
	routes: [
        { path: '/', name: 'homepage', component: homepage },
		{ path: '/createappointment', component: createAppointment },
		{ path: '/app', component: test }
		{ path: '/loginUser', component: loginUser }
		
	]
});


var app = new Vue({
	router,
	el: '#app'
});
