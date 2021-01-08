var app = new Vue({
	el: '#addFeedback',
	data: {
		Comment: "",
		Anonymous: false,
		Publish: true,
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
		

	},
	methods: {
		submit() {
			if (this.Comment != "") {
				axios
					.post("/gateway/Feedback", {
						Comment: this.Comment,
						Anonymous: this.Anonymous,
						Publish: this.Publish
					}, {
                            headers: {
                                'Authorization': localStorage.getItem('keyToken')
                        }
					
                    }).then(response => {
						//JSAlert.alert("Your feedback has been saved!");
						alert("Your feedback has been saved!")

						setTimeout(function () {
							if (window.location.hash != '#r') {
								window.location.hash = 'r';
								window.location.reload(1);
							}
						}, 3000);


					})
			} else {
				JSAlert.alert("You have to fill in the form");
			}

		},
		logOut: function () {
			localStorage.removeItem('keyToken');
			localStorage.removeItem('keyRole');
			window.location.href = "/public/index.html";
		}
	},
	mounted() {
		localStorage.getItem('keyToken');
		localStorage.getItem('keyRole');
		axios
			.post("/gateway/Feedback", {
						Comment: this.Comment,
						Anonymous: this.Anonymous,
						Publish: this.Publish
			}, {
				headers: {
						'Authorization': localStorage.getItem('keyToken')
					}
			}
		).then(response => {
			alert("Your feedback has been saved!")
		}).catch(error => {
			if (error.response.status === 400 || error.response.status === 403) {
				alert("You don't have access this page! Kako_");
				window.location.href = "/public/index.html";
			}
		});,
		logOut: function () {
			localStorage.removeItem('keyToken');
			localStorage.removeItem('keyRole');
			window.location.href = "/public/index.html";
		}

	}
})