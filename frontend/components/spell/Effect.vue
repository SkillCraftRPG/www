<template>
  <div>
    <h3 v-if="title" class="h5">{{ title }}</h3>
    <table class="table table-striped">
      <tbody>
        <tr>
          <th class="w-sixth" scope="row">Incantation</th>
          <td class="w-third">{{ castingTime }}</td>
          <th class="w-sixth" scope="row">Composantes</th>
          <td class="w-third">
            <template v-if="components">{{ components }}</template>
            <span v-else class="text-muted">—</span>
          </td>
        </tr>
        <tr>
          <th scope="row">Durée</th>
          <td>{{ duration }}</td>
          <th scope="row">Portée</th>
          <td>{{ range }}</td>
        </tr>
        <tr v-if="effect.focus">
          <th scope="row">Focus</th>
          <td colspan="3">{{ effect.focus }}</td>
        </tr>
        <tr v-if="effect.material">
          <th scope="row">Matériel</th>
          <td colspan="3">{{ effect.material }}</td>
        </tr>
      </tbody>
    </table>
    <MarkdownContent v-if="effect.description" :text="effect.description" />
  </div>
</template>

<script setup lang="ts">
import type { SpellEffect } from "~/types/magic";

const props = defineProps<{
  effect: SpellEffect;
  title?: string | undefined;
}>();

const castingTime = computed<string>(() => {
  const formatted: string = props.effect.castingTime.trim().toUpperCase();
  switch (formatted) {
    case "1":
    case "2":
      const actions: number = Number(formatted);
      return [actions, $t("unit.action", actions)].join(" ");
    case "R":
      return "Réaction";
    default:
      throw new Error(`Invalid spell casting time: ${props.effect.castingTime}`);
  }
});
const components = computed<string>(() => {
  const components: string[] = [];
  if (props.effect.focus) {
    components.push("Focus");
  }
  if (props.effect.material) {
    components.push("Matériel");
  }
  if (props.effect.somatic) {
    components.push("Somatique");
  }
  if (props.effect.verbal) {
    components.push("Verbal");
  }
  return components.join(", ");
});
const duration = computed<string>(() => {
  if (typeof props.effect.duration !== "number") {
    return "Jusqu’à dissipation";
  } else if (!Number.isInteger(props.effect.duration)) {
    throw new Error(`Invalid spell duration: ${props.effect.duration}`);
  }
  const concentration: string = props.effect.concentration ? "Concentration, jusqu’à " : "";
  let duration: string = "";
  switch (props.effect.duration) {
    case 0:
      duration = "Instantanée";
      break;
    case 6:
      duration = "1 round";
      break;
    case 60:
      duration = "1 minute";
      break;
    case 600:
      duration = "10 minutes";
      break;
    case 3600:
      duration = "1 heure";
      break;
    default:
      duration = [props.effect.duration, $t("unit.second", props.effect.duration)].join(" ");
      break;
  }
  return concentration + duration;
});
const range = computed<string>(() => {
  switch (props.effect.range) {
    case 0:
      return "Soi";
    case 1:
      return "Toucher";
  }
  if (props.effect.range < 0) {
    throw new Error(`Invalid spell range: ${props.effect.range}`);
  }
  const meters: number = props.effect.range * 1.5;
  return `${props.effect.range} (${[meters, $t("unit.meter", Math.floor(meters))].join(" ")})`;
});
</script>
