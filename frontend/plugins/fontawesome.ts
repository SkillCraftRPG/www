// For Nuxt 3
import { library, config } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import { faBrain, faDumbbell, faHeart } from "@fortawesome/free-solid-svg-icons";

config.autoAddCss = false;

library.add(faBrain, faDumbbell, faHeart);

export default defineNuxtPlugin((nuxtApp) => {
  nuxtApp.vueApp.component("font-awesome-icon", FontAwesomeIcon);
});
