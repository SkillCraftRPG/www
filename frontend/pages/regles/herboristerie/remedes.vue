<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les remèdes ont la fonction de <NuxtLink to="/regles/combat/degats/soins">guérir</NuxtLink>, au contraire des
      <NuxtLink to="/regles/herboristerie/poisons">poisons</NuxtLink>. Ils servent à soigner des effets naturels, c’est-à-dire induits par une source non
      magique, et ne peuvent être utilisés qu’afin de guérir des effets temporaires. Certaines plantes magiques, par exemple le l’édelweiss (étoile d’argent ou
      étoile des neiges), les fruits de l’arbre à lotos ou encore la racine de mandragore, peuvent être incorporés à un remède afin de guérir les effets
      permanents et/ou induits par une source <NuxtLink to="/regles/magie">magique</NuxtLink>.
    </p>
    <h2 class="h3">Remèdes de base</h2>
    <p>Le talent <NuxtLink to="/regles/talents/herboristerie">Herboristerie</NuxtLink> permet d’apprendre les remèdes de base.</p>
    <ul>
      <li>
        <strong>Antidote.</strong> Ce remède qui retire un effet d’<NuxtLink to="/regles/combat/conditions/empoisonne">empoisonnement</NuxtLink> lorsque
        consommé. Il est produit par la combustion de la bonne quantité de plusieurs matériaux : tourbe, charbon et poix (résine produite par la distillation du
        bois de pin ou de bouleau), ainsi qu’une des herbes suivantes (aneth, figuier, livèche ou vigne commune).
      </li>
      <li>
        <strong>Déliant musculaire.</strong> Cette injection musculaire retire instantanément un effet de
        <NuxtLink to="/regles/combat/conditions/paralyse">paralysie</NuxtLink>. Il est produit en mélangeant du ginseng et de l’orpin rose (racine d’or ou
        racine hyperboréenne).
      </li>
      <li>
        <strong>Huile minérale.</strong> Cette huile issue de la distillation de la houille peut être appliquée dans les oreilles afin de retirer un effet
        d’<NuxtLink to="/regles/combat/conditions/assourdi">assourdissement</NuxtLink> une heure après son application.
      </li>
      <li>
        <strong>Médicament.</strong> Ce remède supprime les effets d’une maladie pendant les 24 prochaines heures. La maladie prend fin après 7 jours
        consécutifs de consommation du remède, même si sa durée est plus longue que 7 jours. Il est composé d’un mélange d’herbes : échinacée, ail, gingembre,
        curcuma ou sureau, et réglisse.
      </li>
      <li>
        <strong> Œil-de-pirate. </strong> Des gouttes pour les yeux, appliquées sous un cache-œil porté pendant une heure afin de retirer un effet d’<NuxtLink
          to="/regles/combat/conditions/aveugle"
          >aveuglement</NuxtLink
        >. Elles sont obtenues à partir de foie de morue ou de bœuf, et de patates douces, de carottes ou de citrouille.
      </li>
      <li>
        <strong>Tisane de santé.</strong> Cette infusion de camomille double la <NuxtLink to="/regles/aventure/repos">régénération</NuxtLink> de
        <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> du personnage pendant les 8 prochaines heures. Elle est généralement consommée avant
        une <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink>.
      </li>
    </ul>
    <h2 class="h3">Remèdes avancés</h2>
    <p>Le talent <NuxtLink to="/regles/talents/apothicairerie">Apothicairerie</NuxtLink> permet d’apprendre les remèdes avancés.</p>
    <ul>
      <li>
        <strong>Fortifiant.</strong> Cette infusion médicinale permet d’annuler une réduction de points de
        <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> maximum ou d’augmenter les points de Vitalité maximum d’une créature, en fonction de
        ses ingrédients. Elle prend effet à la fin de la prochaine heure de <NuxtLink to="/regles/aventure/repos/halte">halte</NuxtLink> ou de
        <NuxtLink to="/regles/aventure/repos/sommeil">sommeil</NuxtLink>. Lorsque utilisée afin de contrer une réduction de points de Vitalité maximum, elle
        permet de soustraire jusqu’à 6d6 (21) points de cette réduction. Lorsque utilisée afin d’augmenter les points de Vitalité maximaux, elle réduit de 2d6
        par <NuxtLink to="/regles/personnages/progression/tiers">tiers</NuxtLink> (7, 14 ou 21) l’
        <NuxtLink to="/regles/statistiques/energie">Énergie</NuxtLink> maximale de la créature, mais augmente ses points de Vitalité du même nombre pendant les
        huit prochaines heures. La créature ne peut ensuite pas bénéficier des effets de cette infusion pendant les 24 prochaines heures. Les ingrédients la
        composant sont du millepertuis ou de l’armoise, de la fleur de sang ainsi que du khat.
      </li>
      <li>
        <strong>Pommade miracle.</strong> Cette pommade permet d’annuler une réduction à un <NuxtLink to="/regles/attributs">attribut</NuxtLink>. Elle est
        appliquée sur la peau et prend effet dix minutes plus tard. Elle est composée de réglisse, d’une des plantes rares (ashwagandha, sureau ou tagète),
        ainsi que d’un fluide d’animal ou de créature déterminant l’attribut affecté, tel que décrit par le
        <NuxtLink to="/regles/magie/pouvoirs/niveau">niveau 2</NuxtLink> du pouvoir
        <NuxtLink to="/regles/magie/pouvoirs/augmentation-naturelle">Augmentation naturelle</NuxtLink>.
      </li>
      <li>
        <strong>Stimulant.</strong> Cette injection musculaire retire instantanément un niveau de
        <NuxtLink to="/regles/combat/conditions/fatigue">Fatigue</NuxtLink>. La créature ne peut ensuite pas bénéficier des effets de cette injection pendant
        les 24 prochaines heures. Elle contient du ginseng ou de l’orpin rose, de l’onagre bisannuelle ainsi que du khat.
      </li>
      <li>
        <strong>Tisane de d’ardeur.</strong> Cette infusion de camomille contient également de l’échinacée, une herbe odorante (coriandre, lavande ou menthe
        poivrée), un mélange d’épices (basilic, curcuma, romarin et thym) ainsi qu’une des plantes rares suivantes : ashwagandha, sureau ou tagète. Elle
        quadruple la <NuxtLink to="/regles/aventure/repos">régénération</NuxtLink> de <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> du
        personnage pendant les 24 prochaines heures. Elle est généralement consommée avant une
        <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink>.
      </li>
      <li>
        <strong>Tonus.</strong> Cette concoction médicinale permet à une créature de récupérer instantanément 3+3d4 points de
        <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> ou d’<NuxtLink to="/regles/statistiques/energie">Énergie</NuxtLink>. À la fin de sa
        prochaine heure de <NuxtLink to="/regles/aventure/repos/halte">halte</NuxtLink> ou de <NuxtLink to="/regles/aventure/repos/sommeil">sommeil</NuxtLink>,
        elle récupère également 15 points de Vitalité ou d’Énergie. La créature ne peut ensuite pas bénéficier des effets de cette concoction pendant les 24
        prochaines heures. Cette concoction à base d’herbes contient du millepertuis, de l’armoise, une des herbes odorantes et le même mélange d’épices que la
        Tisane d’ardeur, ainsi qu’une des plantes rares suivantes en fonction de l’effet escompté : de la fleur de sang (Vitalité) ou de l’onagre bisannuelle
        (Énergie).
      </li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Herboristerie", to: "/regles/herboristerie" }];
const title: string = "Remèdes";

useSeo({
  title,
  description:
    "Découvrez les remèdes de base et avancés : potions, infusions et onguents soignant poisons, blessures, fatigue et effets néfastes grâce à l’herboristerie.",
});
</script>
