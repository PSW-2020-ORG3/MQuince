var app = new Vue({
	el: '#appointments',
	data: {
		appointments: [],
		doctors: []
	},
	mounted() {

		axios
			.get('/gateway/Appointment/GetForPatient', {
				params: {
					patientId: "6459c216-1770-41eb-a56a-7f4524728546"
				},
				headers: {
					'Authorization': localStorage.getItem('keyToken')
				}
			}).then(response => {
				this.appointments = response.data
			})
		axios
			.get('/gateway/Doctor/GetAll', {
				headers: {
					'Authorization': localStorage.getItem('keyToken')
				}
			}).then(response => {
				this.doctors = response.data
			})


	},
	methods: {
		cancelAppointment: function (appointmentId) {
			axios.put('/gateway/Appointment/CancelAppointment/' + appointmentId, null , {
				headers: {
					"Authorization": localStorage.getItem('keyToken')
				}
			}
			).then((response) => {
				if (response.status === 200) {
					alert("Successful cancellation!");
					window.location.href = "../../public/Appointment/Appointment.html";
				} else {
					alert("It is not possible to cancel an appointment!");
					window.location.href = "../../public/Appointment/Appointment.html";
				}
			}).catch(function (error) {
				this.serverError = true;
				if (error.response) {
					console.log(error.response.status)
					alert("It is not possible to cancel an appointment!");
					window.location.href = "../../public/Appointment/Appointment.html";
				} else if (error.request) {
					console.log(error.request)
					alert("Error!")
				}
			});
		}									
	}		
})