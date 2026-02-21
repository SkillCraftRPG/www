<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Voici des suggestions de traits de personnalité que vous pouvez utiliser afin de décrire le tempérament de votre personnage, sa manière d’agir, de penser
      et de réagir. Vous pouvez choisir aléatoirement un trait en jetant 1d100.
    </p>
    <ol>
      <li v-for="(trait, index) in traits" :key="index">{{ trait }}</li>
    </ol>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Personnages", to: "/regles/personnages" },
  { text: "Création de personnage", to: "/regles/personnages/creation" },
];
const title: string = "Traits de personnalité";

const traits: string[] = [
  "Je garde mon calme en toute circonstance, même quand tout s’effondre.",
  "J’ai toujours un plan de secours, même si je ne le partage pas.",
  "Je dis tout haut ce que les autres préfèrent laisser entendre.",
  "Je privilégie l’action directe aux stratégies inutilement complexes.",
  "J’accorde ma confiance avec parcimonie.",
  "Je suis presque toujours engagé dans un projet.",
  "Je m’ennuie rapidement sans stimulation nouvelle.",
  "Ma curiosité me pousse à tout examiner en profondeur.",
  "La reconnaissance m’importe plus que l’argent.",
  "Je respecte un code d’honneur personnel inflexible.",
  "Je suis plus à l’aise avec les animaux qu’avec les humains.",
  "Je ressens intensément la souffrance des autres.",
  "L’humour est mon réflexe face à la tension.",
  "J’observe longtemps avant d’agir.",
  "Je persévère même lorsque l’échec semble certain.",
  "Je ne tolère pas le travail approximatif.",
  "Le changement m’est nécessaire pour avancer.",
  "Je parle peu, mais avec intention.",
  "Je soupçonne les bonnes intentions trop visibles.",
  "La pression améliore mes performances.",
  "Les énigmes et mystères me fascinent.",
  "J’accepte des risques que d’autres évitent.",
  "Ma loyauté est entière, mais sélective.",
  "Je juge uniquement les actes, jamais les discours.",
  "L’inaction m’irrite profondément.",
  "Les défis impossibles m’attirent.",
  "Je préfère la vérité brute aux politesses vides.",
  "Les codes sociaux me fatiguent.",
  "Je conserve les objets chargés de sens.",
  "J’apprends surtout par l’expérience.",
  "Je garde un optimisme tenace.",
  "Je vis selon mes propres règles.",
  "L’autorité m’inspire une méfiance instinctive.",
  "Je privilégie les solutions simples.",
  "Les offenses marquent durablement ma mémoire.",
  "Je protège farouchement ceux qui me sont chers.",
  "L’effort physique m’apaise.",
  "J’ai peu de patience pour l’incompétence.",
  "L’inconnu m’appelle.",
  "J’optimise constamment ce que je fais.",
  "Ma notion de l’espace personnel diffère de la norme.",
  "Je cherche la paix, mais tranche sans hésiter.",
  "Je me perds souvent dans mes pensées.",
  "Mon passé influence encore mes choix.",
  "Je valorise le travail avant tout.",
  "Je sais désamorcer les conflits par le ton.",
  "La musique me touche profondément.",
  "Les cultures étrangères m’attirent.",
  "Je privilégie les actes aux promesses.",
  "J’ai confiance en mes capacités.",
  "Je remarque les détails négligés par les autres.",
  "J’ai besoin de longues périodes de solitude.",
  "Ma franchise peut déranger.",
  "Les environnements rudes me conviennent.",
  "La routine m’use rapidement.",
  "J’aide spontanément sans attendre de retour.",
  "J’analyse parfois à l’excès.",
  "Je garde mes souffrances pour moi.",
  "Mon instinct de survie est très développé.",
  "J’ai du mal à abandonner un objectif.",
  "Je recherche la différence chez les autres.",
  "Le dépassement personnel me motive.",
  "Certains lieux me marquent durablement.",
  "Je respecte des rituels personnels discrets.",
  "Je parle avec passion de ce que je maîtrise.",
  "Les apparences trop parfaites m’inquiètent.",
  "Je prends mes responsabilités très au sérieux.",
  "Je vis intensément, sans tout planifier.",
  "Je défends instinctivement les plus vulnérables.",
  "L’injustice me met en colère.",
  "Je suis méthodique et attentif.",
  "Le devoir guide mes décisions.",
  "Une idée nouvelle peut m’absorber entièrement.",
  "J’apprends mieux par l’échec.",
  "Je reste fonctionnel dans le chaos.",
  "La compétence compte plus que le statut.",
  "Je suis plus dur envers moi-même qu’envers les autres.",
  "J’ai conservé une curiosité enfantine.",
  "Je peux paraître socialement maladroit.",
  "Je cherche les motivations cachées.",
  "Les liens humains priment sur les idéologies.",
  "J’estime l’authenticité plus que l’élégance.",
  "Il est difficile de m’impressionner.",
  "J’écoute avant de juger.",
  "Je change d’avis face à de meilleurs arguments.",
  "Je poursuis mes objectifs avec obstination.",
  "Je conserve ce qui pourrait servir plus tard.",
  "Je cherche du sens dans chacune de mes actions.",
  "Je me sens plus à l’aise en périphérie qu’au centre.",
  "J’avance même lorsque la peur est présente.",
  "Je préfère agir plutôt que me plaindre.",
  "Je suis conscient de mes contradictions.",
  "Je m’adapte rapidement aux environnements nouveaux.",
  "L’expérience vécue vaut plus que la théorie.",
  "Je supporte mal le gaspillage, matériel ou humain.",
  "Je remarque vite les incohérences.",
  "Je prends le temps de mesurer les conséquences.",
  "J’ai une endurance mentale supérieure à la moyenne.",
  "Je préfère la constance aux élans passagers.",
  "Je poursuis la cohérence intérieure avant tout.",
];

useSeo({
  title,
  description: "Découvrez les Traits de personnalité : une liste variée pour définir le tempérament, les réactions et la manière d’agir de votre personnage.",
});
</script>
