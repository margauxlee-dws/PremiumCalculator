# PremiumCalculator
PremiumCalculator is a .Net Core and Angular application for generating death premiums.


## Technology Stack 
Visual Studio 2019 
ASP.NET Core 3.1.402 
ASP.NET Core 3.1 Runtime (v3.1.7) - Windows Hosting Bundle 
Node.js v12.19.0 with NPM v6.14.0 
Swashbuckle.Asp.netCore 5.6.3 
IIS v10.0.19041.1 
NOTE: This application was developed using the technologies and versions as listed above. If using different versions, there may be incompabilities. 

 
##A rchitecture 
Frontend – Angular 
Backend – ASP.NET CORE API 
Database – SQL Server 2019 Express  


## Deployment 

### Database Deployment – Requires SQL Server database, Visual Studio  
1. Open Solution PremiumCalculator.Web.API.sln 
2. Update the database connection string in appsettings.json to your target database server 
3. Open Package Manager Console 
4. Execute Update-Database –migration Initial 

 
### Backend API Deployment – Requires IIS, Visual Studio 
*INITIAL SETUP* 
1. In IIS, create a new website with the following details 
	Site name : PremiumCalculatorAPI 
	Physical path : local directory where assets will be deployed e.g. c:\Projects\Sites\PremiumCalculatorAPI 
	Port : available port on the targer server e.g. 5000 
2. In IIS, select the newly created website from step 1, and open 'Handler Mappings'.  Ensure that aspNetCore is added and enabled. 

*PUBLISH* 
1. Using Visual Studio, open [source]\PremiumCalculator\PremiumCalculatorAPI\PremiumCalculator.Web.API.sln 
2. Publish the project PremiumCalculator.Web.API into the website created as part of *INITAL SETUP*  There is a Publish Profile 'IISProfile' that can be used as a starting point, which can be amended to match targer server configuration e.g. configure port number, connection string etc. 

 
## Usage 
Backend API- Swagger documentation of interface available at http://[targerserver:port]/swagger e.g. http://localhost:5000/swagger/index.html

 
## Thoughts and considerations: 
1. Database deployment. Entity Framework migration was chosen over DACPAC due to the simplicity of data models.  If database objects and models are more complex, it may be beneficial to use DACPACs for ease of control and manageability. 
2. Data vs Service Layer. For larger applications, I'd recommend separating the database layer (handles database communication) from the service layer (processes logic and communicate with the database layer).  Only for the purpose of this demo, the database context is included in the service layer. 
3. API / Service Layer authentication. Current implementation has the Service Layer open.  This layer must have authentication implemented to identify consuming applications. 
4. Application Logging. Current implementation has no application logging.  Ideally, some level of logging must be incorporated to capture/audit requests/responses, exceptions, etc. This can be used to notify applications owners/support of any issues. 

 