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
        <tr v-if="ability.components.focus">
          <th scope="row">Focus</th>
          <td colspan="3">{{ ability.components.focus }}</td>
        </tr>
        <tr v-if="ability.components.material">
          <th scope="row">Matériel</th>
          <td colspan="3">{{ ability.components.material }}</td>
        </tr>
      </tbody>
    </table>
    <MarkdownContent v-if="ability.htmlContent" :text="ability.htmlContent" />
  </div>
</template>

<script setup lang="ts">
import type { SpellAbility } from "~/types/magic";

const props = defineProps<{
  ability: SpellAbility;
  title?: string | undefined;
}>();

const castingTime = computed<string>(() => {
  let formatted: string = "";
  const trimmed: string = props.ability.casting.time.trim();
  switch (trimmed) {
    case "1":
    case "2":
      const actions: number = Number(trimmed);
      formatted = [actions, $t("unit.Action", actions)].join(" ");
    case "R":
      formatted = "Réaction";
    case "1m":
      formatted = "1 minute";
    case "10m":
      formatted = "10 minutes";
    case "1h":
      formatted = "1 heure";
    case "8h":
      formatted = "8 heures";
    case "12h":
      formatted = "12 heures";
    case "24h":
      formatted = "24 heures";
    default:
      throw new Error(`Invalid spell casting time: ${props.ability.casting.time}`);
  }
  return props.ability.casting.ritual ? `${formatted} (rituel)` : formatted;
});
const components = computed<string>(() => {
  const components: string[] = [];
  if (props.ability.components.focus) {
    components.push("Focus");
  }
  if (props.ability.components.material) {
    components.push("Matériel");
  }
  if (props.ability.components.somatic) {
    components.push("Somatique");
  }
  if (props.ability.components.verbal) {
    components.push("Verbal");
  }
  return components.join(", ");
});
const duration = computed<string>(() => {
  if (!props.ability.duration) {
    return "Jusqu’à dissipation";
  } else if (props.ability.duration.value === 0) {
    return "Instantanée";
  } else if (props.ability.duration.value < 0) {
    throw new Error(`Invalid spell duration: ${JSON.stringify(props.ability.duration)}`);
  }
  const concentration: string = props.ability.duration.concentration ? "Concentration, jusqu’à " : "";
  const duration: string = [props.ability.duration.value, $t(`unit.${props.ability.duration.unit}`, props.ability.duration.value)].join(" ");
  return concentration + duration;
});
const range = computed<string>(() => {
  switch (props.ability.range) {
    case 0:
      return "Soi";
    case 1:
      return "Toucher";
  }
  if (props.ability.range < 0) {
    throw new Error(`Invalid spell range: ${props.ability.range}`);
  }
  const meters: number = props.ability.range * 1.5;
  return `${props.ability.range} (${[meters, $t("unit.Meter", Math.floor(meters))].join(" ")})`;
});
</script>
