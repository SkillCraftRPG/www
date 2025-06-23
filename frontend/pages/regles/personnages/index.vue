<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>Au cinéma comme dans la littérature, l’attention du public est centrée sur un ou plusieurs héros ou héroïnes.</p>
    <p>Dans le jeu de rôle, ce sont les personnages des joueurs qui sont les protagonistes de l’histoire.</p>
    <p>Leurs paroles et leurs actions donnent vie à l’intrigue racontée par le maître de jeu.</p>
    <!-- TODO(fpion): tiles -->
    <ul>
      <li>
        <NuxtLink to="/regles/personnages/creation">Création de personnage</NuxtLink>
      </li>
      <li>
        <NuxtLink to="/regles/personnages/progression">Progression de personnage</NuxtLink>
      </li>
    </ul>
  </main>
</template>

<script setup lang="ts">
const title: string = "Personnages";

useSeoMeta({
  title,
  description: "Découvrez le fonctionnement des personnages dans le jeu, véritables héros de l’histoire, et explorez les règles de création et de progression.",
});
useLinks();
</script>
