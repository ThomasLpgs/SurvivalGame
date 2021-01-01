# Survival Game 
*Groupe: CONTE Jonathan, JACQUES Nils, LASPOUGEAS Thomas, SEVRAIN Florian*

## Présentation du jeu

### Barres d'états
Notre jeu de survie est basé sur 3 barres d'états:
1. Barre de vie:
Quand un ennemi attaque, on perd 10 points de vie par coups. On perd aussi de la vie quand notre barre de faim est à 0. Cependant, quand notre barre de faim est supérieure à 90, alors on gagne 2 points de vie par seconde.

2. Barre de faim:
La barre de faim se vide quand on se déplace, saute, attaque ... On peut regagner des points dans notre barre de faim quand on ramasse un morceau de viande;

3. Barre de stamina:
La barre de stamina se vide quand on court, saute, attaque ... On peut regagner des points de stamina quand on ne fait aucune action ou quand on marche

### Déplacement joueur
Z - Avancer
Q - Aller à gauche
D - Aller à droite
S - Aller en arrière
SHIFT + Z - Courrir
ESPACE - Sauter
Clic gauche - coup de pied en bas
Courrir + clic gauche - coup de pied en hauteur

### IA Ennemis
On peut rencontrer des loups sur la map qui se déplacent librement puis qui, d'abord nous regarde si on se rapprochent d'eux et ensuite nous attaque si l'on est trop près. Quand ils attaquent on perd 10 points de vie par secondes. Les loups meurent quand on les attaque et ils nous drop un morceau de viande.

Quand on marche sur un morceau de viande, on regagne 20 points dans notre barre de faim et le morceau de viande disparaît.

## Inventaire
On avait commencé à faire un inventaire pour pouvoir stocker des viandes, ramasser du bois ... Par manque de temps, nous n'avons pas implémenté la fonctionnalité mais le graphique de l'inventaire y est.
La touche `i` permet d'activer ou désactiver l'inventaire.
