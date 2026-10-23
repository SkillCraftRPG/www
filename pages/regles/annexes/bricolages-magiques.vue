<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <RulesBreadcrumb :active="title" :parent="parent" />
    <p>
      Les bricolages magiques sont des <NuxtLink to="/regles/magie/pouvoirs">pouvoirs</NuxtLink> augmentant ou modifiant les capacités d’objets ou de créatures.
      Ils sont le produit pur du mélange de magie et d’ingéniosité. Les restrictions suivantes s’appliquent à ces pouvoirs.
    </p>
    <ul>
      <li>Le talent <NuxtLink to="/regles/talents/bricolage-magique">Bricolage magique</NuxtLink> permet d’acquérir les bricolages magiques de tiers 0.</li>
      <li>Le talent <NuxtLink to="/regles/talents/infusions-magiques">Infusions magiques</NuxtLink> permet d’acquérir les bricolages magiques de tiers 1</li>
      <li>La spécialisation <NuxtLink to="/regles/specialisations/bricoleur">Bricoleur</NuxtLink> permet d’acquérir les bricolages magiques de tiers 2.</li>
      <li>
        Afin de <NuxtLink to="/regles/magie/pouvoirs/canalisation">canaliser</NuxtLink> un bricolage magique de tiers 0 à un niveau supérieur, il faut avoir
        acquis le talent <NuxtLink to="/regles/talents/magie-puissante">Magie puissante</NuxtLink>.
      </li>
      <li>
        Afin de canaliser un bricolage magique de tiers 1 à un niveau supérieur, il faut avoir acquis le talent
        <NuxtLink to="/regles/talents/magie-puissante">Magie puissante</NuxtLink> ainsi que la spécialisation
        <NuxtLink to="/regles/specialisations/bricoleur">Bricoleur</NuxtLink>.
      </li>
      <li>
        Afin de canaliser un bricolage magique de tiers 2 à un niveau supérieur, il faut avoir acquis le talent
        <NuxtLink to="/regles/talents/magie-puissante">Magie puissante</NuxtLink> ainsi qu’une des spécialisations suivantes :
        <NuxtLink to="/regles/specialisations/alchimiste">Alchimiste</NuxtLink> ou <NuxtLink to="/regles/specialisations/artificier">Artificier</NuxtLink>.
      </li>
    </ul>
    <p>
      Si le personnage <NuxtLink to="/regles/specialisations/acquisition">acquiert</NuxtLink> une
      <NuxtLink to="/regles/specialisations">spécialisation</NuxtLink> lui permettant d’<NuxtLink to="/regles/magie/pouvoirs/acquisition">acquérir</NuxtLink> un
      de ces pouvoirs, ces restrictions ne s’appliquent pas à ce pouvoir. Par exemple, si le personnage acquiert la spécialisation
      <NuxtLink to="/regles/specialisations/animiste">Animiste</NuxtLink>, alors il peut acquérir le pouvoir
      <NuxtLink to="/regles/magie/pouvoirs/liberte">Liberté</NuxtLink> et le canaliser à un niveau supérieur s’il a acquis le talent
      <NuxtLink to="/regles/talents/magie-puissante">Magie puissante</NuxtLink> et ce, sans avoir acquis la spécialisation
      <NuxtLink to="/regles/specialisations/bricoleur">Bricoleur</NuxtLink>. Par la suite, s’il acquiert la spécialisation
      <NuxtLink to="/regles/specialisations/druide">Druide</NuxtLink>, alors il peut acquérir le pouvoir
      <NuxtLink to="/regles/magie/pouvoirs/resonance-elementaire">Résonance élémentaire</NuxtLink> s’il a acquis le talent
      <NuxtLink to="/regles/talents/magie-puissante">Magie puissante</NuxtLink> et ce, sans avoir acquis la spécialisation
      <NuxtLink to="/regles/specialisations/alchimiste">Alchimiste</NuxtLink> ni <NuxtLink to="/regles/specialisations/artificier">Artificier</NuxtLink>.
    </p>
    <SpellList v-if="spells.length" :items="spells" :scope="category" />
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/tar/breadcrumb";
import type { SearchResults } from "~/types/game";
import type { Spell } from "~/types/magic";
import { SpellCategories } from "~/types/constants";

const config = useRuntimeConfig();
const parent: Breadcrumb[] = [{ text: "Annexes", to: "/regles/annexes" }];
const title: string = "Bricolages magiques";

const category: string = SpellCategories.MagicalTinkering;
const { data } = await useLazyAsyncData<SearchResults<Spell>>(
  `spells:${category}`,
  () =>
    $fetch(`/api/spells?category=${category}`, {
      baseURL: config.public.apiBaseUrl,
    }),
  {
    server: false,
  },
);
const spells = computed<Spell[]>(() => data.value?.items ?? []);

useSeo({
  title,
  description:
    "Découvrez les bricolages magiques de SkillCraft, des pouvoirs alliant magie et ingéniosité pour modifier les capacités d’objets et de créatures.",
});
</script>
