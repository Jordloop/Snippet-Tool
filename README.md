# Code Snippet Database

#### Team Week project for C Sharp

#### **By Adrian Agnic, John Dowd, Andrew Glines, and Jordan Loop for Epicodus**

## Description

* This application will allow a user to store and retrieve snippets of code from a database.
* The user will be able to create a new user account.
* The user will be able to log in with a username and password.
* The user will be able to enter code into a text entry box.
* The user will be able to assign tags to any snippet of code.
* The user will be able to search for code matching any specified, previously entered tag.
* The user will be able to search for code containing any string of text.
* The user will be able to view all saved snippets.



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

# Database Creation
 To create  the production database enter the following commands in sqlcmd:
  * CREATE DATABASE snippet_tool;<br>
  GO
  * USE snippet_tool;<br>
  GO
  * CREATE TABLE end_users (id int IDENTITY(1,1), name varchar(255), password varchar(255));<br>
  GO
  * CREATE TABLE join_end_users_snippets(id int IDENTITY(1,1), id_snippet int, id_end_user int);<br>
  GO
  * CREATE TABLE join_end_users_tags(id int IDENTITY(1,1), id_end_user int, id_tag int);<br>
  GO
  * CREATE TABLE (join_favorites(id int IDENTITY(1,1),	id_tag int,	id_end_user int);<br>
  GO
  * CREATE TABLE join_snippets_tags(id int IDENTITY(1,1), id_snippet int, id_tag int);<br>
  GO
  * CREATE TABLE snippets(id int IDENTITY(1,1), description varchar(255), text varchar(max), time datetime);<br>
  GO
  * CREATE TABLE tags(id int IDENTITY(1,1),	text varchar(255));<br>
  GO

 To create  the test database enter the following commands in sqlcmd:
  * CREATE DATABASE snippet_tool;<br>
  GO<br>
  * USE snippet_tool;<br>
  GO<br>
  * CREATE TABLE end_users (id int IDENTITY(1,1), name varchar(255), password varchar(255));<br>
  GO<br>
  * CREATE TABLE join_end_users_snippets(id int IDENTITY(1,1), id_snippet int, id_end_user int);<br>
  GO<br>
  * CREATE TABLE join_end_users_tags(id int IDENTITY(1,1), id_end_user int, id_tag int);<br>
  GO<br>
  * CREATE TABLE (join_favorites(id int IDENTITY(1,1),	id_tag int,	id_end_user int);<br>
  GO<br>
  * CREATE TABLE join_snippets_tags(id int IDENTITY(1,1), id_snippet int, id_tag int);<br>
  GO<br>
  * CREATE TABLE snippets(id int IDENTITY(1,1), description varchar(255), text varchar(max), time datetime);<br>
  GO<br>
  * CREATE TABLE tags(id int IDENTITY(1,1),	text varchar(255));<br>
  GO


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

Copyright (c) 2017 Adrian Agnic, John Dowd, Andrew Glines, Jordan Loop, Epicodus#
