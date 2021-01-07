var app = new Vue({
    el: '#loginUser',
    data: function () {
        return {
            username: '',
			password: ''
        }
    },
    template: ` 
	<div id="Login">
		 <div class="loginbox">
				<h1>Login</h1>
					<form>
						<p>Username</p>
						<input type="text" name="" id="username" placeholder="Enter Username" v-model="username">
						<p>Password</p>
						<input type="password" name="" id="password" placeholder="Enter Password" v-model="password">
						<input type="button" name="" id="sendMessageButton" value="Login" v-on:click="submit">
					</form>
		</div>

					<div class="modal fade" id="myModal" role="dialog">
                        <div class="modal-dialog">
		                      <!-- Modal content-->
			                  <div class="modal-content">
					                <div class="modal-header">
								          <button type="button" class="close" data-dismiss="modal">&times;</button>
									</div>
							  <div class="modal-body">
                              <p>Please enter username.</p>
							 </div>
							 <div class="modal-footer">
                              <button type="button" class="btn btn-default" data-dismiss="modal" >Ok</button>
                             </div>
                          </div>
                        </div>
					</div>

					<div class="modal fade" id="myModal1" role="dialog">
                        <div class="modal-dialog">
		                      <!-- Modal content-->
			                  <div class="modal-content">
					                <div class="modal-header">
								          <button type="button" class="close" data-dismiss="modal">&times;</button>
									</div>
							  <div class="modal-body">
                              <p>Please enter password.</p>
							 </div>
							 <div class="modal-footer">
                              <button type="button" class="btn btn-default" data-dismiss="modal" >Ok</button>
                             </div>
                          </div>
                        </div>
					</div>

				<div class="modal fade" id="myModal2" role="dialog">
                        <div class="modal-dialog">
		                      <!-- Modal content-->
			                  <div class="modal-content">
					                <div class="modal-header">
								          <button type="button" class="close" data-dismiss="modal">&times;</button>
									</div>
							  <div class="modal-body">
                              <p>Wrong username or password.</p>
							 </div>
							 <div class="modal-footer">
                              <button type="button" class="btn btn-default" data-dismiss="modal" >Ok</button>
                             </div>
                          </div>
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
							window.location.href = "/public/Login/LoginUser.html";
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