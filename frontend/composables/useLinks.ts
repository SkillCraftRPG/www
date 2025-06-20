import { useHead, useRoute, useRuntimeConfig } from "nuxt/app";

export function useLinks() {
  const config = useRuntimeConfig();
  const route = useRoute();
  const href: string = config.public.baseUrl + route.fullPath;

  useHead(() => ({
    link: [
      {
        rel: "canonical",
        href,
      },
      {
        rel: "alternate",
        hreflang: "fr",
        href,
      },
    ],
  }));
}
