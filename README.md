# Photograph System 
# Project Overview
This project is a web-based system for managing and saving photographs delivered to LID Vashem. </br>
It consists of a client-side application developed with Angular and a server-side application built with C# .NET 7. </br>

# Client-Side (Angular)
**Prerequisites**
Node.js and npm installed [(Download Node.js)](https://nodejs.org/en) </br>
Angular CLI installed globally (npm install -g @angular/cli) </br>
**Getting Started**
1. Clone the repository.
2. Install dependencies: npm install
3. Run the development server: ng serve
4. Open your browser and go to http://localhost:4200/ to view the application.

**Components**
1. **Application Component** </br>
The Application component is the entry point of our collection management system.</br>
It contains the Main Collection component, which serves as the central element for managing and displaying collections.</br>

3. **Main Collection Component**
The Main Collection component is responsible for overseeing and presenting details about a specific collection.</br>
It is utilized within the Application component and interacts with the CollectionService. Key functionalities include:</br>

      **Display Information:**</br>
      Shows additional information about the selected collection.</br>
      **Add New Image:**</br>
      Provides options to add a new image to the collection.</br>
      **Delete Last Photo:**</br>
      Allows users to delete the last photo from the collection.</br>
      **Collection Management:**</br>
      Receives the collection data based on a collection number from the client.</br>
      Saves the collection, including all added images.</br>
 **Communication:**
 Communicates with the CollectionService for data interaction.</br>

3. **Display-Collection Component**
The Display-Collection component is used within the Main Collection component to visually represent</br>
the data of a specific collection retrieved from the database.</br>

5. **Image Tab Component**
The Image Tapping component is utilized to display individual images within the Main Collection component.</br>
It provides a user-friendly interface for viewing and interacting with images in the collection.</br>

# Server-Side (C# .NET 7)
**Prerequisites**
.NET SDK 7 installed [(Download .NET)](https://dotnet.microsoft.com/en-us/download)
**Getting Started**
1. Navigate to the server-side folder
2. Run the application.
3. Open your browser and go to localhost to access the API

1. **Data Access Layer (DL)**
Responsibility:</br>
Interacts with the data source, which is a JSON file acting as a database.</br>
Provides methods to retrieve a collection based on a provided collection number.</br>
Saves the collection to the database and creates text files for each image in the collection.</br>

3. **Business Logic Layer (BL)**
Responsibility:</br>
Contains the logic for processing and managing collections.</br>
Communicates with the Data Access Layer to retrieve and save data.</br>

4. **Collection Controller**
Responsibility:</br>
Handles HTTP requests and interacts with the Business Logic Layer.</br>
Contains API endpoints that clients can call to perform operations on collections.</br>
Defines an API endpoint to get a collection based on the provided collection number.</br>
Defines an API endpoint to save a collection to the database.</br>

**GetCollectionName(string collectionNumber)**
Purpose:</br>
Retrieves a collection based on the provided collectionNumber from the database.</br>
1. Input: Accepts a collectionNumber as a parameter.</br>
2. Data Retrieval: Utilizes the Data Access Layer to fetch the corresponding collection from the database (JSON file in this case).</br>
3 . Processing: Processes the retrieved data if additional business logic is required.</br>
4. Output: Returns a Task<Collection> representing the asynchronous operation to get the collection. </br>
Clients (such as the Angular front-end) can call this function to obtain details about a specific collection.</br>

**SaveCollection(Collection collectionData**);
Purpose: Saves a collection to the database, and for each image in the collection, it generates a text file with image information.</br>
1. Input: Accepts a collectionData object representing the collection to be saved.</br>
2. Data Saving: Uses the Data Access Layer to persist the collection data in the database (JSON file).</br>
3. Text File Generation: Iterates through each image in the collection.</br>
4. Create a text file for each image with relevant information (e.g., image path, metadata).</br>
5. Output: Completes the saving process without returning any specific result</br>
Clients invoke this function to store a new collection in the system, including associated images.</br>

6. Entities
Responsibility:
Defines the structure of data entities used in the application, specifically the Collection entity.
The Collection entity represents the data structure of a collection.

**Database**
The application uses a JSON file (DBcollections.json) as a simple database. Ensure it's properly configured and accessible.
   
**Error Handling**
This project includes error-handling middleware that catches exceptions and returns appropriate error responses.
Errors are logged using NLog, and the details can be found in the log files

**Acknowledgments**
NLog - Logging library used for error handling and logging.
Swagger - API documentation and testing tool.

 
