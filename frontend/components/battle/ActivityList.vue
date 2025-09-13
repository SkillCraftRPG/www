<template>
  <ClientOnly>
    <div class="row">
      <div class="col-xs-12 col-sm-6 col-lg-4 mb-4">
        <BattleActionSelect v-model="actions" />
      </div>
      <div class="col-xs-12 col-sm-6 col-lg-4 mb-4">
        <BattleThreateningSelect v-model="threatening" />
      </div>
      <div class="col-xs-12 col-sm-6 col-lg-4 mb-4">
        <ListMode v-model="mode" />
      </div>
    </div>
    <div v-if="mode === 'grid'" class="row">
      <div v-for="activity in activities" :key="activity.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <BattleActivityCard :activity="activity" />
      </div>
    </div>
    <table v-else-if="mode === 'list'" class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-third">Activité</th>
          <th scope="col" class="w-third">Actions</th>
          <th scope="col" class="w-third">Résumé</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="activity in activities" :key="activity.id">
          <td>
            <NuxtLink :to="activity.path">{{ activity.name }}</NuxtLink>
          </td>
          <td>
            <template v-if="hasActions(activity)">
              <IconAction v-for="index in activity.actions.mandatory" :key="index" class="me-1" />
              <IconAction v-for="index in activity.actions.optional" :key="index" class="me-1" optional />
              <IconReaction v-if="activity.actions.reaction" class="me-1" />
              <IconOpportunity v-if="activity.threatening" class="me-1" :variable="mayBeThreatening(activity)" />
            </template>
            <span v-else class="text-muted">{{ "—" }}</span>
          </td>
          <td>{{ activity.summary }}</td>
        </tr>
      </tbody>
    </table>
  </ClientOnly>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Activity } from "~/types/game";
import type { ListMode } from "~/types/components";

const { orderBy } = arrayUtils;

const props = defineProps<{
  items: Activity[];
}>();

const actions = ref<string>("");
const mode = ref<ListMode>("grid");
const threatening = ref<string>("");

const activities = computed<Activity[]>(() => {
  return orderBy(
    props.items.filter((activity) => {
      const total: number = activity.actions.mandatory + activity.actions.optional;
      switch (actions.value) {
        case "1":
          if (total !== 1) {
            return false;
          }
          break;
        case "2":
          if (total !== 2) {
            return false;
          }
          break;
        case "3":
          if (total !== 3) {
            return false;
          }
          break;
        case "reaction":
          if (!activity.actions.reaction) {
            return false;
          }
          break;
        case "free":
          if (total > 0 || activity.actions.reaction) {
            return false;
          }
          break;
      }
      switch (threatening.value) {
        case "maybe":
          if (activity.threatening !== "maybe") {
            return false;
          }
          break;
        case "no":
          if (activity.threatening !== false) {
            return false;
          }
          break;
        case "no-maybe":
          if (activity.threatening !== false && activity.threatening !== "maybe") {
            return false;
          }
          break;
        case "yes":
          if (activity.threatening !== true) {
            return false;
          }
          break;
        case "yes-maybe":
          if (activity.threatening !== true && activity.threatening !== "maybe") {
            return false;
          }
          break;
      }
      return true;
    }),
    "name",
  ); // TODO(fpion): filters
});

function hasActions(activity: Activity): boolean {
  return activity.actions.mandatory > 0 || activity.actions.optional > 0 || activity.actions.reaction;
}
function mayBeThreatening(activity: Activity): boolean {
  return activity.threatening === "maybe";
}
</script>
