# Visie en scope

Deze template is gebaseerd op het document `"01 visie en scope(1).pdf"`uit de
voorbeeldcase _Sweet Dreams_ van het vak Software Analysis, aangevuld met
enkele extra rubrieken.

## Visie

### Huidige situatie

Het stuurprogramma voor drugpreventie is niet aanwezig op het web. Ze voeren campagnes via flyering en infosessies. In de huidige maatschappij is een aanwezigheid op het internet echter gewenst voor een maximaal bereik. 

### Gewenste situatie

Het stuurprogramma voor drugpreventie heeft een nadrukkelijke aanwezigheid op het web. Dit via een dynamische web-app met enkele extra's. Zo bevat de website een newsfeed, een event kalender, een alcoholtester enzovoort.

### Businessrequirements

Het stuur programma wilt een web-app om:

1. Meer studenten te kunnen bereiken
2. Geînteresseerden beter op de hoogte houden van hun acties
3. Een beter overzicht krijgen van het alcoholgebruik van de Hasseltse en Diepenbeekse studenten.

## Belanghebbenden

### Eindgebruikers

1. De studenten: het is de bedoeling dat studenten de web-app actief gaan gebruiken. Zowel om events op te zoeken als om hun alcoholgebruik te dempen.
2. Het stuurprogramma: zij zullen de website gebruiken om zich beter kenbaar te maken. Ook zullen ze statistieken verzamelen over bv. het aantal studenten dat op stap gaat, de gemiddelde hoeveelheid acohol enzovoort.

### Gebruikersomgeving

Alle studenten zullen toegang hebben tot de website. Het is de bedoeling dat zoveel mogelijk studenten de website gebruiken, daarvoor is het nodig dat ze er ook daadwerkelijk voordeel uit halen bij het gebruik van de web app. Verder zullen de rechthebbenden toegang hebben tot de administratie van de website. Basiskennis van de gebruikte browser en administratie termen zijn gekend.

### Overige belanghebbenden

1. Studentenverenigingen: dit zijn de verenigingen die de meeste fuiven organiseren. Zij kunnen hun fuiven op de website zetten.
2. De PXL: De PXL zit in de stuurgroep en wilt voor haar studenten zorgen, dit is het uiteindelijke doel van de hoge school.
3. De UHasselt: zie PXL.
4. De KHLIM: Zie PXL.
5. De stad Hasselt: Zij hebben er baat bij om de overlast door studenten te beperken. Ze hebben er dus belang bij om de website te laten aanslaan.
6. De ouders: ouders willen het beste voor hun kinderen. Overmatig alcoholgebruik wordt op neergekeken en kan getracked worden via de web-app.

## Systeemscope

### Omschrijving van het systeem

De belangrijkste functionaliteit van het systeem is de event kalender. Via deze kalender zullen de bezoekers kunnen zien wat er te doen is in hun nabije omgeving op een intuïtieve wijze. Verder zal er een optie zijn om carpooling te organiseren. Dit om het rijden onder invloed te voorkomen en ervoor te zorgen dat de studenten een manier hebben om veilig thuis te geraken. Een andere, vereiste functie is de newsfeed. De newsfeed zal zich bevonden op de hoofdpagina en is dynamisch. Deze wordt dus automatisch geupdated met tweets en facebook-posts van het stuurprogramma. Verdere mogelijke functies zijn een alcoholtester, een lifesaver-pagina en een FAQ-pagina. Verder is het nodig dat het systeem volledig geïntegreed is met Facebook. Dit om de login te vereenvoudigen, en om op een simpele manier events toe te voegen.

### Positionering van het systeem

De web-app zal draaien via een externe service provider. De keuze hiervoor valt bij het stuurprogramma. Het stuurprogramma heeft een administratie-interface om de website te beheren. Een technische beperking is dat de back-end geprogrammeerd wordt door middel van ASP.NET en de database beheerd wordt door MySQL.

### Globale gebruikersrequirements

1. Studenten willen kijken welke events er zijn
2. Studenten willen vervoer regelen via de web-app
3. Gebruikers kunnen kijken welke acties het stuurprogramma gepland heeft
4. Studenten kunnen hun alcoholgebruik opvolgen via de website
5. Het stuurprogramma kan het algemene alcoholgebruik in het uitgaansleven tracken
6. Het stuurprogramma kan events goed- of afkeuren
7. Het stuurprogramma kan de newsfeed beheren

### Niet-functionele requirements

1. Het gebruik is intuïtief
2. De website heeft een aantrekkelijk uiterlijk
3. De website moet een waarschuwende ondertoon jegens alcohol hebben
4. De toegang tot de website is laagdrempelig

## Voorlopige planning

### Risico's

Het is de eerste keer dat we met een Facebook SDK werken. Dit zal dus wat wennen zijn. Verder is de scheiding tussen front- en back-end nog niet compleet duidelijk, waardoor we in deze stage van het project nog wat verward zijn.

### Huidig kennisniveau

Uitstekende kennis van: HTML, CSS, PHP, Javascript, C#
Matige kennis van: ASP.NET, AJAX
Geen kennis van: Facebook SDK, Twitter SDK

### Plan van aanpak

Wij pakken dit project aan door middel van een stapsgewijze aanpak. We gaan voorzichtig te werk en zorgen dat de analyse in orde is. Verassingen zullen we zoveel mogelijk vermijden aan de hand van een algemene structuur en analyse. Tijdens het programmeren zal de repository in orde gehouden worden en de gemaakte afspraken gevolgd worden. Verder stellen we enkele mijlpalen om te controleren of we op schema zitten.

Een ander aspect van onze aanpak is het werken naargelang onze specialiteiten. We kunnen een specialist inzake Javascript en een specialist inzake PHP in ons team hebben zitten. Zij zullen dus taken krijgen volgens hun specialiteit. Dit doen we om onze indivuele sterktes zoveel mogelijk te benutten en de opdrachten af te bakenen.

De teamverdeling is als volgt:
Kevin Strijbos - organisator
Rudy Mas - verslaggever
Joran Claessens - Communicatie met derden
Sacha Reyskens, Bram Van Vleymen en Frédérique Van Wonterghem zullen bijspringen waar nodig.

### Bronnen

Concrete oplijsting van te raadplegen bronnen. Dit is dus meer dan [gewoon Stackoverflow](http://stackoverflow.com).
