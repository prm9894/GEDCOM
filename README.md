GEDCOM
======

A .NET library that imports data from a .ged (GEDCOM) file. GEDCOM is a format for saving Genealogy data and is an export format for Family Tree Maker.

One day I decided I would create a website for my mom. She has been working on our family genealogy for about 30 years. I wanted to display all that hard work for the extended family to view and be able to enjoy all the hard work my mom did. The data was stored in Family Tree Maker and after identifying an export option to GEDCOM I decided to create a simple library to import the data. This was a quick attempt, less than 2 hours, to read the .ged file. I do have a website that once done I will contribute to this project. In the meantime I wanted to share the library for anyone else that might want to do the same thing. I plan to continue to enhance the library and clean it up.

Example Usage in a .NET Web application

In the Global.asax Application_Start() method:

string path = HttpContext.Current.Server.MapPath(string.Format("~/App_Data/{0}", ConfigurationManager.AppSettings["GedFileName"]));
var gedcomDataSource = GEDCOM.DataSource.GEDCOM_Cache.Load(path);


Within the web application you can fetch data using this format:

var individuals = GEDCOM.DataSource.GEDCOM_Cache.Fetch().Data.Individuals.Where(i => i.SurName.ToLower() == familySurName.ToLower());

OR

var individuals = GEDCOM.DataSource.GEDCOM_Cache.Fetch().Data.Individuals.Where(i => i.FullName.ToLower() == id.ToLower());
