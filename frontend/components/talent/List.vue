<template>
  <ClientOnly>
    <div class="row">
      <div class="col-xs-12 col-sm-6 col-lg-4 mb-4">
        <YesNoSelect id="allow-multiple-purchases" label="Achats multiples" placeholder="Tous" v-model="allowMultiplePurchases" />
      </div>
      <div class="col-xs-12 col-sm-6 col-lg-4 mb-4">
        <SkillSelect extended label="Filtrer par compétence" :model-value="skill?.id" placeholder="Tous" :skills="skills" @selected="skill = $event" />
      </div>
      <div class="col-sm-12 col-lg-4 mb-4">
        <ListMode v-model="mode" />
      </div>
    </div>
    <template v-for="group in groups" :key="group.tier">
      <h3 class="h5">Talents de tiers {{ group.tier }}</h3>
      <div v-if="mode === 'grid'" class="row">
        <div v-for="talent in group.talents" :key="talent.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
          <TalentCard :talent="talent" class="d-flex flex-column h-100" />
        </div>
      </div>
      <table v-else-if="mode === 'list'" class="table table-striped">
        <thead>
          <tr>
            <th scope="col">Nom</th>
            <th scope="col">Talent requis</th>
            <th scope="col">Compétence</th>
            <th scope="col">Résumé</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="talent in group.talents" :key="talent.id">
            <td>
              <NuxtLink :to="`/regles/talents/${talent.slug}`">{{ talent.name }}</NuxtLink>
              <template v-if="talent.allowMultiplePurchases">
                <br />
                <i>Achats&nbsp;multiples</i>
              </template>
            </td>
            <td>
              <NuxtLink v-if="talent.requiredTalent" :to="`/regles/talents/${talent.requiredTalent.slug}`">{{ talent.requiredTalent.name }}</NuxtLink>
              <span v-else class="text-muted">{{ "—" }}</span>
            </td>
            <td>
              <NuxtLink v-if="talent.skill" :to="`/regles/competences/${talent.skill.slug}`">{{ talent.skill.name }}</NuxtLink>
              <span v-else class="text-muted">{{ "—" }}</span>
            </td>
            <td>
              <template v-if="talent.summary">{{ talent.summary }}</template>
              <span v-else class="text-muted">{{ "—" }}</span>
            </td>
          </tr>
        </tbody>
      </table>
    </template>
  </ClientOnly>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { ListMode } from "~/types/components";
import type { Skill, Talent } from "~/types/game";

type TalentGroup = {
  tier: number;
  talents: Talent[];
};

const { orderBy } = arrayUtils;

const props = defineProps<{
  items: Talent[];
}>();

const allowMultiplePurchases = ref<boolean>();
const mode = ref<ListMode>("grid");
const skill = ref<Skill>();
const skills = ref<Skill[]>([]);

const groups = computed<TalentGroup[]>(() => {
  const map = new Map<number, Talent[]>();
  props.items.forEach((talent) => {
    if (typeof allowMultiplePurchases.value === "boolean" && allowMultiplePurchases.value !== talent.allowMultiplePurchases) {
      return;
    }
    if (typeof skill.value !== "undefined") {
      if (skill.value.id === "any") {
        if (!talent.skill) {
          return;
        }
      } else if (skill.value.id === "none") {
        if (talent.skill) {
          return;
        }
      } else if (skill.value.id !== talent.skill?.id) {
        return;
      }
    }
    const talents: Talent[] | undefined = map.get(talent.tier);
    if (talents) {
      talents.push(talent);
    } else {
      map.set(talent.tier, [talent]);
    }
  });

  const groups: TalentGroup[] = [];
  for (let tier = 0; tier <= 3; tier++) {
    const talents: Talent[] = orderBy(map.get(tier) ?? [], "name");
    if (talents.length) {
      groups.push({ tier, talents });
    }
  }
  return groups;
});

watch(
  () => props.items,
  (items) => {
    const map = new Map<string, Skill>();
    items.forEach((talent) => {
      if (talent.skill) {
        map.set(talent.skill.id, talent.skill);
      }
    });
    skills.value = orderBy([...map.values()], "name");
  },
  { deep: true, immediate: true },
);
</script>
