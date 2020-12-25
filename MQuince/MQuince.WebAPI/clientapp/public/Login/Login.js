
var app = new Vue({
	el: '#login',
	data: {
		username: '',
		password: ''
	},
	methods: {
		submit() {
			if (this.username.length !== 0 || this.password.length !== 0) {
				axios
					.post("/api/User", {
						username: this.username,
						password: this.password
					}).then(response => {
						const loggedIn = localStorage.getItem('user');
						localStorage.setItem('user-token', token);		
						if(response.status === 200){
							alert("Successful login!")
							window.location.href = "../../public/Appointment/Appointment.html";
							console.log(response.status)
							
						} else {
							alert("Not successful login!")
							console.log(response.status)
						}
					}).catch(function (error) {
						localStorage.removeItem('user-token')
						this.serverError = true;
						if (error.response) {
							console.log(error.response.status)
							
							alert("User don't exist!")
							
						} else if (error.request) {
							console.log(error.request)
							alert("Error!")
						}
					});
			
			}else {
				console.log(this.username);
				alert("You have to fill in the form!");
		}
	}
	}
		
 })

		
		