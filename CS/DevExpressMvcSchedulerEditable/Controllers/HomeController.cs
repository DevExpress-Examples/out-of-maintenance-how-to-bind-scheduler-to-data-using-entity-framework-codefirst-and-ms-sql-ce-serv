using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DevExpressMvcSchedulerEF.View
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

public ActionResult Index()
{
    return View(SchedulerDataHelper.DataObject);
}

        public ActionResult SchedulerPartial()
        {
            return PartialView("SchedulerPartial", SchedulerDataHelper.DataObject);
        }

        public ActionResult EditAppointment()
        {
            UpdateAppointment();
            return PartialView("SchedulerPartial", SchedulerDataHelper.DataObject);
        }
        #region #updateappointment
        static void UpdateAppointment()
{
    EFAppointment insertedAppt = SchedulerExtension.GetAppointmentToInsert<EFAppointment>(SchedulerSettingsHelper.CommonSchedulerSettings, 
        SchedulerDataHelper.GetAppointments(), SchedulerDataHelper.GetResources());
    SchedulerDataHelper.InsertAppointment(insertedAppt);

    EFAppointment[] updatedAppt = SchedulerExtension.GetAppointmentsToUpdate<EFAppointment>(SchedulerSettingsHelper.CommonSchedulerSettings, 
        SchedulerDataHelper.GetAppointments(), SchedulerDataHelper.GetResources());
    foreach (var appt in updatedAppt)
    {
        SchedulerDataHelper.UpdateAppointment(appt);
    }

    EFAppointment[] removedAppt = SchedulerExtension.GetAppointmentsToRemove<EFAppointment>(SchedulerSettingsHelper.CommonSchedulerSettings,
        SchedulerDataHelper.GetAppointments(), SchedulerDataHelper.GetResources());
    foreach (var appt in removedAppt)
    {
        SchedulerDataHelper.RemoveAppointment(appt);
    }

}
        #endregion #updateappointment

    }
}
