<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      L’<strong>Incantation</strong> correspond à la durée nécessaire afin de <NuxtLink to="/regles/magie/pouvoirs/canalisation">canaliser</NuxtLink> le
      pouvoir. Cette durée varie en fonction de la nature du pouvoir.
    </p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-20">Incantation</th>
          <th scope="col" class="w-80">Description</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>
            <NuxtLink to="/regles/combat/deroulement/tour">1 action</NuxtLink>
          </td>
          <td>Certains pouvoirs peuvent être canalisés rapidement.</td>
        </tr>
        <tr>
          <td>
            <NuxtLink to="/regles/combat/deroulement/tour">2 actions</NuxtLink>
          </td>
          <td>La canalisation de la plupart des pouvoirs nécessite deux actions.</td>
        </tr>
        <tr>
          <td>
            <NuxtLink to="/regles/combat/deroulement/tour">Réaction</NuxtLink>
          </td>
          <td>
            Certains pouvoirs peuvent être canalisés en réaction à un déclencheur spécifique. Le talent
            <NuxtLink to="/regles/talents/magie-guerriere">Magie guerrière</NuxtLink> permet de remplacer une
            <NuxtLink to="/regles/combat/attaque/opportunite">attaque d’opportunité</NuxtLink> par un pouvoir dont l’incantation est de deux actions ou moins.
          </td>
        </tr>
        <tr>
          <td>
            <NuxtLink to="/regles/aventure/temps">Durée fixe</NuxtLink>
          </td>
          <td>
            La canalisation de certains pouvoirs nécessite plusieurs minutes, et parfois même plusieurs heures. Une créature doit maintenir sa
            <NuxtLink to="/regles/combat/activites/concentration">concentration</NuxtLink> pendant toute la durée de la canalisation. Si elle perd la
            concentration, la canalisation échoue. Aucune <NuxtLink to="/regles/magie/pouvoirs/energie">dépense</NuxtLink> d’<NuxtLink
              to="/regles/statistiques/energie"
              >Énergie</NuxtLink
            >
            n’est engendrée, les <NuxtLink to="/regles/magie/parametres/composantes">composantes matérielles</NuxtLink> ne sont pas perdues, mais la créature
            doit recommencer la canalisation depuis le début.
          </td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Magie", to: "/regles/magie" },
  { text: "Paramètres", to: "/regles/magie/parametres" },
];
const title: string = "Incantation";

useSeo({
  title,
  description:
    "Découvrez l’incantation : durée nécessaire pour canaliser un pouvoir, selon actions, réactions ou concentration prolongée avec composantes matérielles.",
});
</script>
