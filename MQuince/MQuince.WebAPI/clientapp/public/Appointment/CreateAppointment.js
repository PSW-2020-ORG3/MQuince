var app = new Vue({
    el: '#createAppointment',
    data: function () {
        return {
            specializations: [],
            doctors: [],
            appointments: [],
            currentStep: 0,
            visibleSpecialization: true,
            visiblePrevious: false,
            visibleNext: true,
            visibleDoctors: false,
            visibleAppointments: false,
            visibleSubmit:false,
            visibleAppTime: false,
            visibleFinished:false,
            selectedSpecialization: '',
            submitMessage:'',
            selectedDoctor: '',
            selectedAppointment:'predef'
        }
    },
    template: ` 
	<div class="container">
            <!-- Contact Section Heading-->
            <h5 class=" text-center  mb-0 text-uppercase" style="color:#1abc9c; margin-top: 2rem;">Create appointment</h5>
            <!-- Icon Divider-->
            <!-- Contact Section Form-->
            <div class="row section-design">
                <div class="col-lg-8 mx-auto">
                    <br/>
                    <!-- To configure the contact form email address, go to mail/contact_me.php and update the email address in the PHP file on line 19.-->
                   
                    <form id="contactForm" name="sentMessage" novalidate="novalidate">
    
                        <div  class="control-group" v-bind:hidden="!visibleSpecialization">
                            <label >Select specialization</label>
                            <br/>
                            <select style="min-height: 20px;" class="select" v-model="selectedSpecialization">
					            <option v-for="(specialization, index) in specializations" class="option" v-bind:value="specialization.id"  :value="specialization.id">{{specialization.entityDTO.name}}</option>
				            </select>
                        </div>


                        <div v-bind:hidden="!visibleDoctors">
                            <label>Select doctor</label>
                            <br/>
                            <select style="min-height: 20px;" class="select" v-model="selectedDoctor">
					            <option v-for="(doctor, index) in doctors" class="option" v-bind:value="doctors.id"  :value="doctors.id">{{'Dr ' + doctor.entityDTO.name + ' '+  doctor.entityDTO.surname}}</option>
				            </select>
                        </div>

                        <!--<div v-bind:hidden="!visibleDoctors">
                            <label>Select doctor</label>
                            <br/>
                            <select style="min-height: 20px;" class="select" v-model="selectedDoctor">
					            <option v-for="(doctor, index) in doctors" class="option" v-bind:value="doctors.id"  :value="doctors.id">{{'Dr ' + doctor.entityDTO.name + ' '+  doctor.entityDTO.surname}}</option>
				            </select>
                        </div>-->
                        
                        <div v-bind:hidden="!visibleSubmit">
                            <label>{{submitMessage}}</label>
                        </div>
                        <br />

                        <div class="form-group">
                            <button v-bind:hidden="!visiblePrevious" v-on:click="previous" style="margin-left: 15%; width: 20%;" class="btn btn-primary btn-xl" id="sendMessageButton" type="button">Previous</button>
                            <button v-bind:hidden="!visibleNext" style="margin-left: 30%; width: 20%;" v-on:click="next" class="btn btn-primary btn-xl" id="sendMessageButton" type="button">Next</button>
                            <button v-bind:hidden="!visibleSubmit" style="margin-left: 30%; width: 20%;" class="btn btn-primary btn-xl" id="sendMessageButton" type="button">Potvrdi</button>
                        </div>
                    
                       
                    </form>
                </div>
            </div>
        </div>
`,
    mounted() {

        axios
            .get('/api/specialization')
            .then(response => (this.specializations = response.data));
    },
    methods: {
        next: function () {
            if (this.currentStep == 0 && this.selectedSpecialization != '') {
                this.currentStep = 1;
                this.visiblePrevious = true;
                this.visibleSpecialization = false;

                axios
                    .get('/api/doctor/specialization/' + this.selectedSpecialization).then(response => {
                        this.doctors = response.data
                    })

                this.visibleDoctors = true;
            } else if (this.currentStep == 1 && this.selectedDoctor != '') {
                this.currentStep = 2;
                this.visiblePrevious = true;
                this.visibleDoctors = false;

                //get appointment 

                this.visibleAppointments = true;
            } else if (this.currentStep == 2 && this.selectedAppointment != '') {
                this.currentStep = 3;
                this.visiblePrevious = true;
                this.visibleSubmit = true;
                this.visibleNext= false;
                this.visibleAppointments = false;

                //submit
                this.submitMessage='Da li sigurno zelite da zakazete termin?'

                this.visibleSubmit = true;
            }
        },
        previous: function () {
            if (this.currentStep == 1) {
                this.currentStep = 0;
                this.visiblePrevious = false;
                this.visibleSpecialization = true;


                this.visibleDoctors = false;
            } else if (this.currentStep == 2) {
                this.currentStep = 1;
                this.visiblePrevious = true;
                this.visibleDoctors = true;


                this.visibleAppointments = false;
            } else if (this.currentStep == 3) {
                this.currentStep = 2;
                this.visiblePrevious = true;
                this.visibleAppointments = true;

                this.visibleNext = true;
                this.visibleSubmit = false;
            }
        }
    }
});