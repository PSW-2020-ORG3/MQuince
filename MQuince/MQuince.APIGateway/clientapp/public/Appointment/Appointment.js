﻿var app = new Vue({
	el: '#appointments',
	data: {
		appointments: [],
		doctors: [],
		reportEntity: null,
		reportText: '',
		doctor: null,
		doctorName: '',
		dateTime: '',
		appointment: null,
		timeFrom: '',
		timeTo: '',
		doctorID: null
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
		report: function (appointmentId) {
			var modal = document.getElementById("myModal");
			modal.style.display = "block";	
			
			axios
				.get('/gateway/Appointment/GetReportForAppointment', {
					params: {
						id: appointmentId
					}
				}).then(response => {
					console.log("report poziv",this.doctorID)
					this.reportEntity = response.data
					this.reportText = this.reportEntity.entityDTO.reportText
				})
				
			axios
				.get('/gateway/Appointment/'+ appointmentId, {
					headers: {
                       'Authorization': localStorage.getItem('keyToken')
                    }
				}).then(response => {
					this.doctorID = response.data.entityDTO.doctorId
					this.dateTime = response.data.entityDTO.endDateTime.substr(0, 10);
					this.timeFrom = response.data.entityDTO.startDateTime.substr(11, 5);
					this.timeTo = response.data.entityDTO.endDateTime.substr(11, 5);

					axios
						.get('/gateway/Doctor/'+ this.doctorID, {
							headers: {
							   'Authorization': localStorage.getItem('keyToken')
							}
						}).then(response => {
							console.log("Doc poziv",response.data)
							this.doctorName = response.data.entityDTO.name + ' ' + response.data.entityDTO.surname;
						})

				})


        
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