# Use Case ID: Controle op reviews

**Actoren**: Student, Admin 
**Trigger**: Een review wordt geplaatst door een student

## Omschrijving

Bij het plaatsen van een review zal deze geaccepteerd of verwijderd worden als deze wel of niet conform is met de regels.

## Precondities

1. De student moet ingelogd zijn.
2. De student moet een review plaatsen.
3. De admin moet ingelogd zijn.

## Postcondities

1a. De review werd geplaatst.
1b. De review werd verwijderd.

## Normale flow

1. De student plaatst een review.
2. De review wordt in een wachtrij gezet om gecontroleerd te worden.
3. De admin controleert de review
4. De admin accepteert de review.
5. De review verschijnt op de website.


## Alternatieve flow
1. De student plaatst een review.
2. De review wordt in een wachtrij gezet om gecontroleerd te worden.
3. De admin weigert de review. 
4. De review verschijnt niet op de website.

## Uitzonderingen

**1E1.**	De student kiest zelf zijn review te wissen, waardoor de request om deze te controleren ook verwijderd wordt.

## Inclusief