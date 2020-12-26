
var app = new Vue({
	el: '#login',
	data: {
		username: '',
		password: ''
	},
	methods: {
		submit() {
			
			if (this.username.length !== 0 && this.password.length !== 0) {
				axios
					.post("/api/User", {
						username: this.username,
						password: this.password
					}).then(response => {
						var user = response.data
						localStorage.setItem("validToken", user.token)		
						
						if(user.userRole === 0){
							window.location.href = "../../public/index.html";

						} else {
							alert("Admin")
						}
					}).catch(function (error) {
						localStorage.removeItem('user-token')
						this.serverError = true;
						if (error.response.status === 400 || error.response.status === 403) {
							console.log(error.response.status)
							alert("Username doesn't exist or username/password is incorrect!")

						} else if (error.request) {
							console.log(error.request)
							alert("Error!")
						}
					});
			}else {
				console.log(this.username);
				alert("You have to fill in the form!");
		}
	},
	
		retrieveToken(state, token){
			state.token = token
		}
	}
		
 })

		
		