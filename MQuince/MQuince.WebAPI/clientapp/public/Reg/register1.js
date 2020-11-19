Vue.component("register1", {
    data: function () {
        return {
            name: ""
        }
    },
    template: ` 
	<div class="container" id="addFeedback">
            <!-- Contact Section Heading-->
            <h2 class="page-section-heading text-center text-uppercase text-secondary mb-0">Registration</h2>

            <h5 class=" text-center  mb-0 text-uppercase" style="color:#1abc9c; margin-top: 2rem;">Basic information</h5>
            <!-- Icon Divider-->
            <!-- Contact Section Form-->
            <div class="row section-design">
                <div class="col-lg-8 mx-auto">
                    <!-- To configure the contact form email address, go to mail/contact_me.php and update the email address in the PHP file on line 19.-->
                    <form id="contactForm" name="sentMessage" novalidate="novalidate">
                        <div class="control-group">
                            <div class="form-group floating-label-form-group controls mb-0 pb-2" style=" color: #6c757d;opacity: 1;">
                                <label>First Name</label>
                                <input v-model="name" class="form-control" id="name" type="text" placeholder="First Name" required="required" data-validation-required-message="Please enter your name." />
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>

                        <div class="control-group">
                                
                            <div class="form-group floating-label-form-group controls mb-0 pb-2" style=" color: #6c757d;opacity: 1;">
                                <label>Last Name</label>
                                <input class="form-control" id="name" type="text" placeholder="Last Name" required="required" data-validation-required-message="Please enter your name." />
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>

                        <div class="control-group">
                            <div class="form-group floating-label-form-group controls mb-0 pb-2" style=" color: #6c757d;opacity: 1;">
                                <label>JMBG</label>
                                <input class="form-control" id="name" type="text" placeholder="JMBG" required="required" data-validation-required-message="Please enter your name." />
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>                  
                        


                        <div class="control-group">
                            <div class="form-group floating-label-form-group controls mb-0 pb-2" style="color: #6c757d;opacity: 1 ;">
                                <label>Marital status</label>
                                <select class="form-control"  style="text-indent: 1%"> 
                                    <option selected disabled>Marital status</option>
                                    <option>Single</option>
                                    <option>Married</option>
                                    <option>Divorces</option>
                                    <option>Widowed</option>
                                </select>
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>

                        <div class="control-group">
                            <div class="form-group floating-label-form-group controls mb-0 pb-2" style="color: #6c757d;opacity: 1;">
                                <label>Date of birth</label>
                                <input class="form-control" id="name" type="date" placeholder="Date of birth" required="required" data-validation-required-message="Please enter your name." />
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>

                        <div class="control-group">
                            <div class="control-group" style=" color: #6c757d;opacity: 1; margin-left: 15%; margin-top: 4%;">
                                <input type="radio" id="Anonymous" name="signing" style="margin-right: 2%; margin-left: 20%">Female</input>                               
                                <input type="radio" id="Signed" name="signing"  style="margin-right: 2%; margin-left: 15%;">Male</input>
                            </div>
                            
                        </div>
                              

                        <br />
                        <div id="success"></div>
                        <div class="form-group"><router-link to="/reg2"><button style="width: 20%; margin-left: 65%;" class="btn btn-primary btn-xl" id="sendMessageButton" type="button">Next</button></router-link></div>
                    </form>
                </div>
            </div>
        </div>
`
    ,
    methods: {

    }
});