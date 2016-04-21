# Use Case ID: UC05

**Actoren**: Gebruiker  
**Trigger**: Het evenement is afgelopen

## Omschrijving

Een gebruiker van de website kan inloggen via Facebook of een zelfgemaakt account. Als de ingelogde gebruiker zichzelf op aanwezig zet op een bepaald evenement zal dit opgeslagen worden.

Zodra het evenement is afgelopen zal de ingelogde gebruiker een notificatie krijgen om het evenement te beoordelen.

## Precondities

1. De gebruiker is ingelogd
2. De gebruiker staat op aanwezig op een bepaald evenement
3. Het evenement is afgelopen

## Postcondities

1. De notificatie is verdwenen
2. De evenement rating is opgeslagen

## Normale flow

1. De gebruiker krijgt een notificatie na afloop van het evenement
2. De gebruiker wordt naar de pagina van het evenement gebracht
3. De gebruiker geeft een punt op vijf
4. De rating wordt opgeslagen in de database

## Alternatieve flow

1. De gebruiker zet zichzelf als aanwezig op een evenement dat al afgelopen is. (max. 24h na afloop evenement)
2. De gebruiker wordt direct naar de omschrijvingspagina gebracht
3. De gebruiker krijgt een melding dat hij een rating kan geven
4. Rating wordt opgeslagen

## Uitzonderingen

**1E1.** Het evenement is geannuleerd, waardoor de student geen rating meer kan geven  
**1E2.** De database is niet beschikbaar, het systeem geeft een foutmelding

## Inclusief

Geen