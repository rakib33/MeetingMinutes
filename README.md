# Meeting Minutes
This is simple asp.net core mvc app for meeting minutes.

## Task Details: 

- First Part:
  
According given UI Customer Name will be loaded in drop down list based on radio button selection “Corporate” and “Individual”. Corporate Customer will be loaded from Database Table named ’Corporate_Customer_Tbl’ and Individual Customer will be loaded from Database Table named ‘Individual_Customer_Tbl’. 
Date will be selected from bootstrap calendar, Time will be 12 Hours Format such as 9:10 AM, 3:20 PM.
 
- Second Part:
  
Select Product/Service dropdown list will be loaded from a Database Table named ‘Products_Service_Tbl’, unit will be loaded based on Selected Product/Service option in read only textbox, Quantity(input only numeric value. 
‘Add’ button will add these data to below bootstrap table. Any number of rows can be added to this table. Added  rows can be edited or deleted.
 
- Third Part:
 
‘Save’ button will save First Part data in table ‘Meeting_Minutes_Master_Tbl’ using stored procedure ‘Meeting_Minutes_Master_Save_SP’ and 
Second Part data in table‘Meeting_Minutes_Details_Tbl’ using stored procedure ‘Meeting_Minutes _Details_Save_SP’.
 
- Guide Line:
  
Use ASP.Net, HTML, Bootstrap, and JQuery as client side programming language, C #as Server side programming language and MS SQL Server as database.



## Front-end UI

<img width="1138" height="627" alt="image" src="https://github.com/user-attachments/assets/0ed9b0dc-5820-4d66-883f-47a8e00881cd" />

