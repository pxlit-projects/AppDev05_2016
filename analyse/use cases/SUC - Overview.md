# Use Case ID: UC01

**Actoren**: Administrator  
**Trigger**: De Aanwezigheidsstatistieken worden opgevraagd

## Omschrijving

Een administrator kan de aanwezigheidsstatistieken van elk evenement opvragen. Deze pagina bevat een overzicht van de aanwezigheidsstatistieken per evenement. Zoals het geslacht, leeftijd, hoeveel mensen er gaan ...

## Precondities

1. Er moet tenminste één evenement in de database staan
2. De administrator is ingelogd

## Postcondities

1. Lijst van aanwezigheidsstatistieken voor een evenement

## Normale flow

1. Het systeem toont een lijst van evenementen of bezoekers
2. De administrator kan hier door scrollen
3. De administrator klikt op een evenement waar hij/zij de aanwezigheidsstatistieken wilt zien
4. Het systeem toont de aanwezigheidsstatistieken van dit evenement (geslacht, leeftijd ...)

## Alternatieve flow

1. Het systeem toont een lijst van evenementen
2. De administrator zoekt naar een bepaald evenement met de zoekfunctie
3. De administrator klikt op het evenement waar hij/zij de aanwezigheidsstatistieken wilt zien
4. Het systeem toont de aanwezigheidsstatistieken van dit evenement (geslacht, leeftijd ...)

## Uitzonderingen

**1E1.** De database is niet beschikbaar, het systeem geeft een foutmelding  
**1E2.** Het evenement heeft nog geen statistieken, het systeem geeft een foutmelding ("Er zijn nog geen statistieken beschikbaar voor dit evenement.")

## Inclusief

Geen

---

# Use Case ID: UC02

**Actoren**: Organisator, Administrator  
**Trigger**: Een organisator wilt zich registreren / Een organisator gedraagt zich niet naar de normen van de administrator

## Omschrijving

Een organisator kan zich registreren, maar moet hierbij geaccepteerd worden door de administrator (a). Een organisator kan ook verwijderd worden wegens het breken van de overeenkomst met de site-eigenaar, zelfs na de registratie (b).

## Precondities

1a. De organisator moet geregistreerd zijn  
1b. De organisator moet geaccepteerd zijn op de website  
2. De administrator moet ingelogd zijn


## Postcondities

1a. De organisator werd geaccepteerd en staat tussen de lijst van actieve organisaties  
1b. De organisator werd verwijderd en heeft geen toegang meer tot de website

## Normale flow

1. De organisator registreert zich
2. De administrator kijkt de gegevens van de organisator na
3. De administrator accepteert de organisator
4. De organisator kan nu evenementen aanmaken op de website

## Alternatieve flow

1. De administrator verwijdert de organisator wegens slecht gedrag wanneer deze zich niet gedraagt conform de regels
2. De organisator heeft geen toegang meer tot de website

## Uitzonderingen

**1E1.** De organisator kan zich uitschrijven van de website, oude evenementengegevens worden wel bewaard  
**1E2.** De organisator wordt bij de registratie al verwijderd wegens fraude of foute informatie

## Inclusief

Geen

---

# Use Case ID: UC03

**Actoren**: Gebruiker, Administrator  
**Trigger**: Een review wordt geplaatst door een gebruiker

## Omschrijving

Bij het plaatsen van een review zal deze geaccepteerd of verwijderd worden als deze wel of niet conform is met de regels.

## Precondities

1. De gebruiker moet ingelogd zijn
2. De gebruiker moet een review plaatsen
3. De administrator moet ingelogd zijn

## Postcondities

1.1 De review werd geplaatst  
1.2 De review werd verwijderd

## Normale flow

1. De gebruiker plaatst een review
2. De review wordt in een wachtrij gezet om gecontroleerd te worden
3. De administrator controleert de review
4. De administrator accepteert de review
5. De review verschijnt op de website


