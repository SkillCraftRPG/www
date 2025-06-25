import { useHead, useRoute, useRuntimeConfig } from "nuxt/app";

type SeoMeta = {
  title?: string | null
  description?: string | null
}

export function useSeo(meta?: SeoMeta): void {
  const config = useRuntimeConfig();
  const route = useRoute();
  const href: string = config.public.baseUrl + route.fullPath;
  const locale: string = 'fr'

  if (meta) {
    useSeoMeta({
      title: meta.title ?? undefined,
      description: meta.description ?? undefined,
      ogTitle: meta.title ?? undefined,
      ogDescription: meta.description ?? undefined,
      ogImage: undefined, // TODO(fpion): OpenGraph Image
      ogUrl: href,
      ogLocale: locale,
      ogSiteName: 'SkillCraft' // TODO(fpion): duplication with app.vue
    })
  }

  useHead(() => ({
    link: [
      {
        rel: "canonical",
        href,
      },
      {
        rel: "alternate",
        hreflang: locale,
        href,
      },
    ],
  }));
}
