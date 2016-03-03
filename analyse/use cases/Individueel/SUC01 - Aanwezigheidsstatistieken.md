# Use Case ID: UC01

**Actoren**: Administrator<br>
**Trigger**: De Aanwezigheidsstatistieken worden opgevraagd

## Omschrijving

Een administrator kan de aanwezigheidsstatistieken van elk evenement opvragen. Deze pagina bevat een overzicht van de aanwezigheidsstatistieken per evenement. Zoals het geslacht, leeftijd, hoeveel mensen er gaan ...

## Precondities

1. Er moet tenminste één evenement in de database staan
2. De administrator is ingelogd

## Postcondities

1. Lijst van aanwezigheidsstatistieken voor een evenement

## Normale flow

1. Het systeem toont een lijst van evenementen
2. De administrator kan hier door scrollen
3. De administrator klikt op een evenement waar hij/zij de aanwezigheidsstatistieken wilt zien
4. Het systeem toont de aanwezigheidsstatistieken van dit evenement (geslacht, leeftijd ...)

## Alternatieve flow

1. Het systeem toont een lijst van evenementen
2. De administrator zoekt naar een bepaald evenement met de zoekfunctie
3. De administrator klikt op het evenement waar hij/zij de aanwezigheidsstatistieken wilt zien
4. Het systeem toont de aanwezigheidsstatistieken van dit evenement (geslacht, leeftijd ...)

## Uitzonderingen

**1E1.** De database is niet beschikbaar, het systeem geeft een foutmelding

**1E2.** Het evenement heeft nog geen statistieken, het systeem geeft een foutmelding ("Er zijn nog geen statistieken beschikbaar voor dit evenement.")

## Inclusief

Geen