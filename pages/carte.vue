<template>
  <main class="container">
    <ClientOnly>
      <MapExample :width="map.width" :height="map.height" :path="map.path" :markers="markers" />
    </ClientOnly>
  </main>
</template>

<script setup lang="ts">
import type { MapInfo, MarkerInfo } from "~/types/map";

const map: MapInfo = {
  width: 7200,
  height: 5400,
  path: "/ouespero.jpg",
};

const markers: MarkerInfo[] = [
  {
    x: 2080,
    y: 3110,
    title: "Vallie",
    popup: "<b>Hello world!</b><br>I am a popup.",
  },
  {
    x: 2670,
    y: 3625,
    title: "Sarénie",
  },
];
</script>
