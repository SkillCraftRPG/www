<template>
  <div id="map"></div>
</template>

<script setup lang="ts">
import "leaflet/dist/leaflet.css";
import L from "leaflet";

import type { MarkerInfo } from "~/types/map";

const props = defineProps<{
  width: number;
  height: number;
  path: string;
  markers?: MarkerInfo[];
}>();

onMounted(() => {
  const map = L.map("map", {
    crs: L.CRS.Simple,
    minZoom: -3,
  });
  const bounds = [
    [0, 0],
    [props.height, props.width],
  ];
  L.imageOverlay(props.path, bounds).addTo(map);
  map.fitBounds(bounds);

  props.markers?.forEach((data) => {
    const marker = L.marker([props.height - data.y, data.x], {
      title: data.title ?? undefined,
      alt: data.title ? `${data.title}’s Marker` : undefined,
    }).addTo(map);
    if (data.popup) {
      marker.bindPopup(data.popup);
    }
  });
});
</script>

<style scoped>
#map {
  height: 1000px;
}
</style>
