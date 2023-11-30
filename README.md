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

5. **Image Tapping Component**
The Image Tapping component is utilized to display individual images within the Main Collection component.</br>
It provides a user-friendly interface for viewing and interacting with images in the collection.</br>

# Server-Side (C# .NET 7)
**Prerequisites**
.NET SDK 7 installed [(Download .NET)](https://dotnet.microsoft.com/en-us/download)
**Getting Started**
1. Navigate to the server-side folder
2. Run the application.
3. Open your browser and go to localhost to access the API

**Database**
The application uses a JSON file (DBcollections.json) as a simple database. Ensure it's properly configured and accessible.
   
**Error Handling**
This project includes error-handling middleware that catches exceptions and returns appropriate error responses.
Errors are logged using NLog, and the details can be found in the log files

**Acknowledgments**
NLog - Logging library used for error handling and logging.
Swagger - API documentation and testing tool.

 
