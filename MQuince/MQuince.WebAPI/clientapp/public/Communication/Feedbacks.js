var app = new Vue({
	el: '#feedbacks',
	data: {
		feedbacks: []
	},
	methods: {

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
})