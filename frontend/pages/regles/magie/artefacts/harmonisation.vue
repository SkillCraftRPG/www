<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Certains artefacts magiques exigent qu’un personnage forme un lien particulier avec eux avant de pouvoir
      <NuxtLink to="/regles/magie/artefacts/utilisation">utiliser</NuxtLink> leurs propriétés.
    </p>
    <p>
      Ce lien est appelé <strong>harmonisation</strong>, et consiste en un rituel d’une durée d’<NuxtLink to="/regles/aventure/temps">une heure</NuxtLink>
      pouvant s’effectuer pendant une <NuxtLink to="/regles/aventure/repos/halte">halte</NuxtLink>.
    </p>
    <p>
      Le rituel dépend du type d’artefact : pratique martiale pour une arme, méditation pour un artefact merveilleux, ou toute autre activité appropriée. Si le
      rituel est interrompu, la tentative échoue.
    </p>
    <p>
      Une fois le lien créé, le personnage comprend intuitivement comment activer les propriétés magiques de l’artefact, y compris ses éventuels mots de
      commande. Sans ce lien, aucune de ses capacités magiques ne fonctionne.
    </p>
    <h2 class="h3">Prérequis</h2>
    <p>
      Un artefact peut imposer des conditions précises pour permettre l’harmonisation (<NuxtLink to="/regles/especes">espèce</NuxtLink>,
      <NuxtLink to="/regles/specialisations">spécialisation</NuxtLink>, etc.).
    </p>
    <p>
      Un personnage ne peut s’harmoniser à l’artefact que s’il satisfait ces conditions ; sinon, il n’en obtient que les bénéfices non magiques, si l’artefact
      en possède.
    </p>
    <h2 class="h3">Limite</h2>
    <p>Un personnage peut être harmonisé à un maximum de 3 artefacts magiques.</p>
    <p>Une fois cette limite atteinte, toute tentative de créer un lien supplémentaire échoue automatiquement tant qu’un lien existant n’a pas été rompu.</p>
    <h2 class="h3">Perte d’un lien</h2>
    <p>
      L’harmonisation prend fin si le personnage ne satisfait plus les prérequis, si l’artefact reste à plus de 30 mètres de lui pendant 24 heures, s’il
      <NuxtLink to="/regles/combat/mort-agonie">meurt</NuxtLink>, ou si une autre créature se lie à l’artefact.
    </p>
    <p>Le personnage peut également mettre fin volontairement à une liaison par un rituel d’une durée d’une heure, sauf si l’artefact est maudit.</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Magie", to: "/regles/magie" },
  { text: "Artefacts", to: "/regles/magie/artefacts" },
];
const title: string = "Harmonisation";

useSeo({
  title,
  description: "Découvrez l’harmonisation, le rituel essentiel permettant de créer un lien magique avec un artefact afin d’en activer pleinement les pouvoirs.",
});
</script>
