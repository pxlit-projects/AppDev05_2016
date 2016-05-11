# AppDev05_2016

## groepsleden

- Kevin Strijbos
- Bram Van Vleymen
- Joran Claessens
- Frédérique Van Wonterghem
- Sacha Reyskens

## omschrijving

- analyse: de analysedocumenten
- design: mock-ups van de uiteindelijke lay-out
- docs: algemene documenten 
- planning: de planning om het werk te verdelen
- scrum: de scrumverslagen
- source: bevat de source code

## webapp-stufv
In deze solution bevindt zich de website zelf, inclusief de web api. Dit project wordt gepublished naar de cloud
door middel van Azure. De website is geschreven in asp.net mvc.

## desktopapp-stufv
De desktop app zit in deze solution. Deze app gebruikt de web api in de cloud (root/api/controller) om de database aan te spreken.

## Web API
De web API bevindt zich in het project "webapp-stufv". De controllers zitten in de map "web_api_controllers". 
De web API kan aangesproken worden met de url "root/api/controller". JSON wordt gebruikt voor de data te ontvangen en versturen.
