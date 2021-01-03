﻿var app = new Vue({
	el: '#feedbacks',
	data: {
		feedbacks: [],
		showLogIn: true,
		showLogOut: false,
		showCreateAppointment: false,
		showAddFeedback: false,
		showFeedback: true,
		showObserveFeedback: true,
		showObserveAppointment: false
	},
	created() {
		var role = localStorage.getItem('keyRole');
		//role=2
		if (role == null) {
			this.showLogIn = true;
			this.showLogOut = false;
			this.showCreateAppointment = false;
			this.showAddFeedback = false;
			this.showFeedback = true;
			this.showObserveFeedback = true;
			this.showObserveAppointment = false
		}
		if (role == 0) { // patient
			this.showLogIn = false;
			this.showLogOut = true;
			this.showCreateAppointment = true;
			this.showAddFeedback = true;
			this.showFeedback = true;
			this.showObserveFeedback = true;
			this.showObserveAppointment = true;
		} else if (role == 1) { // admin
			this.showLogIn = false;
			this.showLogOut = true;
			this.showCreateAppointment = false;
			this.showAddFeedback = true;
			this.showFeedback = false;
			this.showObserveFeedback = false;
			this.showObserveAppointment = false;
		}
		axios
			.get('/api/Feedback/GetByStatus', {
				params: {
					publish: true,
					approved: true
				},
					headers: {
						'Authorization': localStorage.getItem('keyToken')
					}
				
			}).then(response => {
				this.feedbacks = response.data
			}).catch(error => {
						if (error.response.status === 400 || error.response.status === 403) {
							alert("You don't have access this page!");
							
						}
				});

	},
	mounted() {
		localStorage.getItem('keyToken');
		localStorage.getItem('keyRole');
		axios
			.get('/api/Feedback/GetByStatus', {
				params: {
					publish: true,
					approved: true
				},
					headers: {
						'Authorization': localStorage.getItem('keyToken')
					}
				
		}).then(response => {
			this.feedbacks = response.data;
		}).catch(error => {
			if (error.response.status === 400 || error.response.status === 403) {
				alert("You don't have access this page!");
				window.location.href = "/public/index.html";
			}
		});

	},
	methods: {
		
		
		
		logOut: function () {
			localStorage.removeItem('keyToken');
			localStorage.removeItem('keyRole');
			window.location.href = "/public/index.html";
		}
	}
})
