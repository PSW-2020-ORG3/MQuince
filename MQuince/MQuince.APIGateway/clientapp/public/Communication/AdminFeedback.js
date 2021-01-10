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
					.get('/gateway/Feedback/GetByStatus', {
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
					.get('/gateway/Feedback/GetByStatus', {
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
					.get('/gateway/Feedback/GetByStatus', {
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
					.put("/gateway/Feedback/Approve/" + fdb.id, null, {
						headers: {
							"Authorization": localStorage.getItem('keyToken')
						}
					}
					)
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
	created() {
		axios
			.get('/gateway/Feedback/GetByStatus', {
				params: {
					publish: true,
					approved: true
				}
			}).then(response => {
				this.feedbacks = response.data
			})

    }
})