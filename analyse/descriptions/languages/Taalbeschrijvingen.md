# ADO .Net #

## Omschrijving ##
.Net is een taal gecreëerd door Microsoft om het ontwikkelen op een Windows platform eenvoudiger te maken. Gaandeweg is de taal uitgebreid naar andere platformen. ADO .net is het gedeelte van deze taal dat zich focust op de databanken van een (web)-applicatie. Zo kan je met diverse databanken werken via ADO .Net om de gegevens te gebruiken in je applicatie zelf. ADO .Net is eigenlijk dus een standaard interface voor data access. 

* .Net Framework
* ADO .Net voor zowel web- als gewone applicaties. 
* Bruikbaar met de talrijke soorten van databanken
* Stelt gebruiker in staat met willekeurige databanken te communiceren

## Objecten ## 
**Connection** : maakt het contact met een gegevensbron.

**Command** : maakt commando's en query's naar een gegevensbron.

**DataReader** : leest stromen van tekst uit de gegevensbron.

**DataSet** : een dataset is een verzameling van DataTable-objecten. Deze DataTable-objecten kunnen onderling gelinkt zijn met DataRelation-objecten. Een Dataset wordt ook dikwijls omschreven als een 'offline' weergave van een database.

**DataTable** : een tabel in het geheugen zoals deze op een database zou voorkomen met rijen en kolommen. Als de gegevens worden geraadpleegd van een DataTable wordt er automatisch een standaard DataView opgeroepen.

**DataView** : maakt het mogelijk om in een DataTable te sorteren en filteren.

**DataAdapter** : zorgt voor een vertaling van verzoeken vanuit de ADO.NET-laag naar de database en omgekeerd.

## Ons project ##
Wij zullen de ADO .Net gebruiken op onze (web)-applicatie te verbinden met onze databank, en zo een gegevensstroom creëren waarmee we gegevens kunnen opslaan en ook gegevens kunnen vertonen op onze website/applicatie. Als IDE gebruiken we Visual Studio 2015 Community version.

# SQL #

## Omschrijving ##
SQL oftewel Structured Query Language is een taal voor een relationeel databasemanagementsysteem. Door middel van deze taal kunnen we praten met onze database en gegevens toevoegen, opvragen, bewerken of verwijderen. 

* Structured Query Language
* Gebruikt om met database te communiceren voor gegevens flow
* Werking met ADO .Net framework

## Ons project ##
We gebruiken SQL in ons project om met onze database aan gegevensuitwisseling te doen. We gebruiken hierbij ook het ADO .Net framework om de databank te connecteren aan onze applicatie zelf.


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


# Facebook API #

## Omschrijving ##
Met het Facebook API is het mogelijk om data van Facebook te kunnen verkrijgen, deze informatie krijgen we binnen via JSON, het is daarna mogelijk om deze data te gebruiken in JavaScript om applicaties rond Facebook uit te bouwen.
Met de juiste authorisation key is het mogelijk om data te verkrijgen door middel van volgende link: https://graph.facebook.com/<name>.

Op de plaats van <name> dient met een objectnaam in te vullen.
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
Data manipulatie: https://graph.facebook.com/<name>
Facebook for Developers: https://developers.facebook.com/


# HTML5 #

## Omschrijving ##
HTML5 (HyperText Markup Language 5) is de laatste versie van de HTML-standaard. HTML5 zorgt ervoor dat alle kleine foutjes van zijn voorganger worden verbeterd.

HTML5 introduceert nieuwe tags die ervoor zorgen dat er meer structuur in het document komt zoals &lt;header&gt; om het header-gedeelte aan te duiden , &lt;nav&gt; voor navigatie en &lt;article&gt; om het artikeldeel aan te duiden. Verder komen er tags die het mogelijk maken om interactieve content af te spelen zonder gebruik te maken van een Flash Player-plug-in, zoals de &lt;video&gt;-tag.

HTML5 zorgt er ook voor dat webapplicaties offline beschikbaar kunnen worden, bij het eerste bezoek aan de applicatie download je dan automatisch de benodigde files voor de webapp en dan kun je deze later offline gebruiken. Als je in zo’n offline applicatie dan veranderingen aanbrengt dan worden deze naar de server doorgestuurd op het eerstvolgende moment dat er weer internetverbinding is. Verder is er nu een mogelijkheid om drag and drop te implementeren.

## Ons Project ## 
HTML5 zal voor ons project standaard gebruikt worden om pagina’s op te stellen. Hierbij zullen we ook gebruik maken van de nieuwe tags zoals <header> en <nav>.

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