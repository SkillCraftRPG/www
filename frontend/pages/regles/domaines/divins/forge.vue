<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les divinités appartement à ce domaine sont intéressées aux <NuxtLink to="/regles/equipement/marchandise">métaux</NuxtLink> et au métier de forgeron.
      Elles s’associent à la patience et aux œuvres créatrices et artisanales.
    </p>
    <p>
      Type de dégâts de l’<NuxtLink to="/regles/specialisations/pretre">Attaque divine</NuxtLink> : <NuxtLink to="/regles/combat/degats/types">feu</NuxtLink>
    </p>
    <!-- Artisan divin (Tiers 0) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Artisan divin</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;0</TarBadge>
      </div>
    </div>
    <p>
      Le personnage acquiert gratuitement le talent <NuxtLink to="/regles/talents/artisanat">Artisanat</NuxtLink> et est formé à l’utilisation des
      <NuxtLink to="/regles/equipement/outils">outils de forgeron</NuxtLink>.
    </p>
    <!-- Grâce du forgeron (Tiers 1) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Grâce du forgeron</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;1</TarBadge>
      </div>
    </div>
    <p>
      Le personnage peut effectuer un rituel d’une durée minimale de <NuxtLink to="/regles/aventure/temps">10 minutes</NuxtLink> afin de consacrer une
      <NuxtLink to="/regles/equipement/armes">arme</NuxtLink>, un <NuxtLink to="/regles/equipement/boucliers">bouclier</NuxtLink> ou une
      <NuxtLink to="/regles/equipement/armures">armure</NuxtLink>.
    </p>
    <p>
      À la fin du rituel, il choisit un nombre inférieur ou égal à son <NuxtLink to="/regles/personnages/progression/tiers">tiers</NuxtLink> et effectue un
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/artisanat">Artisanat</NuxtLink>. Il peut remplacer son
      <NuxtLink to="/regles/attributs/adresse">Adresse</NuxtLink> par sa <NuxtLink to="/regles/attributs/sante">Santé</NuxtLink> et peut
      <NuxtLink to="/regles/competences/tests/faire-10">Faire 10</NuxtLink> s’il le désire. La
      <NuxtLink to="/regles/competences/tests/difficulte">difficulté</NuxtLink> varie en fonction du nombre sélectionné.
    </p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-50">Bonus</th>
          <th scope="col" class="w-50">Difficulté</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>+1</td>
          <td>Moyenne (15)</td>
        </tr>
        <tr>
          <td>+2</td>
          <td>Élevée (20)</td>
        </tr>
        <tr>
          <td>+3</td>
          <td>Très élevée (25)</td>
        </tr>
      </tbody>
    </table>
    <p>
      Si le test est réussi, l’<NuxtLink to="/regles/equipement">équipement</NuxtLink> devient <NuxtLink to="/regles/combat/degats/types">magique</NuxtLink> et
      confère un bonus également au nombre sélectionné.
    </p>
    <ul>
      <li>Au test des <NuxtLink to="/regles/combat/attaque">attaques</NuxtLink> effectuées en maniant l’arme.</li>
      <li>Aux <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> infligés par l’arme.</li>
      <li>À la <NuxtLink to="/regles/equipement/defense">Défense</NuxtLink> conférée par le bouclier ou l’armure.</li>
    </ul>
    <p>L’effet dure pendant 24 heures, ou jusqu’à ce que le personnage effectue le rituel à nouveau.</p>
    <p>
      Le personnage doit compléter une <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink> afin de pouvoir effectuer le rituel à nouveau,
      autant en cas de réussite qu’en cas d’échec.
    </p>
    <!-- Grâce de l’artisan (Pouvoir divin) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Grâce de l’artisan</h2>
      <div class="h5">
        <TarBadge variant="secondary">Pouvoir&nbsp;divin</TarBadge>
      </div>
    </div>
    <p>
      Le personnage effectue un rituel d’une durée d’<NuxtLink to="/regles/aventure/temps">une heure</NuxtLink> afin de créer un objet non magique constitué au
      moins partiellement de <NuxtLink to="/regles/equipement/marchandise">métal</NuxtLink> : une <NuxtLink to="/regles/equipement/armes">arme</NuxtLink>, un
      <NuxtLink to="/regles/equipement/boucliers">bouclier</NuxtLink>, une pièce d’<NuxtLink to="/regles/equipement/armures">armure</NuxtLink>,
      <NuxtLink to="/regles/equipement/armes/munitions">10 munitions</NuxtLink>, des <NuxtLink to="/regles/equipement/outils">outils</NuxtLink>, etc.
    </p>
    <p>
      Il présente son <NuxtLink to="/regles/equipement/general">symbole divin</NuxtLink> au métal, qui prend la forme de l’objet dans un escape inoccupé situé à
      1,5 mètres ou moins de sa position. Il peut fabriquer la réplique d’un objet existant, par exemple une clé, s’il en possède l’original.
    </p>
    <p>
      La valeur de la création doit être d’au plus <NuxtLink to="/regles/equipement/monnaie">100 deniers</NuxtLink>, et il doit fournir du métal, à l’état brut
      ou transformé, d’une valeur supérieure ou égale à celle de l’objet.
    </p>
    <!-- Âme des flammes (Tiers 2) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Âme des flammes</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;2</TarBadge>
      </div>
    </div>
    <p>
      Le personnage est <NuxtLink to="/regles/combat/degats/efficacite">résistant</NuxtLink> aux <NuxtLink to="/regles/combat/degats">dégâts</NuxtLink> de
      <NuxtLink to="/regles/combat/degats/types">feu</NuxtLink>. Également, il se voit conférer un bonus (+1) à l’<NuxtLink to="/regles/combat/attaque/esquive"
        >Esquive</NuxtLink
      >
      lorsqu’il porte une <NuxtLink to="/regles/equipement/armures">armure</NuxtLink> <NuxtLink to="/regles/equipement/armures/lourdes">lourde</NuxtLink>{{ " "
      }}<NuxtLink to="/regles/equipement/armures/partielles">complète</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Domaines divins", to: "/regles/domaines/divins" },
];
const title: string = "Forge";

useSeo({
  title,
  description:
    "Découvrez le domaine divin de la Forge, dédié aux métaux et à l’artisanat sacré, offrant consécration d’armes, création d’objets et pouvoirs liés au feu et à la maîtrise du métal.",
});
</script>
