Vue.component("register4", {
    data: function () {
        return {

        }
    },
    template: ` 
    <div class="container" id="addFeedback">
            <!-- Contact Section Heading-->
            <h2 class="page-section-heading text-center text-uppercase text-secondary mb-0">Registration</h2>

            <h5 class=" text-center  mb-0 text-uppercase" style="color:#1abc9c; margin-top: 2rem;">Patient account setup</h5>
            <!-- Icon Divider-->
            <!-- Contact Section Form-->
            <div class="row section-design">
                <div class="col-lg-8 mx-auto">
                    <!-- To configure the contact form email address, go to mail/contact_me.php and update the email address in the PHP file on line 19.-->
                    <form id="contactForm" name="sentMessage" novalidate="novalidate">

                        <div class="control-group">
                            <div class="form-group floating-label-form-group controls mb-0 pb-2" style="color: #6c757d;opacity: 1 ">
                                <label>Password</label>
                                <input class="form-control" id="name" type="password" placeholder="Password" required="required" data-validation-required-message="Please enter your name." />
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>

                        <div class="control-group">
                            <div class="form-group floating-label-form-group controls mb-0 pb-2" style="color: #6c757d;opacity: 1 ">
                                <label>Confirm password</label>
                                <input class="form-control" id="name" type="password" placeholder="Confirm password" required="required" data-validation-required-message="Please enter your name." />
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>

                        <h5 class=" text-center  mb-0 text-uppercase" style="color:#1abc9c; margin-top: 2rem;">Profile picture</h5>
                        
                        <br />
                        <div id="success"></div>
                        <div class="form-group"><router-link to="/reg3"><button style="margin-left: 15%; width: 20%;"v-on:click="submit()" class="btn btn-primary btn-xl" id="sendMessageButton" type="button">Previous</button></router-link>
                        <button style="margin-left: 30%; width: 20%;" v-on:click="submit()" class="btn btn-primary btn-xl" id="sendMessageButton" type="button">Finish</button></div>
                    </form>
                </div>
            </div>
        </div>
`
    ,
    methods: {

    }
});