# Use Case ID: UC03

**Actoren**: Gebruiker, Administrator<br>
**Trigger**: Een review wordt geplaatst door een gebruiker

## Omschrijving

Bij het plaatsen van een review zal deze geaccepteerd of verwijderd worden als deze wel of niet conform is met de regels.

## Precondities

1. De gebruiker moet ingelogd zijn.
2. De gebruiker moet een review plaatsen.
3. De administrator moet ingelogd zijn.

## Postcondities

1.1 De review werd geplaatst.<br>
1.2 De review werd verwijderd.

## Normale flow

1. De gebruiker plaatst een review.
2. De review wordt in een wachtrij gezet om gecontroleerd te worden.
3. De administrator controleert de review
4. De administrator accepteert de review.
5. De review verschijnt op de website.


## Alternatieve flow
4.1. De administrator weigert de review.
4.2. De review verschijnt niet op de website.

## Uitzonderingen

**1E1.** De gebruiker kiest zelf zijn review te wissen, waardoor de request om deze te controleren ook verwijderd wordt.

## Inclusief

Geen