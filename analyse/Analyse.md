# Scope
# Visie en scope

## Visie

### Huidige situatie

Het stuurprogramma voor drugpreventie is niet aanwezig op het web. Ze voeren campagnes via flyering en infosessies. In de huidige maatschappij is een aanwezigheid op het internet echter gewenst voor een maximaal bereik. 

### Gewenste situatie

Het stuurprogramma voor drugpreventie heeft een nadrukkelijke aanwezigheid op het web. Dit via een dynamische webapplicatie met enkele extra's. Zo bevat de website een newsfeed, een evenement kalender, een alcoholtester, enzovoort.

### Businessrequirements

Het stuurprogramma wilt een webapplicatie om:

1. Meer studenten te kunnen bereiken
2. Geïnteresseerden beter op de hoogte houden van hun acties
3. Een beter overzicht krijgen van het alcoholgebruik van de Hasseltse en Diepenbeekse studenten.

## Belanghebbenden

### Eindgebruikers

1. De gebruikers: het is de bedoeling dat gebruikers de webapplicatie actief gaan gebruiken. Zowel om evenementen op te zoeken als om hun alcoholgebruik te dempen.
2. Het stuurprogramma: zij zullen de website gebruiken om zich beter kenbaar te maken. Ook zullen ze statistieken verzamelen over bijvoorbeeld het aantal studenten dat op stap gaat, de gemiddelde hoeveelheid acohol, enzovoort.

### Gebruikersomgeving

Alle studenten zullen toegang hebben tot de website. Het is de bedoeling dat zoveel mogelijk studenten de website gebruiken, daarvoor is het nodig dat ze er ook daadwerkelijk voordeel uit halen bij het gebruik van de webapplicatie. Verder zullen de rechthebbenden toegang hebben tot de administratie van de website. Basiskennis van de gebruikte browser en administratie termen zijn gekend.

### Overige belanghebbenden

1. Studentenverenigingen: dit zijn de verenigingen die de meeste fuiven organiseren. Zij kunnen hun fuiven op de website zetten.
2. De PXL: De PXL zit in de stuurgroep en wilt voor haar studenten zorgen, dit is het uiteindelijke doel van de hogeschool.
3. De UHasselt: zie PXL.
4. De KHLIM: Zie PXL.
5. De stad Hasselt: Zij hebben er baat bij om de overlast door studenten te beperken. Ze hebben er dus belang bij om de website te laten aanslaan.
6. De ouders: ouders willen het beste voor hun kinderen. Overmatig alcoholgebruik wordt op neergekeken en kan getraceerd worden via de web-app.

## Systeemscope

### Omschrijving van het systeem

De belangrijkste functionaliteit van het systeem is de evenement kalender. Via deze kalender zullen de bezoekers kunnen zien wat er te doen is in hun nabije omgeving op een intuïtieve wijze. Verder zal er een optie zijn om carpooling te organiseren. Dit om het rijden onder invloed te voorkomen en ervoor te zorgen dat de studenten een manier hebben om veilig thuis te geraken. Een andere, vereiste functie is de newsfeed. De newsfeed zal zich bevonden op de hoofdpagina en is dynamisch. Deze wordt dus automatisch geupdated met tweets en facebook-posts van het stuurprogramma. Verdere mogelijke functies zijn een alcoholtester, een lifesaver-pagina en een FAQ-pagina. Verder is het nodig dat het systeem volledig geïntegreed is met Facebook. Dit om de login te vereenvoudigen en om op een simpele manier evenementen toe te voegen.

### Positionering van het systeem

De webapplicatie zal draaien via een externe service provider. De keuze hiervoor valt bij het stuurprogramma. Het stuurprogramma heeft een administratie-interface om de website te beheren. Een technische beperking is dat de back-end geprogrammeerd wordt door middel van ASP.NET en de database beheerd wordt door MySQL.

### Globale gebruikersrequirements

1. Gebruikers willen kijken welke evenementen er zijn
2. Gebruikers willen vervoer regelen via de webapplicatie
3. Gebruikers kunnen kijken welke acties het stuurprogramma gepland heeft
4. Gebruikers kunnen hun alcoholgebruik opvolgen via de website
5. Het stuurprogramma kan het algemene alcoholgebruik in het uitgaansleven tracken
6. Het stuurprogramma kan evenementen goed- of afkeuren
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


