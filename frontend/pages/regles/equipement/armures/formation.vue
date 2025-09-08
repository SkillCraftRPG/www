<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Formation" :parent="parent" />
    <p>Tout personnage peut revêtir une armure. Néanmoins, une formation est nécessaire afin d’être protégé convenablement.</p>
    <h2 class="h3">Talents</h2>
    <p>Les talents suivants forment le personnage au port des armures d’une certaine catégorie :</p>
    <div class="row">
      <div v-for="talent in talents" :key="talent.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <TalentCard class="d-flex flex-column h-100" :talent="talent" />
      </div>
    </div>
    <h2 class="h3">Pénalités</h2>
    <p>Si une créature porte une armure pour laquelle elle n’est pas formée, elle se voit affligée des pénalités suivantes :</p>
    <ul>
      <li>
        <NuxtLink to="/regles/competences/tests/avantage-desavantage">Désavantage</NuxtLink> au <NuxtLink to="/regles/competences/tests">test</NuxtLink> des
        <NuxtLink to="/regles/competences">compétences</NuxtLink> associées à l’<NuxtLink to="/regles/attributs/adresse">Adresse</NuxtLink>, à la
        <NuxtLink to="/regles/attributs/vigueur">Vigueur</NuxtLink> et au surnaturel, notamment :
        <ul>
          <li>
            <NuxtLink to="/regles/competences/acrobaties">Acrobaties</NuxtLink>
          </li>
          <li>
            <NuxtLink to="/regles/competences/artisanat">Artisanat</NuxtLink>
          </li>
          <li>
            <NuxtLink to="/regles/competences/athletisme">Athlétisme</NuxtLink>
          </li>
          <li>
            <NuxtLink to="/regles/competences/furtivite">Furtivité</NuxtLink>
          </li>
          <li>
            <NuxtLink to="/regles/competences/melee">Mêlée</NuxtLink>
          </li>
          <li>
            <NuxtLink to="/regles/competences/occultisme">Occultisme</NuxtLink>
          </li>
          <li>
            <NuxtLink to="/regles/competences/orientation">Orientation</NuxtLink>
          </li>
          <li>
            <NuxtLink to="/regles/competences/roublardise">Roublardise</NuxtLink>
          </li>
        </ul>
      </li>
      <li>Incapacité à canaliser un <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> nécessitant la composante <strong>Somatique</strong>.</li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Talent } from "~/types/game";
import { getTalents } from "~/services/talents";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Armures", to: "/regles/equipement/armures" },
];
const slugs: Set<string> = new Set(["cuirasse", "formation-martiale", "melee", "orientation"]);
const title: string = "Formation au port d’armure";
const { orderBy } = arrayUtils;

const talents = computed<Talent[]>(() =>
  orderBy(
    getTalents({ requiredTalent: true, skill: true })
      .filter(({ slug }) => slugs.has(slug))
      .map((talent) => ({ ...talent, sort: [talent.tier, talent.slug].join("_") })),
    "sort",
  ),
);

useSeo({
  title,
  description: "Découvrez l’importance de la formation au port d’armure et les pénalités encourues sans compétence adéquate.",
});
</script>
