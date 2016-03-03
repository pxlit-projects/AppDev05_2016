# Use Case ID: UC02

**Actoren**: Organisator, Administrator<br>
**Trigger**: Een organisator wilt zich registreren / Een organisator gedraagt zich niet naar de normen van de administrator

## Omschrijving

Een organisator kan zich registreren, maar moet hierbij geaccepteerd worden door de administrator (a). Een organisator kan ook verwijderd worden wegens het breken van de overeenkomst met de site-eigenaar, zelfs na de registratie (b).

## Precondities

1a. De organisator moet geregistreerd zijn.<br>
1b. De organisator moet geaccepteerd zijn op de website.<br>
2. De administrator moet ingelogd zijn.


## Postcondities

1a. De organisator werd geaccepteerd en staat tussen de lijst van actieve organisaties.<br>
1b. De organisator werd verwijderd en heeft geen toegang meer tot de website.

## Normale flow

1. De organisator registreert zich.
2. De administrator kijkt de gegevens van de organisator na.
3. De administrator accepteert de organisator.
4. De organisator kan nu evenementen aanmaken op de website.

## Alternatieve flow

1. De administrator verwijdert de organisator wegens slecht gedrag wanneer deze zich niet gedraagt conform de regels.
2. De organisator heeft geen toegang meer tot de website.

## Uitzonderingen

**1E1.** De organisator kan zich uitschrijven van de website, oude evenementengegevens worden wel bewaard.

**1E2.** De organisator wordt bij de registratie al verwijderd wegens fraude of foute informatie.

## Inclusief

Geen