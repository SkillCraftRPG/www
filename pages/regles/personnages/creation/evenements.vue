<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Voici des suggestions d’événements que vous pouvez utiliser afin d’inspirer l’histoire de votre personnage. Vous pouvez choisir aléatoirement un événement
      en jetant 1d100.
    </p>
    <ol>
      <li v-for="(event, index) in events" :key="index">{{ event }}</li>
    </ol>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Personnages", to: "/regles/personnages" },
  { text: "Création de personnage", to: "/regles/personnages/creation" },
];
const title: string = "Événements";

const events: string[] = [
  "Ce que je possède de plus précieux, c’est ma liberté. Je ne laisserai plus jamais quelqu’un me l’enlever.",
  "Ceux qui combattent à mes côtés sont dignes de mon sacrifice.",
  "C’est mon devoir de protéger mes étudiants.",
  "Dans une ville portuaire, j’ai un ou une amante qui m’a presque dérobé à la mer.",
  "Depuis que je suis enfant, j’ai entendu des histoires à propos d’une cité perdue. Je vise à la retrouver, apprendre ses secrets et faire mon nom comme historien.",
  "Des pirates sans merci ont assassiné mon capitaine et mon équipage, pillé mon navire et m’ont laissé à la mort. Je me vengerai un jour.",
  "D’abord, je suis loyal envers mon capitaine, ensuite, vers n’importe qui d’autre.",
  "Je deviendrai le plus grand voleur ayant existé.",
  "Je dois ma survie à un autre orphelin qui m’a appris à vivre dans la rue.",
  "Je dois mon existence au prêtre qui m’a adopté lorsque mes parents sont décédés.",
  "Je dois m’assurer qu’un texte ancien contenant de terribles secrets ne tombent pas en mauvaises mains.",
  "Je dois protéger un enfant de ce monde. Je travaille à rendre ce monde plus sécuritaire pour lui.",
  "Je dois tout à mon mentor – un individu horrible qui croupit en prison en quelque part.",
  "Je donnerais ma vie pour retrouver une ancienne relique de mon culte perdue il y a longtemps.",
  "Je donnerais toujours ma vie pour mes compagnons d’armes.",
  "Je désire la richesse pour assurer une conquête amoureuse.",
  "Je désire préserver un texte ancien que mes ennemis considèrent profanes et cherchent à détruire.",
  "Je ferai tout afin de devenir célèbre.",
  "Je ferai tout en mon pouvoir afin de protéger le temple que je sers.",
  "Je ferai tout en mon pouvoir afin de prouver que je suis supérieur à un rival que je déteste.",
  "Je ferais n’importe quoi pour les autres membres de ma précédente troupe.",
  "Je me souviendrai toujours de mon premier navire.",
  "Je ne vendrais jamais un objet d’art ou un autre trésor historique ayant une signification quelconque.",
  "Je n’ai jamais reçu ma part d’un butin ou de profits, et je désire récupérer cette part.",
  "Je n’arrive pas à atteindre l’illumination que je cherchais lorsque je suis entré en isolement.",
  "Je n’avais pas le choix et laisser ceux que j’aime derrière. Je m’en lamente et j’espère les revoir un jour.",
  "Je n’oublierai jamais la défaite cuisante de ma compagnie et ceux qui nous ont vaincus.",
  "Je parraine un orphelinat afin d’éviter aux autres ce que j’ai vécu.",
  "Je protège ceux qui ne peuvent se protéger eux-mêmes.",
  "Je sacrifierais corps et âme afin de protéger les innocents.",
  "Je souffre de terribles visions d’un désastre à venir et ferai tout afin de l’empêcher.",
  "Je souhaite que ma chérie d’enfance m’ait accompagné en poursuite de ma destinée.",
  "Je suis coupable d’un crime terrible et j’espère pouvoir me racheter.",
  "Je suis fasciné par la beauté et les merveilles des contrées que j’explore.",
  "Je suis follement en amour avec quelqu’un qui ne connaît pas ma réelle identité, et j’ai peur de me faire rejeter si je la révèle.",
  "Je suis le dernier membre de ma tribu et je dois m’assurer que leurs noms deviennent légendes.",
  "Je suis membre d’un réseau clandestin qui offre le passage et l’exil à ceux qui en ont besoin.",
  "Je suis un partisan, j’ai manifesté et commis des crimes mineurs contre mon seigneur ou la hiérarchie qui régissait ma terre natale.",
  "Je tente de payer une vieille dette à un généreux bienfaiteur.",
  "Je travaille afin de préserver une bibliothèque, un monastère, une université ou un scriptorium.",
  "Je travaille comme espion, je reste à l’affût des événements qui se produisent et je rencontre régulièrement mon réseau afin de diffuser l’information.",
  "Je veux retrouver mon mentor qui est disparu au cours d’une expédition.",
  "Je viens d’une famille noble et je réclamerai un jour mes terres et mon titre de ceux qui me l’ont arraché.",
  "J’abattrai mon courroux contre les malfaiteurs qui ont détruit ma terre natale.",
  "J’affronterai tous les défis afin de gagner l’approbation de ma famille.",
  "J’ai cherché toute ma vie la réponse à une question.",
  "J’ai choisi la solitude parce que celui ou celle que j’aime n’est pas atteignable.",
  "J’ai choisi l’isolement afin d’éviter de confronter ceux qui me pourchassent.",
  "J’ai des sentiments pour l’héritier d’une famille que ma maison déteste.",
  "J’ai découvert un grand mal que seul moi peut détruire pendant mon isolation.",
  "J’ai escroqué et ruiné quelqu’un qui ne le méritait point. Je désire me repentir pour ce méfait, mais je ne me pardonnerai peut-être jamais.",
  "J’ai floué la mauvaise personne et je dois m’assurer que cet individu ne croise jamais mon chemin ni celui de mes proches.",
  "J’ai un rival amical, et un seul d’entre nous peut être le meilleur. Je prouverai que ce sera moi.",
  "J’ai une grande dette envers ma guilde. C’est grâce à eux si je suis la personne que je suis aujourd’hui.",
  "J’ai vendu mon âme pour du savoir et je veux accomplir de grands exploits pour la récupérer.",
  "J’ai échappé à la pauvreté en cambriolant une personne importante, ce qui m’a valu une prime sur ma tête.",
  "J’ai été intimidé par un belliqueux noble et je me venge contre les intimidateurs que je croise.",
  "J’aime ma patrie, j’ai travaillé pour celle-ci, je vais protéger ma patrie.",
  "J’aspire à apporter le prestige à une bibliothèque, un musée ou une université.",
  "J’assouvirai un jour ma vengeance contre les forces maléfiques qui ont détruit mon commerce et ruiné mon enfance.",
  "J’espère revoir ma famille. Je n’ai aucune idée d’où elle se trouve.",
  "J’idolâtre un héros des temps anciens et je me compare constamment à cette personne.",
  "J’éprouve secrètement de l’amour envers mon riche patron qui parraine mes recherches archéologiques et historiques.",
  "Le peuple doit me voir comme un héros et un sauveur.",
  "Le travail de ma vie est une série de tomes associés à un domaine spécifique de connaissance.",
  "Les dieux de mon peuple me réconfortent même quand je suis loin de mon peuple.",
  "L’alliance de ma maison avec celle d’une autre famille doit être protégée à tout prix.",
  "L’atelier où j’ai appris ma profession est l’endroit le plus important au monde pour moi.",
  "Ma famille, mon clan ou ma tribu est l’élément le plus important de ma vie, même lorsqu’ils se trouvent loin de moi.",
  "Ma loyauté à mon souverain est inébranlable.",
  "Ma plus grande cause est de servir mon peuple.",
  "Mes gains acquis par le crime ne servent qu’à supporter ma famille.",
  "Mes outils représentent mon passé et je les traîne partout avec moi afin de ne pas oublier qui je suis.",
  "Mes tourments m’ont éloigné de celui ou de celle que j’aime. J’aimerais retrouver le cœur de cette personne.",
  "Mon honneur est ma vie.",
  "Mon identité secrète est la seule chose qui me protège de mes ennemis. Jamais je ne la révélerai.",
  "Mon instrument est ma possession la plus chère, elle me rappelle quelqu’un que j’aime.",
  "Mon journal intime contient mes pensées et mes découvertes. Ce sera mon héritage.",
  "Mon maître n’était pas digne de mes services, je cherche donc à être l’apprenti d’un maître qui le sera.",
  "Mon navire est ce qui est le plus important pour moi – le capitaine et son équipage ne sont que des accessoires.",
  "Mon village ou ma ville est mon domicile, je le défendrai à tout prix.",
  "On a causé de terribles préjudices à moi, ma famille et ou mon espèce. J’assouvirai ma vengeance contre ces criminels.",
  "Personne ne devrait endurer les difficultés que j’ai dû affronter.",
  "Personne n’est plus important que les autres membres de mon ordre à mes yeux.",
  "Personne n’est plus important que les membres de ma famille.",
  "Procréer est un devoir pour la survie de ma tribu.",
  "Quelque part là-bas, j’ai un enfant qui ne me connaît pas. Je travaille à construire un monde meilleur pour lui.",
  "Quelqu’un a sauvé ma vie sur un champ de bataille. Depuis ce jour, je ne laisserai jamais un ami derrière.",
  "Quelqu’un m’a volé mon précieux instrument et je désire le récupérer.",
  "Quelqu’un que j’aimais est mort à cause d’une erreur que j’ai commise. Je vais m’assurer que cela n’arrive plus jamais.",
  "Si ma découverte devenait publique, le monde pourrait gravement être atteint.",
  "Tant que je conserve ce souvenir de ma terre natale, je pourrai affronter n’importe quelle adversité en terre hostile.",
  "Tout ce que j’entreprends est pour le bien commun.",
  "Un bien important m’a été dérobé et je désire le voler en retour.",
  "Un jour, je retournerai auprès de ma guilde et je prouverai que je suis le meilleur artisan de celle-ci.",
  "Un jour, j’assouvirai ma vengeance contre la hiérarchie corrompue d’un temple m’ayant désigné comme hérétique.",
  "Un puissant individu a tué quelqu’un que j’aimais. Un jour, j’assouvirai ma vengeance contre cette personne.",
  "Une attaque contre la nature intacte de mon milieu sauvage est une attaque contre moi.",
  "Une force maléfique vit en moi, je le sens. Elle ne doit jamais être libérée.",
  "Une profonde culpabilité me consume de l’intérieur. Je souhaite me repentir au travers de mes actions.",
];

useSeo({
  title,
  description: "Découvrez 100 événements inspirants pour enrichir l’histoire de votre personnage et façonner son destin unique en jeu de rôle.",
});
</script>
