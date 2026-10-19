export function setQuery(key: string, value: boolean | string | null | undefined): void {
  const route = useRoute();
  const router = useRouter();

  const query = { ...route.query };
  if (typeof value === "undefined" || value === null || value === "") {
    delete query[key];
  } else {
    query[key] = value.toString();
  }
  router.replace({ query });
}
