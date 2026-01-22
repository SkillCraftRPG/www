<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Au contraire des <NuxtLink to="/regles/herboristerie/remedes">remèdes</NuxtLink>, le rôle des poisons est d’infliger une certaine
      <NuxtLink to="/regles/combat/degats">douleur</NuxtLink>, une nuisance, ou même d’apporter la <NuxtLink to="/regles/combat/mort-agonie">mort</NuxtLink> à
      leurs victimes. Ils sont considérés comme une source naturelle, ils peuvent donc être guéris par les remèdes. L’application d’un poison s’effectue
      généralement par l’activité <NuxtLink to="/regles/combat/activites/objet">Objet</NuxtLink> (<NuxtLink to="/regles/combat/deroulement/tour"
        >une action</NuxtLink
      >).
    </p>
    <h2 class="h3">Table des matières</h2>
    <ul>
      <li>
        <a href="#triggers">Déclencheurs</a>
      </li>
      <li>
        <a href="#basic">Poisons de base</a>
        <ul>
          <li v-for="poison in basic" :key="poison.id">
            <a :href="`#${poison.id}`">{{ poison.name }} ({{ $t(`herbalism.trigger.options.${poison.trigger}`) }})</a>
          </li>
        </ul>
      </li>
      <li>
        <a href="#advanced">Poisons avancés</a>
        <ul>
          <li v-for="poison in advanced" :key="poison.id">
            <a :href="`#${poison.id}`">{{ poison.name }} ({{ $t(`herbalism.trigger.options.${poison.trigger}`) }})</a>
          </li>
        </ul>
      </li>
    </ul>
    <h2 id="triggers" class="h3">Déclencheurs</h2>
    <p>
      Chaque poison est associé à un des déclencheurs suivants. Il ne peut être activé que par ce déclencheur, et ce déclencheur ne peut jamais être modifié.
    </p>
    <ul>
      <li>
        <strong>{{ $t("herbalism.trigger.options.Injury") }}.</strong> Un poison appartenant à cette catégorie peut être appliqué sur une
        <NuxtLink to="/regles/equipement/armes">arme</NuxtLink>, des <NuxtLink to="/regles/equipement/armes/munitions">munitions</NuxtLink>, des éléments de
        piège ou tout autre objet infligeant des dégâts <NuxtLink to="/regles/combat/degats/types">perforants</NuxtLink> ou
        <NuxtLink to="/regles/combat/degats/types">tranchants</NuxtLink>. Il demeure actif jusqu’à ce qu’il soit nettoyé ou transmis par une
        <NuxtLink to="/regles/combat/degats">blessure</NuxtLink>.
      </li>
      <li>
        <strong>{{ $t("herbalism.trigger.options.Contact") }}.</strong> Un poison de contact peut être appliqué sur un objet ou une surface. Il demeure actif
        jusqu’à ce qu’il soit nettoyé ou touché par une créature ayant la peau exposée.
      </li>
      <li>
        <strong>{{ $t("herbalism.trigger.options.Ingested") }}.</strong> Une créature doit avaler une dose complète d’un poison appartenant à cette catégorie
        pour en subir les effets. La dose peut être dissimulée dans de la nourriture ou un liquide. À la discrétion du maître de jeu, une dose partielle peut
        avoir un effet réduit, par exemple en conférant l’<NuxtLink to="/regles/competences/tests/avantage-desavantage">avantage</NuxtLink> au
        <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink>.
      </li>
      <li>
        <strong>{{ $t("herbalism.trigger.options.Inhaled") }}.</strong> Ces poisons se présentent sous forme de poudre ou de gaz qui agissent lorsqu’ils sont
        inhalés. Souffler la poudre ou libérer le gaz expose les créatures dans un cube de 1,5 mètres d’arête à ses effets. Le nuage se dissipe immédiatement
        après. Retenir sa respiration est inefficace contre les poisons inhalés, puisqu’ils agissent sur les muqueuses nasales, les conduits lacrymaux et
        d’autres parties du corps.
      </li>
    </ul>
    <h2 id="basic" class="h3">Poisons de base</h2>
    <p>Le talent <NuxtLink to="/regles/talents/herboristerie">Herboristerie</NuxtLink> permet d’apprendre les poisons de base.</p>
    <template v-for="poison in basic" :key="poison.id">
      <h3 :id="poison.id" class="h5">{{ poison.name }} ({{ $t(`herbalism.trigger.options.${poison.trigger}`) }})</h3>
      <MarkdownContent :text="poison.description" />
    </template>
    <h2 id="advanced" class="h3">Poisons avancés</h2>
    <p>Le talent <NuxtLink to="/regles/talents/toxicologie">Toxicologie</NuxtLink> permet d’apprendre les poisons avancés.</p>
    <template v-for="poison in advanced" :key="poison.id">
      <h3 :id="poison.id" class="h5">{{ poison.name }} ({{ $t(`herbalism.trigger.options.${poison.trigger}`) }})</h3>
      <MarkdownContent :text="poison.description" />
    </template>
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Poison } from "~/types/game";
import { getPoisons } from "~/services/herbalism";

const parent: Breadcrumb[] = [{ text: "Herboristerie", to: "/regles/herboristerie" }];
const title: string = "Poisons";
const { orderBy } = arrayUtils;

const poisons = ref<Poison[]>(getPoisons());

const advanced = computed<Poison[]>(() =>
  orderBy(
    poisons.value.filter(({ category }) => category === "Advanced"),
    "slug",
  ),
);
const basic = computed<Poison[]>(() =>
  orderBy(
    poisons.value.filter(({ category }) => category === "Basic"),
    "slug",
  ),
);

useSeo({
  title,
  description:
    "Découvrez les poisons de base et avancés : toxines de contact, ingestion ou inhalation infligeant douleur, paralysie, folie ou mort, et leurs effets détaillés.",
});
</script>
