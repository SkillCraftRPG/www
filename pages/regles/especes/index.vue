<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>
      Une espèce représente un regroupement d’individus présentant des caractéristiques communes, comme la forme du corps, la couleur de peau, de yeux et de
      cheveux, les comportements sociaux et l’espérance de vie. Certaines espèces se décomposent en plusieurs ethnies, associés à un territoire, une
      organisation géopolitique et un ensemble de mœurs et coutumes.
    </p>
    <p>
      Les personnages appartiennent tous à une espèce, et lorsqu’une espèce se décline en plusieurs ethnies, ils appartiennent à une de ces ethnies. L’espèce et
      le peuple sont choisis à la <NuxtLink to="/regles/personnages/creation">création du personnage</NuxtLink>, et ne changent jamais par la suite.
    </p>
    <p>Les espèces et ethnies définissent les caractéristiques de personnage suivantes :</p>
    <ul>
      <li><strong>Traits.</strong> Des capacités spécifiques aux individus de cette espèce ou ethnie.</li>
      <li>
        <strong>Langues.</strong> Les individus d’une même espèce ou ethnie parlent généralement les mêmes <NuxtLink to="/regles/langues">langues</NuxtLink>,
        mais vous pouvez choisir de parler des langues différentes, avec l’accord de votre maître de jeu et une histoire crédible.
      </li>
      <li><strong>Nom.</strong> Chaque espèce ou ethnie présente des exemples de noms pour votre personnage. Vous pouvez choisir un nom différent.</li>
      <li>
        <strong>Vitesse.</strong> Les espèces et ethnies définissent vos <NuxtLink to="/regles/aventure/mouvement/vitesse">vitesses de déplacement</NuxtLink>.
      </li>
      <li>
        <strong>Apparence.</strong> Les membres d’une même ethnie ou espèce partagent une similarité d’apparence. Votre ethnie ou espèce définit votre
        <NuxtLink to="/regles/especes/taille">taille</NuxtLink>, poids et vieillissement.
      </li>
    </ul>
    <h2 class="h3">Table des matières</h2>
    <ul>
      <li>
        <a href="#common">Espèces communes</a>
      </li>
      <li>
        <a href="#crossed">Espèces croisées</a>
      </li>
      <li>
        <a href="#animals">Hommes-animaux</a>
      </li>
      <li>
        <a href="#fairies">Fées</a>
      </li>
      <li>
        <a href="#elementals">Élémentaires</a>
      </li>
      <li>
        <a href="#horde">Horde</a>
      </li>
    </ul>
    <h2 id="common" class="h3">Espèces communes</h2>
    <p>
      Ces espèces sont répandues aux quatre coins du continent. Cette présence universelle fait d’elles sont la norme démographique, culturelle et politique du
      continent. Leurs sociétés ont façonné les peuplements, les routes, les institutions et l’économie locale, en plus de servir de référence linguistique et
      sociale dans la majorité des régions. Malgré une forte cohésion sociale, ces sociétés sont néanmoins pensées d’abord et avant tout pour ces espèces. Les
      autres espèces peuvent donc ressentir un profond décalage culture et structurel, allant jusqu’à l’exclusion.
    </p>
    <SpeciesList cols="4" :items="commonSpecies" />
    <h2 id="crossed" class="h3">Espèces croisées</h2>
    <p>
      Les espèces dites croisées sont issues de l’union de deux lignées distinctes. Leur héritage multiple leur confère des traits physiques, culturels ou
      surnaturels variables, qui ne se manifestent jamais de manière uniforme. Leur degré d’intégration aux sociétés des espèces communes varie fortement en
      fonction de l’individu. Certains s’insèrent aisément dans les sociétés de l’un ou l’autre de leurs parents, tandis que d’autres peinent à trouver leur
      place, pris entre des normes sociales, biologiques ou symboliques parfois incompatibles. Leur identité se construit donc davantage par le vécu personnel
      que par l’appartenance collective.
    </p>
    <SpeciesList cols="3" :items="crossedSpecies" />
    <h2 id="animals" class="h3">Hommes-animaux</h2>
    <p>
      Les hommes-animaux sont les autochtones de la région. Autrefois maîtres d’un vaste territoire, ils ont vu leurs terres se réduire au fil des siècles, sous
      la pression de l’expansion des autres peuples. Face à ce recul, deux voies se sont imposées. Certains ont choisi le repli, vivant en marge des sociétés
      établies afin de préserver leurs valeurs et traditions millénaires. D’autres se sont intégrés, volontairement ou sous contrainte, au prix d’une érosion
      parfois profonde de leur culture ancestrale. Cette fracture marque encore aujourd’hui l’identité et le destin de ces peuples.
    </p>
    <SpeciesList cols="3" :items="animalSpecies" />
    <h2 id="fairies" class="h3">Fées</h2>
    <p>
      Les fées sont issues d’autres dimensions, lumineuses ou ombrageuses, et entretiennent un lien étroit avec les forces qui imprègnent le monde. Leur
      existence ne s’organise ni autour des peuples mortels ni autour de leurs structures politiques, culturelles ou religieuses. Leurs territoires s’articulent
      plutôt autour de lieux de pouvoir, véritables sources naturelles de magie. Elles y veillent avant tout à la préservation de ces sites et à l’équilibre des
      forces qui s’y manifestent, agissant selon des logiques qui leur sont propres et souvent étrangères aux enjeux des sociétés du continent.
    </p>
    <SpeciesList cols="4" :items="fairySpecies" />
    <h2 id="elementals" class="h3">Élémentaires</h2>
    <p>
      Les élémentaires tirent leur origine de la présence d’esprits élémentaires venus d’autres dimensions. Leur existence est intimement liée à des lieux
      fortement marqués par leur élément, auxquels ils s’attachent bien davantage qu’à des frontières, des organisations politiques, des religions ou des
      cultures. De ce fait, ils demeurent généralement neutres dans les conflits militaires et politiques. Leurs actions sont guidées avant tout par l’intérêt
      de leur espèce et la préservation de leur habitat, quitte à ignorer ou contrarier les enjeux des peuples qui les entourent.
    </p>
    <SpeciesList cols="4" :items="elementalSpecies" />
    <h2 id="horde" class="h3">Horde</h2>
    <p>
      La Horde désigne une confédération tribale aux contours flous et changeants, composée d’espèces habituellement considérées comme monstrueuses. Son
      organisation varie fortement d’un clan à l’autre, sans autorité centrale durable ni structure politique unifiée. Arrivée récemment dans la région depuis
      l’Est lointain du continent, la Horde se manifeste par des conquêtes et des raids dont la violence et la brutalité diffèrent selon l’espèce et le clan.
      Les motivations qui les animent sont tout aussi hétérogènes : accumulation de richesses, contrôle de territoires ou de peuples, quête de prestige, défis
      personnels ou autres ambitions propres à chaque individu.
    </p>
    <SpeciesList cols="3" :items="hordeSpecies" />
  </main>
