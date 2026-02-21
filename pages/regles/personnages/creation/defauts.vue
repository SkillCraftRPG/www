<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Voici des suggestions de défauts que vous pouvez utiliser afin de décrire les faiblesses et obstacles auxquels votre personnage fait face. Vous pouvez
      choisir aléatoirement un défaut en jetant 1d100.
    </p>
    <ol>
      <li v-for="(flaw, index) in flaws" :key="index">{{ flaw }}</li>
    </ol>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Personnages", to: "/regles/personnages" },
  { text: "Création de personnage", to: "/regles/personnages/creation" },
];
const title: string = "Défauts";

const flaws: string[] = [
  "Un scandale m’empêche de retourner chez moi, et les ennuis semblent me suivre.",
  "Quelqu’un d’innocent paie pour une faute que j’ai commise, et je vis avec.",
  "Je refuse d’admettre mes défaites et accuse toujours les autres de tricher.",
  "Je suis sujet à des faiblesses physiques qui compliquent certains environnements.",
  "Mes actes ont déjà couvert ma famille de honte.",
  "Malgré ma bonne volonté, je déçois souvent ceux qui comptent sur moi.",
  "Je crois que seuls les forts méritent de survivre.",
  "Peu de gens connaissent ma véritable nature.",
  "L’argent exerce sur moi une attraction malsaine.",
  "Je vois le monde comme un lieu sans espoir.",
  "Mes convictions sont rigides et difficiles à ébranler.",
  "La promesse de savoir me détourne facilement de mes priorités.",
  "Je parle trop longtemps, même quand ce n’est pas approprié.",
  "J’ai du mal à remettre mes idées en question.",
  "Je juge sévèrement ceux que je considère paresseux.",
  "Une obsession personnelle nuit à tout le reste de ma vie.",
  "Je me crois culturellement supérieur aux autres.",
  "J’ai du mal à faire confiance aux étrangers.",
  "Mon esprit est absorbé par mes créations au point de négliger mes besoins.",
  "Je m’attends toujours au pire des inconnus.",
  "J’abuse trop facilement de substances ou de plaisirs.",
  "La mort me laisse indifférent.",
  "Je pars du principe que les gens sont foncièrement mauvais.",
  "L’éloignement d’un lieu ou d’un repère me rend instable.",
  "La souffrance des innocents me fait perdre tout contrôle.",
  "Je pense que tout le monde est corruptible.",
  "Je me crois intellectuellement supérieur à beaucoup.",
  "Je vole par réflexe des objets sans réelle nécessité.",
  "Je suis incapable de garder un secret.",
  "Je cherche compulsivement des passages cachés et des complots.",
  "Je cède trop facilement au charme.",
  "Tromper les puissants me procure un plaisir dangereux.",
  "J’ai besoin de conditions très strictes pour me reposer.",
  "Je me plains constamment.",
  "Je méprise les croyances qui ne sont pas les miennes.",
  "Je garde tout, incapable de jeter quoi que ce soit.",
  "Je rejette ce qui m’est étranger par principe.",
  "Je n’ai aucun sens du temps et suis souvent en retard.",
  "Je n’éprouve aucune compassion pour les morts.",
  "Je suis mal à l’aise dans les interactions sociales ordinaires.",
  "J’obéis aux ordres même quand ils sont moralement douteux.",
  "Le travail mal fait me met hors de moi.",
  "L’alcool ou l’excès me rendent agressif et imprévisible.",
  "Des pensées violentes persistent malgré mes efforts pour les étouffer.",
  "Face au danger, je privilégie parfois ma propre survie.",
  "Mon langage corporel me trahit quand je mens.",
  "Une peur irrationnelle me suit partout.",
  "Je suis attiré par des plaisirs qui me nuisent.",
  "Je suis prisonnier d’habitudes ou d’addictions.",
  "Mes désirs prennent souvent le dessus sur la raison.",
  "Je suis incapable de rompre certains rituels.",
  "De vieilles blessures continuent de me faire souffrir.",
  "Je respecte peu ceux qui ne prouvent pas leur valeur.",
  "Mon vécu m’a rendu émotionnellement distant.",
  "Je cumule les vices sans réelle retenue.",
  "Je suis mal à l’aise avec le rire et l’humour.",
  "Je sacrifie mes relations au profit de mes objectifs.",
  "Mes paroles franches me causent souvent des ennuis.",
  "J’ai du mal à faire confiance à mes alliés.",
  "Je cache un secret capable de tout détruire.",
  "Je nourris des rancunes tenaces.",
  "Je méprise ceux qui ne rivalisent pas avec moi.",
  "Je me laisse dominer par mon besoin d’avoir raison.",
  "Je préfère accumuler des secrets plutôt que les partager.",
  "Une erreur passée me hante et je la dissimule à tout prix.",
  "Je veux toujours diriger, même quand ce n’est pas nécessaire.",
  "Je n’offre jamais rien sans attendre un retour.",
  "Mon regard et mon attitude mettent mal à l’aise.",
  "Je respecte la loi même lorsqu’elle est injuste.",
  "Une satire passée a fait de moi une cible.",
  "Je m’épuise au-delà du raisonnable.",
  "Je complique inutilement des problèmes simples.",
  "J’évite les interactions en feignant l’incompréhension.",
  "Je fais trop confiance à ceux en position d’autorité.",
  "Je me souviens de chaque affront et ne pardonne pas.",
  "Je crois secrètement valoir plus que les autres.",
  "Je vois la morale de façon binaire et rigide.",
  "Des souvenirs violents me hantent encore.",
  "Je prends parfois ce qui ne m’appartient pas.",
  "Je parle sans réfléchir et offense involontairement.",
  "Je doute systématiquement de la parole des autres.",
  "Je parle seul et peine à créer des liens.",
  "Je crois percevoir des présences que personne d’autre ne voit.",
  "J’évalue mes relations comme des transactions.",
  "Je suis trop absorbé par mes pensées pour agir à temps.",
  "Je me crois persécuté par le monde entier.",
  "Je vois des menaces cachées dans chaque parole.",
  "Je fuis lorsque la situation tourne mal.",
  "Je cache mon identité derrière un symbole permanent.",
  "Je ne fais confiance qu’à moi-même.",
  "Je vis dans l’excès, sans mesure.",
  "Mon ambition sociale dépasse mes scrupules.",
  "J’ai horreur d’admettre mes torts.",
  "Je préfère attaquer par traîtrise que faire face.",
  "Je prends des risques insensés pour la gloire ou le savoir.",
  "Gagner compte plus que tout le reste.",
  "Les objets rares m’obsèdent dangereusement.",
  "Je mens par automatisme.",
  "Ma fierté me rend aveugle à mes limites.",
  "La violence est trop souvent ma réponse par défaut.",
];

useSeo({
  title,
  description:
    "Découvrez les Défauts : une sélection de faiblesses, vices et travers pour enrichir la profondeur psychologique et narrative de votre personnage.",
});
</script>
