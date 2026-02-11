<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les divinités appartenant à ce domaine s’intéressent aux subterfuges, aux farces et à la ruse. Leurs disciples sont bien souvent des espions, des voleurs,
      des assassins et des libérateurs.
    </p>
    <p>
      Type de dégâts de l’<NuxtLink to="/regles/specialisations/pretre">Attaque divine</NuxtLink> :
      <NuxtLink to="/regles/combat/degats/types">psychique</NuxtLink>
    </p>
    <!-- Duperie (Tiers 0) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Duperie</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;0</TarBadge>
      </div>
    </div>
    <p>
      Le personnage peut acquérir <NuxtLink to="/regles/talents/points">à rabais</NuxtLink> les talents
      <NuxtLink to="/regles/talents/illusions-mineures">Illusions mineures</NuxtLink> et <NuxtLink to="/regles/talents/pareidolie">Paréidolie</NuxtLink>.
    </p>
    <!-- Subterfuge (Tiers 1) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Subterfuge</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;1</TarBadge>
      </div>
    </div>
    <p>
      Le personnage touche une créature consentante autre que lui-même par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink> et dépense 10
      points d’<NuxtLink to="/regles/statistiques/energie">Énergie</NuxtLink>. La cible se voit conférer l’<NuxtLink
        to="/regles/competences/tests/avantage-desavantage"
        >avantage</NuxtLink
      >
      à ses <NuxtLink to="/regles/competences/tests">tests</NuxtLink> de <NuxtLink to="/regles/competences/furtivite">Furtivité</NuxtLink> ou de
      <NuxtLink to="/regles/competences/roublardise">Roublardise</NuxtLink>, au choix du personnage, pendant la prochaine
      <NuxtLink to="/regles/aventure/temps">heure</NuxtLink>, ou jusqu’à ce que le personnage réutilise cette capacité.
    </p>
    <!-- Double illusoire (Pouvoir divin) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Double illusoire</h2>
      <div class="h5">
        <TarBadge variant="secondary">Pouvoir&nbsp;divin</TarBadge>
      </div>
    </div>
    <p>
      Par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le personnage présente son
      <NuxtLink to="/regles/equipement/general">symbole divin</NuxtLink> en récitant une prière de ruse. Un double illusoire de lui-même apparaît dans un espace
      <NuxtLink to="/regles/aventure/mouvement/espace-occupe">inoccupé</NuxtLink> qu’il peut
      <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink> et situé à 9 mètres de sa position. L’illusion dure
      <NuxtLink to="/regles/aventure/temps">une minute</NuxtLink> et le personnage doit
      <NuxtLink to="/regles/magie/parametres/duree">se concentrer</NuxtLink> sur celle-ci, comme s’il s’agissait d’un
      <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink>.
    </p>
    <ul>
      <li>
        Une fois par <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>,
        il peut déplacer l’illusion de 9 mètres dans un autre espace qu’il peut voir, mais il doit rester en tout temps à 36 mètres ou moins de l’illusion.
      </li>
      <li>
        Il ne partage pas ses <NuxtLink to="/regles/competences/perception">sens</NuxtLink> avec l’illusion, mais il peut
        <NuxtLink to="/regles/magie/pouvoirs/canalisation">canaliser</NuxtLink> au travers de celle-ci, comme s’il se trouvait à sa position.
      </li>
      <li>
        Lorsque le personnage et son illusion sont situés à 1,5 mètres ou moins de la position d’une même créature, le double illusoire distrait cette créature.
        Le personnage se voit alors conférer l’<NuxtLink to="/regles/competences/tests/avantage-desavantage">avantage</NuxtLink> au
        <NuxtLink to="/regles/competences/tests">test</NuxtLink> de ses <NuxtLink to="/regles/combat/attaque">attaques</NuxtLink> dirigées contre cette
        créature.
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
      Le personnage acquiert gratuitement le pouvoir <NuxtLink to="/regles/magie/pouvoirs/invisibilite">Invisibilité</NuxtLink>. Il peut également utiliser son
      <NuxtLink to="/regles/specialisations/clerc">pouvoir divin</NuxtLink> afin de devenir
      <NuxtLink to="/regles/combat/conditions/invisible">invisible</NuxtLink> jusqu’au début de son prochain
      <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>. Par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, il présente son
      <NuxtLink to="/regles/equipement/general">symbole divin</NuxtLink> en récitant une prière de ruse. Il redevient visible s’il effectue une
      <NuxtLink to="/regles/combat/attaque">attaque</NuxtLink> ou <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalise</NuxtLink> un
      <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink>.
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
    "Découvrez le domaine de la Supercherie, consacré à la ruse, aux illusions et aux ténèbres, offrant subterfuge, vision nocturne, charmes et duplications d’ombre.",
});
</script>
