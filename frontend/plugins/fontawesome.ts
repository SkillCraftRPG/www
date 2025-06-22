// For Nuxt 3
import { library, config } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import { faBrain, faCheck, faDumbbell, faHeart, faTimes } from "@fortawesome/free-solid-svg-icons";

config.autoAddCss = false;

library.add(faBrain, faCheck, faDumbbell, faHeart, faTimes);

export default defineNuxtPlugin((nuxtApp) => {
  nuxtApp.vueApp.component("font-awesome-icon", FontAwesomeIcon);
});
