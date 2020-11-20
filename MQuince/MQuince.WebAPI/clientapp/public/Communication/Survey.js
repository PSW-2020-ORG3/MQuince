var app = new Vue({
	el: '#survey',
	data: {
		questions: [],
		doctorQuestions: [],
		grades: [],
		doctorGrades: []
	},
	methods: {
		radioChanged: function (questionId, grade) {
			for (let j = 0; j < this.questions.length; j++) {
				if (this.questions[j].entityDTO.question.id == questionId) {
					this.grades[j] = grade;
					break;
				}
			}
			for (let j = 0; j < this.doctorQuestions.length; j++) {
				if (this.doctorQuestions[j].entityDTO.question.id == questionId) {
					this.doctorGrades[j] = grade;
					break;
				}
			}
			console.log(this.grades)
		},

		submit() {
			send = true;
			for (let j = 0; j < this.grades.length; j++) {
				if (this.grades[j] == 0) {
					send = false;
				}
			}
			for (let j = 0; j < this.doctorGrades.length; j++) {
				if (this.doctorGrades[j] == 0) {
					send = false;
				}
			}

			if (send == true) {

				for (let j = 0; j < this.questions.length; j++) {
					if (this.grades[j] == 1)
						this.questions[j].entityDTO.oneStar += 1;
					if (this.grades[j] == 2)
						this.questions[j].entityDTO.twoStar += 1;
					if (this.grades[j] == 3)
						this.questions[j].entityDTO.threeStar += 1;
					if (this.grades[j] == 4)
						this.questions[j].entityDTO.fourStar += 1;
					if (this.grades[j] == 5) {
						this.questions[j].entityDTO.fiveStar += 1;
					}
				}

				axios
					.post("/api/HospitalSurveyContoller/Update",this.questions)
					.then(response => {
					
					for (let j = 0; j < this.doctorQuestions.length; j++) {
						if (this.doctorGrades[j] == 1)
							this.doctorQuestions[j].entityDTO.oneStar += 1;
						if (this.doctorGrades[j] == 2)
							this.doctorQuestions[j].entityDTO.twoStar += 1;
						if (this.doctorGrades[j] == 3)
							this.doctorQuestions[j].entityDTO.threeStar += 1;
						if (this.doctorGrades[j] == 4)
							this.doctorQuestions[j].entityDTO.fourStar += 1;
						if (this.doctorGrades[j] == 5) {
							this.doctorQuestions[j].entityDTO.fiveStar += 1;
						}
					}

					axios
						.post("/api/DoctorSurvey/Update", this.doctorQuestions)
						.then(response => {
							JSAlert.alert("Success!");
						})
				})
			} else {
				JSAlert.alert("You have to answer all the questions!");
			}
		}
	},
	created() {
		axios
			.get('/api/HospitalSurveyContoller/GetAll')
			.then(response => {
				this.questions = response.data
				for (var i = 0; i < this.questions.length; i++) {
					console.log(this.questions[i].entityDTO.question._question)
					this.grades.push(0);
				}

			})
		axios
			.get('/api/DoctorSurvey/GetAll')
			.then(response => {
				this.doctorQuestions = response.data
				for (var i = 0; i < this.doctorQuestions.length; i++) {
					console.log(this.doctorQuestions[i].entityDTO.question._question)
					this.doctorGrades.push(0);
				}

			})

	}
})