var app = new Vue({
    el: '#headerMain',
    data: function () {
        return {
            showLogIn: true,
            showLogOut: false,
            showCreateAppointment: false,
            showAddFeedback: false,
			showFeedback: true,
            showObserveFeedback: true,
            showObserveAppointment: false,
            showAdminFeedbacks: false,
			isAdmin: false
        }
    },
    template: ` 
	<div class="container">
        <header style="margin-top:10px" id="header" class="fixed-top">
        <div class="container d-flex align-items-center">
            <h1 class="logo mr-auto"><a href="/public/index.html">MQUINCE Medic</a></h1>
            <nav class="nav-menu d-none d-lg-block">
                <ul id="index">
                    <li><a href="/public/index.html">Home</a></li>
                    <li><a style="text-align: center; display: block" v-bind:hidden="!showAdminFeedbacks" href="/public/Communication/AdminFeedback.html">Feedbacks</a></li>
                    <li v-bind:hidden="!showFeedback" class="drop-down">
                        <a id="feedback" href="" class="feedback-btn" style="text-align: left; display: block">Feedback</a>
                        <ul class="drop-down-menu">
                            <li v-bind:hidden="!showAddFeedback"><a id="addFeedback" href="/public/Communication/AddFeedback.html">Add feedback</a></li>
                            <li v-bind:hidden="!showObserveFeedback"><a href="/public/Communication/Feedbacks.html">Observe feedbacks</a></li>
                        </ul>
                    </li>
                    <li v-bind:hidden="!showObserveAppointment"><a href="/public/Appointment/Appointment.html">Observe appointment</a></li>
                    <li v-bind:hidden="!showCreateAppointment" class="drop-down">
                        <a href="" class="appointment-btn scrollto" style="text-align: center; display: block; color:white">Create appointment</a>
                        <ul>
                            <li><a href="/public/Appointment/CreateAppointment.html">Standard appointment</a></li>
                            <li><a href="#">Recommended appointment</a></li>
                        </ul>
                    </li>
                    <li v-on:click="logIn" v-bind:hidden="!showLogIn"><a href="#">Log in</a></li>
                    <li v-on:click="logOut" v-bind:hidden="!showLogOut"><a href="#">Log out</a></li>
                </ul>
            </nav>
        </div>
    </header>
    </div>

`,
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
			this.showObserveAppointment = false;
			this.showAdminFeedbacks = false;
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
			this.showAdminFeedbacks = false;
			this.isAdmin = false;
		} else if (role == 1) { // admin
			this.showLogIn = false;
			this.showLogOut = true;
			this.showCreateAppointment = false;
			this.showAddFeedback = false;
			this.showFeedback = false;
			this.showObserveFeedback = false;
			this.showObserveAppointment = false;
			this.showAdminFeedbacks = true;
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
		}
	}

})