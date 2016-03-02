# Use Case ID: Controle op organisaties

**Actoren**: Administrator 
**Trigger**: Een organisatie wilt zich registreren / een organisatie gedraagt zich niet naar de normen van de admin

## Omschrijving

Een organisatie kan zich registreren, maar moet hierbij geaccepteerd worden door de admin(a). Een organisatie kan ook verwijderd worden wegens het breken van de overeenkomst met de site eigenaar, zelfs na de registratie (b).

## Precondities

1a. De organisatie moet geregistreerd zijn.
1b. De organisatie moet geaccepteerd zijn op de website.
2. De admin moet ingelogd zijn.


## Postcondities

1a. De organisatie werd geaccepteerd en staat tussen de lijst van actieve organisaties.
1b. De organisatie werd verwijderd en heeft geen toegang meer tot de website.

## Normale flow
// Registratie
1. De organisatie registreert zich.
2. De admin kijkt de gegevens van de organisatie na.
3. De admin accepteert de organisatie.
4. De organisatie kan nu events aanmaken op de website.

// Slecht gedrag
1. De admin verwijdert de organisatie wegens slecht gedrag, niet conform aan de regels.
2. De organisatie heeft geen toegang meer tot de website.

## Alternatieve flow

Geen alternatieven.

## Uitzonderingen

**1E1.**	De organisatie kiest er zelf voor te verdwijnen van de website, betekende dat de organisatie zichzelf verwijdert.

**1E2.**	De organisatie wordt bij de registratie al verwijderd wegens fraude/foute informatie.

## Inclusief