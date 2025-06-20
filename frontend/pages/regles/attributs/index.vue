<template>
  <main class="container">
    <h1>Attributs</h1>
    <AppBreadcrumb active="Attributs" />
    <p>Les attributs quantifient les forces et faiblesses des personnages et créatures. Ils influencent également les chances de réussite de leurs actions.</p>
    <p>La valeur d’un attribut varie généralement entre -5 et +5, mais certaines conditions peuvent amener cette valeur en-dehors de ces bornes.</p>
    <p>Le système SkillCraft utilise <strong>5 attributs</strong> :</p>
    <ul>
      <li>2 attributs physiques, qui bénéficieront davantage aux personnages actifs.</li>
      <li>2 attributs mentaux, qui bénéficieront davantage aux personnages intellectuels.</li>
      <li>Un attribut universel dont tous les personnages bénéficient.</li>
    </ul>
    <table v-if="attributes.length" class="table table-striped">
      <thead>
        <tr>
          <th scope="col">Attribut</th>
          <th scope="col">Résumé</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="attribute in attributes" :key="attribute.id">
          <td>
            <NuxtLink :to="`/regles/attributs/${attribute.slug}`">{{ attribute.name }}</NuxtLink>
            <br />
            {{ categorize(attribute).text }}
          </td>
          <td>
            <span v-if="attribute.summary">{{ attribute.summary }}</span>
            <span v-else class="text-muted">{{ "—" }}</span>
          </td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<script setup lang="ts">
import type { Attribute, SearchResults } from "~/types/game";

useSeoMeta({
  title: "Attributs",
  description:
    "Découvrez le fonctionnement des attributs de personnage : des caractéristiques clés qui définissent les forces, faiblesses et compétences de vos héros.",
});
useLinks();

const { data } = await useFetch("/api/attributes", {
  baseURL: "http://localhost:8088",
  server: false,
});

const attributes = computed<Attribute[]>(() => (data.value as SearchResults<Attribute>)?.items ?? []);

type AttributeCategory = {
  icon: string;
  order: number;
  text: string;
};
function categorize(attribute: Attribute): AttributeCategory {
  switch (attribute.value) {
    case "Dexterity":
    case "Vigor":
      return { icon: "", order: 0, text: "Physique" };
    case "Intellect":
    case "Senses":
      return { icon: "", order: 1, text: "Mental" };
  }
  return { icon: "", order: 2, text: "Universel" };
}
</script>
