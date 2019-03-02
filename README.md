# Hair Salon

By Tristan Setha 03/01/19

## Description

## Setup/Installation Requirements

<br/>Cloning:
<br/>Download .NET Core 1.1.4 SDK and .NET Core Runtime 1.1.2 and install them. Download Mono and install it.
<br/>Open terminal and $ cd into preferred destination of clone
<br/>Run the command $ git clone https://github.com/tristansetha/HairSalon.Solution
<br/>$ cd into HairSalon.Solution
<br/>To edit: open in preffered text editor

<br/>Running:
<br/>Download tristan_setha zip file
<br/>Download and install MAMP: //Link top mamp website download
<br/>Open mamp and Start Servers
<br/>Click on Open WebStart page
<br/>Click on 'tools' at the top menu bar then click on PHPMYADMIN
<br/>Click on databases, click on import, then select and import tristan_setha.zip

<br/>In command prompt or terminal
<br/>Navigate into HairSalon.Solution directory: $ cd HairSalonSolution
<br/>Navigate into HairSalon directory: $ cd HairSalon
<br/>while in the HairSalon directory use the commands:
<br/>$ dotnet restore
<br/>$ dotnet run
<br/>Open the path from "Now listening on: http://localhost:5000 in your favorite web browser

<br/>To run tests:
<br/>Run tests:
Mode    <br/>
<br/>use the command $ dotnet test


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