</template>

<script setup lang="ts">
import type { SearchResults } from "~/types/game";
import type { Species } from "~/types/lineages";

const config = useRuntimeConfig();
const title: string = "Espèces";

const { data } = await useLazyAsyncData<SearchResults<Species>>(
  "species",
  () =>
    $fetch("/api/species?sort=Slug", {
      baseURL: config.public.apiBaseUrl,
    }),
  {
    server: false,
  },
);

const allSpecies = computed<Species[]>(() => data.value?.items ?? []);

const animalSlugs: Set<string> = new Set(["amphydre", "centaure", "harseme", "minotaure", "sarne", "skame"]);
const animalSpecies = computed<Species[]>(() => allSpecies.value.filter(({ slug }) => animalSlugs.has(slug)));

const commonSlugs: Set<string> = new Set(["elfe", "humain", "nain", "petit-gens"]);
const commonSpecies = computed<Species[]>(() => allSpecies.value.filter(({ slug }) => commonSlugs.has(slug)));

const crossedSlugs: Set<string> = new Set(["celestin", "demi-elfe", "demi-orque", "dhampir", "infernon", "sang-dragon"]);
const crossedSpecies = computed<Species[]>(() => allSpecies.value.filter(({ slug }) => crossedSlugs.has(slug)));

const elementalSlugs: Set<string> = new Set(["gnome", "salamandre", "sylphe", "triton"]);
const elementalSpecies = computed<Species[]>(() => allSpecies.value.filter(({ slug }) => elementalSlugs.has(slug)));

const fairySlugs: Set<string> = new Set(["satyre"]);
const fairySpecies = computed<Species[]>(() => allSpecies.value.filter(({ slug }) => fairySlugs.has(slug)));

const hordeSlugs: Set<string> = new Set(["gobelin"]);
const hordeSpecies = computed<Species[]>(() => allSpecies.value.filter(({ slug }) => hordeSlugs.has(slug)));

useSeo({
  title,
  description: "Découvrez les espèces et leurs ethnies : un regroupement d’individus aux traits physiques, sociaux et culturels communs dans le jeu.",
});
</script>
