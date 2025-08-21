<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>Intrépides et impétueux, les aventuriers affronteront de nombreux obstacles variés au fil de leurs expéditions.</p>
    <p>Les divers rebondissements qu’ils vivront toucheront à un des piliers du jeu, soit l’exploration, l’interaction sociale et le combat.</p>
    <p>Ces aventures éprouvantes exigeront d’eux qu’ils se reposent afin de maximiser leur potentiel.</p>
    <p>Enfin, ils pourront bénéficier de leurs expériences entres les aventures et faire fructifier leurs acquis.</p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
const title: string = "Aventure";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/aventure/temps",
    title: "Temps",
    description: "Cycle de jeu et différentes périodes temporelles.",
  },
  {
    path: "/regles/aventure/mouvement",
    title: "Mouvement",
    description: "Déplacements selon vitesse, terrain et furtivité, en combat ou en voyage.",
  },
];

/* TODO(fpion):
 * Environnement
 * Interaction sociale
 * Repos
 * Alcoolémie
 * Entre les aventures
 */

useSeo({
  title,
  description: "Découvrez les règles dirigeant les aventures : temps, mouvement, environnement, interactions sociales, repos et activités entre les aventures.",
});
</script>
