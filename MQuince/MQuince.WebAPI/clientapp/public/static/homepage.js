Vue.component("homepage", {
	data: function () {
		return {
			logged: null,
			error: '',
			username: '',
			usernameError: '',
			password: '',
			passwordError: ''
		}
	},
	template: ` 
<div>
	<section style="max-height:400px; object-fit: fill;" id="hero" class="d-flex align-items-center">
		<div class="container">
		</div>
  </section>
</div>
`
	,
	methods: {
		checkFormValid: function () {
			this.error = '';
			this.usernameError = '';
			this.passwordError = '';

			if (this.username == "")
				this.usernameError = 'Korisnicko ime je obavezno polje!';
			else if (this.password == "")
				this.passwordError = 'Sifra je obavezno polje!';
			else {
				let loginData = { username: this.username, password: this.password };


				axios
					.post('/users/login', JSON.stringify(loginData))
					.then(response => {
						if (response.data != "") {
							//TODO 1: set cookie
							window.location.href = "/";
						}
						else {
							//TODO 2: napraviti neki lepsi nacin prikaza 
							this.error = 'Uneti su pogresni podaci ili je korisnik blokiran!';
						}


					});


			}
		}
	}
});


