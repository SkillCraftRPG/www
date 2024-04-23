import { createRouter, createWebHistory } from "vue-router";

import HomeView from "./views/HomeView.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    // Home
    {
      name: "Home",
      path: "/",
      component: HomeView,
    },
    // NotFound
    {
      name: "NotFound",
      path: "/:pathMatch(.*)*",
      // route level code-splitting
      // this generates a separate chunk (ProfileView.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import("./views/NotFound.vue"),
    },
  ],
});

export default router;
