var app = new Vue({
	el: '#adminFeedback',
	data: {
		status: "Published",
		feedbacks: [],
		showLogIn: false,
        showLogOut: true,
        showCreateAppointment: false,
        showAddFeedback: false,
		showFeedback: false,
        showObserveFeedback: false,
        showObserveAppointment: false,
		showFeedbackAdmin: true
	},
	created() {
		var role = localStorage.getItem('keyRole');

		if (role == 0) {
			window.location.href = "/public/index.html";
		} else if (role == null) {
			window.location.href = "/public/Login/Login.html";
		}

		//role=2
		if (role == null) {
			this.showLogIn = true;
			this.showLogOut = false;
			this.showCreateAppointment = false;
			this.showAddFeedback = false;
			this.showFeedback = true;
			this.showObserveFeedback = true;
			this.showObserveAppointment = false;
			this.showFeedbackAdmin = false;
		}
		if (role == 0) { // patient
			this.showLogIn = false;
			this.showLogOut = true;
			this.showCreateAppointment = true;
			this.showAddFeedback = true;
			this.showFeedback = true;
			this.showObserveFeedback = true;
			this.showObserveAppointment = true;
			this.showFeedbackAdmin = false;
		} else if (role == 1) { // admin
			this.showLogIn = false;
			this.showLogOut = true;
			this.showCreateAppointment = false;
			this.showAddFeedback = false;
			this.showFeedback = false;
			this.showObserveFeedback = false;
			this.showObserveAppointment = false;
			this.showFeedbackAdmin = true;
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
	},
	methods: {
		statusChanged() {
			if (this.status == "Published") {
				axios
					.get('/gateway/Feedback/GetByStatus', {
						params: {
							publish: true,
							approved: true
						}
					}).then(response => {
						this.feedbacks = response.data
					})
			}
			else if (this.status == "Pending") {
				axios
					.get('/gateway/Feedback/GetByStatus', {
						params: {
							publish: true,
							approved: false
						}
					}).then(response => {
						this.feedbacks = response.data
					})
			}
			else if (this.status == "Private") {
				axios
					.get('/gateway/Feedback/GetByStatus', {
						params: {
							publish: false,
							approved: false
						}
					}).then(response => {
						this.feedbacks = response.data
					})
			}
		},
		approve: function (fdb) {
			var self = this

			alert("You  have successfully published a feedback!")
				fdb.entityDTO.approved = true
				axios
					.put("/gateway/Feedback/Approve/" + fdb.id, null, {
						headers: {
							"Authorization": localStorage.getItem('keyToken')
						}
					}
					)
					.then(response => {
						for (i = 0; i < self.feedbacks.length; i++) {
							if (self.feedbacks[i].id == fdb.id) {
								self.feedbacks.splice(i, 1);
								break;
							}
						}
					})
        },
		logIn: function () {
			window.location.href = "/public/Login/Login.html";
		},
		logOut: function () {
			localStorage.removeItem('keyToken');
			localStorage.removeItem('keyRole');
			window.location.href = "/public/index.html";
		}
	}
})