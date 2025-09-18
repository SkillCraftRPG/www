<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Vous tentez de désarmer une créature.</p>
    <p>
      Effectuez un <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/combat/attaque">attaque</NuxtLink>{{ " "
      }}<NuxtLink to="/regles/competences/tests/oppose">opposé</NuxtLink> à un test d’<NuxtLink to="/regles/competences/athletisme">Athlétisme</NuxtLink> ou
      d’<NuxtLink to="/regles/competences/acrobaties">Acrobaties</NuxtLink>, au choix de la cible.
    </p>
    <p>
      Si votre test réussit, la cible est forcée de <NuxtLink to="/regles/combat/activites/lacher">lâcher</NuxtLink> son arme. L’arme tombe au sol, à ses pieds.
    </p>
    <p>
      Cette activité comme comme une attaque. Vous devez respecter votre limite d’attaques, et l’activité n’est pas exempte de la pénalité des
      <NuxtLink to="/regles/combat/attaque/multiples">attaques multiples</NuxtLink>.
    </p>
    <p>Les <NuxtLink to="/regles/talents">talents</NuxtLink> suivants améliorent votre capacité à désarmer :</p>
    <div class="row">
      <div v-for="talent in talents" :key="talent.id" class="col-xs-12 col-sm-6 mb-4">
        <TalentCard class="d-flex flex-column h-100" :talent="talent" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Talent } from "~/types/game";
import { getTalents } from "~/services/talents";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Activités", to: "/regles/combat/activites" },
];
const slugs: Set<string> = new Set(["manoeuvres-de-combat", "poigne-de-fer"]);
const title: string = "Désarmer";
const { orderBy } = arrayUtils;

const allTalents = ref<Talent[]>(getTalents());

const talents = computed<Talent[]>(() =>
  orderBy(
    allTalents.value.filter(({ slug }) => slugs.has(slug)).map((talent) => ({ ...talent, sort: [talent.tier, talent.slug].join("_") })),
    "sort",
  ),
);

useSeo({
  title,
  description:
    "Découvrez l’action Désarmer : forcez un adversaire à lâcher son arme grâce à un test opposé et exploitez des talents pour améliorer cette capacité.",
});
</script>
