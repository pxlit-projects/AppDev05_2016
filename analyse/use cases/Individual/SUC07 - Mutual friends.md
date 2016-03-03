# Use Case ID: UC07

**Actoren**: Gebruiker<br>
**Trigger**: Weergave van een event.

## Omschrijving

Bij de selectie van een evenement kan de gebruiker zien welke gemeenschappelijke vrienden naar dat bepaald evenement gaan.
Een gebruiker kan zien welke gemeenschappelijke vrienden naar een bepaald evenement gaan.

## Precondities

1. De gebruiker is ingelogd.

## Postcondities

1. De gebruiker ziet welke gemeenschappelijke vrienden die naar een bepaald evenement gaan.

## Normale flow

1. Het systeem toont een lijst met evenementen.
2. De gebruiker bekijkt een evenement.
3. Het systeem toont zijn vrienden aan de hand van de database.

## Alternatieve flow

1.1 De gebruiker zijn profiel is gelinkt aan een sociaal medium.<br>
1.2 De vrienden van de gebruiker worden opgeslagen in de database.<br>
1.3 De gebruiker bekijkt een evenement.<br>
1.4 Het systeem toont een lijst met van gemeenschappelijke vrienden aan de hand van de database. 

## Uitzonderingen

**1E1.** 	Er zijn geen evenementen beschikbaar, het systeem geeft een foutmelding.

## Inclusief

Geen
