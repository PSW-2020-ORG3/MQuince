var app = new Vue({
    el: '#login',
    data: function () {
        return {
            username: '',
            password: ''
        }
    },
    template: ` 
	<div class="container">
            <h5 class=" text-center  mb-0 text-uppercase" style="margin-top: 2rem;">Login</h5>
    
            <div class="row section-design">
                <div class="col-lg-8 mx-auto">
                    <br/>
                   
                    <form id="contactForm" name="sentMessage" novalidate="novalidate">
    
                         <div class="control-group">
                            <div class="form-group controls mb-0 pb-2" style=" color: #6c757d;opacity: 1;">
                                <input v-model="username" placeholder="Username" class="form-control" id="name" type="text"  />
                            </div>
                        </div>

                        <div class="control-group">
                            <div class="form-group controls mb-0 pb-2" style=" color: #6c757d;opacity: 1;">
                                <input v-model="password" placeholder="Password" class="form-control" id="password" type="password"  />
                            </div>
                        </div>

                        <div  class="form-group">
                              <button v-on:click="login" style="background: #1977cc;margin-top: 15px;margin-left: 40%; width: 20%;" class="btn btn-primary btn-xl" id="sendMessageButton" type="button">Login</button>
                        </div>
                    
                       
                       </form>
                <div>
                </div>
                </div>
            </div>
        </div>
`,
    methods: {
        login: function () {
            axios
                .post("/gateway/User", {
                    Username: this.username,
                    Password: this.password
                }).then((response) => {
                    window.location.href = "/public/index.html";
                    localStorage.setItem('keyToken', response.data.token)
                    localStorage.setItem('keyRole', response.data.userRole)
                    localStorage.setItem('keyGuid', response.data.id)
                }, (error) => {
                    alert("Invalid credentials")
                    this.username = ''
                    this.password =''
                });
        }
    }
});