# Talen
# ADO .Net #

## Omschrijving ##
.Net is een taal gecreëerd door Microsoft om het ontwikkelen op een Windows platform eenvoudiger te maken. Gaandeweg is de taal uitgebreid naar andere platformen. ADO .net is het gedeelte van deze taal dat zich focust op de databanken van een (web)-applicatie. Zo kan je met diverse databanken werken via ADO .Net om de gegevens te gebruiken in je applicatie zelf. ADO .Net is eigenlijk dus een standaard interface voor data access. 

* .Net Framework
* ADO .Net voor zowel web- als gewone applicaties. 
* Bruikbaar met de talrijke soorten van databanken
* Stelt gebruiker in staat met willekeurige databanken te communiceren

## Objecten 
**Connection** : maakt het contact met een gegevensbron.

**Command** : maakt commando's en query's naar een gegevensbron.

**DataReader** : leest stromen van tekst uit de gegevensbron.

**DataSet** : een dataset is een verzameling van DataTable-objecten. Deze DataTable-objecten kunnen onderling gelinkt zijn met DataRelation-objecten. Een Dataset wordt ook dikwijls omschreven als een 'offline' weergave van een database.

**DataTable** : een tabel in het geheugen zoals deze op een database zou voorkomen met rijen en kolommen. Als de gegevens worden geraadpleegd van een DataTable wordt er automatisch een standaard DataView opgeroepen.

**DataView** : maakt het mogelijk om in een DataTable te sorteren en filteren.

**DataAdapter** : zorgt voor een vertaling van verzoeken vanuit de ADO.NET-laag naar de database en omgekeerd.

## Ons project ##
Wij zullen de ADO .Net gebruiken op onze (web)-applicatie te verbinden met onze databank, en zo een gegevensstroom creëren waarmee we gegevens kunnen opslaan en ook gegevens kunnen vertonen op onze website/applicatie. Als IDE gebruiken we Visual Studio 2015 Community version.

---

# SQL #

## Omschrijving ##
SQL oftewel Structured Query Language is een taal voor een relationeel databasemanagementsysteem. Door middel van deze taal kunnen we praten met onze database en gegevens toevoegen, opvragen, bewerken of verwijderen. 

* Structured Query Language
* Gebruikt om met database te communiceren voor gegevens flow
* Werking met ADO .Net framework

## Ons project ##
We gebruiken SQL in ons project om met onze database aan gegevensuitwisseling te doen. We gebruiken hierbij ook het ADO .Net framework om de databank te connecteren aan onze applicatie zelf.

---

# ASP.NET #

## Omschrijving ##
.NET is een taal gecreëerd door Microsoft om het ontwikkelen op een Windows platform te versimpelen. Gaandeweg is de taal uitgebreid naar andere platformen. ASP.NET is het gedeelte van deze taal dat zich focust op web toepassingen. Zo kan een complete web applicatie in deze taal geschreven worden. PHP komt niet aan de pas in deze taal, de back-end wordt volledig vervangen door ASP.NET. Het is echter nog altijd noodzakelijk om HTML en CSS te schrijven. De drag and drop methode produceert lelijke code.
 
* .NET framework
* ASP.NET voor web applicaties
* Geen PHP
* HTML/CSS nog altijd noodzakelijk

## ASP.NET MVC ##
Het MVC framework is een framework voor ASP.NET toepassingen. Het dwingt je om het MVC software patroon te hanteren en zo de structuur van je code danig aan te passen. De structuur bestaat uit een model, een view en een controller. Het framework gaat zelfs zo ver dat de verschillende soorten opgedeeld zijn in verschillende mappen. Ook hanteert het framework verschillende conventies voor de naamgeving. Zo zal de controller communiceren met zijn view op basis van de naam.
 
