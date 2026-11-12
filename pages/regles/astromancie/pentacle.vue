<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <RulesBreadcrumb :active="title" :parent="parent" />
    <p>
      Le pentacle est un symbole très important de l’astromancie, et sera omniprésent dans les
      <NuxtLink to="/regles/astromancie/ecole">écoles de magie</NuxtLink>. Il illustre la relation des composantes essentielles de l’astromancie, soit les
      <NuxtLink to="/regles/elementarisme">éléments</NuxtLink>, les cercles de magie ainsi que les
      <NuxtLink to="/regles/astromancie/signes">signes astrologiques</NuxtLink>.
    </p>
    <ul>
      <li>
        <strong>Le Soleil</strong>, associé à l’or dans la tradition alchimique, symbolise la source de toute magie, tandis que l’or constitue un puissant
        canalisateur de ces énergies.
      </li>
      <li>
        Autour du Soleil gravitent les <strong>éléments fondamentaux</strong> de la magie : l’Esprit (Ω), l’Air (🜁), l’Eau (🜄), le Feu (🜂) et la Terre (🜃), dont
        les forces façonnent le monde.
      </li>
      <li>
        Les <strong>cercles de magie</strong> se situent entre les éléments, symbolisant les différentes façons de canaliser et de combiner leurs forces :
        l’Envoûtement (Air–Esprit), la Divination (Esprit–Eau), l’Abjuration (Eau–Terre), la Transmutation (Terre–Feu) et l’Invocation (Feu–Air).
      </li>
      <li>
        Enfin, les <strong>signes astrologiques</strong> sont répartis autour du sceau en groupes, chaque groupe étant disposé dans la section de son cercle
        afin d’en représenter les différentes facettes et influences.
      </li>
    </ul>
    <div class="row">
      <div v-for="item in pentacle" :key="item.circle" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 col-fifth mb-4">
        <TarCard>
          <template #title-override>
            <h5 class="card-title text-center mb-3"><IconCircle :circle="item.circle" />&nbsp;{{ item.circle }}</h5>
          </template>
          <template #subtitle-override>
            <h6 class="card-subtitle text-center mb-3 text-body-secondary">
              <span v-for="element in item.elements" :key="element" class="mx-3"><IconElement :element="element" />&nbsp;{{ element }}</span>
            </h6>
          </template>
          <div class="d-table mx-auto text-start">
            <div v-for="sign in item.signs" :key="sign"><IconSign :sign="sign" />&nbsp;{{ sign }}</div>
          </div>
        </TarCard>
      </div>
    </div>
    <div class="text-center">
      <img :alt="title" src="@/assets/img/astromancie/pentacle.png" />
    </div>
  </main>
</template>

<script setup lang="ts">
import pentacle from "~/assets/data/pentacle.json";
import type { Breadcrumb } from "~/types/tar/breadcrumb";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Astromancie", to: "/regles/astromancie" },
];
const title: string = "Pentacle";

useSeo({
  title,
  description:
    "Découvrez le pentacle de SkillCraft : un symbole d’astromancie reliant le Soleil, les cinq éléments, les cercles de magie et les 25 signes astrologiques.",
});
</script>
