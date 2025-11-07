<template>
  <div class="container-fluid mt-4 py-5 roadmap">
    <div class="mt-2 row">
      <div class="col-lg-12">
        <div class="horizontal-timeline">
          <ul class="list-inline items">
            <li v-for="(item, index) in items" :key="index" class="list-inline-item items-list">
              <div class="px-4">
                <div :class="getDateClasses(index)">{{ $d(new Date(item.date)) }}</div>
                <h5 class="pt-2">{{ item.title }}</h5>
                <p class="text-muted">{{ item.summary }}</p>
                <ClientOnly>
                  <TarButton icon="fas fa-list" text="Détails" data-bs-toggle="modal" :data-bs-target="`#roadmap-item-detail-${index}`" />
                  <TarModal centered class="modal" :close="$t('actions.close')" :id="`roadmap-item-detail-${index}`" :title="item.title">
                    <p>
                      <strong>Échéance : {{ $d(new Date(item.date)) }}</strong>
                    </p>
                    <template v-if="item.detail.length">
                      <p class="text-muted">{{ item.summary }}</p>
                      <ul>
                        <li v-for="(detail, index) in item.detail" :key="index">{{ detail }}</li>
                      </ul>
                    </template>
                    <div v-else>{{ item.summary }}</div>
                    <template #footer>
                      <TarButton icon="fas fa-times" :text="$t('actions.close')" variant="secondary" data-bs-dismiss="modal" />
                    </template>
                  </TarModal>
                </ClientOnly>
              </div>
            </li>
          </ul>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import allItems from "~/assets/data/roadmap.json";

const now: string = new Date().toISOString();
const { orderBy } = arrayUtils;
type RoadmapItem = {
  id: string;
  date: string;
  title: string;
  summary: string;
  detail: string[];
};

const items = computed<RoadmapItem[]>(() =>
  orderBy(allItems, "date")
    .filter(({ date }) => date >= now)
    .slice(0, 3),
);

function getDateClasses(index: number): string[] {
  const classes: string[] = ["event-date", "badge"];
  switch (index) {
    case 0:
      classes.push("bg-success");
      break;
    case 1:
      classes.push("bg-warning");
      break;
    case 2:
      classes.push("bg-danger");
      break;
    default:
      classes.push("bg-secondary");
      break;
  }
  return classes;
}
</script>

<style scoped>
.roadmap {
  background-color: #f0f0f0;
  border: 1px solid #cccccc;
  border-radius: 10px;
}

[data-bs-theme=dark] .roadmap {
  background-color: #2c2c2c;
  border: 1px solid #444444;
}

.horizontal-timeline .items {
  border-top: 3px solid #cccccc;
}

[data-bs-theme=dark] .horizontal-timeline .items {
  border-top: 3px solid #444444;
}

.horizontal-timeline .items .items-list {
  display: block;
  position: relative;
  text-align: center;
  padding-top: 70px;
  margin-right: 0;
}

.horizontal-timeline .items .items-list:before {
  content: "";
  position: absolute;
  height: 36px;
  border-right: 2px dashed #cccccc;
  top: 0;
}

[data-bs-theme=dark] .horizontal-timeline .items .items-list:before {
  border-right: 2px dashed #444444;
}

.horizontal-timeline .items .items-list .event-date {
  position: absolute;
  top: 36px;
  left: 0;
  right: 0;
  width: 100px;
  margin: 0 auto;
  font-size: 0.9rem;
  padding-top: 8px;
}

.modal {
  text-align: left;
}

@media (min-width: 1140px) {
  .horizontal-timeline .items .items-list {
    display: inline-block;
    width: 33%;
    padding-top: 45px;
  }

  .horizontal-timeline .items .items-list .event-date {
    top: -40px;
  }
}
</style>
