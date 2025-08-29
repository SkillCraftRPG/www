<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>Intrépides et impétueux, les aventuriers affronteront de nombreux obstacles variés au fil de leurs expéditions.</p>
    <p>Les divers rebondissements qu’ils vivront toucheront à un des piliers du jeu, soit l’exploration, l’interaction sociale et le combat.</p>
    <p>Ces aventures éprouvantes exigeront d’eux qu’ils se reposent afin de maximiser leur potentiel.</p>
    <p>Enfin, ils pourront bénéficier de leurs expériences entres les aventures et faire fructifier leurs acquis.</p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
    <h2 class="h3">Entre les aventures</h2>
    <p>Entre deux aventures, le personnage se repose et prépare sa prochaine aventure.</p>
    <p>
      Il adopte un <NuxtLink to="/regles/equipement/depenses">style de vie</NuxtLink> et paie les coûts associés à celui-ci afin de survivre. Adopter un style
      de vie ayant un coût élevé peut aider un personnage à se frayer un chemin parmi les hautes sphères de la société ou à attirer l’attention des autorités.
    </p>
    <p>
      Il peut s’occuper en accomplissant diverses activités, notamment s’adonner à une profession, se remettre de blessures ayant mis sa vie en péril, effectuer
      des recherches, s’entraîner ou tout simplement profiter de la vie en se reposant en toute sérénité.
    </p>
    <p>Certaines activités à but lucratif peuvent lui rapporter de l’argent ou d’autres faveurs matérielles, à la discrétion du maître de jeu.</p>
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
  {
    path: "/regles/aventure/environnement",
    title: "Environnement",
    description: "Règles d’environnement : chutes, vision, survie et objets.",
  },
  {
    path: "/regles/aventure/interaction-sociale",
    title: "Interaction sociale",
    description: "Règles d’interaction sociale et attitudes des personnages.",
  },
  {
    path: "/regles/aventure/repos",
    title: "Repos",
    description: "Sommeil et halte, sources de repos et régénération.",
  },
  {
    path: "/regles/aventure/alcoolemie",
    title: "Alcoolémie",
    description: "🚧",
  },
];

useSeo({
  title,
  description: "Découvrez les règles dirigeant les aventures : temps, mouvement, environnement, interactions sociales, repos et activités entre les aventures.",
});
</script>
