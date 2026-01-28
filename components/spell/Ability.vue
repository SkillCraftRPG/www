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
    <MarkdownContent v-if="ability.description" :text="ability.description" />
  </div>
</template>

<script setup lang="ts">
import type { SpellAbility } from "~/types/magic";

const props = defineProps<{
  ability: SpellAbility;
  title?: string | undefined;
}>();

const castingTime = computed<string>(() => {
  const formatted: string = props.ability.casting.time.trim();
  switch (formatted) {
    case "1":
    case "2":
      const actions: number = Number(formatted);
      return [actions, $t("unit.action", actions)].join(" ");
    case "R":
      return "Réaction";
    case "1m":
      return "1 minute";
    case "10m":
      return "10 minutes";
    case "8h":
      return "8 heures";
    default:
      throw new Error(`Invalid spell casting time: ${props.ability.casting.time}`);
  }
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
  return `${props.ability.range} (${[meters, $t("unit.meter", Math.floor(meters))].join(" ")})`;
});
</script>
