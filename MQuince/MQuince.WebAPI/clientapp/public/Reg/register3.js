Vue.component("register3", {
    data: function () {
        return {

        }
    },
    template: ` 
    <div class="container" id="addFeedback">
            <!-- Contact Section Heading-->
            <h2 class="page-section-heading text-center text-uppercase text-secondary mb-0">Registration</h2>

            <h5 class=" text-center  mb-0 text-uppercase" style="color:#1abc9c; margin-top: 2rem;">Basic medical information</h5>
            <!-- Icon Divider-->
            <!-- Contact Section Form-->
            <div class="row section-design">
                <div class="col-lg-8 mx-auto">
                    <!-- To configure the contact form email address, go to mail/contact_me.php and update the email address in the PHP file on line 19.-->
                    <form id="contactForm" name="sentMessage" novalidate="novalidate">

                        <div class="control-group">
                            <div class="form-group floating-label-form-group controls mb-0 pb-2" style="color: #6c757d;opacity: 1 ;">
                                <label>Blood Type</label>
                                <select class="form-control"  style="text-indent: 1%"> 
                                    <option selected disabled>Blood Type</option>
                                    <option>A</option>
                                    <option>B</option>
                                    <option>AB</option>
                                    <option>0</option>
                                    <option>I don't know</option>
                                </select>
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>
                        <div class="control-group">
                            <div class="form-group floating-label-form-group controls mb-0 pb-2" style="color: #6c757d;opacity: 1 ;">
                                <label>Rh factor</label>
                                <select class="form-control"  style="text-indent: 1%"> 
                                    <option selected disabled>Rh factor</option>
                                    <option>+</option>
                                    <option>-</option>
                                    <option>I don't know</option>
                                </select>
                                <p class="help-block text-danger"></p>
                            </div>

                        </div>     
                        <h5 class=" text-center  mb-0 text-uppercase" style="color:#1abc9c; margin-top: 2rem; margin-bottom: 4rem;">Allergies</h5>
                        <div class="control-group">
                            <div class="form-group  controls mb-0 pb-2 " style="margin-left: 15%; color: #495057;
                            background-color: #fff;
                            background-clip: padding-box;
                            border: 0.125rem solid #ced4da;
                            border-radius: 0.5rem; margin-top: 2rem; width: 70%; padding: 1rem;">
                                <div class="ScrollStyle">
                                <div>
                                <input  style="height: 1rem;"  id="name" type="checkbox" placeholder="Telephone" required="required" data-validation-required-message="Please enter your name." />
                                    <label style=" margin-top: -10px; margin-left: 5px;">Penicillin</label>
                                </div>  
                                <div>
                                    <input  style="height: 1rem "  id="name" type="checkbox" placeholder="Telephone" required="required" data-validation-required-message="Please enter your name." />
                                        <label style=" margin-top: -10px; margin-left: 5px;">Local anesthetics</label>
                                </div>
                                <div>
                                    <input  style="height: 1rem"  id="name" type="checkbox" placeholder="Telephone" required="required" data-validation-required-message="Please enter your name." />
                                        <label style=" margin-top: -10px; margin-left: 5px;">Sulfonamides</label>
                                </div>
                                <div>
                                    <input  style="height: 1rem"  id="name" type="checkbox" placeholder="Telephone" required="required" data-validation-required-message="Please enter your name." />
                                        <label style=" margin-top: -10px; margin-left: 5px;">Tetracycline</label>
                                </div>
                                <div>
                                    <input  style="height: 1rem"  id="name" type="checkbox" placeholder="Telephone" required="required" data-validation-required-message="Please enter your name." />
                                        <label style=" margin-top: -10px; margin-left: 5px;">Dilantin</label>
                                </div>
                                <div>
                                    <input  style="height: 1rem"  id="name" type="checkbox" placeholder="Telephone" required="required" data-validation-required-message="Please enter your name." />
                                        <label style=" margin-top: -10px; margin-left: 5px;">Food</label>
                                </div>
                                <p class="help-block text-danger"></p>
                                </div>
                            </div>
                        </div>

                        <h5 class=" text-center  mb-0 text-uppercase" style="color:#1abc9c; margin-top: 2rem; margin-bottom: 4rem;">Risk factors</h5>
                        <div class="control-group">
                            <div class="form-group  controls mb-0 pb-2 " style="margin-left: 15%; color: #495057;
                            background-color: #fff;
                            background-clip: padding-box;
                            border: 0.125rem solid #ced4da;
                            border-radius: 0.5rem; margin-top: 2rem; width: 70%; padding: 1rem;">
                                <div class="ScrollStyle">
                                <div>
                                <input  style="height: 1rem;"  id="name" type="checkbox" placeholder="Telephone" required="required" data-validation-required-message="Please enter your name." />
                                    <label style=" margin-top: -10px; margin-left: 5px;">High Level of Cholesterol</label>
                                </div>  
                                <div>
                                    <input  style="height: 1rem "  id="name" type="checkbox" placeholder="Telephone" required="required" data-validation-required-message="Please enter your name." />
                                        <label style=" margin-top: -10px; margin-left: 5px;">Smoking</label>
                                </div>
                                <div>
                                    <input  style="height: 1rem"  id="name" type="checkbox" placeholder="Telephone" required="required" data-validation-required-message="Please enter your name." />
                                        <label style=" margin-top: -10px; margin-left: 5px;">Hypertension</label>
                                </div>
                                <div>
                                    <input  style="height: 1rem"  id="name" type="checkbox" placeholder="Telephone" required="required" data-validation-required-message="Please enter your name." />
                                        <label style=" margin-top: -10px; margin-left: 5px;">Diabetes</label>
                                </div>
                                <div>
                                    <input  style="height: 1rem"  id="name" type="checkbox" placeholder="Telephone" required="required" data-validation-required-message="Please enter your name." />
                                        <label style=" margin-top: -10px; margin-left: 5px;">Obesity</label>
                                </div>
                                <div>
                                    <input  style="height: 1rem"  id="name" type="checkbox" placeholder="Telephone" required="required" data-validation-required-message="Please enter your name." />
                                        <label style=" margin-top: -10px; margin-left: 5px;">Alcoholism</label>
                                </div>
                                <p class="help-block text-danger"></p>
                                </div>
                            </div>
                        </div>

                        <h5 class=" text-center  mb-0 text-uppercase" style="color:#1abc9c; margin-top: 2rem; margin-bottom: 4rem;">Chosen doctor</h5>
                        <div class="control-group">
                            <div class="form-group floating-label-form-group controls mb-0 pb-2" style="color: #6c757d;opacity: 1 ;">
                                <label>Chosen doctor</label>
                                <select class="form-control"  style="text-indent: 1%"> 
                                    <option selected disabled>Chosen doctor</option>
                                    <option>Pera Peric</option>
                                    <option>Nikola Nikolic</option>
                                    <option>Mara Maric</option>
                                    <option>I don't have a chosen doctor</option>
                                </select>
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>               
                        
                        <br />
                        <div id="success"></div>
                        <div class="form-group"><router-link to="/reg2"><button style="margin-left: 15%; width: 20%;"v-on:click="submit()" class="btn btn-primary btn-xl" id="sendMessageButton" type="button">Previous</button></router-link>
                        <router-link to="/reg4"><button style="margin-left: 30%; width: 20%;" v-on:click="submit()" class="btn btn-primary btn-xl" id="sendMessageButton" type="button">Next</button></router-link></div>
                    </form>
                </div>
            </div>
        </div>
`
    ,
    methods: {

    }
});