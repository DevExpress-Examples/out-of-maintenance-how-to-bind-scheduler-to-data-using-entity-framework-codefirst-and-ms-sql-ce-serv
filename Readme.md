<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128553261/12.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4124)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/DevExpressMvcSchedulerEditable/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/DevExpressMvcSchedulerEditable/Controllers/HomeController.vb))
* [EFAppointment.cs](./CS/DevExpressMvcSchedulerEditable/Models/EFAppointment.cs) (VB: [EFAppointment.vb](./VB/DevExpressMvcSchedulerEditable/Models/EFAppointment.vb))
* [EFResource.cs](./CS/DevExpressMvcSchedulerEditable/Models/EFResource.cs) (VB: [EFResource.vb](./VB/DevExpressMvcSchedulerEditable/Models/EFResource.vb))
* [SchedulerContext.cs](./CS/DevExpressMvcSchedulerEditable/Models/SchedulerContext.cs) (VB: [SchedulerContext.vb](./VB/DevExpressMvcSchedulerEditable/Models/SchedulerContext.vb))
* [SchedulerDataHelper.cs](./CS/DevExpressMvcSchedulerEditable/Models/SchedulerDataHelper.cs) (VB: [SchedulerDataHelper.vb](./VB/DevExpressMvcSchedulerEditable/Models/SchedulerDataHelper.vb))
* [SchedulerSettingsHelper.cs](./CS/DevExpressMvcSchedulerEditable/Models/SchedulerSettingsHelper.cs) (VB: [SchedulerSettingsHelper.vb](./VB/DevExpressMvcSchedulerEditable/Models/SchedulerSettingsHelper.vb))
* [Index.cshtml](./CS/DevExpressMvcSchedulerEditable/Views/Home/Index.cshtml)
* [SchedulerPartial.cshtml](./CS/DevExpressMvcSchedulerEditable/Views/Home/SchedulerPartial.cshtml)
<!-- default file list end -->
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


