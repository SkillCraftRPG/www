import type { ListMode } from "~/types/components";

export function getQuery(key: string): string {
  const route = useRoute();
  const value = route.query[key];
  return ((Array.isArray(value) ? value[0] : value) ?? "").trim();
}

export function setQueries(values: Record<string, boolean | string | null | undefined>): void {
  const route = useRoute();
  const router = useRouter();

  const query = { ...route.query };
  for (const [key, value] of Object.entries(values)) {
    if (typeof value === "undefined" || value === null || value === "") {
      delete query[key];
    } else {
      query[key] = value.toString();
    }
  }
  router.replace({ query });
}

export function setQuery(key: string, value: boolean | string | null | undefined): void {
  setQueries({ [key]: value });
}

export function useListMode() {
  const mode = computed<ListMode>(() => (getQuery("mode").toLocaleLowerCase() === "list" ? "list" : "grid"));

  function setMode(value: ListMode): void {
    setQuery("mode", value === "grid" ? "" : value);
  }

  return { mode, setMode };
}
