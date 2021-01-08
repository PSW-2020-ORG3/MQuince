
Vue.component("create-appointment", {
	data: function () {
		return {
			specializations: null,
			doctors: '',
			selectedSpecialization:'',
			disabledDates: { to: new Date() }
		}
	},
	template: ` 
<div>
	<table style="width:100%;horizontal-align: center">
		</tr style="width:100%;horizontal-align: center">
			<td>Izaberite specijalizaciju:</td>
		</tr>
		<tr style="width:100%;horizontal-align: center">
			<td>
				<select style="min-height: 200px;" class="select" name="selectedSpecialization" style="width:100px" v-model="selectedSpecialization">
					<option v-for="(specialization, index) in specializations" class="option" v-bind:value="specialization.id" v-model="selectedSpecialization" :value="specialization.id">{{specialization.entityDTO.name}}</option>
				</select>
			</td>
		</tr>
	</table>
	<div>
		{{selectedSpecialization}}
	</div>
</div>
`,
	mounted() {

		axios
			.get('/api/specialization')
			.then(response => (this.specializations = response.data));
	},
	methods: {

	}
});


