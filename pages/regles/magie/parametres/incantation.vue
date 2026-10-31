<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <RulesBreadcrumb :active="title" :parent="parent" />
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
            n’est engendrée, les composantes <NuxtLink to="/regles/magie/parametres/composantes">Matériel</NuxtLink> ne sont pas perdues, mais la créature doit
            recommencer la canalisation depuis le début.
          </td>
        </tr>
      </tbody>
    </table>
    <h2 class="h3">Rituel</h2>
    <p>
      Certains pouvoir peuvent être <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalisés</NuxtLink> en rituel, en plus de pouvoir être canalisés
      normalement. Le rituel doit être d’une durée minimale de <NuxtLink to="/regles/aventure/temps">10 minutes</NuxtLink> additionnées à la durée de
      canalisation normale du pouvoir.
    </p>
    <p>
      Collaborez avec votre maître de jeu afin de déterminer en quoi consiste le rituel. N’oubliez pas d’inclure toutes les
      <NuxtLink to="/regles/magie/parametres/composantes">composantes</NuxtLink> du pouvoir dans les étapes du rituel.
    </p>
    <p>
      Lorsque vous canalisez un pouvoir en rituel, vous réussissez automatiquement le <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink
        to="/regles/competences/occultisme"
        >Occultisme</NuxtLink
      >, et la canalisation ne vous coûte qu’un seul point d’<NuxtLink to="/regles/statistiques/energie">Énergie</NuxtLink>. Cette
      <NuxtLink to="/regles/magie/pouvoirs/energie">dépense</NuxtLink> ne peut être réduite d’aucune manière.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/tar/breadcrumb";

const parent: Breadcrumb[] = [
  { text: "Magie", to: "/regles/magie" },
  { text: "Paramètres", to: "/regles/magie/parametres" },
];
const title: string = "Incantation";

useSeo({
  title,
  description: "Découvrez les règles d’incantation de SkillCraft, les durées de canalisation des pouvoirs et les rituels permettant d’économiser l’Énergie.",
});
</script>
