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