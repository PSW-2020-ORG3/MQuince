var app = new Vue({
	el: '#adminFeedback',
	data: {
		status: "Published",
		feedbacks: []
	},
	methods: {
		statusChanged() {
			if (this.status == "Published") {
				axios
					.get('/api/Feedback/GetByStatus', {
						params: {
							publish: true,
							approved: true
						}
					}).then(response => {
						this.feedbacks = response.data
					})
			}
			else if (this.status == "Pending") {
				axios
					.get('/api/Feedback/GetByStatus', {
						params: {
							publish: true,
							approved: false
						}
					}).then(response => {
						this.feedbacks = response.data
					})
			}
			else if (this.status == "Private") {
				axios
					.get('/api/Feedback/GetByStatus', {
						params: {
							publish: false,
							approved: false
						}
					}).then(response => {
						this.feedbacks = response.data
					})
			}
		},
		approve: function (fdb) {
			var self = this
			JSAlert.confirm("Are you sure you want to approve this feedback?").then(function (result) {
				if (!result)
					return;
				fdb.entityDTO.approved = true
				axios
					.post("/api/Feedback/Update", {
						Id: fdb.id,
						Anonymous: fdb.entityDTO.anonymous,
						Approved: true,
						Comment: fdb.entityDTO.comment,
						Publish: fdb.entityDTO.publish,
						User: fdb.entityDTO.user
					})
					.then(response => {
						for (i = 0; i < self.feedbacks.length; i++) {
							if (self.feedbacks[i].id == fdb.id) {
								self.feedbacks.splice(i, 1);
								break;
							}
						}
						JSAlert.alert("Success!");
					})
			})
        }
	},
	mounted() {
		localStorage.getItem('keyToken');
		localStorage.getItem('keyRole');
		axios
			.get('/api/Feedback/GetByStatus', {
				params: {
					publish: true,
					approved: true
				},
					headers: {
						'Authorization': localStorage.getItem('keyToken')
					}
				
		}).then(response => {
			this.feedbacks = response.data;
		}).catch(error => {
			if (error.response.status === 400 || error.response.status === 403) {
				alert("You don't have access this page!");
				window.location.href = "/public/index.html";
			}
		});

	},
	created() {
		localStorage.getItem('keyToken');
		localStorage.getItem('keyRole');
		axios
			.get('/api/Feedback/GetByStatus', {
				params: {
					publish: true,
					approved: true
				},
				headers: {
					'Authorization': localStorage.getItem('keyToken')
				}
				
			}).then(response => {
				this.feedbacks = response.data
			}).catch(error => {
			if (error.response.status === 400 || error.response.status === 403) {
				alert("You don't have access this page!");
				window.location.href = "/public/index.html";
			}
		});

    }
})