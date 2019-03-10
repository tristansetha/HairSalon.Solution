# Hair Salon

By Tristan Setha 03/01/19

## Description
A website that lets users add stylists, specialties and clients into a database. Users can edit, delete, and organize data within the the website.

## Setup/Installation Requirements

<br/>To Clone:
<br/>Download .NET Core 1.1.4 SDK and .NET Core Runtime 1.1.2 and install them. Download Mono and install it.
<br/>Open terminal and $ cd into preferred destination of clone
<br/>Run the command:
```
$ git clone https://github.com/tristansetha/HairSalon.Solution
```
<br/>Navigate into the HairSalon directory
```
$ cd HairSalon.Solution
```
<br/>To edit: open entire dot solutions director in preffered text editor

<br/>To Run:
<br/>Download tristan_setha zip file
<br/>Download and install MAMP: //Link top mamp website download
<br/>Open mamp and Start Servers
<br/>Click on Open WebStart page
<br/>Click on 'tools' at the top menu bar then click on PHPMYADMIN
<br/>Click on databases, click on import, then select and import tristan_setha.zip
<br/>In command prompt or terminal
<br/>Navigate into HairSalon.Solution directory: 
```
$ cd HairSalon.Solution
```
<br/>Navigate into HairSalon directory: 
```
$ cd HairSalon
```
<br/>while in the HairSalon directory use the commands:
```
$ dotnet restore
$ dotnet run
```
<br/>Open the path from "Now listening on: http://localhost:5000 in your favorite web browser

<br/>To run tests:
<br/>Open mamp and Start Servers
<br/>Click on Open WebStart page
<br/>Click on 'tools' at the top menu bar then click on PHPMYADMIN
<br/>Click on databases, click on import, then select and import tristan_setha_test.zip
<br/>Navigate into HairSalon.Tests
<br/>use the command:
```
$ dotnet restore
```
<br/>then run the command:
```
$ dotnet test
```


## Specs

|   Behavior                          | Input Example | Output Example |
| ------------------------------------|:-------------:| :-------------:|
|  user clicks to Add new Stylist | click link  | stylist form |
|  user enters stylist form with name and details  | Name: "Scott" Details: "Great stylist"  | list of stylists|
|  user clicks on a stylist is sent to client form | click stylist link | list of clients, add new client link |
|  user clicks to add new client, and is sent to client form | click add new client | client form |
|  User enters enters in client name and submits   | client name: "Amy" |  redirected to client list and add new client link  |


## Technologies Used

C#, .NetCore 1.1, Mamp, MyPhpAdmin, MySql, HTML, Git, Visual Studio code

ask me anything!!! tristansetha@gmail.com

MIT

Copyright (c) 2019 Tristan Setha
