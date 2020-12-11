var app = new Vue({
	el: '#appointments',
	data: {
		appointments: [],
		doctors: []
	},
    mounted() {

       axios
			.get('/api/Appointment/GetForPatient', {
				params: {
					patientId: "6459c216-1770-41eb-a56a-7f4524728546"
				}
				}).then(response => {
					this.appointments = response.data
			})
		axios
			.get('/api/Doctor/GetAll').then(response => {
                this.doctors = response.data
			})
		
		
	},
    methods: {
		cancelAppointment: function (appointmentId) {
			axios.put('/api/Appointment/canceledAppointment/' + appointmentId
				).then( (response) => {
						if(response.status !== 204){
							alert("Successful cancellation!");
						}else{
							alert("It is not possible to cancel an appointment!");
						}
						})
					}		
										
			}
		
		
})
