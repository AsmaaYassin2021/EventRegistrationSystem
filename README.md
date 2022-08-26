# EventRegistrationSystem
  1-Using Net Core 3.1
2- Entity framework code first, the project is EventReg.Data
so using Package console manager we need to run add-migration EventDB-v1 then UpdateDatabase
How do we extend the data model? We need to create a new class inherits from the Event 
class and create the interface of that class and modify OnModelCreating method " I did an 
example for that""
3-For running API 
from IIS express , there is a swagger UI for all APIs ==>https://localhost:44357/swagger
3.1- For running Admin API
a- run /api/Admin/authentication using this body to generate token to use for running Admin 
APIs
{
 "userName": "Admin",
 "password": "Admin12345"
}
b- Click on authorize button then write Bearer +generated token 
c- then running any API
4- Using Serilog for logs 
5-Phone number validation is 12 numbers
