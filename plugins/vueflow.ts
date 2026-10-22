import { VueFlow } from "@vue-flow/core";

export default defineNuxtPlugin((nuxtApp) => {
  nuxtApp.vueApp.component("VueFlow", VueFlow);
});
