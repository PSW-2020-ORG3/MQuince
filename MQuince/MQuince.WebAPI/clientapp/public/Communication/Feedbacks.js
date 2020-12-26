var app = new Vue({
	el: '#feedbacks',
	data: {
		feedbacks: [],
		userToken: null
	},
	methods: {

	},
	created() {
		axios
			.get('/api/Feedback/GetByStatus', {
				params: {
					publish: true,
					approved: true
				}, 
				headers: {
					'Authorization': 'Bearer ' + this.userToken
				}
			}).then(response => {
				this.feedbacks = response.data
			}).catch(error => {
						if (error.response.status === 400 || error.response.status === 403) {
							alert("You don't have access this page!");
							this.$router.push({ name: 'loginUser' })
						}
				});

	},
	mounted() {
		this.userToken = localStorage.getItem('validToken');
		axios
			.get('/api/Feedback/GetByStatus', {
				params: {
					publish: true,
					approved: true
				}, 
				headers: {
					'Authorization': 'Bearer ' + this.userToken
				}
		}).then(response => {
			this.feedbacks = response.data;
		}).catch(error => {
			if (error.response.status === 400 || error.response.status === 403) {
				alert("You don't have access this page!");
				this.$router.push({ name: 'loginUser' })
			}
		});

	}
})