<template>
  <main class="container">
    <h1>Calendrier</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <ul>
      <li>Date : {{ date }}</li>
      <li>Année : {{ year }}</li>
      <li>Mois : {{ month }}</li>
      <li>Jour du mois : {{ monthDay }}</li>
      <li>Année bissextile : {{ isCurrentYearLeaping }}</li>
      <li>Nombre de jours dans l’année : {{ daysInYear }}</li>
      <li>Nombre de jours dans le mois : {{ daysInMonth }}</li>
      <li>Plante : {{ plant }}</li>
      <li>Signe astrologique : {{ astrologicalSign }}</li>
      <li>Équinoxe de printemps : {{ isSpringEquinox }}</li>
      <li>Solstice d’été : {{ isSummerSolstice }}</li>
      <li>Équinoxe d’automne : {{ isAutumnEquinox }}</li>
      <li>Solstice d’hiver : {{ isWinterSolstice }}</li>
      <li>Numéro du jour dans l’année : {{ dayOfYear }}</li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";
import calendar, { type CalendarDate } from "~/types/calendar";

const parent: Breadcrumb[] = [];
const title: string = "Calendrier";

const date = ref<string>("1003-12-31");

const parsedDate = computed<CalendarDate>(() => calendar.parseDate(date.value));
const year = computed<number>(() => parsedDate.value.getYear());
const isCurrentYearLeaping = computed<boolean>(() => parsedDate.value.isLeapYear());
const daysInYear = computed<number>(() => parsedDate.value.getDaysInYear());

const month = computed<number>(() => parsedDate.value.getMonth());
const daysInMonth = computed<number>(() => parsedDate.value.getDaysInMonth());

const monthDay = computed<number>(() => parsedDate.value.getDay());
const dayOfYear = computed<number>(() => parsedDate.value.getDayOfYear());

const isSpringEquinox = computed<boolean>(() => parsedDate.value.isSpringEquinox());
const isSummerSolstice = computed<boolean>(() => parsedDate.value.isSummerSolstice());
const isAutumnEquinox = computed<boolean>(() => parsedDate.value.isAutumnEquinox());
const isWinterSolstice = computed<boolean>(() => parsedDate.value.isWinterSolstice());

const plant = computed<string>(() => parsedDate.value.getPlant());
const astrologicalSign = computed<string>(() => parsedDate.value.getAstrologicalSign());

// TODO(fpion): liste des événements [WHERE (year IS NULL OR year = :year) AND month = :month AND day = :day]

useSeo({
  title,
  description: "🚧",
});
</script>
