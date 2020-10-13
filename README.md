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

 
## Architecture 
Frontend – Angular   
Backend – ASP.NET CORE API   
Database – SQL Server 2019 Express    


## Deployment 

### Database Deployment – Requires SQL Server database, Visual Studio  
1. Open solution **PremiumCalculator.Web.API.sln**. 
2. Update the database connection string in **appsettings.json** to your target database server. 
3. Open Package Manager Console. 
4. Execute **Update-Database –migration Initial** . 

 
### Backend API Deployment – Requires IIS, Visual Studio 
#### INITIAL SETUP
1. In IIS, create a new website with the following details:  
	**Site name** : PremiumCalculatorAPI   
	**Physical path** : local directory where assets will be deployed e.g. c:\Projects\Sites\PremiumCalculatorAPI   
	**Port** : available port on the targer server e.g. 5000 .   
2. In IIS, select the newly created website from step 1, and open 'Handler Mappings'.  Ensure that aspNetCore is added and enabled. 

#### PUBLISH 
1. Using Visual Studio, open **[source]\PremiumCalculator\PremiumCalculator.Web.API\PremiumCalculator.Web.API.sln**. 
2. Build the solution
3. Publish the project **PremiumCalculator.Web.API** into the website created as part of **INITAL SETUP**.  
There is a Publish Profile **IISProfile** that can be used as a starting point, which can be amended to match targer server configuration e.g. configure port number, connection string etc. 

 
### Frontend UI Deployment – Requires IIS, Visual Studio 
#### INITIAL SETUP
1. In IIS, create a new website with the following details:   
	**Site name** : PremiumCalculator   
	**Physical path** : local directory where assets will be deployed e.g. c:\Projects\Sites\PremiumCalculator  
	**Port** : available port on the targer server e.g. 80 
2. The **[source]\PremiumCalculator\PremiumCalculator.Web.UI\PremiumCalculator.Web.UI\ClientApp** is the Angular CLI application.  To install packages, execute **npm install** from this location.
	a. npm install --save @angular/material  
	b. npm install --save bootstrap  
	c. npm install --save jquery  
	c. npm install --save cdk   

#### PUBLISH
1. Using Visual Studio, open **[source]\PremiumCalculator\PremiumCalculator.Web.UI\PremiumCalculator.Web.UI.sln** . 
2. Ensure that the path to PremiumCalculatorAPI is correct. At the moment, it is still configured in premium-calculator.components.ts.  (It will be moved to global configurations) 
	> private api_path: string = "https://localhost:44315/";
3. Build the solution
4. Publish the project **PremiumCalculator.Web.UI** into the website created as part of **INITAL SETUP**.   
There is a Publish Profile **IISProfile** that can be used as a starting point, which can be amended to match targer server configuration e.g. configure port number, connection string etc. 


## Usage 
Backend API- Swagger documentation of interface available at http://[targerserver:port]/swagger e.g. http://localhost:5000/swagger/index.html .  
Frontend UI - Available at http://[targerserver:port] e.g. http://localhost .

## Clarifications
1.	Where will the application be hosted? I am assuming the application will be hosted on IIS.  If this is correct, what is the target environment and version?
2.	Alternatively, for the purpose of executing the application, will you be running it from Visual Studio?  If yes, what version will you be using?  For reference, I have VS2019, asking this in case incompatibilities arise with different versions.
3.	Is there a database available?  If yes, I am assuming this is SQL Server and what version?    
4.	The requirement noted ‘As a Member’, are the:  
	a. users part of the organization (e.g. can be authenticated via Active Directory)  
	b. or open to public with credentials to the application (e.g. external brokers)?
5.	The data input required for premium calculation (Name, Age, Date of Birth and Death Sum Insured), what are the constraints? E.g.  
	a. Name – length, only alpha characters,  
	b. Age – min/max,   
	c. Date of Birth – earliest/latest, does it align with age 
	d. Death Sum Insured – min/max?
6.	Is this application to be used as a calculator, or eventual submission of Quotes.  Possibly thinking if there is a need to capture the submissions?  
7.	Is there a need to maintain effectivity dates of the Rating Factors? 
8.	What is the data format for the premium calculated i.e. up to 2 decimal places or whole numbers only?
9.	Re requirement #3 Given all the input fields are specified, change in the occupation dropdown should trigger the premium calculation.  If the premium has already been calculated, what happens when:  
	a. The user clears out any of the other input fields (Name, Age, Date of Birth, Death Sum Insured)  – will the premium be cleared out?  
	b. The user  updates any of the other input fields – will the premium be updated or cleared out?  If the premiums keeps updating, then page might get confusing.  If premium gets cleared out, user may not be aware that the dropdown is the trigger for calculation.   
Just thinking, a suggestion will it be agreeable to use a submit button to trigger premium calculation.  This way, the intent of the action i.e. button click is clear.
10. Re the premium formula :  
	>Death Premium = (Death Cover amount * Occupation Rating Factor * Age) /1000 * 12 

	Out of curiosity, could this be the annualised premium (not monthly premium) because the there is a multiplier of **12**?

## Assumptions 
1. The application is a web application.
2. Fields constraints:  
	a. Name - maxlengh 100  
	b. Age range : 1 to 100  
	c. Date of Birth : 1920-01-01   
	d. Death Sum insured : 1 to 10,000,000
3. Required/mandatory validators are by defahult shown.  Not that pretty, but this can be refined depending on further screen usability designs. 
 
## Thoughts and considerations: 
1. Database deployment. Entity Framework migration was chosen over DACPAC due to the simplicity of data models.  If database objects and models are more complex, it may be beneficial to use DACPACs for ease of control and manageability. 
2. Data vs Service Layer. For larger applications, I'd recommend separating the database layer (handles database communication) from the service layer (processes logic and communicate with the database layer).  Only for the purpose of this demo, the database context is included in the service layer. 
3. API / Service Layer authentication. Current implementation has the Service Layer open.  This layer must have authentication implemented to identify consuming applications. 
4. Test units can be created against the Service Layer.
5. Application Logging. Current implementation has no application logging.  Ideally, some level of logging must be incorporated to capture/audit requests/responses, exceptions, etc. This can be used to notify applications owners/support of any issues. 
6. CORS has been enabled, open for all only for the sample app.  In real applications, additional restrictrions must be applied.


 