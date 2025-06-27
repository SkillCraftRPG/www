// For Nuxt 3
import { library, config } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import { faArrowUp, faBrain, faCheck, faDumbbell, faHeart, faLightbulb, faTimes } from "@fortawesome/free-solid-svg-icons";

config.autoAddCss = false;

library.add(faArrowUp, faBrain, faCheck, faDumbbell, faHeart, faLightbulb, faTimes);

export default defineNuxtPlugin((nuxtApp) => {
  nuxtApp.vueApp.component("font-awesome-icon", FontAwesomeIcon);
});
