<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les esprits appartenant à ce domaine sont associés à la nature sauvage, à la faune et à la flore. Les animistes s’identifiant à ce domaine sont sages et
      se rassemblent dans des cercles de pierres dressées.
    </p>
    <!-- Magie sauvage (Tiers 0) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Magie sauvage</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;0</TarBadge>
      </div>
    </div>
    <p>
      Le personnage acquiert gratuitement un <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> de tiers 0 associé à son
      <NuxtLink to="/regles/domaines/animisme">domaine d’animisme</NuxtLink>.
    </p>
    <!-- Récupération naturelle (Tiers 1) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Récupération naturelle</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;1</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage acquiert le talent <NuxtLink to="/regles/talents/meditation">Méditation</NuxtLink>, alors il acquiert également gratuitement un
      pouvoir de tiers 1 associé à son domaine d’animisme.
    </p>
    <!-- Grands pas (Tiers 2) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Grands pas</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;2</TarBadge>
      </div>
    </div>
    <p>Le personnage acquiert les capacités suivantes :</p>
    <ul>
      <li>
        Il n’est plus affligé par le <NuxtLink to="/regles/aventure/mouvement/terrain-difficile">terrain difficile</NuxtLink> lorsque celui-ci n’est pas
        magique.
      </li>
      <li>Il peut traverser de la végétation non magique, par exemple des épines ou des dangers similaires, sans être ralenti ni blessé par celle-ci.</li>
      <li>
        Il se voit conférer l’<NuxtLink to="/regles/competences/tests/avantage-desavantage">avantage</NuxtLink> à ses
        <NuxtLink to="/regles/competences/tests/sauvegarde">jets de sauvegarde</NuxtLink> contre les créatures et effets végétaux magiques tentant d’entraver
        ses <NuxtLink to="/regles/aventure/mouvement">mouvements</NuxtLink>.
      </li>
    </ul>
    <!-- Garde sauvage (Tiers 3) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Garde sauvage</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;3</TarBadge>
      </div>
    </div>
    <p>
      Le personnage est immunisé aux <NuxtLink to="/regles/herboristerie/poisons">poisons</NuxtLink> et maladies. De plus, il ne peut être
      <NuxtLink to="/regles/combat/conditions/apeure">apeuré</NuxtLink> ni <NuxtLink to="/regles/combat/conditions/charme">charmé</NuxtLink> par les
      élémentaires et les fées.
    </p>
    <!-- Sanctuaire sauvage (Tiers 3) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Sanctuaire sauvage</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;3</TarBadge>
      </div>
    </div>
    <p>
      Les créatures naturelles ressentent la connexion entre le personnage et la nature sauvage, elles seront donc hésitantes à lui faire du mal. Lorsqu’une
      bête ou une plante tente d’<NuxtLink to="/regles/combat/attaque">attaquer</NuxtLink> le personnage, alors celle-ci doit effectuer un
      <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de <NuxtLink to="/regles/competences/discipline">Discipline</NuxtLink> de
      <NuxtLink to="/regles/competences/tests/difficulte">difficulté</NuxtLink> égale au
      <NuxtLink to="/regles/competences/tests/passif">test passif</NuxtLink> d’<NuxtLink to="/regles/competences/occultisme">Occultisme</NuxtLink> du
      personnage. En cas de réussite, la créature est immunisée à cet effet pendant les 24 prochaines heures. En cas d’échec, la créature doit attaquer une
      autre cible, sinon l’attaque échoue automatiquement.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Domaines d’animisme", to: "/regles/domaines/animisme" },
];
const title: string = "Terre";

useSeo({
  title,
  description:
    "Découvrez le domaine d’animisme Terre : magie sauvage, endurance accrue, immunités naturelles, affinité avec la faune et la flore, déplacements facilités.",
});
</script>
