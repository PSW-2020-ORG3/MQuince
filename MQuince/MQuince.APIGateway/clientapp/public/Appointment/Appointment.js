﻿var app = new Vue({
	el: '#appointments',
	data: {
		appointments: [],
		doctors: [],
		reportText: 'This is some report text'
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
		report: function (appointment) {
			
			var modal = document.getElementById("myModal");
			modal.style.display = "block";

        
		},
		close: function () {
			 
			var modal = document.getElementById("myModal");
			modal.style.display = "none";
        
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