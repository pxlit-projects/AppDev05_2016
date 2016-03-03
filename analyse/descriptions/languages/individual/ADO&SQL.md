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