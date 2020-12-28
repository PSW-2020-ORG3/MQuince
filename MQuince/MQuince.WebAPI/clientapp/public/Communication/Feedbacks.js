var app = new Vue({
	el: '#feedbacks',
	data: {
		feedbacks: [],
		status: "AllFeedbacks"
	},
	methods: {
		onChange() {


			console.log(event.target.value)
				axios
					.get('/api/Feedback/GetByStatus', {
						params: {
							publish: true,
							approved: true
						}
					}).then(response => {
						this.feedbacks = response.data
					})
			
		},
		created() {
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
	}
})