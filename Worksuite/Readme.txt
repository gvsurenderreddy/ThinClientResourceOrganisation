
Website Configuration options
=============================


  Static content url -

  	The static content website provides all the library based javascript and css.

  	The location of the static content web site is set in the web.config.  Please read the comment in the web.config file with regard to the exepected format of the url.

    <appSettings>
    	...
    	<add key="static_content_website_host" value="http://localhost:2258/" />

	</appSettings>


	This is used in the following clients

		- Configuration.Web.ThinClient
		- Worksuite.Web.ThinClient


Database
========


  Worksuite
  ---------

  The database connection string is stored in: 
	Persistence\WorkSuite.Persistence.EF\Infrastructure\WorkSuiteConnectionString.txt.  

  It is a standard code first entity framework connection string.  The current version worksuite is being developed against SQLServer 2012.




  Configuration - 

  The database connection string is stored in:
	Persistence\Configuration.Persistence.EF\Infrastructure\ConfigurationConnectionString.txt.  

  It is a standard code first entity framework connection string.  The current version worksuite is being developed against SQLServer 2012.
