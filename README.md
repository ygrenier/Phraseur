# Phraseur

Petit utilitaire de construction de phrases

## Fichiers de données

Les fichiers de **thème** utilisés doivent se trouver dans le dossier **datas** et doivent tous avoir l'extensions **.txt**.

Ces fichiers doivent ont le format suivant

```
; Les lignes commençant par un point virgule sont ignorées, se sont des commentaires 

; Les lignes commençant par '@' définissent le titre du thème (celui qui s'affiche dans le sélecteur de thème)
@ Premier thème

; Les lignes commençant par un '#' démarre une nouvelle collection de mots, avec comme titre ce qui suit le '#'
# Premier mot

; Tout ce qui suit représente les mots/phrase

; Une ligne avec un '=' indique un couple mot/phrase où 'mot' est le mot mis en gras
; et 'phrase' est le texte utiliser pour construire la phrase finale
Mot=C'est un mot dans une phrase
Sujet=C'est un sujet de discussion

; Une ligne qui ne possède pas de '=' est uniquement la 'phrase'
C'est une phrase sans mot mis en évidence

# La suite
Important =  qui a beaucoup d'importance
Oubli = qu'on peut oublier

# Fin
au travail
dans la vie
```
