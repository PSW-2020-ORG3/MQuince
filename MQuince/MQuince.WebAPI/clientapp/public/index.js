var app = new Vue({
	el: '#index',
	data: {
		showLogIn: true,
		showLogOut: false,
		showCreateAppointment: false,
		showAddFeedback: false,
		showFeedback: false,
		showObserveFeedback: false,
		showObserveAppointment: false
	},
	mounted() {
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
	},
	methods: {
		logOut: function () {
			localStorage.removeItem('keyToken');
			localStorage.removeItem('keyRole')
        }
		}
	
})