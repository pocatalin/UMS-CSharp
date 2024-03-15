![Annotation 2024-03-15 225252](https://github.com/pocatalin/UMS-CCharp/assets/32682232/2678f514-e8aa-4f9c-b8e5-5d76b30d2db0)This is a University Management System(UMS) that i created using Winforms .NET Technology in tandem with an MS SQL SERVER Database.This app has 3 different roles that i will display later.
The login has the function to check the credentials and what case to open,may it be the student,admin,or professor, it also has a use case to change the password on the spot.
![Annotation 2024-03-15 224940](https://github.com/pocatalin/UMS-CCharp/assets/32682232/14c0d838-da9d-4f44-8ff7-52217ce254ae)
![Annotation 2024-03-15 224956](https://github.com/pocatalin/UMS-CCharp/assets/32682232/515dfda5-cb2b-4a6a-842b-946836b4df72)
This is the student use form where a student can only see their grades,attendances and personal info,when clicking a button there will be a dynamically generated list of buttons depending on the courses that a student takes,and each buttons displaying the relevant data.
![Annotation 2024-03-15 225035](https://github.com/pocatalin/UMS-CCharp/assets/32682232/14558efa-00d6-4d55-a92e-28ed2d29aaa8)
![Annotation 2024-03-15 225057](https://github.com/pocatalin/UMS-CCharp/assets/32682232/07baccb3-47a1-4e63-9e1b-80bdbe0e2d5d)
![Annotation 2024-03-15 225120](https://github.com/pocatalin/UMS-CCharp/assets/32682232/12b92a30-b22f-462f-9bc9-724fef975df5)
![Annotation 2024-03-15 225208](https://github.com/pocatalin/UMS-CCharp/assets/32682232/b9793bb4-024b-4cb0-8f21-8e1de471613e)
This is the the professor form where a teacher has 3 buttons,one for grades,that has one combo box containing 2 options,one is to add a grade where the professor selects where he would like to a add a grade to ,then he would need to pick a student from a list(only those who attend the previously selected course) then he could add their marks(or only one mark) the date being added to the database ,and the other option is to view the grades for a course that the teaches.
The Attendance button has the same functionality as the Grade ,but it only asks to pick a course and the professor will only need to insert the ids of the students.
![Annotation 2024-03-15 225252](https://github.com/pocatalin/UMS-CCharp/assets/32682232/96dbee67
![Annotation 2024-03-15 225309](https://github.com/pocatalin/UMS-CCharp/assets/32682232/8b397d44-5865-49b1-a9dc-2b6209c79dd9)
-cc45-465d-8f62-af8252da278c)
![Annotation 2024-03-15 225336](https://github.com/pocatalin/UMS-CCharp/assets/32682232/909e6984-a87b-42fe-829e-41ba4cab7d75)
![Annotation 2024-03-15 225406](https://github.com/pocatalin/UMS-CCharp/assets/32682232/bf156cd9-adb2-493a-a88b-6a8f6b322c28)
![Annotation 2024-03-15 225425](https://github.com/pocatalin/UMS-CCharp/assets/32682232/9db98770-86c3-45be-bdfa-b13f49c1323d)
This what happens when the Personal Information button,this is to make it more secure.
![Annotation 2024-03-15 225442](https://github.com/pocatalin/UMS-CCharp/assets/32682232/50a19d8b-9ee8-4da6-9262-3d1ea423845c)
So the last is the admin form ,here the admin can manage all the data,the buttons to add are all self explanatory .The Refresh button will refresh all the tables,the edit will take one row ,it doest matthew what take,it will take that data and make a dynamic pop up that has all the columns and the data ,a table can have fewer columns than other tables so i made it dynamic.The Save Changes will save all the data to the database,only the current table,and the remove will delete it only in the app,only after saving the changes the row will be deleted from the database.
![Uploading Annotation 2024-03-15 225533.png…]()


