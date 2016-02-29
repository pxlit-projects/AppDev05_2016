# Use Case ID: Vervoersysteem - Aanbieden als BOB

**Actoren**: Student.  
**Trigger**: Een student wilt zich aanbieden als BOB

## Omschrijving

Bij evenementen bestaat er de keuze voor de student om je aan te bieden als BOB. Als een student zich aanbiedt als BOB zal deze persoon verantwoordelijk zijn voor de andere studenten die met hem meegaan naar het evenement. Van deze persoon zal er verwacht worden dat hij nuchter blijft en ervoor zorgt dat iedereen veilig thuis geraakt.

## Precondities

1. De student moet ingelogd zijn.
2. De student moet een evenement geselecteerd hebben om zich aan te bieden als BOB.
3. De student moet zich als aanwezig opgeven hebben voor het evenement.

## Postcondities

1. De student staat in de lijst van beschikbare BOB's voor het geslecteerde evenement.

## Normale flow

1. De student  zich aan voor het geselecteerde evenement.
2. Zijn gegevens worden geëvalueerd door het systeem.
2. De studentbiedt kan ingeven hoeveel personen hij kan meenemen.
3. De student accepteert de voorwaarden en slaat de gegevens op.
4. De gegevens van de student worden opgenomen voor het geselecteerde evenement.

## Alternatieve flow

Geen alternatieven

## Uitzonderingen

**1E1.**	Het evenement is geannuleerd, waardoor de student zich niet meer kan opgeven als BOB.

**1E2.**	De database is niet beschikbaar, het systeem geeft een errormessage.

## Inclusief

/
