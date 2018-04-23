# How to bind Scheduler to data using Entity Framework CodeFirst and MS SQL CE server


<p>This example is based on the project described in the <a href="http://documentation.devexpress.com/#AspNet/CustomDocument11629"><u>Lesson 3 - Use Scheduler in Complex Views</u></a> article. Instead of MS Access database and LINQ to SQL data access model this example employs Entity Framework Code First model and MS SQL Server Compact Edition.<br />
To install support for Entity framework 4.3 and MS SQL CE 4, run the following command in the Package Manager Console:<br />
<i>PM> Install-Package EntityFramework.SqlServerCompact</i><i><br />
</i>Then, implement Code First models for appointments (<strong>EFAppointment </strong>type) and resources (<strong>EFResource </strong>type).  They are accessible via the custom <strong>SchedulerC</strong><strong>o</strong><strong>ntext</strong> class that descends from the <i>System.Data.Entity.DbContext </i>class.   <br />
A static instance of a SchedulerContext class is available via the <strong>LocalContext </strong>property of the custom<strong> S</strong><strong>chedulerSettingsHelper</strong> class. <br />
Local views of entities (<strong>SchedulerSettingsHelper.LocalContext.EFResources.Local</strong> and <strong>SchedulerSettingsHelper.LocalContext.EFAppointments.Local</strong>) are the objects to which the Scheduler is bound when executing the <strong>Bind </strong>method in<strong> </strong>the code for the partial view.<br />
All operations with appointments are performed on the EFAppointment local view of a static <strong>SchedulerContext </strong>instance.  <br />
Changes are saved using the base <strong>DbContext.SaveChanges</strong> method.</p><p>See also:<br />
<a href="https://www.devexpress.com/Support/Center/p/E4107">E4107: Entity Framework CodeFirst model for XtraScheduler data binding</a><br />
<a href="https://www.devexpress.com/Support/Center/p/E4115">E4115: How to bind Scheduler to data using Entity Framework CodeFirst model</a></p>

<br/>


