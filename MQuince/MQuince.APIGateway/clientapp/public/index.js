﻿var app = new Vue({
	el: '#index',
	data: {
		showLogIn: true,
		showLogOut: false,
		showCreateAppointment: false,
		showAddFeedback: false,
		showFeedback: false,
		showObserveFeedback: false,
		showObserveAppointment: false,
		isAdmin: false,
		currentRole: null

	},
	mounted() {
		var role = localStorage.getItem('keyRole');
		this.currentRole = role;
		//role=2
		if (role == null) {
			this.showLogIn = true;
			this.showLogOut = false;
			this.showCreateAppointment = false;
			this.showAddFeedback = false;
			this.showFeedback = true;
			this.showObserveFeedback = true;
			this.showObserveAppointment = false;
			this.isAdmin = false;
        }
		if (role == 0) { // patient
			this.showLogIn = false;
			this.showLogOut = true;
			this.showCreateAppointment = true;
			this.showAddFeedback = true;
			this.showFeedback = true;
			this.showObserveFeedback = true;
			this.showObserveAppointment = true;
			this.isAdmin = false;
		} else if (role == 1) { // admin
			window.location.href = "/public/Communication/AdminFeedback.html";
			this.showLogIn = false;
			this.showLogOut = true;
			this.showCreateAppointment = false;
			this.showAddFeedback = true;
			this.showFeedback = false;
			this.showObserveFeedback = false;
			this.showObserveAppointment = false;
			this.isAdmin = true;
		}
	},
	methods: {
		logIn: function () {
			axios
				.post("/gateway/User", {
					Username: "admin",
					Password: "admin"
				}).then((response) => {
					console.log('test')
					localStorage.setItem('keyToken', response.data.token)
					localStorage.setItem('keyRole', response.data.userRole)
					}, (error) => {
						console.log(error);
					});
		},
		logOut: function () {
			localStorage.removeItem('keyToken');
			localStorage.removeItem('keyRole')
        }
	}
	
})