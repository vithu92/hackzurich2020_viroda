# HackZurich2020

## Welcome to our HackZurich2020 project on Github. 

We created a power full AR mobile app to help a Migros customer to make better decision and get information more easily when browsing goods at the store.

Our system uses image recognition to allow tracking of various goods in 3D space with that we can show a lot of useful additional data without the need to touch a product and read the small prints on the back.

We optimized our system to make the most important information instantly available; As soon as the customer points his phone at products we display him the carbon food print and calories. Further we offer recommendations for fitting products which are often bought together and recipes which can be made with the ingredients.

## Technology Stack
- Unity with Vuforia
  Unity with Vuforia allows a rapid development of an AR app which runs  cross platform and offers a large selection of applications. We integrated Vuforia to detect and track the goods of the Migros warehouses and display data next to it in 3D space.
- RStudio
  R is a powerful language for mathematical calculations which we used to create a basket analysis model from a dataset which was provided by Migros with that we were able to find connections between goods which consumer like to buy together and base our recommender system on. We found out that bananas go very well with everything and are collectively desired.
- Migros REST API
  For our information gathering we used the form Migros provided REST API to be able to give the consumers fresh information about the products they are looking at. 

## Further Steps
We think that given more time our app could be extend with various good additions:
- Navigation in store to help customers find their products better and faster using the store layout provided by Migros.
- Direct comparison between products informing the customer about nutritional values and sustainability impact.