## Alternatieve flow
4.1. De administrator weigert de review  
4.2. De review verschijnt niet op de website

## Uitzonderingen

**1E1.** De gebruiker kiest zelf zijn review te wissen, waardoor de request om deze te controleren ook verwijderd wordt

## Inclusief

Geen

---

# Use Case ID: UC04

**Actoren**: Gebruiker  
**Trigger**: De gebruiker zoekt naar informatie over geplande evenementen

## Omschrijving

De gebruiker kan een evenementenlijst raadplegen op de hoofdpagina van de website. Deze pagina bevat een overzicht van de evenementen van de komende twee weken, deze bevat de titel, organisator en dag, uur en plaats van het evenement. Door op een evenement te klikken, komt de gebruiker op de eigenlijke evenementenpagina. Op deze pagina krijgt hij meer informatie over het evenement, als ook een mogelijkheid om aan te duiden of hij naar dit evenement gaat of niet.

## Precondities

1. Organisatoren moeten evenementen hebben ingegeven
2. Gebruiker meld zich aan op de website (optioneel) (*)

## Postcondities

1. Gebruiker krijgt de informatie te zien

## Normale flow

1. Het systeem toont een lijst van evenementen
2. De gebruiker kan door deze lijst scrollen
3. De gebruiker klikt op het evenement dat hem boeit
4. Het systeem toont alle informatie van het evenement
5. Het systeem toont een lijst van zijn vrienden die naar het evenement gaan (*)
6. De gebruiker heeft de optie om te bevestigen dat hij naar het evenement gaat (*)

## Alternatieve flow

3.1 De gebruiker klikt op de link die hem naar de evenementenpagina brengt  
3.2 Het systeem toont hem een lijst van alle toekomstige evenementen  
3.3 De gebruiker klikt op het evenement dat hem boeit

## Uitzonderingen

**1E1.** Geen toekomstige evenementen beschikbaar, het systeem geeft hier een melding van  
**1E2.** De databank is niet beschikbaar, het systeem geeft hier een foutpagina

## Inclusief

Geen

---

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

---

# Use Case ID: UC06

**Actoren**: Gebruiker  
**Trigger**: Bij de persoonlijke instellingen van de gebruiker

## Omschrijving

Een gebruiker kan aan de hand van een filteringsysteem bepalen welk soort evenementen hij te zien wil krijgen.

## Precondities

1. De gebruiker is ingelogd

## Postcondities

1. De gebruiker ziet enkel een lijst met events afhankelijk van de gekozen criteria

## Normale flow

1. De gebruiker gaat naar de persoonlijke instellingen van zijn profiel
2. De gebruiker kiest het type evenement door middel van verschillende criteria

## Alternatieve flow

Geen alternatief

## Uitzonderingen

Geen uitzonderingen

## Inclusief

Geen

---

# Use Case ID: UC07

**Actoren**: Gebruiker  
**Trigger**: Weergave van een event

## Omschrijving

Bij de selectie van een evenement kan de gebruiker zien welke gemeenschappelijke vrienden naar dat bepaald evenement gaan.
Een gebruiker kan zien welke gemeenschappelijke vrienden naar een bepaald evenement gaan.

## Precondities

1. De gebruiker is ingelogd

## Postcondities

1. De gebruiker ziet welke gemeenschappelijke vrienden die naar een bepaald evenement gaan

## Normale flow

1. Het systeem toont een lijst met evenementen
2. De gebruiker bekijkt een evenement
3. Het systeem toont zijn vrienden aan de hand van de database

## Alternatieve flow

1.1 De gebruiker zijn profiel is gelinkt aan een sociaal medium  
1.2 De vrienden van de gebruiker worden opgeslagen in de database  
1.3 De gebruiker bekijkt een evenement  
1.4 Het systeem toont een lijst met van gemeenschappelijke vrienden aan de hand van de database

