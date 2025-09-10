<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      La durée indique pendant combien de temps les effets d’un pouvoir agissent. Lorsque cette période est atteinte, le pouvoir s’arrête et ses effets
      n’agissent plus.
    </p>
    <p>
      Un pouvoir d’une durée <strong>instantanée</strong> prend effet immédiatement, puis se termine immédiatement. Il est donc impossible d’annuler les effets
      de ce pouvoir lorsqu’ils ont été appliqués.
    </p>
    <p>Certains pouvoirs sont permanents ; leurs effets agissent jusqu’à ce que le pouvoir soit dissipé d’une quelconque manière.</p>
    <h2 class="h3">Concentration</h2>
    <p>Les pouvoirs portant la mention <strong>Concentration</strong> nécessitent l’attention continue afin d’être maintenus.</p>
    <p>
      À chaque tour, la créature doit maintenir le pouvoir en effectuant l’<NuxtLink to="/regles/combat/deroulement/tour">action libre</NuxtLink>{{ " "
      }}<strong>Concentration</strong>.
    </p>
    <p>
      Une créature ne peut se concentrer que sur un seul pouvoir à la fois. Si elle canalise un autre pouvoir nécessitant la concentration, le premier pouvoir
      prend immédiatement fin, laissant place à l’autre pouvoir.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Magie", to: "/regles/magie" },
  { text: "Paramètres", to: "/regles/magie/parametres" },
];
const title: string = "Durée";

useSeo({
  title,
  description: "Découvrez comment la durée et la concentration influencent les effets des pouvoirs, qu’ils soient instantanés, permanents ou maintenus.",
});
</script>
