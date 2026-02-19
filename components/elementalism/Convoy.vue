<template>
  <div>
    <h3 id="convoi" class="h5">Convoi élémentaire</h3>
    <p>
      Par deux <NuxtLink to="/regles/combat/deroulement/tour">actions</NuxtLink>, le personnage peut dépenser 7 points d’<NuxtLink
        to="/regles/elementarisme/essence"
        >essence élémentaire</NuxtLink
      >
      afin de se téléporter dans la dimension élémentaire associée à sa <NuxtLink to="/regles/specialisations/elementariste">spécialité</NuxtLink>. Il peut
      transporter un nombre total de créatures (en s’incluant) égal au double de ses <NuxtLink to="/regles/attributs/sens">Sens</NuxtLink> (minimum&nbsp;2) en
      formant un cercle en se tenant par la main.
    </p>
    <ul>
      <li>
        Il peut spécifier un emplacement qu’il connaît dans cette dimension, et se téléporte à proximité de l’emplacement, à la discrétion du maître de jeu.
      </li>
      <li>S’il spécifie un cercle de téléportation qu’il connaît, alors cette capacité le téléporte précisément à ce cercle.</li>
      <li>S’il ne spécifie aucun emplacement, alors est téléporté à un emplacement aléatoire dans la dimension ciblée, déterminé par le maître de jeu.</li>
    </ul>
  </div>
</template>
