# Use Case ID: UC09

**Actoren**: Gebruiker  
**Trigger**: Een gebruiker wilt naar een evenement gaan en zoekt een BOB.

## Omschrijving

Bij evenementen bestaat er de keuze voor de gebruiker om op zoek te gaan naar een BOB. De gebruiker kan hierbij een keuze maken uit een lijst van personen die zich aangeboden hebben als BOB. De gebruiker zou hierdoor veilig thuis moeten geraken met behulp van de persoon die zich aangeboden had als BOB.

## Precondities

1. De gebruiker moet ingelogd zijn.
2. De gebruiker moet een evenement geselecteerd hebben om een BOB te zoeken.
3. De gebruiker moet zich als aanwezig opgeven hebben voor het evenement.

## Postcondities

1. De gebruiker staat genoteerd in het systeem samen met de geselecteerde BOB.
2. Het aantal beschikbare plaatsen bij de BOB zal dalen.

## Normale flow

1. De gebruiker zoekt een BOB voor het geselecteerde evenement.
2. Zijn gegevens worden geëvalueerd door het systeem.
2. De gebruiker selecteert de persoon waar hij mee wil gaan naar het evenement.
3. De gebruiker accepteert de voorwaarden en slaat de gegevens op.
4. De aanvraag wordt gestuurd naar de geselecteerde BOB.
5. De BOB accepteert de aanvraag.
6. De gegevens van de gebruiker worden opgenomen, samen met de BOB, voor het geselecteerde evenement.

## Alternatieve flow

2.1 De persoon geeft zich als "beschikbaar" op.<br>
2.2 De gebruiker accepteert de voorwaarden en slaat de gegevens op.<br>
2.3 De gegevens van de gebruiker worden opgenomen, samen met de BOB, voor het geselecteerde evenement. 

## Uitzonderingen

**1E1.**	Het evenement is geannuleerd, waardoor de gebruiker niet meer kan zoeken naar een BOB.

**1E2.**	Er zijn geen beschikbare plaatsen meer voor de geselecteerde BOB.

**1E3.**	De aanvraag wordt geannuleerd.

**1E4.**	De database is niet beschikbaar, het systeem geeft een foutmelding.

## Inclusief

Geen
