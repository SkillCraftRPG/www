<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les divinités appartenant à ce domaine sont intéressées par aux subterfuges, aux farces et à la ruse. Leurs disciples sont bien souvent des espions, des
      voleurs, des assassins et des libérateurs. Ces divinités sont parfois associées à la nuit, à l’obscurité et à Lune.
    </p>
    <p>
      Type de dégâts de l’<NuxtLink to="/regles/specialisations/pretre">Attaque divine</NuxtLink> : <NuxtLink to="/regles/combat/degats/types">froid</NuxtLink>
    </p>
    <!-- Subterfuge (Tiers 0) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Subterfuge</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;0</TarBadge>
      </div>
    </div>
    <p>
      Par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink> et en dépensant 10 points d’<NuxtLink to="/regles/statistiques/energie"
        >Énergie</NuxtLink
      >, le personnage touche une créature consentante (différente de lui-même) afin de lui conférer l’<NuxtLink
        to="/regles/competences/tests/avantage-desavantage"
        >avantage</NuxtLink
      >
      à ses <NuxtLink to="/regles/competences/tests">tests</NuxtLink> de <NuxtLink to="/regles/competences/furtivite">Furtivité</NuxtLink> pendant la prochaine
      <NuxtLink to="/regles/aventure/temps">heure</NuxtLink>. Si le personnage réutilise cette capacité, l’avantage est transféré à la nouvelle cible.
    </p>
    <!-- Yeux de la Nuit (Tiers 1) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Yeux de la nuit</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;1</TarBadge>
      </div>
    </div>
    <p>
      Le personnage acquiert une <NuxtLink to="/regles/aventure/environnement/vision">vision dans le noir</NuxtLink> à une distance de 90 mètres. Il peut
      partager cette vision pendant une <NuxtLink to="/regles/aventure/temps">heure</NuxtLink> aux créatures de son choix qu’il peut voir et situées à 3 mètres
      ou moins de sa position. Le nombre maximal de créatures qu’il peut cibler est égal à ses <NuxtLink to="/regles/attributs/sens">Sens</NuxtLink> (minimum
      1). Il doit compléter une <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink> afin de réutiliser cette capacité.
    </p>
    <!-- Crépuscule (Pouvoir divin) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Crépuscule</h2>
      <div class="h5">
        <TarBadge variant="secondary">Pouvoir&nbsp;divin</TarBadge>
      </div>
    </div>
    <p>
      Le personnage présente son <NuxtLink to="/regles/equipement/general">symbole divin</NuxtLink> par une
      <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink> et récite une prière au crépuscule. Pendant la prochaine
      <NuxtLink to="/regles/aventure/temps">minute</NuxtLink> ou jusqu’à ce qu’il devienne
      <NuxtLink to="/regles/combat/conditions/incapable">incapable</NuxtLink>, il dégage une aura de
      <NuxtLink to="/regles/aventure/environnement/vision">pénombre</NuxtLink> dans un rayon de 9 mètres. Lorsqu’il termine son tour ou lorsqu’une créature
      termine son <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink> dans la zone, le personnage peut utiliser sa
      <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> afin de lui conférer un des effets suivants :
    </p>
    <ul>
      <li>
        Un nombre de points de <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink>{{ " "
        }}<NuxtLink to="/regles/combat/degats/temporaire">temporaires</NuxtLink> égal à 1d10 +
        <NuxtLink to="/regles/statistiques/puissance">Puissance</NuxtLink>.
      </li>
      <li>
        Il met fin à un <NuxtLink to="/regles/combat/conditions/charme">charme</NuxtLink> ou à un effet de
        <NuxtLink to="/regles/combat/conditions/apeure">peur</NuxtLink> affligeant cette créature.
      </li>
    </ul>
    <!-- Manteau des ombres (Tiers 2) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Manteau des ombres</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;2</TarBadge>
      </div>
    </div>
    <p>
      Par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le personnage présente son
      <NuxtLink to="/regles/equipement/general">symbole divin</NuxtLink> en récitant une prière de ruse. Il devient
      <NuxtLink to="/regles/combat/conditions/invisible">invisible</NuxtLink> jusqu’à la fin de son prochain
      <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, ou jusqu’à ce qu’il effectue une action offensive telle une
      <NuxtLink to="/regles/combat/attaque">attaque</NuxtLink> ou <NuxtLink to="/regles/combat/activites/canaliser">canalise</NuxtLink> un
      <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink>.
    </p>
    <p>
      Alternativement, le personnage peut créer un double illusoire de lui-même. L’illusion apparaît dans un espace inoccupé qu’il peut
      <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink> et situé à 9 mètres de sa position. L’illusion dure
      <NuxtLink to="/regles/aventure/temps">une minute</NuxtLink> et le personnage doit
      <NuxtLink to="/regles/magie/parametres/duree">se concentrer</NuxtLink> sur celle-ci, comme s’il s’agissait d’un
      <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink>.
    </p>
    <p>
      Une fois par <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, il
      peut déplacer l’illusion de 9 mètres dans un autre espace qu’il peut voir, mais il doit rester en tout temps à 36 mètres ou moins de l’illusion.
    </p>
    <p>
      Bien qu’il ne partage pas ses sens avec l’illusion, le personnage peut <NuxtLink to="/regles/magie/pouvoirs/canalisation">canaliser</NuxtLink> au travers
      de celle-ci, comme s’il se trouvait à la position de son illusion.
    </p>
    <p>
      Lorsque le personnage et son illusion sont situés à 1,5 mètres ou moins de la position d’une créature, le personnage se voit conférer l’<NuxtLink
        to="/regles/competences/tests/avantage-desavantage"
        >avantage</NuxtLink
      >
      au <NuxtLink to="/regles/competences/tests">test</NuxtLink> de ses <NuxtLink to="/regles/combat/attaque">attaques</NuxtLink> dirigées contre cette
      créature, qui est distraite par l’illusion.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Domaines divins", to: "/regles/domaines/divins" },
];
const title: string = "Supercherie";

useSeo({
  title,
  description:
    "Découvrez le domaine de la Supercherie, consacré à la ruse, aux illusions et aux ténèbres, offrant subtrefuge, vision nocturne, charmes et duplications d’ombre.",
});
</script>
