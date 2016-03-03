# Use Case ID: UC05

**Actoren**: bezoekers   
**Trigger**: het event is afgelopen

## Omschrijving

Een bezoeker van de website kan inloggen via Facebook of een zelfgemaakt account. Als de ingelogde bezoeker zichzelf op aanwezig zet op een bepaald evenement zal dit opgeslagen worden.
Zodra het evenement is afgelopen zal de ingelogde bezoeker een notificatie krijgen om het evenement te beoordelen.

## Precondities

1. De bezoeker is ingelogd.
2. De bezoeker staat op aanwezig op een bepaald evenement.
3. Het evenement is afgelopen.

## Postcondities

1. De notificatie is verdwenen.
2. De event rating is opgeslagen.
3. De gemiddelde rating is aangepast.

## Normale flow

1. Bezoeker logged in.
2. Bezoeker zet zichzelf aanwezig op een evenement.
3. Bezoeker krijgt een notificatie na afloop van het evenement.
4. Bezoeker wordt naar de pagina van het evenement gebracht.
5. Bezoeker geeft een punt op vijf.
6. Rating wordt opgeslagen in de database.
7. De gemiddelde rating van het evenement wordt aangepast met de nieuwe rating.

## Alternatieve flow

1. Bezoeker zet zichzelf aanwezig op een evenement dat al afgelopen is. (max. 24h na afloop evenement)
2. Bezoeker wordt direct naar de omschrijvingspagina gebracht.
3. Bezoeker krijgt een melding dat hij een rating kan geven.
4. Rating wordt opgeslagen.
5. Gemiddelde rating wordt aangepast.

## Uitzonderingen

**1E1.**	Het evenement is geannuleerd, waardoor de student geen rating meer kan geven.

**1E2.**	De database is niet beschikbaar, het systeem geeft een errormessage.

## Inclusief

/
