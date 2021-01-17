var app = new Vue({
	el: '#statistics',
	data: {
		status: "Published",
		event: null,
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
			.get('/gateway/ScheduleEvent', {
				
			}).then(response => {
				this.event = response.data
				console.log("AAAA", this.event)
			})
	},
	methods: {
		approve: function (fdb) {
			
        },
		logOut: function () {
			localStorage.removeItem('keyToken');
			localStorage.removeItem('keyRole');
			window.location.href = "/public/index.html";
		}
	}
})