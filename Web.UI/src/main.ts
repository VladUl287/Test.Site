import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import router from './router'
import { settingsPlugin } from './settings'

const app = createApp(App)
    .use(router)
    .use(settingsPlugin)

app.mount('#app')
