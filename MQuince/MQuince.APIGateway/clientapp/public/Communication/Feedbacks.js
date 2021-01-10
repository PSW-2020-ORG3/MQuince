﻿﻿var app = new Vue({
	el: '#feedbacks',
	data: {
		feedbacks: [],
		privateFeedbacks: [],
		showLogIn: true,
		showLogOut: false,
		showCreateAppointment: false,
		showAddFeedback: false,
		showFeedback: true,
		showObserveFeedback: true,
		showObserveAppointment: false,
		userName: ''
	},
	created() {
		var role = localStorage.getItem('keyRole');
		var token = localStorage.getItem('keyToken');

		console.log("token",token);
		
		console.log("Username",this.userName);
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
			.get('/gateway/Feedback/GetByStatus', {
				params: {
					publish: true,
					approved: true
				}
			}).then(response => {
				this.feedbacks = response.data
			})

		axios
			.get('/gateway/Feedback/GetByStatus', {
				params: {
					publish: false,
					approved: false
				}
			}).then(response => {
				this.privateFeedbacks = response.data
			})

	},
	methods: {
		logIn: function () {
			axios
				.post("/gateway/User", {
					Username: "patient2",
					Password: "patient2"
				}).then((response) => {
					window.location.href = "/public/index.html";
					localStorage.setItem('keyToken', response.data.token)
					localStorage.setItem('keyRole', response.data.userRole)

				}, (error) => {
					console.log(error);
				});
		},
		logInAdmin: function () {
			axios
				.post("/gateway/User", {
					Username: "admin",
					Password: "admin"
				}).then((response) => {
					window.location.href = "/public/index.html";
					localStorage.setItem('keyToken', response.data.token)
					localStorage.setItem('keyRole', response.data.userRole)

				}, (error) => {
					console.log(error);
				});
		},
		logOut: function () {
			localStorage.removeItem('keyToken');
			localStorage.removeItem('keyRole');
			window.location.href = "/public/index.html";
		},onChange() {


			console.log(event.target.value)
			if(event.target.value == 'AllFeedbacks'){
				axios
					.get('/gateway/Feedback/GetByStatus', {
						params: {
							publish: true,
							approved: true
						}
					}).then(response => {
						this.feedbacks = response.data
					})
			}else {
				axios
					.get('/gateway/Feedback/GetByStatus', {
						params: {
							publish: false,
							approved: false
						}
					}).then(response => {
						this.privateFeedbacks = response.data
					})
			}
			
		},
		created() {
			if(event.target.value == 'AllFeedbacks'){
				axios
					.get('/gateway/Feedback/GetByStatus', {
						params: {
							publish: true,
							approved: true
						}
					}).then(response => {
						this.feedbacks = response.data
					})
			}else {
				axios
					.get('/gateway/Feedback/GetByStatus', {
						params: {
							publish: false,
							approved: false
						}
					}).then(response => {
						this.privateFeedbacks = response.data
					})
			}

		}
	}
})