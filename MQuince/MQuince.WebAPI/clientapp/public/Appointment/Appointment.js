var app = new Vue({
	el: '#specializations',
	data: {
		specializations: []
	},
	methods: {

	},
	created() {
		axios
			.get('/api/Specialization').then(response => {
				this.specializations = response.data
			})

	}
})