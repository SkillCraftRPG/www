<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <RulesBreadcrumb active="Transmutation" :parent="parent" />
    <p>
      Ce cercle rassemble les pouvoirs dont la fonction est de modifier la réalité, soit l’énergie et la matière. Il permet de muter le monde à sa guise, à
      petite ou à grande échelle. Ces pouvoirs peuvent créer, détruire, façonner, embellir et défigurer.
    </p>
    <!-- Pierre de transmutateur (Allégeance) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Pierre de transmutateur</h2>
      <div class="h5">
        <TarBadge variant="secondary">Allégeance</TarBadge>
      </div>
    </div>
    <p>
      Le personnage peut créer une pierre magique de transmutateur en accomplissant un rituel d’une durée de
      <NuxtLink to="/regles/aventure/temps">8 heures</NuxtLink>. S’il fabrique une nouvelle pierre, l’ancienne devient une simple pierre non magique. Il peut
      bénéficier des effets de sa pierre ou la confier à une autre créature afin de faire bénéficier des effets à cette créature. Au moment de la création et
      chaque fois qu’il <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalise</NuxtLink> un
      <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> associé au cercle Transmutation, il peut changer l’effet conféré par la pierre.
    </p>
    <ul>
      <li>Le porteur acquiert une <NuxtLink to="/regles/aventure/environnement/vision">vision dans le noir</NuxtLink> à une distance de 18 mètres.</li>
      <li>
        La <NuxtLink to="/regles/aventure/mouvement/vitesse">vitesse</NuxtLink> du porteur augmente de 2 points de mouvement (0,5 mètre par seconde) lorsqu’il
        n’est pas <NuxtLink to="/regles/equipement/encombrement">encombré</NuxtLink>.
      </li>
      <li>
        Le porteur remplace son <NuxtLink to="/regles/competences/rang">rang</NuxtLink> de
        <NuxtLink to="/regles/competences/resistance">Résistance</NuxtLink> par le double de son
        <NuxtLink to="/regles/personnages/progression/tiers">tiers</NuxtLink>, si ce nombre est supérieur à son rang.
      </li>
      <li>
        Le porteur est <NuxtLink to="/regles/combat/degats/efficacite">résistant</NuxtLink> à un des
        <NuxtLink to="/regles/combat/degats/types">types de dégâts</NuxtLink> suivants, sélectionné par le personnage lorsqu’il applique cet effet : acide, feu,
        foudre, froid ou tonnerre.
      </li>
    </ul>
    <!-- Maître transmutateur (Élévation) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Maître transmutateur</h2>
      <div class="h5">
        <TarBadge variant="secondary">Élévation</TarBadge>
      </div>
    </div>
    <p>
      Par deux <NuxtLink to="/regles/combat/deroulement/tour">actions</NuxtLink>, le personnage peut consommer la réserve d’énergie magique entreposée dans sa
      pierre de transmutateur afin de produire un des effets suivants. La pierre est réduite en poussière, et le personnage ne peut créer une nouvelle pierre
      afin d’avoir complété une <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink>.
    </p>
    <ul>
      <li>
        Un <NuxtLink to="/regles/equipement">objet</NuxtLink> non magique entrant dans un cube de 1,5 mètres d’arête est transformé en un autre objet non
        magique de taille et de poids similaire, de <NuxtLink to="/regles/equipement/monnaie">valeur</NuxtLink> inférieure ou égale. Le personnage doit
        manipuler l’objet pendant 10 minutes ou plus avant d’effectuer la transformation.
      </li>
      <li>
        Le porteur de la pierre est guéri de tout <NuxtLink to="/regles/herboristerie/poisons">poison</NuxtLink>, de toute maladie et de toute malédiction
        l’affligeant. Elle <NuxtLink to="/regles/combat/degats/soins">récupère</NuxtLink> également un nombre de
        <NuxtLink to="/regles/statistiques/vitalite">points de Vitalité</NuxtLink> égal à la moitié de son maximum.
      </li>
      <li>
        Le personnage <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalise</NuxtLink> le
        <NuxtLink to="/regles/magie/pouvoirs/niveau">niveau 6</NuxtLink> du pouvoir <NuxtLink to="/regles/magie/pouvoirs/resurrection">Résurrection</NuxtLink>.
      </li>
      <li>
        L’âge apparent du porteur de la pierre est réduit de 3d10 ans. L’âge apparent ne peut descendre en deçà de 13 ans, et cette capacité n’augmente pas la
        durée de vie du porteur.
      </li>
    </ul>
    <!-- Métamorphe (Élévation) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Métamorphe</h2>
      <div class="h5">
        <TarBadge variant="secondary">Élévation</TarBadge>
      </div>
    </div>
    <p>
      Le personnage acquiert gratuitement le pouvoir <NuxtLink to="/regles/magie/pouvoirs/polymorphisme">Polymorphisme</NuxtLink>. Une fois par jour, il peut
      <NuxtLink to="/regles/magie/pouvoirs/canalisation">canaliser</NuxtLink> ce <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> sans
      <NuxtLink to="/regles/magie/pouvoirs/energie">dépenser de point d’Énergie</NuxtLink> afin d’assumer la forme d’une bête de niveau 1 ou moins. Il ne peut
      canaliser le pouvoir de cette manière que sur lui-même et doit compléter une <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink> afin
      de réutiliser cette capacité.
    </p>
    <!-- TODO(fpion): Spell List -->
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/tar/breadcrumb";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Astromancie", to: "/regles/astromancie" },
];
const title: string = "Cercle de Transmutation";

useSeo({
  title,
  description: "Découvrez le cercle de Transmutation : des pouvoirs d’Astromancie pour modifier la réalité, l’énergie et la matière.",
});
</script>
