import "bootstrap/dist/css/bootstrap.min.css";

import { createApp } from "vue";
import { createPinia } from "pinia";

import App from "./App.vue";
import fontAwesome from "./fontAwesome";
import router from "./router";

const app = createApp(App);

app.use(createPinia());
app.use(fontAwesome);
app.use(router);

app.mount("#app");
