## General
+ n° de slide à agrandir
+ Ajouter du texte, du contenu à nos slides !
+ Structurer les choses (item, sous-item...)
##
## Video
+ Couper soignesement et faire des arrêts sur moments importants
+ ou trouver nouvelle vidéo plus adaptée
##
## Introduction
+ Bien expliquer les contraintes : Serveur unity, ergonomie...
+ Slide 2 !
##

## Solution graphique
+ Expliquer les problèmes du positionnement 3D
+ Mettre des notes sur les images qui expliquent le fonctionnement pour ceux qui écoutentront pas
+ Entrer plus dans les détails (spécification fonctionnelle)
+ T1,T2,T3 => Tx,Ty,Tz
+ Nouvel objet plus parlant ? (ça ressemble à ue sphère là)
##

## Engines
+ Plus de texte pour chaque point
+ Licences payantes ?
+ Moteurs pour scènes complexes : Pas nécessaire, on peut juste quelques objets qu'on peut facilement modifier
+ Open GL : Plus API que langage
+ Open GL ES sur certaines tablettes = Open GL en moins bien
##

## Network
+ Aller directement au coeur du sujet
+ Comment se passe la connexion ?
+ Plug Unity pour valider la reception de l'objet sur le serveur
+ Slide 29 : Mettre en valeur la communication facilité entre 2 devices qui run Unity (Libraries...)
##

## Conclusion
+ Récap de nos choix et ce qui a été fait jusqu'à présent
##

#REUNION n°2

## Présenation
Dans le cahier des chagtes : il faut bien expliquer qu'il y a un serveur. Il faut être plus clair dans les explic&ations, un schéma peut aider.
Pour chacun des points du cahier des charges, on peut développer un peu

##Solution
Il faut faire une slide d'intro et/ou mettre un peu de texte en haut des deux premières slides.

Il faut mettre bien expliquer les problèmes que l'on a, avant de montrer comment on est arrivé à de telles solutions : 

 - La personne doit voir ce qu'elle dessine
 - Elle doit voir les objets qu'elle a dessiné
 - Elle doit voir la figure en 3D ...

Donner l'objectif de l'exemple avant de se lancer dedans : "on veut ajouter un cube du coup on va suivre différentes étapes qui sont : le dessin du rectangle, l'extrusion, puis le placement

Bien rappeler les problèmes qui sont liés au placement d'un objet dans l'espace : 3 rotations - 3 translations --> Dur à appréhender pour un noob. On peut pas faire ça en un coup^, du coup on découpe en trois étapes pour simplifier.

##Moteurs

##Network
Il manque comment aller au serveur : 2 partie :

 - partie tablette/dessin -> Envoi
 - partie serveur -> Reception uniquement

Pas oublier de mentionner le plug-in, et dire qu'il va s'inscrire dans une structure plus grosse mais que l'on ne va pas coder.

Pour les protocoles, poser la question pour savoir quels sont les protocoles de transmition que l'on peut utiliser ?

- HTTP : revoir des infos d'un serveur
- Ftp : communication mais c'est de l'artillerie lourde pour pas grand chose (pas besoin d'un tank pour tuer un moustique) en plus c'est bien plus complexe.

Insiter sur le fait que Unity est prévu pour ce genre de choses et faire dire au diapo "Unity c'est Dieu !"

##Conclusion

Remettre les items dans le bon ordre

Interface : 

- On a réfléchis sur comment faire ça de la manière la plus simple possible : placement en 3 étapes
- on a cherché quel soft serait le plus adapté à notre appli en comparant : Unity
- ...

En gros, il faut dvlp chaque point pour faire ressortir notre travail