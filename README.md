# Dr. Sneuss' Factory

#### C# .Net Core MVC Application, 08/07/2020

#### By **Evgeniya Chernaya**

## Description

This web application creates and manipulate data about engineers, machines, locations and incidents in database of Dr. Sneuss' Factory.

## Setup/Installation Requirements

* Click the green "Clone or download" button at the right of the screen.

* Select "Download ZIP."

* Use a file extractor or unzip program (such as PeaZip, Unzipper, WinZip, Zipware, or 7-ZIP) to extract the ZIP files onto your computer.

* In your browser, navigate to https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-2.2.106-macos-x64-installer for Mac or https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-2.2.203-windows-x64-installer for Windows and click the link "click here to download manually" if the download for .NET Core 2.2 SDK does not start automatically.

* Double-click the downloaded .NET Core 2.2 SDK file and run the installer.

* Open your computer's terminal and navigate to the directory bearing the name of the program and containing the top level subdirectories and files.

### MySQL Setup

* Install MySQLWorkbench on your computer 

* Navigate to the Factory folder in your terminal.

* Enter the command "dotnet restore" in the terminal.

* Enter the command "dotnet build" in the terminal.

* Command: dotnet ef database update (this command will create *evgeniya_chernaya* database in MySQLWorkbench).

* Enter the command "dotnet run" in the terminal.

* Open http://localhost:5000 in your web browser to access the application


## Known Bugs

_No known bugs_

## Technologies Used

  * C# .Net Core MVC
  * Entity Framework
  * Visual Studio Code
  * MySQL Workbench

### License

_This software is licensed under the MIT license_

Copyright (c) 2020 **Evgeniya Chernaya**.