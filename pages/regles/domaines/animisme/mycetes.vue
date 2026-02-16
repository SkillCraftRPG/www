<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les esprits appartenant à ce domaine sont associés à la mort et à la décomposition. Les animistes s’identifiant à ce domaine sont passionnés des
      champignons et des autres mycètes.
    </p>
    <!-- Parole des bois (Tiers 0) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Putréfaction</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;0</TarBadge>
      </div>
    </div>
    <p>Le personnage acquiert gratuitement le pouvoir <NuxtLink to="/regles/magie/pouvoirs/frisson">Frisson</NuxtLink>.</p>
    <p>
      Également, il est entouré de spores invisibles de manière permanente. Ces spores sont inoffensives, sauf s’il utilise sa
      <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> lorsqu’une créature débute son
      <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink> à 3 mètres ou moins de sa position, ou se
      <NuxtLink to="/regles/combat/activites/deplacement">déplace</NuxtLink> volontairement dans cette zone. La cible doit effectuer un
      <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de <NuxtLink to="/regles/competences/resistance">Résistance</NuxtLink> de
      <NuxtLink to="/regles/competences/tests/difficulte">difficulté</NuxtLink> égale au
      <NuxtLink to="/regles/competences/tests/passif">test passif</NuxtLink> d’<NuxtLink to="/regles/competences/occultisme">Occultisme</NuxtLink> du
      personnage. En cas d’échec, la cible reçoit un nombre de d6 <NuxtLink to="/regles/combat/degats/types">points de dégâts nécrotiques</NuxtLink> égal au
      <NuxtLink to="/regles/personnages/progression/tiers">tiers</NuxtLink> du personnage.
    </p>
    <!-- Forme spongieuse (Tiers 1) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Forme spongieuse</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;1</TarBadge>
      </div>
    </div>
    <p>
      Plutôt que d’assumer une <NuxtLink to="/regles/specialisations/animiste">Forme sauvage</NuxtLink>, le personnage peut prendre la forme d’un champignon.
      Lorsqu’il en fait ainsi, il bénéficie des effets suivants.
    </p>
    <ul>
      <li>
        Il se voit conférer un nombre de points de <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink>{{ " "
        }}<NuxtLink to="/regles/combat/degats/temporaire">temporaires</NuxtLink> égal à son
        <NuxtLink to="/regles/personnages/progression/niveau">niveau</NuxtLink>.
      </li>
      <li>
        Ses <NuxtLink to="/regles/combat/attaque/melee">attaques de mêlée</NuxtLink> infligent
        <NuxtLink to="/regles/personnages/progression/tiers">tiers</NuxtLink>&nbsp;+&nbsp;<NuxtLink to="/regles/combat/degats/jet"
          >1d6 points de dégâts</NuxtLink
        >{{ " " }}<NuxtLink to="/regles/combat/degats/types">nécrotiques</NuxtLink> supplémentaires.
      </li>
      <li>Il double le nombre de dés de <NuxtLink to="/regles/combat/degats">dégâts</NuxtLink> infligés par les spores de <strong>Putréfaction</strong>.</li>
    </ul>
    <p>
      Sa forme prend fin après <NuxtLink to="/regles/aventure/temps">10 minutes</NuxtLink>, s’il perd tous les points de Vitalité temporaires, ou s’il assume
      une autre forme sauvage.
    </p>
    <!-- Infestation fongique (Tiers 2) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Infestation fongique</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;2</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage <NuxtLink to="/regles/aventure/environnement/vision">voit</NuxtLink> une bête ou un humanoïde de taille
      <NuxtLink to="/regles/especes/taille">Moyenne</NuxtLink> ou moindre <NuxtLink to="/regles/combat/mort-agonie">mourir</NuxtLink> à 3 mètres ou moins de sa
      position, il peut utiliser sa <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> afin d’infester le cadavre de ses spores. Le cadavre est
      instantanément relevé en zombie possédant un point de <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink>. Le zombie reste animé pendant
      <NuxtLink to="/regles/aventure/temps">une heure</NuxtLink>.
    </p>
    <p>
      Il effectue son <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink> immédiatement après celui du personnage. Il obéit aux commandes mentales du
      personnage, ne peut effectuer que deux <NuxtLink to="/regles/combat/deroulement/tour">actions</NuxtLink> par tour, et les seules activités qu’il peut
      effectuer sont <NuxtLink to="/regles/combat/attaque">Attaquer</NuxtLink> et <NuxtLink to="/regles/combat/activites/deplacement">Déplacement</NuxtLink>.
    </p>
    <!-- Enveloppe fongique (Tiers 3) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Enveloppe fongique</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;3</TarBadge>
      </div>
    </div>
    <p>
      Le personnage ne peut être <NuxtLink to="/regles/combat/conditions/apeure">apeuré</NuxtLink>,
      <NuxtLink to="/regles/combat/conditions/assourdi">assourdi</NuxtLink>, <NuxtLink to="/regles/combat/conditions/aveugle">aveuglé</NuxtLink>, ni
      <NuxtLink to="/regles/combat/conditions/empoisonne">empoisonné</NuxtLink>. De plus, lorsqu’il est victime d’une
      <NuxtLink to="/regles/combat/attaque">attaque</NuxtLink> et que celle-ci s’avère à être un
      <NuxtLink to="/regles/competences/tests/critique">coup critique</NuxtLink>, alors il peut utiliser sa
      <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> afin de transformer le coup critique en simple réussite.
    </p>
    <!-- Nuage de spores (Tiers 3) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Nuage de spores</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;3</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage assume sa <strong>Forme spongieuse</strong>, par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, il peut
      envoyer ses spores former un nuage dans un cube de 3 mètres d’arête centré sur un point qu’il peut
      <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink> situé à 9 mètres ou moins de sa position. Les spores tourbillonnent dans la zone
      pendant <NuxtLink to="/regles/aventure/temps">une minute</NuxtLink>. Une fois par <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, par une
      action, il peut déplacer le nuage de spores, ou rappeler les spores à lui. Le nuage revient automatiquement à lui s’il perd sa
      <strong>Forme spongieuse</strong>.
    </p>
    <p>
      Lorsqu’une créature débute son tour dans la zone ou qu’elle s’y <NuxtLink to="/regles/combat/activites/deplacement">déplace</NuxtLink> volontairement,
      elle est affligée par les effets des spores de <strong>Putréfaction</strong>. Une créature ne peut recevoir ces
      <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> qu’une seule fois par <NuxtLink to="/regles/combat/deroulement">round</NuxtLink>.
      Néanmoins, lorsque ses spores ne sont pas centrées sur lui, le personnage ne peut utiliser sa
      <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> afin d’affliger une créature des effets de ses spores de <strong>Putréfaction</strong>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Domaines d’animisme", to: "/regles/domaines/animisme" },
];
const title: string = "Mycètes";

useSeo({
  title,
  description:
    "Découvrez le domaine des Mycètes, lié à la mort et à la décomposition : spores nécrotiques, formes fongiques, zombification et nuages toxiques au service de l’animiste.",
});
</script>
