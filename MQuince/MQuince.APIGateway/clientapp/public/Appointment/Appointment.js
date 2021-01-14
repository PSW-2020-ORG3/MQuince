var app = new Vue({
	el: '#appointments',
	data: {
		appointments: [],
		doctors: [],
		slides: 5,
		active: 1
	},
	mounted() {
		var role = localStorage.getItem('keyRole');

		if (role == 1) {
			window.location.href = "/public/index.html";
		} else if (role == null) {
			window.location.href = "/public/Login/Login.html";
        }


		axios
			.get('/gateway/Appointment/GetForPatient', {
				params: {
					patientId: localStorage.getItem('keyGuid')
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
		move: function(amount) {
		  let newActive
		  const newIndex = this.active + amount
		  if (newIndex > this.slides) newActive = 1
		  if (newIndex === 0) newActive = this.slides
		  this.active = newActive || newIndex
		},
		jump: function(index) {
		  this.active = index
		},
		addSlide: function() {
		  this.slides = this.slides + 1
		},
		removeSlide: function() {
		  this.slides = this.slides - 1 
		},
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