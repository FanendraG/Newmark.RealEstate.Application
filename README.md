# NewMarkAssignment
Newmark Technical Assignement

Newmark Technical: Senior IC/Principal /Engineer 
Objective: Test will assess your ability to: 
1. Integrate with Azure Blob Storage using C# to retrieve JSON data. 
2. Transform the JSON data into a structured C# model. 
3. Expose an API endpoint that returns the transformed model. 
4. Display the data using a React app/Angular with a parent-child structure. 

## Instructions 
### Azure Blob Storage Integration 
#### Blob Storage Information:
````
Blob URL: https://nmrkpidev.blob.core.windows.net/dev-test/dev-test.json 
SAS Token: ?sp=r&st=2024-10-28T10:35:48Z&se=2025-10-28T18:35:48Z&spr=https&sv=2022-11-02&sr=b&sig=bdeoPWtefikVgUGFCUs4ihsl22ZhQGu4%2B4cAfoMwd4k%3D
````
### Task: Use C# to connect to Azure Blob Storage, incorporating the SAS token to authenticate and access the JSON file. 
## 1. File Structure: The JSON file is structured as follows, with properties containing nested data: 
    Property objects contain lists of Spaces, and each Space has a RentRoll. 
    Each Property also includes fields for Features, Highlights, and Transportation. 

## 
## 2. Transform JSON Data to C# Model 
• Task: Convert the JSON data into a C# model with classes representing Property, 
Space, RentRoll, and any other necessary entities. 

## 3. Create a C# API Endpoint 
### Task: Develop an API endpoint (e.g., /api/properties) that: 
1. Uses the provided Blob URL and SAS token to retrieve the JSON data. 
2. Deserializes the data into the C# model. 
3. Returns the structured data as a JSON response. 
#### Requirements: 
1. Ensure the endpoint can handle errors, such as missing files or invalid token scenarios. 
2. Handle large datasets efficiently (e.g., with async/await). 


## 4. React Application with Parent-Child Display 
 #### Task: Build a React app/ React app/Angular that: 
    1. Calls the C# API endpoint. 
    2. Displays the hierarchical data in a parent-child format: 
       Property -> Spaces -> RentRoll 
       Display additional fields under Property, such as Features, Highlights, and Transportation. 
# UI Example: 
````
 Property One 
 | Features: 24/7 Security, Fitness Center, etc. 
 |  Highlights: Downtown location, LEED certification 
 | Transportation: Green Line (0.5 miles), Route 15 (0.2 miles) 
 | Spaces: 
        | Space A 
            |  January: $1000 
            | February: $1000 
        | Space B 
            | January: $1200 
            | February: $1300 

Stretch Goal: Implement collapsible sections for Property and Space data.
````
Deliverables 
1. C# solution code for Blob Storage integration, data transformation, and API endpoint. 
2. React app code that fetches data from the API and displays it as outlined. 
3. Documentation on setup steps, assumptions, and any handling of the SAS token. 

Evaluation Criteria 
1. Successful integration with Azure Blob Storage. 
2. Clear, maintainable C# code following best practices. 
3. Efficient handling of the hierarchical data structure. 
4. Usable and clear React/Angular display. 
5. Robust error handling in both C# and React components. 

##### Please let us know if you have any questions. Good luck! 
