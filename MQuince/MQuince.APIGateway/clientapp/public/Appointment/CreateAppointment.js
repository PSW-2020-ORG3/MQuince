var app = new Vue({
    el: '#createAppointment',
    data: function () {
        return {
            specializations: [],
            doctors: [],
            dateForAppointment: '',
            appointments: [],
            appointments2:[],
            currentStep: 0,
            visibleSpecialization: true,
            visiblePrevious: false,
            visibleNext: true,
            visibleDoctors: false,
            visibleDate:false,
            visibleAppointment: false,
            visibleSubmit:false,
            visibleAppTime: false,
            visibleFinished:false,
            selectedSpecialization: '',
            selectedDate: '',
            submitMessage:'',
            selectedDoctor: '',
            selectedAppointment: '',
            disabledDates: { to: new Date() }

        }
    },
    template: ` 
	<div class="container">
            <!-- Contact Section Heading-->
            <h5 class=" text-center  mb-0 text-uppercase" style="margin-top: 2rem;">Create appointment</h5>
            <!-- Icon Divider-->
            <!-- Contact Section Form-->
    
            <div class="row section-design">
                <div class="col-lg-8 mx-auto">
                    <br/>
                    <!-- To configure the contact form email address, go to mail/contact_me.php and update the email address in the PHP file on line 19.-->
                   
                    <form id="contactForm" name="sentMessage" novalidate="novalidate">
    
                         <div v-bind:hidden="!visibleSpecialization" class="control-group">

                            <div class="form-group floating-form-group controls mb-0 pb-2" style=";opacity: 1 ;">
                                <br/>

                                <label style="margin-left: 14%;display: block; width: 100%;text-indent: 1%;">Select specialization</label>
                                <select class="form-control"  style="text-indent: 1%" v-model="selectedSpecialization"> 
                                    <option v-for="(specialization, index) in specializations" class="option" v-bind:value="specialization.id"  :value="specialization.id">{{specialization.entityDTO.name}}</option>
                                </select>
                            
                            </div>
                        </div>  

                        <div v-bind:hidden="!visibleDoctors" class="control-group">
                            <div class="form-group floating-form-group controls mb-0 pb-2" style="color: #6c757d;opacity: 1 ;">
                                <br/>
                                <label  style="margin-left: 14%;display: block; width: 100%;text-indent: 1%;">Select doctor</label>
                                <select class="form-control"  style="text-indent: 1%" v-model="selectedDoctor">
					                <option v-for="(doctor, index) in doctors" class="option" v-bind:value="doctor.id"  :value="doctor.id">{{'Dr ' + doctor.entityDTO.name + ' '+  doctor.entityDTO.surname}}</option>
				                </select>
                            </div>
                        </div>  



                        <div v-bind:hidden="!visibleDate" class="control-group">
                            <div class="form-group floating-form-group controls mb-0 pb-2" style="color: #6c757d;opacity: 1 ;">
                                <br/>
                                <label  style="margin-left: 14%;display: block; width: 100%;text-indent: 1%;">Select date</label>
                                <vuejs-datepicker class="vue-calendar-control"  style="margin-left: 14%;text-indent: 1%" :disabled-dates="disabledDates" v-model="dateForAppointment"></vuejs-datepicker>
                            </div>
                        </div>  
                        

                        <div v-bind:hidden="!visibleAppointment" class="control-group">
                            <div class="form-group floating-form-group controls mb-0 pb-2" style="color: #6c757d;opacity: 1 ;">
                                <br/>
                                <label  style="margin-left: 14%;display: block; width: 100%;text-indent: 1%;">Select termin</label>
                                <select class="form-control"  style="text-indent: 1%" v-model="selectedAppointment">
					                <option v-for="(app, index) in appointments" class="option" v-bind:value="app"  :value="app">{{app.startDateTime.substr(11, 5) + ' - '+  app.endDateTime.substr(11, 5)}}</option>
				                </select>
                            </div>
                        </div>  

                

                        <br />

                        <div class="form-group">
                            <button v-bind:hidden="!visiblePrevious" v-on:click="previous" style="background: #1977cc;margin-left: 15%; width: 20%;" class="btn btn-primary btn-xl" id="sendMessageButton" type="button">Previous</button>
                            <button v-if="visiblePrevious == false" v-bind:hidden="!visibleNext" style="background: #1977cc;margin-left: 65%; width: 20%;" v-on:click="next" class="btn btn-primary btn-xl" id="sendMessageButton" type="button">Next</button>
                            <button v-else v-bind:hidden="!visibleNext" style="background: #1977cc;margin-left: 30%; width: 20%;" v-on:click="next" class="btn btn-primary btn-xl" id="sendMessageButton" type="button">Next</button>
                            <button v-bind:hidden="!visibleAppointment" style="background: #1977cc;margin-left: 30%; width: 20%;" v-on:click="submit" class="btn btn-primary btn-xl" id="sendMessageButton" type="button">Potvrdi</button>
                        </div>
                    
                       
                    </form>
                <div>
                </div>
                </div>
            </div>
        </div>
`, components: {
        vuejsDatepicker
    },
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

                this.visibleDate = true;
            } else if (this.currentStep == 2 && this.dateForAppointment != '') {
                this.currentStep = 3;
                this.visiblePrevious = true;
                this.visibleSubmit = true;
                this.visibleNext= false;
                this.visibleDate = false;

                axios
                    .get('/api/Appointment/GetFreeApp', {
                        params: {
                            patientId: "6459c216-1770-41eb-a56a-7f4524728546",
                            doctorId: this.selectedDoctor,
                            date: this.dateForAppointment
                        }
                    }).then(response => {
                        this.appointments = response.data

                    })


                this.visibleAppointment = true;
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


                this.visibleDate = false;
            } else if (this.currentStep == 3) {
                this.currentStep = 2;
                this.visiblePrevious = true;
                this.visibleDate = true;

                this.visibleNext = true;
                this.visibleAppointment = false;
            }
        },
        submit: function () {
            if (this.selectedAppointment != '') {
                axios
                    .post("/api/appointment", {
                        StartDateTime: this.selectedAppointment.startDateTime,
                        EndDateTime: this.selectedAppointment.endDateTime,
                        DoctorId: this.selectedDoctor,
                        PatientId: "6459c216-1770-41eb-a56a-7f4524728546" 
                    }, {
                            headers: {
                                'Authorization': localStorage.getItem('keyToken')
                        }
                    }).then((response) => {
                        alert('Your appointment has been saved!')
                        //JSAlert.alert("Your appointment has been saved!");
                        window.location.href = "../../public/index.html";
                        }, (error) => {
                            console.log(error);
                        });
            }
        }
    }
});