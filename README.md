# Code Snippet Database

#### Team Week project for C Sharp

#### **By Adrian Agnic, John Dowd, Andrew Glines, and Jordan Loop for Epicodus**

## Description

This application will allow a user to store and retrieve snippets of code from a database.
The user will be able to enter code into a text entry box.
The user will be able to assign tags to any snippet of code.
The user will be able to log in using their own password.

The user will be able to search for code matching any specified, previously entered tag.
The user will be able to search for code containing any string of text.



## Behavior and Inputs

|  behavior | input  | output  |
|---|---|---|
| User enters text data into a text box | User clicks Save | Message displays "Code [N] saved to database." |
| User enters text data and a tag into two text boxes | User clicks Save | Message displays "Code [N] and tag [J] saved to database." |
| User enters text data and tags | User clicks Save | Data saved with code text, tag, and timestamp |
| User enters text data and tags | User clicks Save | Image of code text is saved |

| User searches for code matching a tag ("N") from a dropdown list of all tags | Dropdown tag chosen, user clicks "Find Tag" | All code snippets matching tag "N" are displayed |
| User searches for code matching entered text | User types "xyz" and clicks "Find Text" | All code snippets matching "xyz" are displayed |


## Setup/Installation Requirements
# Github

Go to Github repository page at https://github.com/Jordloop/Snippet-Tool.git
Click the "download or clone" button and copy the link.
In your computer's terminal type "git clone" and paste the copied link.

#Database
Open SSMS ; select File > Open > File and select the "snippet_tool.sql" file included with the Github download.  If the database "snippet_tool" does not already exist, add the following lines to the top of the script file:
\> CREATE DATABASE snippet_tool
\> GO
Save the file with the added lines.
Click Execute.


Once downloaded you can open the root html file in the browser of your choice.
You can view the code using the text editor of your choice as well.

## Known Bugs

* No known bugs

## Support and contact details

If you have any issues or have questions, ideas, concerns, or contributions please contact any of the contributors through Github.

## Technologies Used

* HTML
* CSS
* Bootstrap
* JSON
* Nancy
* Razor
* xUnit
* C#
* SQL

### License
This software is licensed under the MIT license.

Copyright (c) 2017 Andrew Glines, Epicodus# Code Snippet Database


![alt text][views]
[views]: img/ViewsFlowchart.PNG "Views Flowchart"
