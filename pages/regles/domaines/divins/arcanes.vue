<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Les divinités appartenant à ce domaine s’intéressent à la magie ainsi qu’à la connaissance des mystères et des secrets.</p>
    <p>
      Type de dégâts de l’<NuxtLink to="/regles/specialisations/pretre">Attaque divine</NuxtLink> : <NuxtLink to="/regles/combat/degats/types">force</NuxtLink>
    </p>
    <!-- Astrologue novice (Tiers 0) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Astrologue novice</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;0</TarBadge>
      </div>
    </div>
    <p>
      Afin de bénéficier de cette capacité, le personnage doit posséder un <NuxtLink to="/regles/equipement/general">grimoire</NuxtLink> d’une valeur minimale
      de <NuxtLink to="/regles/equipement/monnaie">50 deniers</NuxtLink>.
    </p>
    <ul>
      <li>Il acquiert gratuitement un <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> d’<NuxtLink to="#">astromancie</NuxtLink> de tiers 0.</li>
      <li>
        Il sélectionne un des <NuxtLink to="#">signes astrologiques</NuxtLink> associés à ce pouvoir et transcrit gratuitement ce signe dans son grimoire.
      </li>
      <li>Il transcrit également gratuitement le signe opposé au signe sélectionné.</li>
    </ul>
    <!-- Astrologue initié (Tiers 1) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Astrologue initié</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;1</TarBadge>
      </div>
    </div>
    <p>
      Le personnage sélectionne un <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> d’<NuxtLink to="#">astromancie</NuxtLink> de tiers 1. S’il a déjà
      transcrit dans son grimoire le <NuxtLink to="#">signe astrologique</NuxtLink> associé à ce pouvoir, alors il acquiert instantanément et gratuitement ce
      pouvoir.
    </p>
    <p>
      Sinon, il doit utiliser son <NuxtLink to="/regles/specialisations/clerc">pouvoir divin</NuxtLink> afin d’effectuer un rituel divin d’une durée minimale
      d’<NuxtLink to="/regles/aventure/temps">une heure</NuxtLink>. Ce rituel peut être effectué pendant une
      <NuxtLink to="/regles/aventure/repos/halte">halte</NuxtLink>. À la fin de ce rituel, le signe astrologique associé à ce pouvoir ainsi que le signe opposé
      lui sont révélés. Ils sont magiquement transcrits instantanément et gratuitement dans son grimoire. Il acquiert ensuite gratuitement le pouvoir
      sélectionné.
    </p>
    <!-- Abjuration arcane (Pouvoir divin) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Abjuration arcane</h2>
      <div class="h5">
        <TarBadge variant="secondary">Pouvoir&nbsp;divin</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage utilise le talent <NuxtLink to="/regles/talents/renvoi-des-morts-vivants">Renvoi des morts-vivants</NuxtLink>, alors il peut cibler
      une seule créature appartenant à un des types suivants plutôt que de cibler les morts-vivants : aberration, célestiel, élémentaire, fée ou infernal.
    </p>
    <p>
      Lorsqu’il en fait ainsi, si la cible échoue le <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink>, que son niveau est
      inférieur ou égal au <NuxtLink to="/regles/personnages/progression/tiers">tiers</NuxtLink> du personnage et qu’elle provient d’une autre dimension, alors
      elle est bannie dans sa dimension d’origine pendant la prochaine <NuxtLink to="/regles/aventure/temps">minute</NuxtLink>. Le personnage n’a pas besoin de
      maintenir sa <NuxtLink to="/regles/magie/parametres/duree">concentration</NuxtLink> contre une créature bannie.
    </p>
    <!-- Briseur de sorts (Tiers 2) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Briseur de sorts</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;2</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalise</NuxtLink> un
      <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> et qu’une créature <NuxtLink to="/regles/combat/degats/soins">récupère</NuxtLink> des points de
      <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> en raison de ce pouvoir, alors il peut également mettre fin à un pouvoir affectant la
      cible. Le <NuxtLink to="/regles/magie/pouvoirs/niveau">niveau</NuxtLink> du pouvoir canalisé par le personnage doit être supérieur ou égal au niveau du
      pouvoir affligeant la cible.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Domaines divins", to: "/regles/domaines/divins" },
];
const title: string = "Arcanes";

useSeo({
  title,
  description:
    "Découvrez le domaine des Arcanes, consacré à la magie, à l’astromancie et à la dissipation des pouvoirs surnaturels par la connaissance et la maîtrise des secrets.",
});
</script>
