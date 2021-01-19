
# Outil d'édition de gizmo  
  
Création d'un éditeur de gizmo pour modifier leurs positions ainsi que leurs noms depuis une fenêtre dédiée ou depuis la scène.  
  
  
  
## Fonctionnalités  
  
- Fenêtre d'édition de gizmo  
    - Affichage du nom  
    - Affichage de la position  
    - Bouton d'ajout de gizmo  
    - Bouton de suppression d'un gizmo  
    - Bouton d'édition du gizmo  
- Menu volant sur la scène lors d'un clique droit  
    - Bouton d'ajout d'un gizmo à la position cliquée  
    - Bouton de modification de la position du gizmo cliqué  
    - Bouton de réinitialisation de la position du gizmo cliqué  
    - Bouton de suppression du gizmo cliqué  
  
Affichage des gizmos dans la scène.  
Bouton d'accès à l'outil d'édition dans l'objet " EditorGizmoAsset " ou via Window -> Custom -> Editor Gizmos  
Sauvegarde en temps réel des données dans l'objet " EditorGizmoAsset " .  
Impossibilité de modifier la position d'un gizmo si celui-ci n'est pas en mode d'édition.  
  
  
  
## Fonctionnalité manquante  
  
Suppression de la dernière modification via la commande ctrl+z.  
  
  
  
  
## Problèmes rencontrés  
  
Impossibilité de changer la position d'un gizmo en modifiant ses coordonnées dans l'outil cela peut être uniquement fait via l'outil de transformation dans la scène.  
Si un gizmo entre en mode d'édition, l'outil de transformation devient disponible pour tout les autres gizmos, même non-éditable et ses coordonnées seront mise à jour uniquement quand le gizmo deviendra éditable. Je n'ai pas réussi à rendre l'outil inutilisable pour un objet précis de la scène.
Mauvaise utilisation du Scriptable Object lors de la gestion des entrées sur la scène générant un warning.  
  
## Conclusion  
  
J'ai développé deux classes, une pour la création et la gestion de la fenêtre d'édition et une pour la gestion des entrées sur la scène. Étant donné que c’était ma première expérience avec Unity Editor , j'ai eu quelques soucis pour bien comprendre le fonctionnement de ces objets particuliers, mais j'ai tout fois réussi à créer un outil fonctionnel.  
L'outil permet de gérer directement via la scène l'emplacement des gizmos , d'en ajouter ou d'en supprimer. Il est possible de modifier leurs noms dans la fenêtre d’édition ainsi que de visualiser leurs coordonnées en temps réel.

La découverte d'Unity Editor m'a appris de nouvelle chose et d'entrevoir de nouvelle fonctionnalisé lors de la réalisation de futur projet.