## Uitzonderingen

**1E1.** Er zijn geen evenementen beschikbaar, het systeem geeft een foutmelding

## Inclusief

Geen

---

# Use Case ID: UC08

**Actoren**: Gebruiker  
**Trigger**: Een persoon wilt zich aanbieden als BOB

## Omschrijving

Bij evenementen bestaat er de keuze voor de gebruiker om zich aan te bieden als BOB. Als een gebruiker zich aanbiedt als BOB zal deze persoon verantwoordelijk zijn voor de andere studenten die met hem meegaan naar het evenement. Van deze persoon zal er verwacht worden dat hij nuchter blijft en ervoor zorgt dat iedereen veilig thuis geraakt.

## Precondities

1. De gebruiker moet ingelogd zijn
2. De gebruiker moet een evenement geselecteerd hebben om zich aan te bieden als BOB
3. De gebruiker moet zich als aanwezig opgeven hebben voor het evenement

## Postcondities

1. De gebruiker staat in de lijst van beschikbare BOB's voor het geslecteerde evenement

## Normale flow

1. De gebruiker biedt zich aan voor het geselecteerde evenement
2. Zijn gegevens worden geëvalueerd door het systeem
2. De gebruiker kan ingeven hoeveel personen hij kan meenemen
3. De gebruiker accepteert de voorwaarden en slaat de gegevens op
4. De gegevens van de gebruiker worden opgenomen voor het geselecteerde evenement

## Alternatieve flow

Geen alternatieven

## Uitzonderingen

**1E1.** Het evenement is geannuleerd, waardoor de gebruiker zich niet meer kan opgeven als BOB  
**1E2.** De database is niet beschikbaar, het systeem geeft een foutmelding.

## Inclusief

Geen

---

# Use Case ID: UC09

**Actoren**: Gebruiker  
**Trigger**: Een gebruiker wilt naar een evenement gaan en zoekt een BOB

## Omschrijving

Bij evenementen bestaat er de keuze voor de gebruiker om op zoek te gaan naar een BOB. De gebruiker kan hierbij een keuze maken uit een lijst van personen die zich aangeboden hebben als BOB. De gebruiker zou hierdoor veilig thuis moeten geraken met behulp van de persoon die zich aangeboden had als BOB.

## Precondities

1. De gebruiker moet ingelogd zijn
2. De gebruiker moet een evenement geselecteerd hebben om een BOB te zoeken
3. De gebruiker moet zich als aanwezig opgeven hebben voor het evenement

## Postcondities

1. De gebruiker staat genoteerd in het systeem samen met de geselecteerde BOB
2. Het aantal beschikbare plaatsen bij de BOB zal dalen

## Normale flow

1. De gebruiker zoekt een BOB voor het geselecteerde evenement
2. Zijn gegevens worden geëvalueerd door het systeem
2. De gebruiker selecteert de persoon waar hij mee wil gaan naar het evenement
3. De gebruiker accepteert de voorwaarden en slaat de gegevens op
4. De aanvraag wordt gestuurd naar de geselecteerde BOB
5. De BOB accepteert de aanvraag
6. De gegevens van de gebruiker worden opgenomen, samen met de BOB, voor het geselecteerde evenement

## Alternatieve flow

2.1 De persoon geeft zich als "beschikbaar" op  
2.2 De gebruiker accepteert de voorwaarden en slaat de gegevens op  
2.3 De gegevens van de gebruiker worden opgenomen, samen met de BOB, voor het geselecteerde evenement

## Uitzonderingen

**1E1.** Het evenement is geannuleerd, waardoor de gebruiker niet meer kan zoeken naar een BOB  
**1E2.** Er zijn geen beschikbare plaatsen meer voor de geselecteerde BOB  
**1E3.** De aanvraag wordt geannuleerd  
**1E4.** De database is niet beschikbaar, het systeem geeft een foutmelding

## Inclusief

Geen