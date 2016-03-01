# Use Case ID: Evenementenlijst van standpunt student

**Actoren**: Student<br>
**Trigger**: De student zoekt naar informatie over geplande evenementen

## Omschrijving

De student kan een evenementenlijst raadplegen op de hoofdpagina van de website. Deze pagina bevat een overzicht van de evenementen van de komende twee weken, en bevat de titel, organisator en dag, uur en plaats van het evenement. Door op een evenement te klikken, komt de student op de eigenlijke evenementenpagina. Op deze pagina krijgt hij meer informatie over het evenement, als ook een mogelijkheid om aan te duiden of hij naar dit evenement gaat of niet.

## Precondities

1. Organisatoren moeten evenementen hebben ingegeven
2. Student meld zich aan op de website (optioneel) (*)

## Postcondities

1. Student krijgt de informatie te zien

## Normale flow

1. Het systeem toont een lijst van evenementen
2. De student kan door deze lijst scrollen
3. De student klikt op het evenement dat hem boeit
4. Het systeem toont alle informatie van het evenement
5. Het systeem toont een lijst van zijn vrienden die naar het evenement gaan (*)
6. De student heeft de optie om te bevestigen dat hij naar het evenement gaat (*)

## Alternatieve flow

3.1 De student klikt op de link die hem naar de evenementenpagina brengt<br>
3.2 Het systeem toont hem een lijst van alle toekomstige evenementen<br>
3.3 De student klikt op het evenement dat hem boeit

## Uitzonderingen

1E1. Geen toekomstige evenementen beschikbaar, het systeem geeft hier een melding van<br>
1E2. De databank is niet beschikbaar, het systeem geeft hier een foutpagina

## Inclusief

Geen