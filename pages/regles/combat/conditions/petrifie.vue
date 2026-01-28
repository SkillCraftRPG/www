<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Une créature pétrifiée est transformée en pierre avec tout objet non-magique qu’elle tenait ou portait. Son poids est multiplié par 10, et son
      vieillissement est suspendu.
    </p>
    <p>
      Elle est <NuxtLink to="/regles/combat/conditions/incapable">incapable</NuxtLink> : elle ne peut pas bouger, ni parler, et n’est pas consciente de son
      environnement et de ce qui se déroule autour d’elle.
    </p>
    <p>
      Également, elle échoue automatiquement ses <NuxtLink to="/regles/competences/tests/sauvegarde">jets de sauvegarde</NuxtLink> d’<NuxtLink
        to="/regles/competences/athletisme"
        >Athlétisme</NuxtLink
      >
      et d’<NuxtLink to="/regles/competences/acrobaties">Acrobaties</NuxtLink>.
    </p>
    <p>
      Enfin, le <NuxtLink to="/regles/competences/tests">test</NuxtLink> des <NuxtLink to="/regles/combat/attaque">attaques</NuxtLink> dirigées contre elle se
      voit conférer l’<NuxtLink to="/regles/competences/tests/avantage-desavantage">avantage</NuxtLink>. Elle est
      <NuxtLink to="/regles/combat/degats/efficacite">résistante</NuxtLink> aux <NuxtLink to="/regles/combat/degats">dégâts</NuxtLink> de tous
      <NuxtLink to="/regles/combat/degats/types">types</NuxtLink>. Elle est également immunisée aux poisons et maladies, mais ces conditions sont suspendues et
      non pas neutralisées. Elles reprendront effet lorsque la créature ne sera plus pétrifiée.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Conditions", to: "/regles/combat/conditions" },
];
const title: string = "Pétrifié";

useSeo({
  title,
  description: "Découvrez l’état pétrifié : une créature transformée en pierre, incapable d’agir, résistante aux dégâts et immunisée aux poisons et maladies.",
});
</script>
