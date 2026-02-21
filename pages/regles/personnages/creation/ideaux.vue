<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Voici des suggestions d’idéaux que vous pouvez utiliser afin d’élaborer les principes et valeurs importants et défendus par votre personnage. Vous pouvez
      choisir aléatoirement un idéal en jetant 1d100.
    </p>
    <ol>
      <li v-for="(ideal, index) in ideals" :key="index">{{ ideal }}</li>
    </ol>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Personnages", to: "/regles/personnages" },
  { text: "Création de personnage", to: "/regles/personnages/creation" },
];
const title: string = "Idéaux";

const ideals: string[] = [
  "Le monde m’émerveille encore, et je veux le découvrir loin de chez moi.",
  "Je suis prêt à presque tout si cela me rapporte un profit tangible.",
  "Ce sont mes actes qui comptent, pas mon nom.",
  "Je cherche à mériter une reconnaissance supérieure par mes actions.",
  "Je veux exceller dans ce que je fais.",
  "Je suis déterminé à devenir quelqu’un de plus grand.",
  "Je refuse de me résigner à une vie médiocre.",
  "Je veux tracer ma propre voie et décider seul de mon destin.",
  "L’équilibre naturel récompense ceux qui savent modérer leur avidité.",
  "La beauté est une porte vers une vérité plus profonde.",
  "Créer ou agir rend le monde meilleur qu’il ne l’était.",
  "Agir malgré la peur est la marque du courage.",
  "La présence de bonnes personnes rend toute épreuve supportable.",
  "Les liens les plus solides naissent dans l’adversité.",
  "Toute chose doit respecter un équilibre fondamental.",
  "Le changement est inévitable, et il faut l’accompagner.",
  "Les puissants tombent comme les humbles s’élèvent.",
  "Le monde évolue sans cesse, et nous devons l’aider à évoluer.",
  "Je refuse de vivre selon des règles figées.",
  "Aider ceux qui sont dans le besoin passe avant mon confort.",
  "La richesse n’a de valeur que si elle soulage la misère.",
  "Prendre aux puissants pour aider les faibles est légitime.",
  "Un code strict permet de faire face à toutes les situations.",
  "Je veux que les miens profitent pleinement des plaisirs de la vie.",
  "La prospérité collective bénéficie à tous.",
  "Renforcer la communauté est un devoir fondamental.",
  "Nous devons compter les uns sur les autres pour survivre.",
  "Me mesurer aux autres me permet de progresser.",
  "La ruse et la tromperie sont des armes efficaces.",
  "L’innovation naît de la répétition jamais identique.",
  "Le monde a besoin d’idées nouvelles et d’audace.",
  "Si chacun fait sa part, aucun navire ne coule.",
  "Être différent de ses adversaires est un avantage.",
  "Toute découverte majeure s’accompagne de risques.",
  "Je me sens vivant quand je mets tout en jeu.",
  "Les plus grandes récompenses vont aux plus audacieux.",
  "Frôler la mort donne un goût incomparable à la vie.",
  "Rien ni personne ne peut m’écarter de mon appel profond.",
  "Je combats les monstres, quels qu’ils soient.",
  "Je dois affronter ce qui me hante, quel qu’en soit le prix.",
  "Même les morts méritent le respect.",
  "Découvrir ce qui a été oublié donne un sens à ma vie.",
  "La connaissance sert autant la collectivité que ma curiosité.",
  "Il ne faut pas interférer avec des cultures qui ne sont pas les nôtres.",
  "Il faut se plonger dans le chaos pour résoudre les problèmes.",
  "Aucune créature ne mérite de souffrir inutilement.",
  "Je refuse de nuire à ceux qui n’ont rien à perdre.",
  "La loi doit s’appliquer de manière égale à tous.",
  "Chacun mérite une part équitable du fruit du travail commun.",
  "Je fais confiance à une force supérieure pour guider mes actes.",
  "Les liens du sang passent avant tout.",
  "Le progrès repose sur la curiosité et la remise en question.",
  "Aucune chaîne n’est légitime.",
  "Chacun doit être libre de choisir sa voie.",
  "Certains appels me placent au-dessus des règles communes.",
  "La liberté est synonyme de mouvement et d’horizon ouvert.",
  "Aucun tyran ne mérite de gouverner.",
  "Je n’abandonne jamais ceux que j’appelle amis.",
  "Les relations humaines valent plus que les biens matériels.",
  "Mes talents existent pour servir le monde.",
  "Protéger les autres donne un sens à mes combats.",
  "Le bien collectif prime sur l’intérêt individuel.",
  "Mes dons ne m’appartiennent pas uniquement.",
  "Se sacrifier pour les autres est parfois nécessaire.",
  "Je ferai tout pour m’enrichir.",
  "Obtenir ce que je veux passe avant les conséquences.",
  "Rien ne justifie de risquer sa vie sans contrepartie.",
  "L’argent et la renommée motivent mes choix.",
  "Chaque victoire comme chaque échec enseigne quelque chose.",
  "Le travail acharné est une force inébranlable.",
  "L’honnêteté révèle la véritable nature des choses.",
  "Un engagement donné ne doit jamais être rompu.",
  "Déshonorer ses principes, c’est se perdre soi-même.",
  "L’horizon est porteur de promesses.",
  "Je cherche le secret d’une existence qui dépasse la mort.",
  "Devenir un symbole exige de dépasser ses propres failles.",
  "Personne n’a autorité sur moi.",
  "Je dois prouver que je peux me suffire à moi-même.",
  "Obéir aveuglément mène à la tyrannie.",
  "La vie est cruelle, et je l’accepte comme telle.",
  "Je veux que mon nom inspire la crainte.",
  "Abandonner les traditions permet d’avancer.",
  "J’apprends en observant ce qui m’entoure.",
  "Je crée ce dont j’ai besoin avec ce que j’ai sous la main.",
  "La justice ne dépend pas du rang social.",
  "Comprendre les autres cultures permet de se comprendre soi-même.",
  "Le savoir est un chemin vers l’élévation.",
  "Tous les idéaux ne valent pas une guerre.",
  "Se mêler des affaires des autres cause plus de mal que de bien.",
  "La logique doit primer sur l’émotion.",
  "Connaître son ennemi est essentiel avant d’agir.",
  "La chance obéit à des règles qu’il faut respecter.",
  "La force permet d’obtenir ce que l’on mérite.",
  "Les plus forts sont destinés à diriger.",
  "Mon peuple passe avant tout le reste.",
  "La nature surpasse toutes les constructions humaines.",
  "Rien ne doit limiter le potentiel de l’existence.",
  "Protéger les plus faibles est un devoir moral.",
  "Chacun mérite respect et dignité.",
  "Mieux se connaître est la forme ultime de sagesse.",
];

useSeo({
  title,
  description:
    "Découvrez les Idéaux : une liste d’idéaux pour définir les principes moraux, valeurs profondes et convictions guidant les choix de votre personnage.",
});
</script>
