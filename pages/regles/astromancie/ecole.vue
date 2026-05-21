<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <RulesBreadcrumb :active="title" :parent="parent" />
    <p>
      On appelle Mage, ou Astromancien, l’individu qui étudie les <NuxtLink to="/regles/astromancie/signes">signes astrologiques</NuxtLink> afin d’en comprendre
      et d’en maîtriser les pouvoirs. Ces érudits se rassemblent dans des <strong>écoles de magie</strong> qui sont généralement appelées
      <i>Tour de Magie</i> en raison de leur structure érigée en direction du ciel.
    </p>
    <p>
      Il existe plusieurs tours de magie dans le monde, avec des fonctionnements et des particularités qui leur sont propres. En Ouespéro, il en existe un petit
      nombre, qui sont toutes reliées tout en conservant une certaine indépendance, et qui partagent un fonctionnement commun.
    </p>
    <p>
      Les tours de magie sont souvent surnommées <i>Observatoire</i> puisqu’elles sont utilisés afin d’observer les corps célestes. On y retrouve des
      Éphémérides, des tables astronomiques consistant en des gravures à même la pierre. Ces gravures représentent les astres, leur position, les
      constellations, et toute information succincte et jugée pertinente par les mages.
    </p>
    <!-- TODO(fpion): move to Ungar article
      <h2 class="h3">Umyd Gaya</h2>
      <p>
        La plus ancienne tour de magie de l’Ouespéro se nomme <i>Umyd Gaya</i>, qui signifie « Vif-Espoir » dans la langue de ses fondateurs antiques. Elle est
        située dans la cité-État de Narandar, une cité autonome et n’ayant jamais été conquise, administrée par sa tour de magie. Cette cité et sa tour de magie
        ont été construites promptement à la suite du déclin de l’Ancien-Monde. Elles sont des copies conformes de la cité de Varbonie (signifie « harmonie » dans
        la langue de l’Ancien-Monde) et de sa tour de magie, situées dans l’Ancien-Monde, et détruites peu avant la fondation de Narandar.
      </p>
      <p>
        Narandar est la cité-sœur de Kaku, la capitale du royaume régnant sur la région englobant Narandar. Cette région se trouve à l’extrême-Est du continent,
        au Sud des montagnes de Kroumir et au Nord du Haut-plateau Utarmien. Cette région se trouve à l’Ouest de la mer Morne et est bordée à l’Est par la mer
        Abyssale. En raison de sa localisation, cette région accueille des visiteurs de partout dans le monde. Pour cette raison, elle est très prospère et
        considérée comme essentielle à l’accumulation, la préservation et le partage des savoirs.
      </p>
    -->
    <h2 class="h3">Sept Maisons</h2>
    <p>
      En Ouespéro, les tours de magie sont organisées en <strong>sept maisons</strong>. Chaque maison joue un rôle précis au sein de sa tour de magie. Une
      couleur est associée à chaque maison, et les vêtements de ses membres portent cette couleur. Il n’est pas rare qu’un Initié agrémente son accoutrement
      d’un traditionnel chapeau pointu à base ronde de la même couleur que sa robe.
    </p>
    <ul>
      <li>
        <strong>Robe Ambrée.</strong> Les membres de cette maison se spécialisent dans la guérison des malades et des blessés. Ils tâchent également d’offrir
        une sépulture digne aux défunts.
      </li>
      <li><strong>Robe Argentée.</strong> Les membres de cette maison développent et enseignent la philosophie et la logique afin d’enrichir les esprits.</li>
      <li>
        <strong>Robe Azure.</strong> Les membres de cette maison travaillent à faire triompher la justice et la vérité. Ils viennent en aide à ceux qui sont
        dans le besoin.
      </li>
      <li>
        <strong>Robe Écarlate.</strong> Les membres de cette maison collectent des informations à propos des forces du mal menaçant le monde et agissent contre
        ces forces.
      </li>
      <li>
        <strong>Robe Émeraude.</strong> Les membres de cette maison sont l’armée de leur tour, ils défendent celles-ci, autant ses installations que ses
        résidents et sa philosophie.
      </li>
      <li>
        <strong>Robe de Fer.</strong> Les membres de cette maison visent à agir en tant que conseillers, médiateurs et négociateurs auprès des acteurs
        géopolitiques. Ils favorisent la paix et la diplomatie aux conflits violents.
      </li>
      <li>
        <strong>Robe Marron.</strong> Les membres de cette maison désirent recueillir la connaissance et le savoir, et protéger l’érudition de ceux qui veulent
        la faire disparaître.
      </li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/tar/breadcrumb";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Astromancie", to: "/regles/astromancie" },
];
const title: string = "École de magie";

useSeo({
  title,
  description: "Découvrez les écoles de magie de l’Astromancie : tours de magie, observatoires et maisons qui structurent l’étude des signes astrologiques.",
});
</script>
