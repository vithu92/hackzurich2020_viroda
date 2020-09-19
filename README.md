# Welcome to our HackZurich2020 project on Github. 

We created a powerful AR mobile app to help a Migros customer make better decisions and get to the available information more easily while browsing goods at the store.

Our system uses image recognition to allow tracking of various goods in 3D space, with that we can show a lot of useful additional data without the need to touch a product and read the small print on the back.

We optimized our system to make the most important information easily available; As soon as the customer points his phone at products we display action buttons that allows him to **view the product's carbon footprint and calories**. Further the capability to suggest relevant further products is available (based on historical purchasing data) as well as suggesting healthier alternative products.

## Technology Stack
- Unity with Vuforia allows a rapid development of an AR app which runs cross platform and offers a large selection of applications. We integrated Vuforia to detect and track the goods of the Migros warehouses and display data next to it in 3D space.
- RStudio is a powerful language for mathematical calculations which we used to create a basket analysis model from a dataset which was provided by Migros with that we were able to find connections between goods which consumers like to buy together and base our recommender system on. We found out that bananas go very well with everything and are universally desired.
- For our information gathering we used the Migros provided REST API to be able to give the consumers fresh information about the products they are looking at. Furthermore alternative healthier products are provided by the EatFit Service. 

## Further Steps
We think that given more time our app could be extend with various good additions:
- Navigation in store to could help the customers find their products better and faster using the store layout provided by Migros.
- Direct comparison between products could help the customer to be more informed about their choices especially with regard to nutritional values and sustainability impact.
- With a text to speech and a translation extenstions the app could help blind and international people to find their way around Migros better.
