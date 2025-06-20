// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  compatibilityDate: "2025-05-15",
  devtools: { enabled: true },
  modules: ["usebootstrap"],
  css: ["~/assets/styles/main.css"],
  app: {
    head: {
      htmlAttrs: {
        lang: "fr",
      },
      link: [
        { rel: "icon", href: "/favicon.ico" },
        { rel: "icon", type: "image/png", sizes: "32x32", href: "/favicon-32.png" },
        { rel: "apple-touch-icon", href: "/favicon-180.png" },
      ],
    },
  },
  runtimeConfig: {
    public: {
      baseUrl: "https://www.skillcraftrpg.ca",
    },
  },
});
