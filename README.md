# WinForm-Firebase-Send-ReceiveData
The project is created on Windows Forms Apps (.NET Framework) in Visual Studio.  

# CONNECTING TO FIREBASE  
•	Firstly created a project in firebase as a firebase real-time Database.  
•	Imported the libraries FireSharp.Config, FireSharp.Interfaces, and FireSharp.Response.  
•	Then, created a Firebase configuration in which added the AuthSecret which is the database authentication token using a legacy Firebase token generator.  
•	The basePath is the location of the Firebase Real-time Database.  
•	Instantiation is created for establishing the connection between firebase and C#.  

# RETRIEVING THE DATA IF IT EXISTS IN FIREBASE DATA  
•	An event handler button_click is created when the user clicks the “Update” button.  
•	This event retrieves data from the firebase if it is existing and then updates it.  
•	GetTaskAsync: Method for asynchronously retrieving the data specified.  

# UPDATING THE NEW DATA TO THE EXISTING FIREBASE DATA  
•	This part of the code updates the points if the user’s phone number exists in the firebase database.  
•	The points retrieved from the database are then stored in a variable which then is added with new points scored.  
•	Then it sends the total points back again to the firebase database, which performs the update function.  
•	UpdateTaskAsync: Method for asynchronously updating the data specified.  

# ADDING THE NEW DATA TO THE FIREBASE DATA  
•	This part of the code adds the new data to the firebase i.e. which does not exist in the firebase database.  
•	SetTaskAsync: Method for asynchronously writing or replacing data to a defined path.  

<img src="https://github.com/SidraShaikh-2/WinForm-Firebase-Send-ReceiveData/assets/57295469/14001aa9-5e0e-4ef7-9c86-3d0a77a8cabc" width="200">


