# Hair Salon

By Tristan Setha 03/01/19

## Description
A website that lets users add stylists, specialties and clients into a database. Users can edit, delete, and organize data within the website.

## Setup/Installation Requirements

### To Clone:
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
### To edit: 
<br/>open entire dot solutions director in preffered text editor

### Setup:
<br/>Download and install MAMP: https://www.mamp.info/en/downloads
<br/>Open mamp, click preferences, select ports tab, Set the Apache Port to 8888, the MySQL Port to 8889, then click OK.
<br/>Start servers
<br/>Click on Open WebStart page
<br/>Click on 'tools' at the top menu bar then click on PHPMYADMIN
<br/>Click on databases, click on import, in the HairSalon.Solution's folder select and import tristan_setha.sql, then inport tristan_setha_test.sql.
<br/>In command prompt or terminal, Navigate into HairSalon.Solution folder: 
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

### To run tests:
<br/>Open mamp and Start Servers
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
| User clicks 'View stylists, Add stylist or Add client' button | click button | redirects to stylists home page |
| User clicks add new stylist | click button | add a stylist form |
| User clicks 'clear all stylist' | click button | all stylists clear |
| User adds a new stylist | Stylist 'name' and 'details' submit | Add a new client button appears |
| User clicks on stylist | Click 'stylist' | stylist profile | 
| User clicks edit stylist | Click edit button | Edit stylist form |
| User adds a client to stylist | select client and add client | client appears in stylist profile|
| User adds a specialty to stylist | select specialty and add specialty | specialty appears in stylist profile |


## Technologies Used

C#, .NetCore 1.1, Mamp, MyPhpAdmin, MySql, HTML, Git, Visual Studio code

ask me anything!!! tristansetha@gmail.com

MIT

Copyright (c) 2019 Tristan Setha
