# Use Case ID: Vervoersysteem - Student zoekt BOB

**Actoren**: Student.  
**Trigger**: Een student wilt naar een evenement gaan en zoekt een BOB.

## Omschrijving

Bij evenementen bestaat er de keuze voor de student om op zoek te gaan naar een BOB. De student kan hierbij een keuze maken uit een lijst van personen die zich aangeboden hebben als BOB. De student zou hierdoor veilig thuis moeten geraken met behulp van de student die zich aangeboden had als BOB.

## Precondities

1. De student moet ingelogd zijn.
2. De student moet een evenement geselecteerd hebben om een BOB te zoeken.
3. De student moet zich als aanwezig opgeven hebben voor het evenement.

## Postcondities

1. De student staat genoteerd in het systeem samen met de geselecteerde BOB.
2. Het aantal beschikbare plaatsen bij de BOB zal dalen met 1.

## Normale flow

1. De student zoekt een BOB voor het geselecteerde evenement.
2. Zijn gegevens worden geëvalueerd door het systeem.
2. De student selecteert de persoon waar hij mee wil gaan naar het evenement.
3. De student accepteert de voorwaarden en slaat de gegevens op.
4. De gegevens van de student worden opgenomen, samen met de BOB, voor het geselecteerde evenement.

## Alternatieve flow

1. De student zoekt een BOB voor het geselecteerde evenement.
2. Zijn gegevens worden geëvalueerd door het systeem.
2. De student geeft zich als "beschikbaar" op.
3. De student accepteert de voorwaarden en slaat de gegevens op.
4. De gegevens van de student worden opgenomen, samen met de BOB, voor het geselecteerde evenement. 

## Uitzonderingen

**1E1.**	Het evenement is geannuleerd, waardoor de student zich niet meer zoeken naar een BOB.

**1E2.**	Er zijn geen beschikbare plaatsen meer voor de geselecteerde BOB.

**1E3.**	De database is niet beschikbaar, het systeem geeft een errormessage.

## Inclusief

/
