# MedicalAppoinmentSystem

# The follwoing step should be followed to run the application:
1. Clone the application from the git. while cloning the application should clone from "development" branch.
2. Go to "src/Backend" folder and you will se **Datavanced.MedicalAppoinment.System.sln** file. open that file with Visual Studion.
3. The target the **development** branch and take a **pull**.
4. Open the **Package Manager Console** run this command **update-database**. while running this command start up project should be the **API** project and Default project should be **Datavanced.Infrastructures**.
5. After successfully run the command you can see database will be created in you local server **(localdb)\\mssqllocaldb**
6. And then you can build and run the project.
7. After successfully run, you can see all the api in swagger.

# Used Techonology:
1. .Net Core 8
2. MSSQL Server.
3. CLEAN architecture
4. MediatR, CQRS Pattern
5. Entity Framework
