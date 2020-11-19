Vue.component("register2", {
    data: function () {
        return {
            
        }
    },
    template: ` 
    <div class="container" id="addFeedback">
            <!-- Contact Section Heading-->
            <h2 class="page-section-heading text-center text-uppercase text-secondary mb-0">Registration</h2>

            <h5 class=" text-center  mb-0 text-uppercase" style="color:#1abc9c; margin-top: 2rem;">Contact information</h5>
            <!-- Icon Divider-->
            <!-- Contact Section Form-->
            <div class="row section-design">
                <div class="col-lg-8 mx-auto">
                    <!-- To configure the contact form email address, go to mail/contact_me.php and update the email address in the PHP file on line 19.-->
                    <form id="contactForm" name="sentMessage" novalidate="novalidate">
                        <div class="control-group">
                            <div class="form-group floating-label-form-group controls mb-0 pb-2" style="color: #6c757d;opacity: 1 ">
                                <label>Email address</label>
                                <input class="form-control" id="name" type="text" placeholder="Email address" required="required" data-validation-required-message="Please enter your name." />
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>

                        <div class="control-group">
                                
                            <div class="form-group floating-label-form-group controls mb-0 pb-2" style="color: #6c757d;opacity: 1 ">
                                <label>Telephone</label>
                                <input class="form-control" id="name" type="text" placeholder="Telephone" required="required" data-validation-required-message="Please enter your name." />
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>

                        <div class="control-group">
                            <div class="form-group floating-label-form-group controls mb-0 pb-2" style="color: #6c757d;opacity: 1 ;">
                                <label>Country</label>
                                <select class="form-control"  style="text-indent: 1%"> 
                                    <option selected disabled>Country</option>
                                    <option>Serbia</option>
                                    <option>Hungary</option>
                                    <option>Croatia</option>
                                </select>
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>               
                        


                        <div class="control-group">
                            <div class="form-group floating-label-form-group controls mb-0 pb-2" style="color: #6c757d;opacity: 1 ;">
                                <label>City</label>
                                <select class="form-control"  style="text-indent: 1%"> 
                                    <option selected disabled>City</option>
                                    <option>Subotica</option>
                                    <option>Novi Sad</option>
                                    <option>Beograd</option>
                                </select>
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>

                        <div class="control-group">
                                
                            <div class="form-group floating-label-form-group controls mb-0 pb-2" style="color: #6c757d;opacity: 1 ">
                                <label>Street</label>
                                <input class="form-control" id="name" type="text" placeholder="Street" required="required" data-validation-required-message="Please enter your name." />
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>

                        <div class="control-group">
                                
                            <div class="form-group floating-label-form-group controls mb-0 pb-2" style="color: #6c757d;opacity: 1 ">
                                <label>House number</label>
                                <input class="form-control" id="name" type="text" placeholder="House number" required="required" data-validation-required-message="Please enter your name." />
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>

                        <br />
                        <div id="success"></div>
                        <div class="form-group"><router-link to="/"><button style="margin-left: 15%; width: 20%;" class="btn btn-primary btn-xl" id="sendMessageButton" type="button">Previous</button></router-link>
                        <router-link to="/reg3"><button style="margin-left: 30%; width: 20%;" class="btn btn-primary btn-xl" id="sendMessageButton" type="button">Next</button></router-link></div>
                    </form>
                </div>
            </div>
        </div>
`
    ,
    methods: {

    }
});