<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Cette page liste les activités pouvant être effectuées en combat.</p>
    <h2 class="h3">Légende</h2>
    <ul>
      <li>
        Les diamants « <IconAction /> » représentent le nombre d’<NuxtLink to="/regles/combat/deroulement/tour">actions</NuxtLink>
        nécessaires afin d’effectuer cette activité. Certaines activités ont un nombre variable d’actions.
      </li>
      <li>Les activités marquées de « <IconReaction /> » nécessitent d’utiliser sa <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink>.</li>
      <li>
        Les activités qui ne sont ni marquées d’une action, ni d’une réaction, peuvent être effectuées en
        <NuxtLink to="/regles/combat/deroulement/tour">action libre</NuxtLink>.
      </li>
      <li>
        Les activités marquées de « <IconOpportunity /> » déclenchent une <NuxtLink to="/regles/combat/attaque/opportunite">attaque d’opportunité</NuxtLink>.
        L’astérisque « * » indique que l’activité ne déclenche pas toujours l’attaque d’opportunité.
      </li>
    </ul>
    <h2 class="h3">Liste des activités</h2>
    <!-- TODO(fpion): filter by category (1-2-3 actions, reaction, action libre) -->
    <!-- TODO(fpion): filter by threatening -->
    <!-- TODO(fpion): grid vs table  -->
    <div class="row">
      <div v-for="activity in activities" :key="activity.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <BattleActivityCard :activity="activity" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Activity } from "~/types/game";
import type { Breadcrumb } from "~/types/components";
import { getActivities } from "~/services/battle";

const parent: Breadcrumb[] = [{ text: "Combat", to: "/regles/combat" }];
const title: string = "Activités";
const { orderBy } = arrayUtils;

const allActivities = ref<Activity[]>(getActivities());

const activities = computed<Activity[]>(() => orderBy(allActivities.value, "name"));

useSeo({
  title,
  description:
    "Découvrez toutes les activités de combat possibles : attaquer, se défendre, se déplacer, canaliser un pouvoir, préparer une action et plus encore.",
});
</script>
