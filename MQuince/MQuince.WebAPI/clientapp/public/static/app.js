const homepage = { template: '<homepage></homepage>' }

const routes = [
    { path: '/web', component: homepage }

]

const router = new VueRouter({
    routes 
})


const app = new Vue({
  router
}).$mount('#app')