var app = new Vue({
    el: '#loginUser',
    data: function () {
        return {
            username: '',
			password: ''
        }
    },
    template: ` 
	<div class="container">
            <!-- Contact Section Heading-->
            <h5 class=" text-center  mb-0 text-uppercase" style="margin-top: 2rem;">Login</h5>
            <!-- Icon Divider-->
            <!-- Contact Section Form-->
    
            <div class="row section-design">
                <div class="col-lg-8 mx-auto">
                    <br/>
                    <!-- To configure the contact form email address, go to mail/contact_me.php and update the email address in the PHP file on line 19.-->
                   
                    <form id="contactForm" name="sentMessage" novalidate="novalidate">
						<div class="control-group" style="margin-top:45px">
                            <div class="form-group floating-label-form-group controls mb-0 pb-2" style=" color: #6c757d;opacity: 1;">
                                <input v-model="username" class="form-control" id="username" type="text" placeholder="Username" required="required" data-validation-required-message="Please enter your username." />
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>
                        <div class="control-group">     
                            <div class="form-group floating-label-form-group controls mb-0 pb-2" style=" color: #6c757d;opacity: 1;">
                                <input v-model="password" class="form-control" id="password" type = "password" placeholder="Password" required="required" data-validation-required-message="Please enter your password." />
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>    
                        <br />
                        <div id="success"></div>
                        <div class="form-group"><button v-on:click="submit" style="background:#1977cc; margin-left: 40%;" class="btn btn-primary btn-xl" id="sendMessageButton">Login</button></div>
                    </form> 
                </div>
            </div>
    </div>
`, 
    methods: {
       
        
        submit: function () {
			
            if (this.username.length !== 0 &&  this.password !== 0) {
				axios
					.post("/api/User/", {
						username: this.username,
						password: this.password
					}).then(response => {
						
						localStorage.setItem('keyToken', response.data.token)
						localStorage.setItem('keyRole', response.data.userRole)
						
						
						if(response.data.userRole === 0){
							window.location.href = "/public/Communication/AddFeedback.html";
						} else if(response.data.userRole === 1) {
							window.location.href = "/public/Communication/AdminFeedback.html";
						}
					}).catch(error => {
						this.serverError = true;
						console.log(error.response.status)
						if (error.response.status === 400 || error.response.status === 403) {
							alert("Username doesn't exist or username/password is incorrect!")
						} else if (error.request) {
							console.log(error.request)
							alert("Error!")
						}
					});
			}else {
			
				alert("You have to fill in the form!");
		}
        }
    }
});