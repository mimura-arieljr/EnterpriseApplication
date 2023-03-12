# EnterpriseSolution
 Enterprise Application

 A web application that aims to provide basic employee record storage and payroll services for businesses.

 Pre-requisite in running the program:
    - The program is running in .NET Core 7.0 framework using MVC design pattern.
    - Entity Framework 7.0
    - Data is running on MSSQL Server. Connection string is currently set to connect to localhost. This program is developed
      using macOS thus a docker image is used in running an instance of the MSSQL server.

Solution Structure:
    - Codebase has been structured in such a way that each functionality is separated in four projects:
        - EnterpriseSolution
        - Enterprise.Services
        - Enterprises.Persistence
        - Enterprise.Entity