# LibraryManager

Groupe: Noah Bonnel & Colin Prokopowicz

note: le projet [`LibraryManager.Hosting/Program.cs`](LibraryManager.Hosting/Program.cs) compile!

## Qu'est-ce qu'on a fait ?

- Nous sommes le premier groupe à avoir réussi à faire fonctionner le ContextManager 
    - sur la relation OneToMany (`Book` et `Author`)
    - sur la relation ManyToMany `stock` (`Book` et `Library`)
- Nous avons créé une PR pour corriger des typos sur le `README.md` du sujet
- Toutes les étapes jusqu'à la 10 ont été faites (avec quelques petites erreurs sur la 8 et 9)


## Erreurs connues

Afin d'accélérer la correction, voici la liste des erreurs connues :

- les requêtes BDD sur les Book n'utilisent pas la jointure avec Author, renvoyant null sur les appels 
aux api /books et /books/{id}
- /books/type renvoie une liste vide même sur une requête censée renvoyer des résultats
- sur la page du swagger, le schéma Book est visible en plus de BookDto