Het MVC patroon is niet nieuw. Zo werd dit patroon al toegepast in C++ en in Java. Microsoft is echter een stapje verder gegaan door het forceren van dit patroon via de taal zelf. Voor meer info over het MVC patroon kun je op deze site terecht: [http://blog.codinghorror.com/understanding-model-view-controller/](http://blog.codinghorror.com/understanding-model-view-controller/).
 
De voordelen van MVC zijn talrijk. Zo zal je code beter gestructureerd zijn, worden de verschillende functionaliteiten dwangmatig opgesplitst en is je code beter onderhoudbaar. MVC vereist echter wel meer code.

## Ons project ##
Wij zullen de complete back-end schrijven in ASP.NET. Als framework gebruiken we het MVC framework samen met de web API van .NET. Elke HTTP request zal dus via een controller gebeuren, waarop deze controller de gevraagde functie uitvoert. Als IDE gebruiken we Visual Studio 2015 Community.

---

# Bootstrap Framework (JavaScript / JQuery) #

## Omschrijving ##
Bootstrap is destijds ontwikkeld door de medewerkers van Twitter. Het project werd gestart door twee personen, Mark Otto en Jacob Thornton, en zij noemden het in het begin Twitter Blueprint. Na verloop van tijd begonnen meerdere medewerkers van Twitter hieraan te werken en toen werd het omgedoopt naar Bootstrap.

Bootstrap maakt gebruik van JavaScript en JQuery plug-ins, in combinatie met HTML5 en CSS3. Alhoewel CSS3 vooral verwezenlijkt wordt door gebruik te maken van LESS-stylesheets. LESS is een vereenvoudigde taal om styling toe te passen op een website en een compiler zet de LESS-stylesheets dan nadien om naar de eigenlijke CSS-code.

De huidige versie van Bootstrap is versie 3. Deze versie is allereerst gericht op mobile, maar ondersteunt ook alle andere schermresoluties.

Het grote voordeel van Bootstrap is dat je dus geen afzonderlijke pagina’s meer moet maken voor de diverse toestellen en schermresoluties die er gebruikt worden. Afhankelijk van het gebruikte scherm, zal Bootstrap de lay-out aanpassen zodat het op elk type scherm een gebruiksvriendelijk resultaat geeft.

Maar Bootstrap is meer dan dat alleen! Daar de extra JQuery plug-ins, worden er bijkomende elementen voorzien voor de gebruikersinterface, deze omvatten onder andere dialoogvensters, tooltips, en carrousels. Ook werden verschillende bestaande elementen in functionaliteit uitgebreid.

Op dit moment is men druk aan het werk met versie 4 en die zit momenteel al in de alpha fase.

## Ons Project ##
Wij gaan Bootstrap Versie 3 gebruiken in ons project. We gebruiken dit om een responsive-design te creëren op de website. Via deze weg willen we zorgen dat de website gebruikt kan worden op smartphones en tablets, alsook op een laptop of desktop PC.

---

# Facebook API #

## Omschrijving ##
Met het Facebook API is het mogelijk om data van Facebook te kunnen verkrijgen, deze informatie krijgen we binnen via JSON, het is daarna mogelijk om deze data te gebruiken in JavaScript om applicaties rond Facebook uit te bouwen.
Met de juiste authorisation key is het mogelijk om data te verkrijgen door middel van volgende link: https://graph.facebook.com/`<name>`.

Op de plaats van `<name>` dient met een objectnaam in te vullen.
Er zijn verschillende soorten objecten binnen Facebook:
- Profielen
- Groepen
- Events
- Foto's
- ...

Elk object binnen Facebook heeft zijn eigen ID, binnen dat ID hebben ze afhankelijk van welk soort object ze zijn ook specifieke keys zoals bijvoorbeeld voor hun profiel, hun naam, hun vrienden, hun interesses, ....

Er zijn 3 commando's om data te manipuleren:
- GET -> Opvragen van data.
- POST -> Aanmaken van data.
- DELETE -> Verwijderen van data.

## Terms of Use ##

1. Vraag toestemming bij het posten op iemand zijn profiel.
2. Voorzie een duidelijke privacy policy voor de gebruiker en vermeldt ook hoe hun informatie gebruikt zal worden.
3. Hou je ook aan je eigen privacy policy.
4. Verwijder de gebruiker zijn gegevens indien dit door de gebruiker gevraagd wordt.
5. Vraag toestemming bij het gebruiken van de gebruiker zijn data voor reclamedoeleinden.
6. Vraag toestemming voor het verdelen van deze data.
7. Indien je een persoon zijn activiteiten volgt, zorg altijd voor een opt-outsysteem. (*)
8. Zorg voor een goede klantenservice van je applicatie en maak het makkelijk om contact met je op te nemen.
9. Indien gebruikers via de Facebook applicatie op iOS op je applicatie komen, zorg dat er een optie is om terug op de Facebook applicatie te komen (Back to Facebook).
10. Indien gebruikers via de Facebook applicatie op Android op je applicatie komen, zorg dat ze terug op de Facebook applicatie kunnen komen via de terugknop.

## Ons Project ##
Binnen ons project zal deze API gebruikt worden om gebruikers in te laten loggen via Facebook. Doordat ze toestemming geven tot de data van hun profiel kunnen wij die data gebruiken om doelgerichter naar de gebruiker toe te werken.

## Links ##
(*) https://nl.wikipedia.org/wiki/Opt-outsysteem
Uitgebreidere Terms of Use: https://developers.facebook.com/policy/
Data manipulatie: https://graph.facebook.com/`<name>`
Facebook for Developers: https://developers.facebook.com/

---

# HTML5 #

## Omschrijving ##
HTML5 (HyperText Markup Language 5) is de laatste versie van de HTML-standaard. HTML5 zorgt ervoor dat alle kleine foutjes van zijn voorganger worden verbeterd.

HTML5 introduceert nieuwe tags die ervoor zorgen dat er meer structuur in het document komt zoals &lt;header&gt; om het header-gedeelte aan te duiden , `<nav>` voor navigatie en `<article>` om het artikeldeel aan te duiden. Verder komen er tags die het mogelijk maken om interactieve content af te spelen zonder gebruik te maken van een Flash Player-plug-in, zoals de `<video>`-tag.

HTML5 zorgt er ook voor dat webapplicaties offline beschikbaar kunnen worden, bij het eerste bezoek aan de applicatie download je dan automatisch de benodigde files voor de webapp en dan kun je deze later offline gebruiken. Als je in zo’n offline applicatie dan veranderingen aanbrengt dan worden deze naar de server doorgestuurd op het eerstvolgende moment dat er weer internetverbinding is. Verder is er nu een mogelijkheid om drag and drop te implementeren.

## Ons Project ##
HTML5 zal voor ons project standaard gebruikt worden om pagina’s op te stellen. Hierbij zullen we ook gebruik maken van de nieuwe tags zoals `<header>` en `<nav>`.

# CSS3 #

## Omschrijving ##
Cascading Style Sheets (afgekort tot CSS) wordt gebruikt om de opmaak en de vormgeving van je webpagina op te stellen. Een belangrijke reden voor de introductie van Cascading Style Sheets was de eenvoudigere en consistentere vormgeving van webpagina's, met minder webbrowser-specifieke eigenaardigheden. Het World Wide Web Consortium (W3C) heeft daartoe de standaard vastgelegd.

CSS3 is de nieuwste versie van de CSS standaard. Net als HTML5 is CSS3 nog geen officiële standaard maar ondersteunen de nieuwste browsers wel zo goed als mogelijk de nieuwe mogelijkheden. Een korte opsomming:

**Borders**

* border-color
* border-image
* border-radius
* box-shadow

**Backgrounds**

* background-origin en background-clip
* background-size
* multiple backgrounds

**Color**

* HSL colors
* HSLA colors
* opacity
* RGBA colors

**Text effects**

* text-shadow
* text-overflow
* word-wrap

**User-interface**

* box-sizing
* resize
* outline
* nav-top, nav-right, nav-bottom, nav-left

**Selectors**

* attribute selectors

## Ons Project ##
Voor ons project zullen we voor bijna elke webpagina gebruik moeten maken van Cascading Style Sheets. Dit zal ervoor zorgen dat onze pagina’s een betere vorm zullen krijgen en dat deze aantrekkelijk zullen worden gepresenteerd.

---

# Twitter API #

## Wat is het? ##
De Twitter API is een Application Programming Interface, een collectie van functies en procedures die je toestaan om in applicaties de data van Twitter te gaan gebruiken. Dit zijn bijna alle functies van Twitter(tweets, followers, ...). Het werkt over het HTTP protocol.

## Hoe gebruik je het? ##
Er zijn heel veel manieren om de Twitter API te gebruiken, je kan een tweetbutton op je website zetten, een follow button en veel meer. Om deze te implementeren heb je een API key nodig. Dit is een string die een beveiligde handtekening meegeeft wanneer je iets van Twitter opvraagt. Deze API heeft verschillende objecten, waaronder de 4 hoofdobjecten: Tweets, Users, Entities en places. Als je de data van een bepaalde user wilt moet je toestemming vragen aan deze user. De data kan ook gebruikt worden om een newsfeed weer te geven.

## Terms of Use ##

1. Je mag niks voor andere mensen tweeten zonder dat zij hier iets van weten.
2. Je mag de data van Twitter nergens opslaan, maar je mag deze wel opvragen.
3. Je moet per project een verschillende API key aanvragen.
4. Respecteer de privacy van Twitter users, je mag hun informatie niet zomaar vrijgeven.
5. Je mag niet teveel posten(spammy automation).
6. Je mag Twitter niet kopiëren.

Dit zijn alleen de terms of use die voor ons toepasselijk zullen zijn.

## Ons Project ##
In ons project gebruiken we de Twitter API om een korte newsfeed te laten zien op de webapp.

## Links ##
Een link naar de Twitter API documentation: [https://dev.twitter.com/overview/documentation](https://dev.twitter.com/overview/documentation).

Een link naar de Twitter API: [https://dev.twitter.com/](https://dev.twitter.com/).
# Pagina's 
# Controle Organisatie #

Dit is een pagina die enkel de admin kan zien. Door middel van deze pagina kan de admin de organisaties toegang tot de website geven of ontzeggen. Dit kan zowel voor als na de registratie.
  
Na de registratie zal een organisatie een bepaalde tijd moeten wachten, opdat de admin de organisatie kan controleren en hem toestemming kan geven om evenementen op de website te plaatsen. De organisatie kan zich enkel aanmelden via het ‘form’, dus niet via Facebook. De admin kan alle informatie zien die de desbetreffende organisatie gebruikt heeft om zich te registreren en kan zo nakijken of de organisatie wel daadwerkelijk past binnen hun criteria.
 
De pagina moet een gebruiksvriendelijke, snelle en zeer intuïtieve interface hebben die het gemakkelijk maakt voor de admin om een organisatie na te kijken en zo snel mogelijk te accepteren of te weigeren. Ook moet de pagina een lijst hebben van de organisaties die actief zijn, zodat men deze de toegang kan ontzeggen in het geval van frauduleuze praktijken. 

---

# Controle Reviews #

Enkel voor de administrator. De administrator kan dankzij deze functionaliteit reviews verwijderen of goedkeuren door middel van het toepassen van regels. Deze functie zorgt ervoor dat een review het imago van de site niet kan beschadigen.

Iedereen kan reviews schrijven over bepaalde onderwerpen/evenementen maar deze moeten allemaal goedgekeurd worden door de administrator. Indien de review niet geschreven werd volgens de regels, zal deze verwijderd worden door de administrator.
 
Om de werklast van de administrator te verminderen, zal gewerkt worden met een puntensysteem. Als een gebruiker drie goede reviews heeft geschreven, zal het niet langer nodig zijn voor de administrator om deze gebruiker zijn reviews goed te keuren. De gebruiker wordt een trusted user. Op deze manier moet de administrator na verloop van tijd veel minder reviews controleren en kan hij enkel nog reageren op geflagde reviews. Met geflagde reviews bedoelen we reviews die gerapporteerd zijn door andere gebruikers.

Deze functionaliteit moet gebruiksvriendelijk en efficiënt zijn opdat het valideren van reviews geen dagen duurt. Een gedeelte van de validatie van de reviews wordt geautomatiseerd. Het programma zal controleren op verboden woorden in de review. Als een verboden woord gevonden wordt, zal er een melding worden gegeven aan de gebruiker en zal de review niet gepubliceerd worden.

---

# Evenementenlijst #

Op deze pagina wordt een overzicht getoond van alle evenementen die er in de komende dagen zullen plaats vinden. Deze lijst bevat de naam van het evenement, de organisator en de plaats, datum en uur van dit evenement.

Zodra de student op één van de evenementen klikt, wordt de pagina geopend die de poster en meer informatie laat zien over het evenement. Ook staat hier de Facebook link naar het evenement als deze bestaat. Deze link moet door de gebruiker zelf ingevuld worden. Als de student is aangemeld op de website, dan zal hij onderaan de pagina een lijst zien van vrienden die reeds hebben gemeld dat ze aanwezig zullen zijn.

De student heeft dan de mogelijkheid om aan te geven of hij ook gaat of niet.
Vanaf de informatiepagina van het evenement heeft de student altijd de mogelijkheid om terug te keren naar de pagina die de lijst toont van alle evenementen.

---

# Filteringsysteem #

Dit systeem dient om de gebruikers de mogelijkheid te geven om zelf te bepalen welk type events ze willen zien op de website.

Een gebruiker kan via de opties van zijn persoonlijk profiel instellen aan de hand van checkboxes/radiobuttons en drop down menu’s welke events hij wilt weergeven.

Mogelijke categorieën:

* Fuiven
* Sport
* Cultuur

Nadat de gebruiker zijn persoonlijke keuzes gemaakt heeft afhankelijk van deze criteria zal de website enkel deze events weergeven.

Op deze manier krijgt de gebruiker een beknoptere lijst van events waarvoor hij interesse heeft en vergroot dit het potentieel dat hij ook aanwezig zal zijn op bepaalde events.

---

# Hoofdpagina #

## Beschrijving ##
Het eerste wat de bezoekers zullen zien is de hoofdpagina. De hoofdpagina moet er dus aantrekkelijk uitzien. Zo nodigen we de bezoekers uit om de website verder te verkennen. Verder moet de hoofdpagina uitstralen waar de web applicatie voor dient. De bezoekers moeten in één oogwenk kunnen zien wat ze kunnen verwachten van de website. De structuur en opbouw van de website moet dus in kaart worden gebracht op de hoofdpagina. Dit kan met een voorwoord, een navigatie menu, links naar de verschillende secties, thumbnails enzovoort.

## Newsfeed ##
Het stuurprogramma zal actief zijn op Twitter en Facebook. Hier zullen zij nieuwtjes posten en campagnes voeren. De integratie met de sociale media is dus zeer belangrijk voor de web applicatie. Om deze integratie verder door te voeren zullen we een dynamische newsfeed creëren voor de hoofdpagina. Deze newsfeed zal de berichten op Twitter en Facebook op een overzichtelijke wijze tonen aan de bezoeker. Verder kan de hoofdpagina enkele blokelementen bevatten die de gebruiker uitnodigen om ook op de andere pagina's van de web applicatie te kijken. Het belangrijkste is de evenementen lijst. 

Via de evenementen lijst kunnen we de website als vaste waarde vestigen in het Hasseltse/Diepenbeekse nachtleven. Verder maakt een eventementen lijst het mogelijk om het uitgaansleven in kaart te brengen voor de stuurgroep. De evenementen lijst zal dus uitgebreid aangekondigd worden op de hoofdpagina. We kunnen werken met de blok lay-out van Windows 8. Dit geeft een moderne en aantrekkelijke look en nodigt de bezoeker uit om verder te kijken.

![](https://dl.dropboxusercontent.com/u/100598706/PXL/AppDev_Project/project_voorbeeld.png)

---

# Statistiekenpagina #

Deze pagina is alleen voor de administrator.
 
Hier zal de administrator de statistieken van alle events en gebruikers kunnen zien. Eerst zal de admin een lijst krijgen met alle evenementen waar hij door kan scrollen. Er zal ook een zoekfunctie aanwezig zijn. Wanneer hij op een event klikt komen de statistieken tevoorschijn. Zo kan de admin gemakkelijk van event wisselen. Hier zal ook een printknop en e-mailknop voorzien zijn zodat hij deze gemakkelijk kan printen en doormailen indien nodig. De statistieken omvangen bijvoorbeeld:

* Hoeveelheid mannen en vrouwen
* Welke leeftijdsgroepen
* Hoeveel mensen er hebben afgewezen
* De rating van een event
* Hoeveelheid reviews
* Aantal views
* ...

---

# Vervoerssysteem #

Wanneer een persoon zich als aanwezig heeft opgegeven voor een bepaald evenement kan een student zich opgeven als BOB of zoeken naar een BOB voor dat evenement.

Op deze pagina zal een lijst tevoorschijn komen van alle BOB’s waar nog plaatsen beschikbaar zijn. Wanneer een student op een van deze BOB’s klikt, zal hij meer informatie krijgen over deze persoon en daarna kan deze student zijn aanwezigheid bevestigen. Er zal een email worden gestuurd naar de BOB om hem te informeren dat er een persoon zich aangeboden heeft. De BOB Kan hierop beslissen of hij de desbetreffende persoon wilt mee nemen of niet via een eenvoudige knop. Wanneer de student opgenomen is bij de geselecteerde BOB kan deze persoon zichzelf terugvinden bij deze geselecteerde BOB groep.

Na afloop van het event kan een gebruiker een bepaalde BOB een rating geven. Hiervoor moet de gebruiker echter wel ingeschreven zijn geweest op de vervoerslijst van deze BOB. Ook is het mogelijk om een review te schrijven over deze BOB. Dit reviewsysteem zal hetzelfde werken als het systeem beschreven in ControleReviews.md.

Daarnaast zal er een optie zijn voor de persoon om zichzelf aan te bieden als BOB. Hierdoor zal er een nieuwe pagina verschijnen waarbij deze persoon enkele voorwaarden moet accepteren en invoeren hoeveel personen de student kan meenemen. Daarna kan hij alles opslaan en komt deze persoon in de lijst te staan met beschikbare BOB’s.

Deze pagina zal op een gebruiksvriendelijke manier worden gepresenteerd. Dit systeem zal op een snelle en makkelijke manier moeten functioneren, opdat de studenten niet te veel hoeven te klikken of overbodige gegevens moeten invoeren. Er ligt een grote verantwoordelijkheid op deze pagina, omdat iedereen die gebruik zal maken van dit systeem de regels zal moeten naleven. Omdat er bepaalde regels nageleefd moeten worden, zullen er voorwaarden opgesteld worden die de persoon moet accepteren voor deelname. Dit zal ervoor zorgen dat er minder klachten zullen binnenkomen bij misbruik van het systeem.
#Use cases
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
3. Deze veranderingen worden opgeslagen in de database

## Alternatieve flow

Geen alternatief

## Uitzonderingen

**1E1.** De database is niet beschikbaar, het systeem geeft een foutmelding

## Inclusief

Geen

---

# Use Case ID: UC07

**Actoren**: Gebruiker  
**Trigger**: Weergave van een event

## Omschrijving

Bij de selectie van een evenement kan de gebruiker zien welke gemeenschappelijke vrienden naar dat evenement gaan.

## Precondities

1. De gebruiker is ingelogd

## Postcondities

1. De gebruiker ziet welke gemeenschappelijke vrienden naar een bepaald evenement gaan

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

# Woordenlijst
# Woordenlijst

* administrator: **gebruiker die het programma beheert.**
* evenementen: **een activiteit die wordt ingevoerd door een organisatie.**
* foutmelding: **een boodschap die wordt getoond als er iets mis is gegaan.**
* organisator: **een soort gebruiker die evenementen kan aanmaken.**
* pagina: **een sectie van de website.**
* database: **een verzameling van alle gegevens.**
* cloud: **online platform voor gegevens op te slaan en te bewerken.**
* webapplicatie: **een programma via het internet.**

We hebben gemerkt dat we Engelse en Nederlandse woorden door elkaar gebruiken. Deze woordenlijst moet ervoor zorgen dat we weten wanneer we welk woord moeten gebruiken. Verder bevat de woordenlijst enkele definities. Dit om de klant extra uitleg te geven over de gebruikte termen.